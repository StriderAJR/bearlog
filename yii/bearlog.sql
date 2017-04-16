-- phpMyAdmin SQL Dump
-- version 4.0.4.2
-- http://www.phpmyadmin.net
--
-- Хост: localhost
-- Время создания: Апр 16 2017 г., 08:17
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

--
-- Дамп данных таблицы `book`
--

INSERT INTO `book` (`book_id`, `translation_id`, `author_name`, `author_original_name`, `year`) VALUES
('58f35edb23bc30.19456556', '1', '3333', '4444444', 555555),
('58f35f052e6273.04052547', '1', '22333', '3444444', 555555),
('58f36050cb4d02.81211317', '1', '111', '11111', 1111),
('58f361210d3bc6.68253849', '58f361208df224.01603792', '22222333', '333444444', 5555555),
('58f3613d480e95.46031634', '58f3613d3ab192.43894556', '2233333', '33444444', 45555555),
('58f3633d050b58.05194902', '58f3633c7aef71.76827720', '233', '33344444', 5555555),
('58f363cfa20d62.28191407', '58f363cf961d76.33862105', '23', '334', 4555),
('58f363f15d9b71.57117718', '58f363f0cfadc3.32429354', '33', '34', 5),
('58f364f7e5b756.72586694', '58f364f7daf3e9.86124446', '3333', '334', 5),
('58f365333379e2.31190531', '58f36533253a39.00721283', '3', '3334', 555),
('58f36550af29c1.63046203', '58f365503444e7.39176484', '11', '111', 11111),
('58f365a8c7e900.35211559', '58f365a8bb3152.50551973', '11111', '111111', 111111),
('58f365c1c99dc9.95670656', '58f365c1b06e15.59580415', '11', '1111', 11111),
('58f366980c5b62.25305315', '58f366978b27c0.83860217', '2', '2', 2),
('58f3669ce08c73.90062949', '58f3669cd58018.49503902', '2', '2', 2),
('58f366abd9f3c3.22644494', '58f366abccf5d9.05584408', '2', '2', 2),
('58f36821565ce1.98153395', '58f36820e8cfe5.41236781', '2', '2', 222),
('58f3686262e828.17039042', '58f36862545111.03155592', '2', '2', 2),
('58f368a97b9546.67355621', '58f368a96a96c9.10652202', '1', '1', 1),
('58f368badeef22.07916016', '58f368bacf7700.13497425', '666666', '666', 6666);

-- --------------------------------------------------------

--
-- Структура таблицы `category`
--

