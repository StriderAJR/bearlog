using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;
using Bearlog.Web.Models;

namespace Bearlog.Web.Services
{
    public static class LogService
    {
        const string LogTableName = "[u0351346_Bearlog].[u0351346_developer].[log]";

        enum LogType
        {
            Error,
            Info,
            Warning,
            Debug
        }

        private static string GetIpAddress()
        {
            HttpContext context = HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }

        private static void WriteLogEvent(LogType logType, string description)
        {
            using (SqlConnection connection =
                new SqlConnection(WebConfigurationManager.ConnectionStrings["BearlogDb"].ToString()))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string commandText = string.Format(@"
                        INSERT {0}
                        (id, log_time, log_type, user_id, host_address, user_agent, description)
                        VALUES
                        (@id, @log_time, @log_type, @user_id, @host_address, @user_agent, @description)
                    ", LogTableName);

                var cmd = new SqlCommand(commandText, connection);

                Guid id = Guid.NewGuid();
                DateTime logTime = DateTime.Now;
                string logTypeString = logType.ToString("G");
                Guid userId;
                try
                {
                    userId = ((BearlogPrincipal)HttpContext.Current.User).Id;
                }
                catch (Exception)
                {
                    userId = Guid.Empty;
                }
                string hostAddress = GetIpAddress();
                string userAgent = HttpContext.Current.Request.UserAgent;

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@log_time", logTime);
                cmd.Parameters.AddWithValue("@log_type", logType);

                if (userId == Guid.Empty)
                    cmd.Parameters.AddWithValue("@user_id", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@user_id", userId);
                if (string.IsNullOrEmpty(hostAddress))
                    cmd.Parameters.AddWithValue("@host_address", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@host_address", hostAddress);
                if (string.IsNullOrEmpty(userAgent))
                    cmd.Parameters.AddWithValue("@user_agent", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@user_agent", userAgent);

                cmd.Parameters.AddWithValue("@description", description);

                cmd.ExecuteNonQuery();
            }
        }

        public static void WriteInfoMessage(string description)
        {
            WriteLogEvent(LogType.Info, description);
        }

        public static void WriteErrorMessage(string description)
        {
            WriteLogEvent(LogType.Error, description);
        }

        public static void WriteErrorMessage(Exception exception)
        {
            WriteLogEvent(LogType.Error, exception.Message + Environment.NewLine + exception.StackTrace);
        }

        public static void WriteDebugMessage(string description)
        {
            WriteLogEvent(LogType.Debug, description);
        }
    }
}