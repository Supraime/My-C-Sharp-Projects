-- MySqlBackup.NET 2.3.1
-- Dump Time: 2021-06-27 14:02:05
-- --------------------------------------
-- Server version 5.5.50 MySQL Community Server (GPL)


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- 
-- Definition of clients
-- 

DROP TABLE IF EXISTS `clients`;
CREATE TABLE IF NOT EXISTS `clients` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fname` varchar(50) NOT NULL,
  `name` varchar(50) NOT NULL,
  `sname` varchar(50) NOT NULL,
  `day_bd` int(2) NOT NULL,
  `month_bd` int(2) NOT NULL,
  `year_bd` int(4) NOT NULL,
  `telephone` varchar(15) NOT NULL,
  `serial_pass` int(4) NOT NULL,
  `num_pass` int(6) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table clients
-- 

/*!40000 ALTER TABLE `clients` DISABLE KEYS */;
INSERT INTO `clients`(`id`,`fname`,`name`,`sname`,`day_bd`,`month_bd`,`year_bd`,`telephone`,`serial_pass`,`num_pass`) VALUES
(3,'Иванов','Иван','Иванович',19,12,1997,'8954367823',3314,121212),
(7,'Алеев','Иван','Петрович',19,12,1997,'+78954367823',6587,126753),
(8,'Петрово','Петр','Васильевич',12,10,1999,'+78954335823',5476,234576),
(18,'Агапов','Иван','Иванович',2,6,1998,'+79867576575',2213,232323),
(19,'Ураганова','Елизавета','Петровна',21,4,1999,'+79845363622',1256,341243),
(20,'Уранова','Елена','Алексеевна',20,10,1994,'+79843434234',5555,674967),
(21,'Рылеев','Даниил','Александрович',18,8,1993,'+79845365829',2323,564534),
(22,'Лепеева','Анастасия','Олеговна',1,7,1992,'+79364562378',3423,343443),
(23,'Руталов','Петр','Алексеевич',20,3,1989,'+79326436236',2462,832542),
(24,'Афонин','Иван','Васильевич',10,3,1999,'+79457365636',4544,121212),
(25,'Угрюмова','Светлана','Олеговна',8,7,1998,'+79863463463',5343,333333),
(26,'Бубликов','Алексей','Алексеевич',8,5,1998,'+79375734562',3314,123323),
(27,'Успенская','Екатерина','Олеговна',2,7,1988,'+79874646466',5555,123123),
(28,'Харламова','Елизавета','Михайловна',19,9,1987,'+79044743636',2222,132321),
(29,'Вилков','Андрей','Алексеевич',9,11,1994,'+79473555233',4412,222232),
(30,'Петров','Иван','Олегович',18,8,1999,'+79867575746',5678,675867);
/*!40000 ALTER TABLE `clients` ENABLE KEYS */;

-- 
-- Definition of doctors
-- 

DROP TABLE IF EXISTS `doctors`;
CREATE TABLE IF NOT EXISTS `doctors` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fname` varchar(50) NOT NULL,
  `name` varchar(50) NOT NULL,
  `sname` varchar(50) NOT NULL,
  `spec` int(11) NOT NULL,
  `price` int(11) NOT NULL,
  `time_start` int(11) NOT NULL,
  `time_end` int(11) NOT NULL,
  `cabinet` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table doctors
-- 

/*!40000 ALTER TABLE `doctors` DISABLE KEYS */;
INSERT INTO `doctors`(`id`,`fname`,`name`,`sname`,`spec`,`price`,`time_start`,`time_end`,`cabinet`) VALUES
(2,'Шустров','Даниил','Алексеевич',2,500,12,17,102),
(5,'Мельникова','Елена','Олеговна',7,500,12,16,101),
(7,'Васильев','Иван','Петрович',7,200,9,15,226),
(12,'Ахматов','Михаил','Алексеевич',3,600,8,12,66),
(15,'Лепатов','Андрей','Андреевич',2,350,8,15,200),
(16,'Финатова','Ольга','Петровна',7,400,8,18,269);
/*!40000 ALTER TABLE `doctors` ENABLE KEYS */;

