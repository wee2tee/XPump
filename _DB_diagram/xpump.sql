-- phpMyAdmin SQL Dump
-- version 4.4.8
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Mar 16, 2017 at 03:19 AM
-- Server version: 5.6.24
-- PHP Version: 5.5.24

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `xpump`
--

-- --------------------------------------------------------

--
-- Table structure for table `dayend`
--

CREATE TABLE IF NOT EXISTS `dayend` (
  `id` int(11) NOT NULL,
  `saldat` date NOT NULL,
  `rcvqty` decimal(14,2) NOT NULL,
  `salqty` decimal(14,2) NOT NULL,
  `dothertxt` varchar(30) NOT NULL DEFAULT '',
  `dother` decimal(14,2) NOT NULL,
  `difqty` decimal(14,2) NOT NULL,
  `stmas_id` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=50 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `dayend`
--

INSERT INTO `dayend` (`id`, `saldat`, `rcvqty`, `salqty`, `dothertxt`, `dother`, `difqty`, `stmas_id`) VALUES
(45, '2017-02-27', '0.00', '0.00', '', '0.00', '0.00', 48),
(46, '2017-02-27', '0.00', '0.00', '', '0.00', '0.00', 49),
(47, '2017-02-27', '0.00', '0.00', '', '0.00', '0.00', 50),
(48, '2017-02-27', '0.00', '0.00', '', '0.00', '0.00', 51),
(49, '2017-02-27', '0.00', '0.00', '', '0.00', '0.00', 53);

-- --------------------------------------------------------

--
-- Table structure for table `daysttak`
--

CREATE TABLE IF NOT EXISTS `daysttak` (
  `id` int(11) NOT NULL,
  `qty` decimal(15,2) NOT NULL DEFAULT '0.00',
  `dayend_id` int(11) NOT NULL,
  `section_id` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=76 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `daysttak`
--

INSERT INTO `daysttak` (`id`, `qty`, `dayend_id`, `section_id`) VALUES
(69, '-1.00', 45, 69),
(70, '-1.00', 45, 71),
(71, '-1.00', 46, 73),
(72, '-1.00', 47, 74),
(73, '-1.00', 48, 75),
(74, '-1.00', 49, 70),
(75, '-1.00', 49, 72);

-- --------------------------------------------------------

--
-- Table structure for table `nozzle`
--

CREATE TABLE IF NOT EXISTS `nozzle` (
  `id` int(11) NOT NULL,
  `name` varchar(20) NOT NULL,
  `description` varchar(50) DEFAULT NULL,
  `remark` varchar(50) DEFAULT NULL,
  `isactive` tinyint(1) NOT NULL DEFAULT '1',
  `section_id` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=76 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `nozzle`
--

INSERT INTO `nozzle` (`id`, `name`, `description`, `remark`, `isactive`, `section_id`) VALUES
(55, 'NOZ-01', 'หัวจ่าย 1', '', 1, 69),
(56, 'NOZ-02', 'หัวจ่าย 2', '', 1, 69),
(57, 'NOZ-03', 'หัวจ่าย 3', '', 1, 69),
(59, 'NOZ-01', 'หัวจ่าย 1', '', 1, 70),
(60, 'NOZ-01', 'หัวจ่าย 1', '', 1, 72),
(61, 'NOZ-01', 'หัวจ่าย 1', '', 1, 71),
(66, '090G91', '', '', 1, 73),
(67, '120G91', '', '', 1, 73),
(68, '140G91', '', '', 1, 73),
(69, '150G91', '', '', 1, 73),
(70, '020G95', '', '', 1, 74),
(71, '040G95', '', '', 1, 74),
(72, '100G95', '', '', 1, 74),
(73, '110G95', '', '', 1, 74),
(74, '050U91', '', '', 1, 75),
(75, '080U91', '', '', 1, 75);

-- --------------------------------------------------------

--
-- Table structure for table `pricelist`
--

CREATE TABLE IF NOT EXISTS `pricelist` (
  `id` int(11) NOT NULL,
  `date` date NOT NULL,
  `unitpr` decimal(9,2) NOT NULL,
  `stmas_id` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `pricelist`
--

INSERT INTO `pricelist` (`id`, `date`, `unitpr`, `stmas_id`) VALUES
(1, '2017-02-28', '18.00', 48),
(2, '2017-02-28', '20.00', 49),
(3, '2017-02-28', '22.00', 50),
(4, '2017-02-28', '24.00', 51),
(5, '2017-02-28', '26.00', 52),
(6, '2017-02-28', '28.00', 53),
(7, '2017-02-28', '30.00', 54),
(8, '2017-02-28', '18.00', 48),
(9, '2017-02-28', '28.00', 53),
(10, '2017-02-28', '18.00', 48),
(11, '2017-02-28', '28.00', 53),
(12, '2017-02-28', '18.00', 48),
(13, '2017-02-28', '28.00', 53),
(14, '2017-02-28', '18.00', 48),
(15, '2017-02-28', '28.00', 53),
(16, '2017-02-28', '18.00', 48),
(17, '2017-02-28', '28.00', 53),
(18, '2017-02-28', '18.00', 48),
(19, '2017-02-28', '20.00', 49),
(20, '2017-02-28', '22.00', 50),
(21, '2017-02-28', '28.00', 53),
(22, '2017-02-28', '18.00', 48),
(23, '2017-02-28', '20.00', 49),
(24, '2017-02-28', '22.00', 50),
(25, '2017-02-28', '24.00', 51),
(26, '2017-02-28', '28.00', 53),
(27, '2017-02-28', '18.00', 48),
(28, '2017-02-28', '20.00', 49),
(29, '2017-02-28', '22.00', 50),
(30, '2017-02-28', '24.00', 51),
(31, '2017-02-28', '28.00', 53),
(32, '2017-02-28', '18.00', 48),
(33, '2017-02-28', '20.00', 49),
(34, '2017-02-28', '22.00', 50),
(35, '2017-02-28', '24.00', 51),
(36, '2017-02-28', '28.00', 53),
(37, '2017-02-28', '18.00', 48),
(38, '2017-02-28', '20.00', 49),
(39, '2017-02-28', '22.00', 50),
(40, '2017-02-28', '24.00', 51),
(41, '2017-02-28', '28.00', 53);

-- --------------------------------------------------------

--
-- Table structure for table `saleshistory`
--

CREATE TABLE IF NOT EXISTS `saleshistory` (
  `id` int(11) NOT NULL,
  `saldat` date NOT NULL,
  `mitbeg` decimal(14,2) NOT NULL,
  `mitend` decimal(14,2) NOT NULL,
  `salqty` decimal(14,2) NOT NULL,
  `salval` decimal(14,2) NOT NULL,
  `shift_id` int(11) NOT NULL,
  `nozzle_id` int(11) NOT NULL,
  `stmas_id` int(11) NOT NULL,
  `pricelist_id` int(11) NOT NULL,
  `salessummary_id` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=138 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `saleshistory`
--

INSERT INTO `saleshistory` (`id`, `saldat`, `mitbeg`, `mitend`, `salqty`, `salval`, `shift_id`, `nozzle_id`, `stmas_id`, `pricelist_id`, `salessummary_id`) VALUES
(68, '2017-02-28', '1234567.99', '1234888.00', '320.01', '5760.18', 1, 56, 48, 1, 205),
(69, '2017-02-28', '1234.00', '1444.00', '210.00', '3780.00', 1, 57, 48, 1, 205),
(70, '2017-02-28', '123456.00', '123999.00', '543.00', '9774.00', 1, 55, 48, 1, 205),
(71, '2017-02-28', '12345.00', '13333.00', '988.00', '17784.00', 1, 61, 48, 1, 205),
(72, '2017-02-28', '11111.00', '11250.00', '139.00', '3892.00', 1, 59, 53, 6, 206),
(73, '2017-02-28', '22222.00', '22650.00', '428.00', '11984.00', 1, 60, 53, 6, 206),
(74, '2017-02-27', '1000.00', '1200.00', '200.00', '3600.00', 2, 55, 48, 18, 209),
(75, '2017-02-27', '1000.00', '1300.00', '300.00', '5400.00', 2, 56, 48, 18, 209),
(76, '2017-02-27', '1000.00', '1400.00', '400.00', '7200.00', 2, 57, 48, 18, 209),
(77, '2017-02-27', '1000.00', '1500.00', '500.00', '9000.00', 2, 61, 48, 18, 209),
(78, '2017-02-27', '2000.00', '2100.00', '100.00', '2000.00', 2, 66, 49, 19, 211),
(79, '2017-02-27', '2000.00', '2400.00', '400.00', '8000.00', 2, 69, 49, 19, 211),
(80, '2017-02-27', '2000.00', '2200.00', '200.00', '4000.00', 2, 67, 49, 19, 211),
(81, '2017-02-27', '2000.00', '2300.00', '300.00', '6000.00', 2, 68, 49, 19, 211),
(82, '2017-02-27', '3000.00', '3100.00', '100.00', '2200.00', 2, 70, 50, 20, 212),
(83, '2017-02-27', '3000.00', '3500.00', '500.00', '11000.00', 2, 73, 50, 20, 212),
(84, '2017-02-27', '3000.00', '3200.00', '200.00', '4400.00', 2, 71, 50, 20, 212),
(85, '2017-02-27', '3000.00', '3400.00', '400.00', '8800.00', 2, 72, 50, 20, 212),
(86, '2017-02-27', '4000.00', '4200.00', '200.00', '5600.00', 2, 59, 53, 21, 210),
(87, '2017-02-27', '4000.00', '4400.00', '400.00', '11200.00', 2, 60, 53, 21, 210),
(88, '2017-02-27', '1000.00', '1300.00', '300.00', '5400.00', 7, 57, 48, 22, 213),
(89, '2017-02-27', '1000.00', '1100.00', '100.00', '1800.00', 7, 55, 48, 22, 213),
(90, '2017-02-27', '1000.00', '1200.00', '200.00', '3600.00', 7, 56, 48, 22, 213),
(91, '2017-02-27', '1000.00', '1400.00', '400.00', '7200.00', 7, 61, 48, 22, 213),
(92, '2017-02-27', '1000.00', '1300.00', '300.00', '6000.00', 7, 68, 49, 23, 215),
(93, '2017-02-27', '1000.00', '1100.00', '100.00', '2000.00', 7, 66, 49, 23, 215),
(94, '2017-02-27', '1000.00', '1400.00', '400.00', '8000.00', 7, 69, 49, 23, 215),
(95, '2017-02-27', '1000.00', '1200.00', '200.00', '4000.00', 7, 67, 49, 23, 215),
(96, '2017-02-27', '1000.00', '1300.00', '300.00', '6600.00', 7, 72, 50, 24, 216),
(97, '2017-02-27', '1000.00', '1100.00', '100.00', '2200.00', 7, 70, 50, 24, 216),
(98, '2017-02-27', '1000.00', '1400.00', '400.00', '8800.00', 7, 73, 50, 24, 216),
(99, '2017-02-27', '1000.00', '1200.00', '200.00', '4400.00', 7, 71, 50, 24, 216),
(100, '2017-02-27', '0.00', '0.00', '0.00', '0.00', 7, 74, 51, 25, 217),
(101, '2017-02-27', '0.00', '0.00', '0.00', '0.00', 7, 75, 51, 25, 217),
(102, '2017-02-27', '0.00', '0.00', '0.00', '0.00', 7, 59, 53, 26, 214),
(103, '2017-02-27', '0.00', '0.00', '0.00', '0.00', 7, 60, 53, 26, 214),
(104, '2017-03-09', '10.00', '20.00', '10.00', '180.00', 1, 55, 48, 27, 218),
(105, '2017-03-09', '30.00', '40.00', '10.00', '180.00', 1, 56, 48, 27, 218),
(106, '2017-03-09', '50.00', '60.00', '10.00', '180.00', 1, 57, 48, 27, 218),
(107, '2017-03-09', '70.00', '80.00', '10.00', '180.00', 1, 61, 48, 27, 218),
(108, '2017-02-27', '0.00', '0.00', '0.00', '0.00', 1, 59, 53, 17, 208),
(109, '2017-02-27', '0.00', '0.00', '0.00', '0.00', 1, 60, 53, 17, 208),
(110, '2017-02-27', '0.00', '0.00', '0.00', '0.00', 1, 55, 48, 16, 207),
(111, '2017-02-27', '0.00', '0.00', '0.00', '0.00', 1, 56, 48, 16, 207),
(112, '2017-02-27', '0.00', '0.00', '0.00', '0.00', 1, 57, 48, 16, 207),
(113, '2017-02-27', '0.00', '0.00', '0.00', '0.00', 1, 61, 48, 16, 207),
(114, '2017-03-09', '0.00', '0.00', '0.00', '0.00', 1, 70, 50, 29, 221),
(115, '2017-03-09', '0.00', '0.00', '0.00', '0.00', 1, 73, 50, 29, 221),
(116, '2017-03-09', '0.00', '0.00', '0.00', '0.00', 1, 71, 50, 29, 221),
(117, '2017-03-09', '0.00', '0.00', '0.00', '0.00', 1, 72, 50, 29, 221),
(118, '2017-03-09', '0.00', '0.00', '0.00', '0.00', 1, 59, 53, 31, 219),
(119, '2017-03-09', '0.00', '0.00', '0.00', '0.00', 1, 60, 53, 31, 219),
(120, '2017-03-09', '0.00', '0.00', '0.00', '0.00', 1, 74, 51, 30, 222),
(121, '2017-03-09', '0.00', '0.00', '0.00', '0.00', 1, 75, 51, 30, 222),
(122, '2017-03-09', '0.00', '0.00', '0.00', '0.00', 1, 68, 49, 28, 220),
(123, '2017-03-09', '0.00', '0.00', '0.00', '0.00', 1, 66, 49, 28, 220),
(124, '2017-03-09', '0.00', '0.00', '0.00', '0.00', 1, 69, 49, 28, 220),
(125, '2017-03-09', '0.00', '0.00', '0.00', '0.00', 1, 67, 49, 28, 220),
(126, '2017-03-09', '0.00', '0.00', '0.00', '0.00', 2, 57, 48, 37, 223),
(127, '2017-03-09', '0.00', '0.00', '0.00', '0.00', 2, 55, 48, 37, 223),
(128, '2017-03-09', '0.00', '0.00', '0.00', '0.00', 2, 56, 48, 37, 223),
(129, '2017-03-09', '0.00', '0.00', '0.00', '0.00', 2, 61, 48, 37, 223),
(130, '2017-03-09', '0.00', '0.00', '0.00', '0.00', 2, 66, 49, 38, 225),
(131, '2017-03-09', '0.00', '0.00', '0.00', '0.00', 2, 69, 49, 38, 225),
(132, '2017-03-09', '0.00', '0.00', '0.00', '0.00', 2, 67, 49, 38, 225),
(133, '2017-03-09', '0.00', '0.00', '0.00', '0.00', 2, 68, 49, 38, 225),
(134, '2017-03-09', '0.00', '0.00', '0.00', '0.00', 2, 70, 50, 39, 226),
(135, '2017-03-09', '0.00', '0.00', '0.00', '0.00', 2, 73, 50, 39, 226),
(136, '2017-03-09', '0.00', '0.00', '0.00', '0.00', 2, 71, 50, 39, 226),
(137, '2017-03-09', '0.00', '0.00', '0.00', '0.00', 2, 72, 50, 39, 226);

-- --------------------------------------------------------

--
-- Table structure for table `salessummary`
--

CREATE TABLE IF NOT EXISTS `salessummary` (
  `id` int(11) NOT NULL,
  `saldat` date NOT NULL,
  `dtest` decimal(14,2) NOT NULL,
  `dother` decimal(14,2) NOT NULL,
  `dothertxt` varchar(30) NOT NULL DEFAULT '',
  `ddisc` decimal(14,2) NOT NULL,
  `purvat` decimal(14,2) NOT NULL,
  `shift_id` int(11) NOT NULL,
  `stmas_id` int(11) NOT NULL,
  `pricelist_id` int(11) NOT NULL,
  `shiftsales_id` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=228 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `salessummary`
--

INSERT INTO `salessummary` (`id`, `saldat`, `dtest`, `dother`, `dothertxt`, `ddisc`, `purvat`, `shift_id`, `stmas_id`, `pricelist_id`, `shiftsales_id`) VALUES
(205, '2017-02-28', '5.00', '10.00', 'เติมผิด', '200.00', '0.00', 1, 48, 1, 39),
(206, '2017-02-28', '8.00', '1.50', 'น้ำมันหก', '500.00', '0.00', 1, 53, 6, 39),
(207, '2017-02-27', '0.00', '0.00', '', '0.00', '0.00', 1, 48, 16, 43),
(208, '2017-02-27', '0.00', '0.00', '', '0.00', '0.00', 1, 53, 17, 43),
(209, '2017-02-27', '0.00', '0.00', '', '0.00', '0.00', 2, 48, 18, 44),
(210, '2017-02-27', '0.00', '0.00', '', '0.00', '0.00', 2, 53, 21, 44),
(211, '2017-02-27', '0.00', '0.00', '', '0.00', '0.00', 2, 49, 19, 44),
(212, '2017-02-27', '0.00', '0.00', '', '0.00', '0.00', 2, 50, 20, 44),
(213, '2017-02-27', '0.00', '0.00', '', '0.00', '0.00', 7, 48, 22, 45),
(214, '2017-02-27', '0.00', '0.00', '', '0.00', '0.00', 7, 53, 26, 45),
(215, '2017-02-27', '0.00', '0.00', '', '0.00', '0.00', 7, 49, 23, 45),
(216, '2017-02-27', '0.00', '0.00', '', '0.00', '0.00', 7, 50, 24, 45),
(217, '2017-02-27', '0.00', '0.00', '', '0.00', '0.00', 7, 51, 25, 45),
(218, '2017-03-09', '90.00', '100.00', '', '110.00', '2099.30', 1, 48, 27, 46),
(219, '2017-03-09', '0.00', '0.00', '', '0.00', '0.00', 1, 53, 31, 46),
(220, '2017-03-09', '0.00', '0.00', '', '0.00', '0.00', 1, 49, 28, 46),
(221, '2017-03-09', '0.00', '0.00', '', '0.00', '0.00', 1, 50, 29, 46),
(222, '2017-03-09', '0.00', '0.00', '', '0.00', '0.00', 1, 51, 30, 46),
(223, '2017-03-09', '0.00', '0.00', '', '0.00', '0.00', 2, 48, 37, 47),
(224, '2017-03-09', '0.00', '0.00', '', '0.00', '0.00', 2, 53, 41, 47),
(225, '2017-03-09', '0.00', '0.00', '', '0.00', '0.00', 2, 49, 38, 47),
(226, '2017-03-09', '0.00', '0.00', '', '0.00', '0.00', 2, 50, 39, 47),
(227, '2017-03-09', '0.00', '0.00', '', '0.00', '0.00', 2, 51, 40, 47);

-- --------------------------------------------------------

--
-- Table structure for table `section`
--

CREATE TABLE IF NOT EXISTS `section` (
  `id` int(11) NOT NULL,
  `name` varchar(20) NOT NULL,
  `loccod` varchar(4) NOT NULL DEFAULT '',
  `begacc` decimal(14,2) NOT NULL,
  `begtak` decimal(14,2) NOT NULL,
  `begdif` decimal(14,2) NOT NULL,
  `tank_id` int(11) NOT NULL,
  `stmas_id` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=76 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `section`
--

INSERT INTO `section` (`id`, `name`, `loccod`, `begacc`, `begtak`, `begdif`, `tank_id`, `stmas_id`) VALUES
(69, 'SEC-01', '', '1000.00', '100.00', '-900.00', 55, 48),
(70, 'SEC-02', '', '200.00', '200.00', '0.00', 55, 53),
(71, 'SEC-01', '', '1000.00', '989.00', '-11.00', 56, 48),
(72, 'SEC-02', '', '500.00', '502.00', '2.00', 56, 53),
(73, 'SEC-03', '', '100.00', '100.00', '0.00', 56, 49),
(74, 'SEC-04', '', '205.00', '200.00', '-5.00', 56, 50),
(75, 'SEC-05', '', '302.00', '300.00', '-2.00', 56, 51);

-- --------------------------------------------------------

--
-- Table structure for table `settings`
--

CREATE TABLE IF NOT EXISTS `settings` (
  `id` int(11) NOT NULL,
  `express_data_path` text NOT NULL,
  `orgname` varchar(60) NOT NULL DEFAULT ''
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `settings`
--

INSERT INTO `settings` (`id`, `express_data_path`, `orgname`) VALUES
(1, 'testpump', 'ห้างหุ้นส่วนจำกัด วรรณสุขรุ่งเรือง');

-- --------------------------------------------------------

--
-- Table structure for table `shift`
--

CREATE TABLE IF NOT EXISTS `shift` (
  `id` int(11) NOT NULL,
  `seq` int(3) NOT NULL,
  `name` varchar(20) NOT NULL,
  `description` varchar(50) DEFAULT NULL,
  `starttime` time NOT NULL,
  `endtime` time NOT NULL,
  `remark` varchar(50) DEFAULT NULL,
  `saiprefix` varchar(2) NOT NULL DEFAULT '',
  `shsprefix` varchar(2) NOT NULL DEFAULT '',
  `sivprefix` varchar(2) NOT NULL DEFAULT '',
  `paeprefix` varchar(2) NOT NULL DEFAULT '',
  `phpprefix` varchar(2) NOT NULL DEFAULT '',
  `prrprefix` varchar(2) NOT NULL DEFAULT ''
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `shift`
--

INSERT INTO `shift` (`id`, `seq`, `name`, `description`, `starttime`, `endtime`, `remark`, `saiprefix`, `shsprefix`, `sivprefix`, `paeprefix`, `phpprefix`, `prrprefix`) VALUES
(1, 1, 'ผลัด A', 'ผลัดเช้า', '06:00:00', '13:59:59', '', 'AI', 'S1', 'I1', 'AE', 'P1', 'R1'),
(2, 2, 'ผลัด B', 'ผลัดบ่าย', '14:00:00', '21:59:59', '', 'AI', 'S2', 'I2', 'AE', 'P2', 'R2'),
(7, 3, 'ผลัด C', 'ผลัดกลางคืน', '22:00:00', '05:59:59', '', 'AI', 'S3', 'I3', 'AE', 'P3', 'R3');

-- --------------------------------------------------------

--
-- Table structure for table `shiftsales`
--

CREATE TABLE IF NOT EXISTS `shiftsales` (
  `id` int(11) NOT NULL,
  `saldat` date NOT NULL,
  `cretime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `closed` tinyint(1) NOT NULL DEFAULT '0',
  `shift_id` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=48 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `shiftsales`
--

INSERT INTO `shiftsales` (`id`, `saldat`, `cretime`, `closed`, `shift_id`) VALUES
(39, '2017-02-28', '2017-02-28 02:59:02', 0, 1),
(43, '2017-02-27', '2017-02-28 06:38:33', 1, 1),
(44, '2017-02-27', '2017-03-02 07:27:32', 1, 2),
(45, '2017-02-27', '2017-03-02 07:38:40', 1, 7),
(46, '2017-03-09', '2017-03-09 07:25:24', 0, 1),
(47, '2017-03-09', '2017-03-09 09:23:48', 0, 2);

-- --------------------------------------------------------

--
-- Table structure for table `shiftsttak`
--

CREATE TABLE IF NOT EXISTS `shiftsttak` (
  `id` int(11) NOT NULL,
  `takdat` date NOT NULL,
  `qty` decimal(15,2) NOT NULL DEFAULT '-1.00',
  `shiftsales_id` int(11) NOT NULL,
  `section_id` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `shiftsttak`
--

INSERT INTO `shiftsttak` (`id`, `takdat`, `qty`, `shiftsales_id`, `section_id`) VALUES
(17, '2017-02-28', '1200.00', 39, 69),
(18, '2017-02-28', '450.00', 39, 71),
(19, '2017-02-28', '500.00', 39, 70),
(20, '2017-02-28', '2000.00', 39, 72),
(21, '2017-02-27', '-1.00', 43, 69),
(22, '2017-02-27', '-1.00', 43, 71),
(23, '2017-02-27', '-1.00', 43, 70),
(24, '2017-02-27', '-1.00', 43, 72),
(25, '2017-02-27', '-1.00', 44, 69),
(26, '2017-02-27', '-1.00', 44, 71),
(27, '2017-02-27', '-1.00', 44, 70),
(28, '2017-02-27', '-1.00', 44, 72),
(29, '2017-02-27', '-1.00', 44, 73),
(30, '2017-02-27', '-1.00', 44, 74),
(31, '2017-02-27', '-1.00', 45, 69),
(32, '2017-02-27', '-1.00', 45, 71),
(33, '2017-02-27', '-1.00', 45, 70),
(34, '2017-02-27', '-1.00', 45, 72),
(35, '2017-02-27', '-1.00', 45, 73),
(36, '2017-02-27', '-1.00', 45, 74),
(37, '2017-02-27', '-1.00', 45, 75),
(38, '2017-03-09', '-1.00', 46, 69),
(39, '2017-03-09', '-1.00', 46, 71),
(40, '2017-03-09', '-1.00', 46, 70),
(41, '2017-03-09', '-1.00', 46, 72),
(42, '2017-03-09', '-1.00', 46, 73),
(43, '2017-03-09', '-1.00', 46, 74),
(44, '2017-03-09', '-1.00', 46, 75),
(45, '2017-03-09', '-1.00', 47, 69),
(46, '2017-03-09', '-1.00', 47, 71),
(47, '2017-03-09', '-1.00', 47, 70),
(48, '2017-03-09', '-1.00', 47, 72),
(49, '2017-03-09', '-1.00', 47, 73),
(50, '2017-03-09', '-1.00', 47, 74),
(51, '2017-03-09', '-1.00', 47, 75);

-- --------------------------------------------------------

--
-- Table structure for table `stmas`
--

CREATE TABLE IF NOT EXISTS `stmas` (
  `id` int(11) NOT NULL,
  `name` varchar(20) NOT NULL,
  `description` varchar(50) DEFAULT NULL,
  `remark` varchar(50) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=55 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stmas`
--

INSERT INTO `stmas` (`id`, `name`, `description`, `remark`) VALUES
(48, 'DIESEL', 'ดีเซล', ''),
(49, 'GSH91', 'แก๊สโซฮอล์ 91', ''),
(50, 'GSH95', 'แก๊สโซฮอล์ 95', ''),
(51, 'ULG91', 'เบนซิน 91', ''),
(52, 'ULG95', 'เบนซิน 95', ''),
(53, 'VPDIESEL', 'ดีเซล วี-เพาเวอร์', ''),
(54, 'VPGASOLINE', 'เบนซิน วี-เพาเวอร์', '');

-- --------------------------------------------------------

--
-- Table structure for table `tank`
--

CREATE TABLE IF NOT EXISTS `tank` (
  `id` int(11) NOT NULL,
  `name` varchar(20) NOT NULL,
  `startdate` date NOT NULL,
  `enddate` date DEFAULT NULL,
  `description` varchar(50) DEFAULT NULL,
  `remark` varchar(50) DEFAULT NULL,
  `isactive` tinyint(1) NOT NULL DEFAULT '1'
) ENGINE=InnoDB AUTO_INCREMENT=57 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `tank`
--

INSERT INTO `tank` (`id`, `name`, `startdate`, `enddate`, `description`, `remark`, `isactive`) VALUES
(55, 'TANK-01', '2017-01-01', NULL, 'แท๊งค์ 1 ความจุ 15,000 ลิตร', 'ทดสอบระบบ', 1),
(56, 'TANK-02', '2017-01-01', NULL, 'แท๊งค์ 2 ความจุ 7,500 ลิตร', 'ทดสอบ', 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `dayend`
--
ALTER TABLE `dayend`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unq-dayend-saldat` (`saldat`,`stmas_id`),
  ADD KEY `ndx-dayend-stmas_id` (`stmas_id`);

--
-- Indexes for table `daysttak`
--
ALTER TABLE `daysttak`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ndx-daysttak-section_id` (`section_id`),
  ADD KEY `ndx-daysttak-dayend_id` (`dayend_id`);

--
-- Indexes for table `nozzle`
--
ALTER TABLE `nozzle`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unq-nozzle-name` (`name`,`section_id`),
  ADD KEY `ndx-nozzle-section_id` (`section_id`);

--
-- Indexes for table `pricelist`
--
ALTER TABLE `pricelist`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ndx-pricelist-stmas_id` (`stmas_id`);

--
-- Indexes for table `saleshistory`
--
ALTER TABLE `saleshistory`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unq-saleshistory` (`stmas_id`,`saldat`,`shift_id`,`nozzle_id`),
  ADD KEY `ndx-saleshistory-shift_id` (`shift_id`),
  ADD KEY `ndx-saleshistory_nozzle_id` (`nozzle_id`),
  ADD KEY `ndx-saleshistory-stmas_id` (`stmas_id`),
  ADD KEY `ndx-saleshistory-pricelist_id` (`pricelist_id`),
  ADD KEY `ndx-saleshistory-salessummary_id` (`salessummary_id`);

--
-- Indexes for table `salessummary`
--
ALTER TABLE `salessummary`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unq-salessummary` (`stmas_id`,`saldat`,`shift_id`,`shiftsales_id`),
  ADD KEY `ndx-salessummary-shift_id` (`shift_id`),
  ADD KEY `ndx-salessummary-stmas_id` (`stmas_id`),
  ADD KEY `ndx-salessummary-pricelist_id` (`pricelist_id`),
  ADD KEY `ndx-salessummary-shiftsales_id` (`shiftsales_id`);

--
-- Indexes for table `section`
--
ALTER TABLE `section`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ndx-section-tank_id` (`tank_id`),
  ADD KEY `ndx-section-stmas_id` (`stmas_id`);

--
-- Indexes for table `settings`
--
ALTER TABLE `settings`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `shift`
--
ALTER TABLE `shift`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unq-shift-name` (`name`);

--
-- Indexes for table `shiftsales`
--
ALTER TABLE `shiftsales`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unq-shiftsales` (`saldat`,`shift_id`),
  ADD KEY `ndx-shiftsales-shift_id` (`shift_id`);

--
-- Indexes for table `shiftsttak`
--
ALTER TABLE `shiftsttak`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unq-sttak` (`shiftsales_id`,`section_id`),
  ADD KEY `ndx-sttak-section_id` (`section_id`),
  ADD KEY `ndx-sttak-shiftsales_id` (`shiftsales_id`);

--
-- Indexes for table `stmas`
--
ALTER TABLE `stmas`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unq-stmas-name` (`name`);

--
-- Indexes for table `tank`
--
ALTER TABLE `tank`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unq-tank-name` (`name`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `dayend`
--
ALTER TABLE `dayend`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=50;
--
-- AUTO_INCREMENT for table `daysttak`
--
ALTER TABLE `daysttak`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=76;
--
-- AUTO_INCREMENT for table `nozzle`
--
ALTER TABLE `nozzle`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=76;
--
-- AUTO_INCREMENT for table `pricelist`
--
ALTER TABLE `pricelist`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=42;
--
-- AUTO_INCREMENT for table `saleshistory`
--
ALTER TABLE `saleshistory`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=138;
--
-- AUTO_INCREMENT for table `salessummary`
--
ALTER TABLE `salessummary`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=228;
--
-- AUTO_INCREMENT for table `section`
--
ALTER TABLE `section`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=76;
--
-- AUTO_INCREMENT for table `settings`
--
ALTER TABLE `settings`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `shift`
--
ALTER TABLE `shift`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT for table `shiftsales`
--
ALTER TABLE `shiftsales`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=48;
--
-- AUTO_INCREMENT for table `shiftsttak`
--
ALTER TABLE `shiftsttak`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=52;
--
-- AUTO_INCREMENT for table `stmas`
--
ALTER TABLE `stmas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=55;
--
-- AUTO_INCREMENT for table `tank`
--
ALTER TABLE `tank`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=57;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `dayend`
--
ALTER TABLE `dayend`
  ADD CONSTRAINT `fk-dayend-stmas_id` FOREIGN KEY (`stmas_id`) REFERENCES `stmas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `daysttak`
--
ALTER TABLE `daysttak`
  ADD CONSTRAINT `fk-daysttak-dayend_id` FOREIGN KEY (`dayend_id`) REFERENCES `dayend` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk-daysttak-section_id` FOREIGN KEY (`section_id`) REFERENCES `section` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `nozzle`
--
ALTER TABLE `nozzle`
  ADD CONSTRAINT `fk-nozzle-section_id` FOREIGN KEY (`section_id`) REFERENCES `section` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `pricelist`
--
ALTER TABLE `pricelist`
  ADD CONSTRAINT `fk-pricelist-stmas_id` FOREIGN KEY (`stmas_id`) REFERENCES `stmas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `saleshistory`
--
ALTER TABLE `saleshistory`
  ADD CONSTRAINT `fk-saleshistory-nozzle_id` FOREIGN KEY (`nozzle_id`) REFERENCES `nozzle` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk-saleshistory-pricelist_id` FOREIGN KEY (`pricelist_id`) REFERENCES `pricelist` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk-saleshistory-salessummary_id` FOREIGN KEY (`salessummary_id`) REFERENCES `salessummary` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk-saleshistory-shift_id` FOREIGN KEY (`shift_id`) REFERENCES `shift` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk-saleshistory-stmas_id` FOREIGN KEY (`stmas_id`) REFERENCES `stmas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `salessummary`
--
ALTER TABLE `salessummary`
  ADD CONSTRAINT `fk-salessummary-pricelist_id` FOREIGN KEY (`pricelist_id`) REFERENCES `pricelist` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk-salessummary-shift_id` FOREIGN KEY (`shift_id`) REFERENCES `shift` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk-salessummary-shiftsales_id` FOREIGN KEY (`shiftsales_id`) REFERENCES `shiftsales` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk-salessummary-stmas_id` FOREIGN KEY (`stmas_id`) REFERENCES `stmas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `section`
--
ALTER TABLE `section`
  ADD CONSTRAINT `fk-section-stmas_id` FOREIGN KEY (`stmas_id`) REFERENCES `stmas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk-section-tank_id` FOREIGN KEY (`tank_id`) REFERENCES `tank` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `shiftsales`
--
ALTER TABLE `shiftsales`
  ADD CONSTRAINT `fk-shiftsales-shift_id` FOREIGN KEY (`shift_id`) REFERENCES `shift` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `shiftsttak`
--
ALTER TABLE `shiftsttak`
  ADD CONSTRAINT `fk-sttak-section_id` FOREIGN KEY (`section_id`) REFERENCES `section` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk-sttak-shiftsales_id` FOREIGN KEY (`shiftsales_id`) REFERENCES `shiftsales` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
