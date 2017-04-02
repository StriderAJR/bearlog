-- phpMyAdmin SQL Dump
-- version 4.0.4.2
-- http://www.phpmyadmin.net
--
-- Хост: localhost
-- Время создания: Апр 02 2017 г., 09:27
-- Версия сервера: 5.6.13
-- Версия PHP: 5.4.17

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- База данных: `bearlog`
--
CREATE DATABASE IF NOT EXISTS `bearlog` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `bearlog`;

-- --------------------------------------------------------

--
-- Структура таблицы `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `email` varchar(500) NOT NULL,
  `password_hash` varchar(500) NOT NULL,
  `role` varchar(500) NOT NULL,
  `status` int(11) NOT NULL,
  `created_at` datetime NOT NULL,
  `updated_at` datetime NOT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=3 ;

--
-- Дамп данных таблицы `user`
--

INSERT INTO `user` (`user_id`, `email`, `password_hash`, `role`, `status`, `created_at`, `updated_at`) VALUES
(1, 'email@mail.cpo', '$2y$13$GlQKJeQFMEzv0ScbzrugXebc501VxJS93ElgQ9XGMXjECyXPTx4ie', '', 10, '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(2, 'n@mail.ru', '$2y$13$Qo9utKN6mKwnqBBeBIxXfO64mxOzcnkMLZ61KV3nAxH.lhSzOfNnW', '', 10, '0000-00-00 00:00:00', '0000-00-00 00:00:00');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
