//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StridingSoft.Services.Models.Collectioner
{
    using System;
    using System.Collections.Generic;
    
    public partial class item
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public int section_id { get; set; }
    
        public virtual section section { get; set; }
    }
}
