-- phpMyAdmin SQL Dump
-- version 4.0.4.2
-- http://www.phpmyadmin.net
--
-- Хост: localhost
-- Время создания: Апр 16 2017 г., 06:05
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
-- Структура таблицы `book`
--

CREATE TABLE IF NOT EXISTS `book` (
  `book_id` varchar(36) NOT NULL,
  `translation_id` varchar(36) NOT NULL,
  `author_name` varchar(500) NOT NULL,
  `author_original_name` varchar(500) NOT NULL,
  `year` int(11) NOT NULL,
  PRIMARY KEY (`book_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `category`
--

CREATE TABLE IF NOT EXISTS `category` (
  `category_id` varchar(36) NOT NULL,
  `name` varchar(100) NOT NULL,
  PRIMARY KEY (`category_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `comment`
--

CREATE TABLE IF NOT EXISTS `comment` (
  `comment_id` varchar(36) NOT NULL,
  `author_id` varchar(36) NOT NULL,
  `fragment_translation_id` varchar(36) NOT NULL,
  `text` text NOT NULL,
  `created_at` datetime NOT NULL,
  `updated_at` datetime NOT NULL,
  PRIMARY KEY (`comment_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `fragment_image`
--

CREATE TABLE IF NOT EXISTS `fragment_image` (
  `fragment_image_id` varchar(36) NOT NULL,
  `fragment_id` varchar(36) NOT NULL,
  PRIMARY KEY (`fragment_image_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `fragment_subtitle`
--

CREATE TABLE IF NOT EXISTS `fragment_subtitle` (
  `subtitle_fragment_id` varchar(36) NOT NULL,
  `fragment_id` varchar(36) NOT NULL,
  `start_time` time NOT NULL,
  `end_time` time NOT NULL,
  PRIMARY KEY (`subtitle_fragment_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `fragment_translation`
--

CREATE TABLE IF NOT EXISTS `fragment_translation` (
  `fragment_translation_id` varchar(36) NOT NULL,
  `author_id` varchar(36) NOT NULL,
  `fragment_id` varchar(36) NOT NULL,
  `text` text NOT NULL,
  `rating` int(11) NOT NULL,
  `updated_at` datetime NOT NULL,
  `created_at` datetime NOT NULL,
  PRIMARY KEY (`fragment_translation_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `image`
--

CREATE TABLE IF NOT EXISTS `image` (
  `image_id` varchar(36) NOT NULL,
  `translation_id` varchar(36) NOT NULL,
  PRIMARY KEY (`image_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `language`
--

CREATE TABLE IF NOT EXISTS `language` (
  `language_id` varchar(36) NOT NULL,
  `name` int(11) NOT NULL,
  `short_name` int(11) NOT NULL,
  PRIMARY KEY (`language_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `lyrics`
--

CREATE TABLE IF NOT EXISTS `lyrics` (
  `lyrics_id` varchar(36) NOT NULL,
  `translation_id` varchar(36) NOT NULL,
  PRIMARY KEY (`lyrics_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `part_fragment`
--

CREATE TABLE IF NOT EXISTS `part_fragment` (
  `fragment_id` varchar(36) NOT NULL,
  `part_id` varchar(36) NOT NULL,
  `original_text` text NOT NULL,
  PRIMARY KEY (`fragment_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `role`
--

CREATE TABLE IF NOT EXISTS `role` (
  `role_id` varchar(36) NOT NULL,
  `name` varchar(100) NOT NULL,
  PRIMARY KEY (`role_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `role`
--

INSERT INTO `role` (`role_id`, `name`) VALUES
('3285029d-2261-11e7-9df7-78843cf10735', 'admin');

-- --------------------------------------------------------

--
-- Структура таблицы `subtitle`
--

CREATE TABLE IF NOT EXISTS `subtitle` (
  `subtitle_id` varchar(36) NOT NULL,
  `translation_id` varchar(36) NOT NULL,
  PRIMARY KEY (`subtitle_id`),
  KEY `subtitle_fk1` (`translation_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `tranlsation_part`
--

CREATE TABLE IF NOT EXISTS `tranlsation_part` (
  `part_id` varchar(36) NOT NULL,
  `translation_id` varchar(36) NOT NULL,
  `name` text NOT NULL,
  `original_name` varchar(100) NOT NULL,
  PRIMARY KEY (`part_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `translation`
--

CREATE TABLE IF NOT EXISTS `translation` (
  `translation_id` varchar(36) NOT NULL,
  `category_id` varchar(36) NOT NULL,
  `creator_id` varchar(36) NOT NULL,
  `name` varchar(100) NOT NULL,
  `name_original` varchar(500) NOT NULL,
  `from_language_id` varchar(36) NOT NULL,
  `to_language_id` varchar(36) NOT NULL,
  `cover_link` varchar(500) NOT NULL,
  `is_private` tinyint(1) NOT NULL,
  `is_finished` tinyint(1) NOT NULL,
  PRIMARY KEY (`translation_id`),
  KEY `translation_fk0` (`category_id`),
  KEY `translation_fk1` (`creator_id`),
  KEY `translation_fk2` (`from_language_id`),
  KEY `translation_fk3` (`to_language_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `translation_user`
--

CREATE TABLE IF NOT EXISTS `translation_user` (
  `translation_id` varchar(36) NOT NULL,
  `user_id` varchar(36) NOT NULL,
  PRIMARY KEY (`translation_id`,`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `user_id` varchar(36) NOT NULL,
  `user_name` varchar(50) NOT NULL,
  `email` varchar(100) NOT NULL,
  `password_hash` varchar(500) NOT NULL,
  `created_at` datetime NOT NULL,
  `updated_at` datetime NOT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `user`
--

INSERT INTO `user` (`user_id`, `user_name`, `email`, `password_hash`, `created_at`, `updated_at`) VALUES
('672708f8-226a-11e7-9df7-78843cf10735', 'alexander.a.kirsanov', 'alexander.a.kirsanov@gmail.com', '$2y$13$xFtAYOt2Dy2oBlm6uMueCe2ufo9V5BVabMSMuTnqNNiR2HUoFlogC', '2017-04-16 06:02:53', '2017-04-16 06:02:53'),
('9b6626bb-226a-11e7-9df7-78843cf10735', 'zheka', 'dovgiy2014@gmail.com', '$2y$13$ZaJhU1kJg1/FCZqdocGJsuVYpPwudCqeQjw96SYrPB6OqZWwbyLfW', '2017-04-16 06:04:29', '2017-04-16 06:04:29'),
('da3cbb2a-2261-11e7-9df7-78843cf10735', 'nikita', 'pianorockcover@gmail.com', '$2y$13$fOB6qVACa01fcXeexsKteOtxqlSq4AU3irsNVmlOAiwMGkmltox9e', '2017-04-16 04:59:36', '2017-04-16 04:59:36');

-- --------------------------------------------------------

--
-- Структура таблицы `user_role`
--

CREATE TABLE IF NOT EXISTS `user_role` (
  `user_id` varchar(36) NOT NULL,
  `role_id` varchar(36) NOT NULL,
  PRIMARY KEY (`user_id`,`role_id`),
  KEY `user_role_fk1` (`role_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `subtitle`
--
ALTER TABLE `subtitle`
  ADD CONSTRAINT `subtitle_fk1` FOREIGN KEY (`translation_id`) REFERENCES `translation` (`translation_id`);

--
-- Ограничения внешнего ключа таблицы `translation`
--
ALTER TABLE `translation`
  ADD CONSTRAINT `translation_fk3` FOREIGN KEY (`to_language_id`) REFERENCES `language` (`language_id`),
  ADD CONSTRAINT `translation_fk0` FOREIGN KEY (`category_id`) REFERENCES `category` (`category_id`),
  ADD CONSTRAINT `translation_fk1` FOREIGN KEY (`creator_id`) REFERENCES `user` (`user_id`),
  ADD CONSTRAINT `translation_fk2` FOREIGN KEY (`from_language_id`) REFERENCES `language` (`language_id`);

--
-- Ограничения внешнего ключа таблицы `user_role`
--
ALTER TABLE `user_role`
  ADD CONSTRAINT `user_role_fk1` FOREIGN KEY (`role_id`) REFERENCES `role` (`role_id`),
  ADD CONSTRAINT `user_role_fk0` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
