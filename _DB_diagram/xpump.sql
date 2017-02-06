-- phpMyAdmin SQL Dump
-- version 4.4.8
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Feb 03, 2017 at 06:11 AM
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
-- Table structure for table `apmas`
--

CREATE TABLE IF NOT EXISTS `apmas` (
  `id` int(11) NOT NULL,
  `supcod` varchar(20) NOT NULL,
  `supnam` varchar(100) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `apmas`
--

INSERT INTO `apmas` (`id`, `supcod`, `supnam`) VALUES
(1, 'เชลล์', 'บริษัท เชลล์ (ประเทศไทย) จำกัด (มหาชน)'),
(2, 'ปตท.', 'บริษัท ปตท. จำกัด (มหาชน)');

-- --------------------------------------------------------

--
-- Table structure for table `aptrn`
--

CREATE TABLE IF NOT EXISTS `aptrn` (
  `id` int(11) NOT NULL,
  `docnum` varchar(20) NOT NULL,
  `docdat` date NOT NULL,
  `vatnum` varchar(50) DEFAULT NULL,
  `vatdat` date DEFAULT NULL,
  `vatrat` decimal(4,2) NOT NULL,
  `apmas_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `nozzle`
--

INSERT INTO `nozzle` (`id`, `name`, `description`, `remark`, `isactive`, `section_id`) VALUES
(27, 'N-01', 'หัวจ่าย 1', '', 1, 58),
(28, 'N-02', 'หัวจ่าย 2', '', 1, 58),
(29, 'N-03', 'หัวจ่าย 3', '', 0, 58),
(30, 'N-04', 'หัวจ่าย 4', '', 0, 59),
(32, 'N-05', 'หัวจ่ายที่ 5', '', 1, 60);

-- --------------------------------------------------------

--
-- Table structure for table `pricelist`
--

CREATE TABLE IF NOT EXISTS `pricelist` (
  `id` int(11) NOT NULL,
  `date` date NOT NULL,
  `unitpr` decimal(9,2) NOT NULL,
  `stmas_id` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=126 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `pricelist`
--

INSERT INTO `pricelist` (`id`, `date`, `unitpr`, `stmas_id`) VALUES
(1, '2017-01-26', '10.00', 21),
(2, '2017-01-26', '20.00', 22),
(3, '2017-01-26', '30.00', 23),
(4, '2017-01-26', '40.00', 24),
(5, '2017-01-26', '50.00', 25),
(6, '2017-01-26', '10.00', 21),
(7, '2017-01-26', '20.00', 22),
(8, '2017-01-26', '30.00', 23),
(9, '2017-01-26', '40.00', 24),
(10, '2017-01-26', '50.00', 25),
(11, '2017-01-26', '10.00', 21),
(12, '2017-01-26', '20.00', 22),
(13, '2017-01-26', '30.00', 23),
(14, '2017-01-26', '40.00', 24),
(15, '2017-01-26', '50.00', 25),
(16, '2017-01-26', '10.00', 21),
(17, '2017-01-26', '20.00', 22),
(18, '2017-01-26', '30.00', 23),
(19, '2017-01-26', '40.00', 24),
(20, '2017-01-26', '50.00', 25),
(21, '2017-01-26', '10.00', 21),
(22, '2017-01-26', '20.00', 22),
(23, '2017-01-26', '30.00', 23),
(24, '2017-01-26', '40.00', 24),
(25, '2017-01-26', '50.00', 25),
(26, '2017-01-26', '10.00', 21),
(27, '2017-01-26', '20.00', 22),
(28, '2017-01-26', '30.00', 23),
(29, '2017-01-26', '40.00', 24),
(30, '2017-01-26', '50.00', 25),
(31, '2017-01-26', '10.00', 21),
(32, '2017-01-26', '20.00', 22),
(33, '2017-01-26', '30.00', 23),
(34, '2017-01-26', '40.00', 24),
(35, '2017-01-26', '50.00', 25),
(36, '2017-01-26', '10.00', 21),
(37, '2017-01-26', '20.00', 22),
(38, '2017-01-26', '30.00', 23),
(39, '2017-01-26', '40.00', 24),
(40, '2017-01-26', '50.00', 25),
(41, '2017-01-26', '10.00', 21),
(42, '2017-01-26', '20.00', 22),
(43, '2017-01-26', '30.00', 23),
(44, '2017-01-26', '40.00', 24),
(45, '2017-01-26', '50.00', 25),
(46, '2017-01-26', '10.00', 21),
(47, '2017-01-26', '20.00', 22),
(48, '2017-01-26', '30.00', 23),
(49, '2017-01-26', '40.00', 24),
(50, '2017-01-26', '50.00', 25),
(51, '2017-01-26', '10.00', 21),
(52, '2017-01-26', '20.00', 22),
(53, '2017-01-26', '30.00', 23),
(54, '2017-01-26', '40.00', 24),
(55, '2017-01-26', '50.00', 25),
(56, '2017-01-26', '10.00', 21),
(57, '2017-01-26', '20.00', 22),
(58, '2017-01-26', '30.00', 23),
(59, '2017-01-26', '40.00', 24),
(60, '2017-01-26', '50.00', 25),
(61, '2017-01-26', '10.00', 21),
(62, '2017-01-26', '20.00', 22),
(63, '2017-01-26', '30.00', 23),
(64, '2017-01-26', '40.00', 24),
(65, '2017-01-26', '50.00', 25),
(66, '2017-01-26', '10.00', 21),
(67, '2017-01-26', '20.00', 22),
(68, '2017-01-26', '30.00', 23),
(69, '2017-01-26', '40.00', 24),
(70, '2017-01-26', '50.00', 25),
(71, '2017-01-26', '10.00', 21),
(72, '2017-01-26', '20.00', 22),
(73, '2017-01-26', '30.00', 23),
(74, '2017-01-26', '40.00', 24),
(75, '2017-01-26', '50.00', 25),
(76, '2017-01-26', '10.00', 21),
(77, '2017-01-26', '20.00', 22),
(78, '2017-01-26', '30.00', 23),
(79, '2017-01-26', '40.00', 24),
(80, '2017-01-26', '50.00', 25),
(86, '2017-01-31', '10.50', 21),
(87, '2017-01-31', '20.50', 22),
(88, '2017-01-31', '30.50', 23),
(89, '2017-01-31', '40.50', 24),
(90, '2017-01-31', '50.50', 25),
(116, '2017-01-31', '10.50', 21),
(117, '2017-01-31', '20.50', 22),
(118, '2017-01-31', '30.50', 23),
(119, '2017-01-31', '40.50', 24),
(120, '2017-01-31', '50.50', 25),
(121, '2017-01-31', '10.50', 21),
(122, '2017-01-31', '20.50', 22),
(123, '2017-01-31', '30.50', 23),
(124, '2017-01-31', '40.50', 24),
(125, '2017-01-31', '50.50', 25);

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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `saleshistory`
--

INSERT INTO `saleshistory` (`id`, `saldat`, `mitbeg`, `mitend`, `salqty`, `salval`, `shift_id`, `nozzle_id`, `stmas_id`, `pricelist_id`, `salessummary_id`) VALUES
(1, '2017-01-31', '120.20', '456.90', '336.70', '13636.35', 2, 27, 24, 124, 40),
(2, '2017-01-31', '30.11', '40.00', '9.89', '400.55', 2, 28, 24, 124, 40),
(3, '2017-01-31', '10.01', '20.00', '9.99', '404.60', 2, 32, 24, 124, 40);

-- --------------------------------------------------------

--
-- Table structure for table `salessummary`
--

CREATE TABLE IF NOT EXISTS `salessummary` (
  `id` int(11) NOT NULL,
  `saldat` date NOT NULL,
  `total` decimal(14,2) NOT NULL,
  `dtest` decimal(14,2) NOT NULL,
  `dother` decimal(14,2) NOT NULL,
  `dothertxt` varchar(30) NOT NULL DEFAULT '',
  `totqty` decimal(14,2) NOT NULL,
  `totval` decimal(14,2) NOT NULL,
  `ddisc` decimal(14,2) NOT NULL,
  `netval` decimal(14,2) NOT NULL,
  `salvat` decimal(14,2) NOT NULL,
  `purvat` decimal(14,2) NOT NULL,
  `shift_id` int(11) NOT NULL,
  `stmas_id` int(11) NOT NULL,
  `pricelist_id` int(11) NOT NULL,
  `shiftsales_id` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `salessummary`
--

INSERT INTO `salessummary` (`id`, `saldat`, `total`, `dtest`, `dother`, `dothertxt`, `totqty`, `totval`, `ddisc`, `netval`, `salvat`, `purvat`, `shift_id`, `stmas_id`, `pricelist_id`, `shiftsales_id`) VALUES
(32, '2017-01-31', '0.00', '0.00', '0.00', '', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', 1, 21, 116, 8),
(33, '2017-01-31', '0.00', '0.00', '0.00', '', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', 1, 22, 117, 8),
(34, '2017-01-31', '0.00', '0.00', '0.00', '', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', 1, 23, 118, 8),
(35, '2017-01-31', '0.00', '0.00', '0.00', '', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', 1, 24, 119, 8),
(36, '2017-01-31', '0.00', '0.00', '0.00', '', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', 1, 25, 120, 8),
(37, '2017-01-31', '0.00', '0.00', '0.00', '', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', 2, 21, 121, 9),
(38, '2017-01-31', '0.00', '0.00', '0.00', '', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', 2, 22, 122, 9),
(39, '2017-01-31', '0.00', '0.00', '0.00', '', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', 2, 23, 123, 9),
(40, '2017-01-31', '356.58', '0.00', '0.00', '', '356.58', '14441.49', '0.00', '14441.49', '944.77', '0.00', 2, 24, 124, 9),
(41, '2017-01-31', '0.00', '0.00', '0.00', '', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', 2, 25, 125, 9);

-- --------------------------------------------------------

--
-- Table structure for table `section`
--

CREATE TABLE IF NOT EXISTS `section` (
  `id` int(11) NOT NULL,
  `name` varchar(20) NOT NULL,
  `begbal` decimal(14,2) NOT NULL,
  `totbal` decimal(14,2) NOT NULL,
  `tank_id` int(11) NOT NULL,
  `stmas_id` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=61 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `section`
--

INSERT INTO `section` (`id`, `name`, `begbal`, `totbal`, `tank_id`, `stmas_id`) VALUES
(58, 'S-01', '2000.00', '2000.00', 48, 24),
(59, 'S-02', '5500.00', '5500.00', 48, 25),
(60, 'S-03', '200.00', '0.00', 49, 24);

-- --------------------------------------------------------

--
-- Table structure for table `shift`
--

CREATE TABLE IF NOT EXISTS `shift` (
  `id` int(11) NOT NULL,
  `name` varchar(20) NOT NULL,
  `description` varchar(50) DEFAULT NULL,
  `starttime` time NOT NULL,
  `endtime` time NOT NULL,
  `remark` varchar(50) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `shift`
--

INSERT INTO `shift` (`id`, `name`, `description`, `starttime`, `endtime`, `remark`) VALUES
(1, 'ผลัด A', 'ผลัดเช้า', '06:00:00', '13:59:59', ''),
(2, 'ผลัด B', 'ผลัดบ่าย', '14:00:00', '21:59:59', ''),
(3, 'ผลัด C', 'ผลัดกลางคืน', '22:00:00', '05:59:59', '');

-- --------------------------------------------------------

--
-- Table structure for table `shiftsales`
--

CREATE TABLE IF NOT EXISTS `shiftsales` (
  `id` int(11) NOT NULL,
  `saldat` date NOT NULL,
  `shift_id` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `shiftsales`
--

INSERT INTO `shiftsales` (`id`, `saldat`, `shift_id`) VALUES
(8, '2017-01-31', 1),
(9, '2017-01-31', 2);

-- --------------------------------------------------------

--
-- Table structure for table `stcrd`
--

CREATE TABLE IF NOT EXISTS `stcrd` (
  `id` int(11) NOT NULL,
  `trnqty` decimal(14,2) NOT NULL,
  `trnval` decimal(14,2) NOT NULL,
  `vatamt` decimal(14,2) NOT NULL,
  `aptrn_id` int(11) NOT NULL,
  `section_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `stmas`
--

CREATE TABLE IF NOT EXISTS `stmas` (
  `id` int(11) NOT NULL,
  `name` varchar(20) NOT NULL,
  `description` varchar(50) DEFAULT NULL,
  `remark` varchar(50) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stmas`
--

INSERT INTO `stmas` (`id`, `name`, `description`, `remark`) VALUES
(21, 'TEST-1', 'ทดสอบสินค้ารายการที่ 1', 'หมายเหตุ 1'),
(22, 'ก', 'ทดสอบ ก.', 'หมายเหตุ ก.'),
(23, 'ข', 'ทดสอบ ข.', 'หมายเหตุ ข.'),
(24, 'ค', 'ทดสอบ ค.', 'หมายเหตุ ค.'),
(25, 'คอควาย', 'ทดสอบ คอควาย', 'หมายเหตุ คอควาย');

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
) ENGINE=InnoDB AUTO_INCREMENT=50 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `tank`
--

INSERT INTO `tank` (`id`, `name`, `startdate`, `enddate`, `description`, `remark`, `isactive`) VALUES
(48, 'TANK-01', '2017-01-01', NULL, 'ทดสอบแท๊งค์ 1 7,500 ลิตร', '...', 1),
(49, 'TANK-02', '2017-01-21', NULL, 'ทดสอบเพิ่มแท๊งค์ที่ 2 10,000 ลิตร', '', 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `apmas`
--
ALTER TABLE `apmas`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unq-apmas-supcod` (`supcod`);

--
-- Indexes for table `aptrn`
--
ALTER TABLE `aptrn`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unq-aptrn-docnum` (`docnum`),
  ADD KEY `ndx-aptrn-apmas_id` (`apmas_id`);

--
-- Indexes for table `nozzle`
--
ALTER TABLE `nozzle`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unq-nozzle-name` (`name`),
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
  ADD KEY `ndx-shiftsales-shift_id` (`shift_id`);

--
-- Indexes for table `stcrd`
--
ALTER TABLE `stcrd`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ndx-stcrd-aptrn_id` (`aptrn_id`),
  ADD KEY `ndx-stcrd-section_id` (`section_id`);

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
-- AUTO_INCREMENT for table `apmas`
--
ALTER TABLE `apmas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `aptrn`
--
ALTER TABLE `aptrn`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `nozzle`
--
ALTER TABLE `nozzle`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=33;
--
-- AUTO_INCREMENT for table `pricelist`
--
ALTER TABLE `pricelist`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=126;
--
-- AUTO_INCREMENT for table `saleshistory`
--
ALTER TABLE `saleshistory`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `salessummary`
--
ALTER TABLE `salessummary`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=42;
--
-- AUTO_INCREMENT for table `section`
--
ALTER TABLE `section`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=61;
--
-- AUTO_INCREMENT for table `shift`
--
ALTER TABLE `shift`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `shiftsales`
--
ALTER TABLE `shiftsales`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=10;
--
-- AUTO_INCREMENT for table `stcrd`
--
ALTER TABLE `stcrd`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `stmas`
--
ALTER TABLE `stmas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=30;
--
-- AUTO_INCREMENT for table `tank`
--
ALTER TABLE `tank`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=50;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `aptrn`
--
ALTER TABLE `aptrn`
  ADD CONSTRAINT `fk-aptrn-apmas_id` FOREIGN KEY (`apmas_id`) REFERENCES `apmas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

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
-- Constraints for table `stcrd`
--
ALTER TABLE `stcrd`
  ADD CONSTRAINT `fk-stcrd-aptrn_id` FOREIGN KEY (`aptrn_id`) REFERENCES `aptrn` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk-stcrd-section_id` FOREIGN KEY (`section_id`) REFERENCES `section` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
