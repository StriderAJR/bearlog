-- phpMyAdmin SQL Dump
-- version 4.0.4.2
-- http://www.phpmyadmin.net
--
-- Хост: localhost
-- Время создания: Апр 08 2017 г., 13:14
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
-- Структура таблицы `role`
--

CREATE TABLE IF NOT EXISTS `role` (
  `role_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  PRIMARY KEY (`role_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=3 ;

--
-- Дамп данных таблицы `role`
--

INSERT INTO `role` (`role_id`, `name`) VALUES
(1, 'Переводчик'),
(2, 'Администратор');

-- --------------------------------------------------------

--
-- Структура таблицы `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `email` varchar(100) NOT NULL,
  `password_hash` varchar(500) NOT NULL,
  `role_id` int(11) NOT NULL,
  `status` tinyint(1) NOT NULL,
  `created_at` datetime NOT NULL,
  `updated_at` datetime NOT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=12 ;

--
-- Дамп данных таблицы `user`
--

INSERT INTO `user` (`user_id`, `email`, `password_hash`, `role_id`, `status`, `created_at`, `updated_at`) VALUES
(1, 'pianorockcover@gmail.com', '$2y$13$6DBxIP/kvCvbUhc76qy1kOQ6CAqK.zRZqQ2ZaVez4ecTD9CdtB4oG', 1, 1, '2017-04-08 12:27:08', '2017-04-08 12:27:08'),
(2, 'alexander.a.kirsanov@gmail.com', '$2y$13$2lm2LdNZYshQGpgPn/IRlOGMcYwW8t66arg251pm8AyDmeNPcCyHS', 1, 1, '2017-04-08 12:28:08', '2017-04-08 12:28:08'),
(3, 'dovgiy2014@gmail.com', '$2y$13$UOO5inb4YvxqpaywxTHxl.reCbEZkZXI5zdK0aHrPPj66MSAzzOs2', 1, 1, '2017-04-08 12:30:33', '2017-04-08 12:30:33');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