CREATE TABLE IF NOT EXISTS `category` (
  `category_id` varchar(36) NOT NULL,
  `name` varchar(100) NOT NULL,
  PRIMARY KEY (`category_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `category`
--

INSERT INTO `category` (`category_id`, `name`) VALUES
('6bf120d6-229c-11e7-aeb8-78843cf10735', 'book');

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
  `name` varchar(11) NOT NULL,
  `short_name` varchar(11) NOT NULL,
  PRIMARY KEY (`language_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `language`
--

INSERT INTO `language` (`language_id`, `name`, `short_name`) VALUES
('a02f0749-2291-11e7-9df7-78843cf10735', 'English', 'Eng'),
('a02f11cb-2291-11e7-9df7-78843cf10735', 'Russian', 'Rus');

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

--
-- Дамп данных таблицы `translation`
--

INSERT INTO `translation` (`translation_id`, `category_id`, `creator_id`, `name`, `name_original`, `from_language_id`, `to_language_id`, `cover_link`, `is_private`, `is_finished`) VALUES
('58f35edb13f1e6.24589916', '6bf120d6-229c-11e7-aeb8-78843cf10735', 'da3cbb2a-2261-11e7-9df7-78843cf10735', '11', '112', 'a02f0749-2291-11e7-9df7-78843cf10735', 'a02f11cb-2291-11e7-9df7-78843cf10735', '666666666', 1, 0),
('58f35f049180d4.70658398', '6bf120d6-229c-11e7-aeb8-78843cf10735', 'da3cbb2a-2261-11e7-9df7-78843cf10735', '111111', '2222', 'a02f0749-2291-11e7-9df7-78843cf10735', 'a02f11cb-2291-11e7-9df7-78843cf10735', '666666', 1, 0),
('58f36050b53af1.16285435', '6bf120d6-229c-11e7-aeb8-78843cf10735', 'da3cbb2a-2261-11e7-9df7-78843cf10735', '1111', '1111', 'a02f0749-2291-11e7-9df7-78843cf10735', 'a02f11cb-2291-11e7-9df7-78843cf10735', '1111', 1, 0),
('58f361208df224.01603792', '6bf120d6-229c-11e7-aeb8-78843cf10735', 'da3cbb2a-2261-11e7-9df7-78843cf10735', '11111', '11222', 'a02f0749-2291-11e7-9df7-78843cf10735', 'a02f11cb-2291-11e7-9df7-78843cf10735', '66666666', 1, 0),
('58f3613d3ab192.43894556', '6bf120d6-229c-11e7-aeb8-78843cf10735', 'da3cbb2a-2261-11e7-9df7-78843cf10735', '1111111', '22222', 'a02f0749-2291-11e7-9df7-78843cf10735', 'a02f11cb-2291-11e7-9df7-78843cf10735', '666666', 1, 0),
('58f3633c7aef71.76827720', '6bf120d6-229c-11e7-aeb8-78843cf10735', 'da3cbb2a-2261-11e7-9df7-78843cf10735', '1111111', '22222222', 'a02f0749-2291-11e7-9df7-78843cf10735', 'a02f11cb-2291-11e7-9df7-78843cf10735', '6666666', 1, 0),
('58f363cf961d76.33862105', '6bf120d6-229c-11e7-aeb8-78843cf10735', 'da3cbb2a-2261-11e7-9df7-78843cf10735', '11111', '2222', 'a02f0749-2291-11e7-9df7-78843cf10735', 'a02f11cb-2291-11e7-9df7-78843cf10735', '666', 1, 0),
('58f363f0cfadc3.32429354', '6bf120d6-229c-11e7-aeb8-78843cf10735', 'da3cbb2a-2261-11e7-9df7-78843cf10735', '1111', '222', 'a02f0749-2291-11e7-9df7-78843cf10735', 'a02f11cb-2291-11e7-9df7-78843cf10735', '666', 1, 0),
('58f364f7daf3e9.86124446', '6bf120d6-229c-11e7-aeb8-78843cf10735', 'da3cbb2a-2261-11e7-9df7-78843cf10735', '111111', '22222', 'a02f0749-2291-11e7-9df7-78843cf10735', 'a02f11cb-2291-11e7-9df7-78843cf10735', '66666', 1, 0),
('58f36533253a39.00721283', '6bf120d6-229c-11e7-aeb8-78843cf10735', 'da3cbb2a-2261-11e7-9df7-78843cf10735', '11', '112', 'a02f0749-2291-11e7-9df7-78843cf10735', 'a02f11cb-2291-11e7-9df7-78843cf10735', '6666', 1, 0),
('58f365503444e7.39176484', '6bf120d6-229c-11e7-aeb8-78843cf10735', 'da3cbb2a-2261-11e7-9df7-78843cf10735', '1111111', '1111111111', 'a02f0749-2291-11e7-9df7-78843cf10735', 'a02f11cb-2291-11e7-9df7-78843cf10735', '1111111', 1, 0),
('58f365a8bb3152.50551973', '6bf120d6-229c-11e7-aeb8-78843cf10735', 'da3cbb2a-2261-11e7-9df7-78843cf10735', '11111', '1111111', 'a02f0749-2291-11e7-9df7-78843cf10735', 'a02f11cb-2291-11e7-9df7-78843cf10735', '11111', 1, 0),
('58f365c1b06e15.59580415', '6bf120d6-229c-11e7-aeb8-78843cf10735', 'da3cbb2a-2261-11e7-9df7-78843cf10735', '1111', '1', 'a02f0749-2291-11e7-9df7-78843cf10735', 'a02f11cb-2291-11e7-9df7-78843cf10735', '11111', 1, 0),
('58f366978b27c0.83860217', '6bf120d6-229c-11e7-aeb8-78843cf10735', 'da3cbb2a-2261-11e7-9df7-78843cf10735', '22', '22', 'a02f0749-2291-11e7-9df7-78843cf10735', 'a02f11cb-2291-11e7-9df7-78843cf10735', '2', 1, 0),
('58f3669cd58018.49503902', '6bf120d6-229c-11e7-aeb8-78843cf10735', 'da3cbb2a-2261-11e7-9df7-78843cf10735', '22', '22', 'a02f0749-2291-11e7-9df7-78843cf10735', 'a02f11cb-2291-11e7-9df7-78843cf10735', '2', 1, 0),
('58f366abccf5d9.05584408', '6bf120d6-229c-11e7-aeb8-78843cf10735', 'da3cbb2a-2261-11e7-9df7-78843cf10735', '22', '22', 'a02f0749-2291-11e7-9df7-78843cf10735', 'a02f11cb-2291-11e7-9df7-78843cf10735', '2', 1, 0),
('58f36820e8cfe5.41236781', '6bf120d6-229c-11e7-aeb8-78843cf10735', 'da3cbb2a-2261-11e7-9df7-78843cf10735', '222', '2', 'a02f0749-2291-11e7-9df7-78843cf10735', 'a02f11cb-2291-11e7-9df7-78843cf10735', '2222', 1, 0),
('58f36862545111.03155592', '6bf120d6-229c-11e7-aeb8-78843cf10735', 'da3cbb2a-2261-11e7-9df7-78843cf10735', '22', '2', 'a02f0749-2291-11e7-9df7-78843cf10735', 'a02f11cb-2291-11e7-9df7-78843cf10735', '2', 1, 0),
('58f368a96a96c9.10652202', '6bf120d6-229c-11e7-aeb8-78843cf10735', 'da3cbb2a-2261-11e7-9df7-78843cf10735', '1111', '1', 'a02f0749-2291-11e7-9df7-78843cf10735', 'a02f11cb-2291-11e7-9df7-78843cf10735', '1', 0, 0),
('58f368bacf7700.13497425', '6bf120d6-229c-11e7-aeb8-78843cf10735', 'da3cbb2a-2261-11e7-9df7-78843cf10735', '66', '6', 'a02f0749-2291-11e7-9df7-78843cf10735', 'a02f11cb-2291-11e7-9df7-78843cf10735', '66666', 0, 0);

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
  ADD CONSTRAINT `translation_fk0` FOREIGN KEY (`category_id`) REFERENCES `category` (`category_id`),
  ADD CONSTRAINT `translation_fk1` FOREIGN KEY (`creator_id`) REFERENCES `user` (`user_id`),
  ADD CONSTRAINT `translation_fk2` FOREIGN KEY (`from_language_id`) REFERENCES `language` (`language_id`),
  ADD CONSTRAINT `translation_fk3` FOREIGN KEY (`to_language_id`) REFERENCES `language` (`language_id`);

--
-- Ограничения внешнего ключа таблицы `user_role`
--
ALTER TABLE `user_role`
  ADD CONSTRAINT `user_role_fk0` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`),
  ADD CONSTRAINT `user_role_fk1` FOREIGN KEY (`role_id`) REFERENCES `role` (`role_id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