-- 
-- Definition of special
-- 

DROP TABLE IF EXISTS `special`;
CREATE TABLE IF NOT EXISTS `special` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `spec` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table special
-- 

/*!40000 ALTER TABLE `special` DISABLE KEYS */;
INSERT INTO `special`(`id`,`spec`) VALUES
(2,'Хирург'),
(3,'Венеролог'),
(7,'Отоларинголог');
/*!40000 ALTER TABLE `special` ENABLE KEYS */;

-- 
-- Definition of talons
-- 

DROP TABLE IF EXISTS `talons`;
CREATE TABLE IF NOT EXISTS `talons` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_client` int(11) NOT NULL,
  `id_doctor` int(11) NOT NULL,
  `date` varchar(11) NOT NULL,
  `time` varchar(5) NOT NULL,
  `disc` varchar(11) NOT NULL,
  `first_osmt` varchar(50) NOT NULL,
  `price` int(11) NOT NULL,
  `cancel` int(2) NOT NULL DEFAULT '0',
  `createdate` varchar(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=75 DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table talons
-- 

/*!40000 ALTER TABLE `talons` DISABLE KEYS */;
INSERT INTO `talons`(`id`,`id_client`,`id_doctor`,`date`,`time`,`disc`,`first_osmt`,`price`,`cancel`,`createdate`) VALUES
(50,3,4,'10.06.2020','11:00','3%','Первичный осмотр',485,2,'08.06.2020'),
(57,25,9,'11.06.2020','15:30','Отсутствует','Первичный осмотр',200,1,'10.06.2020'),
(58,7,8,'17.06.2020','11:30','3%','Вторичный осмотр',582,2,'10.06.2020'),
(59,22,9,'11.06.2020','13:00','3%','Первичный осмотр',194,2,'10.06.2020'),
(64,21,4,'15.06.2020','14:00','3%','Первичный осмотр',485,2,'11.06.2020'),
(66,26,10,'23.06.2020','11:30','Отсутствует','Первичный осмотр',300,2,'12.06.2020'),
(68,28,13,'19.08.2020','13:30','Отсутствует','Первичный осмотр',500,2,'12.06.2020'),
(69,29,11,'25.06.2020','12:30','Отсутствует','Первичный осмотр',230,2,'12.06.2020'),
(70,3,13,'29.06.2020','12:30','3%','Вторичный осмотр',485,1,'12.06.2020'),
(71,3,10,'30.06.2020','9:00','3%','Первичный осмотр',291,2,'12.06.2020'),
(73,3,8,'18.06.2020','11:00','3%','Первичный осмотр',582,2,'15.06.2020'),
(74,3,16,'18.06.2020','16:00','3%','Первичный осмотр',388,2,'15.06.2020');
/*!40000 ALTER TABLE `talons` ENABLE KEYS */;

-- 
-- Definition of users
-- 

DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `login` varchar(50) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(350) NOT NULL,
  `status` varchar(50) NOT NULL,
  `last_enter` varchar(19) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table users
-- 

/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users`(`id`,`login`,`username`,`password`,`status`,`last_enter`) VALUES
(1,'test','Майоров Д.А','69e762fc5db7bbfc4833bd57af03b14396bbdee20d688bc9bf7251e60ab28bdc','Сотрудник','17.06.2020 7:38:55'),
(2,'qwerty','Кучин Д.О','69e762fc5db7bbfc4833bd57af03b14396bbdee20d688bc9bf7251e60ab28bdc','Администратор','17.06.2020 7:38:35'),
(8,'ghjgj','Матроскин А.А','fb1c4d09b680e861f24d2e8adf6ff58853cf718c607e9234c52324c99d55b6dc','Сотрудник','15.06.2020 0:00:00');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2021-06-27 14:02:05
-- Total time: 0:0:0:0:72 (d:h:m:s:ms)
