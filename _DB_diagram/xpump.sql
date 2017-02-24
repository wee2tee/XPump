-- phpMyAdmin SQL Dump
-- version 4.4.8
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Feb 23, 2017 at 09:37 AM
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `daysttak`
--

CREATE TABLE IF NOT EXISTS `daysttak` (
  `id` int(11) NOT NULL,
  `qty` varchar(45) NOT NULL DEFAULT '0',
  `dayend_id` int(11) NOT NULL,
  `section_id` int(11) NOT NULL
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
) ENGINE=InnoDB AUTO_INCREMENT=62 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `nozzle`
--

INSERT INTO `nozzle` (`id`, `name`, `description`, `remark`, `isactive`, `section_id`) VALUES
(55, 'NOZ-01', 'หัวจ่าย 1', '', 1, 69),
(56, 'NOZ-02', 'หัวจ่าย 2', '', 1, 69),
(57, 'NOZ-03', 'หัวจ่าย 3', '', 1, 69),
(59, 'NOZ-01', 'หัวจ่าย 1', '', 1, 70),
(60, 'NOZ-01', 'หัวจ่าย 1', '', 1, 72),
(61, 'NOZ-01', 'หัวจ่าย 1', '', 1, 71);

-- --------------------------------------------------------

--
-- Table structure for table `pricelist`
--

CREATE TABLE IF NOT EXISTS `pricelist` (
  `id` int(11) NOT NULL,
  `date` date NOT NULL,
  `unitpr` decimal(9,2) NOT NULL,
  `stmas_id` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=305 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `pricelist`
--

INSERT INTO `pricelist` (`id`, `date`, `unitpr`, `stmas_id`) VALUES
(298, '2017-02-22', '18.00', 48),
(299, '2017-02-22', '20.00', 49),
(300, '2017-02-22', '22.00', 50),
(301, '2017-02-22', '24.00', 51),
(302, '2017-02-22', '26.00', 52),
(303, '2017-02-22', '28.00', 53),
(304, '2017-02-22', '30.00', 54);

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
) ENGINE=InnoDB AUTO_INCREMENT=68 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `saleshistory`
--

INSERT INTO `saleshistory` (`id`, `saldat`, `mitbeg`, `mitend`, `salqty`, `salval`, `shift_id`, `nozzle_id`, `stmas_id`, `pricelist_id`, `salessummary_id`) VALUES
(62, '2017-02-22', '0.00', '0.00', '0.00', '0.00', 1, 59, 53, 303, 189),
(63, '2017-02-22', '0.00', '0.00', '0.00', '0.00', 1, 60, 53, 303, 189),
(64, '2017-02-22', '0.00', '0.00', '0.00', '0.00', 1, 57, 48, 298, 184),
(65, '2017-02-22', '0.00', '0.00', '0.00', '0.00', 1, 55, 48, 298, 184),
(66, '2017-02-22', '0.00', '0.00', '0.00', '0.00', 1, 56, 48, 298, 184),
(67, '2017-02-22', '0.00', '0.00', '0.00', '0.00', 1, 61, 48, 298, 184);

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
) ENGINE=InnoDB AUTO_INCREMENT=191 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `salessummary`
--

INSERT INTO `salessummary` (`id`, `saldat`, `dtest`, `dother`, `dothertxt`, `ddisc`, `purvat`, `shift_id`, `stmas_id`, `pricelist_id`, `shiftsales_id`) VALUES
(184, '2017-02-22', '0.00', '0.00', '', '0.00', '0.00', 1, 48, 298, 36),
(185, '2017-02-22', '0.00', '0.00', '', '0.00', '0.00', 1, 49, 299, 36),
(186, '2017-02-22', '0.00', '0.00', '', '0.00', '0.00', 1, 50, 300, 36),
(187, '2017-02-22', '0.00', '0.00', '', '0.00', '0.00', 1, 51, 301, 36),
(188, '2017-02-22', '0.00', '0.00', '', '0.00', '0.00', 1, 52, 302, 36),
(189, '2017-02-22', '0.00', '0.00', '', '0.00', '0.00', 1, 53, 303, 36),
(190, '2017-02-22', '0.00', '0.00', '', '0.00', '0.00', 1, 54, 304, 36);

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
) ENGINE=InnoDB AUTO_INCREMENT=73 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `section`
--

INSERT INTO `section` (`id`, `name`, `loccod`, `begacc`, `begtak`, `begdif`, `tank_id`, `stmas_id`) VALUES
(69, 'SEC-01', '', '1000.00', '0.00', '0.00', 55, 48),
(70, 'SEC-02', '', '200.00', '0.00', '0.00', 55, 53),
(71, 'SEC-01', '', '1000.00', '989.00', '-11.00', 56, 48),
(72, 'SEC-02', '', '500.00', '502.00', '2.00', 56, 53);

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
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

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
  `cretime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `closed` tinyint(1) NOT NULL DEFAULT '0',
  `shift_id` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `shiftsales`
--

INSERT INTO `shiftsales` (`id`, `saldat`, `cretime`, `closed`, `shift_id`) VALUES
(36, '2017-02-22', '2017-02-22 15:57:08', 0, 1);

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
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `shiftsttak`
--

INSERT INTO `shiftsttak` (`id`, `takdat`, `qty`, `shiftsales_id`, `section_id`) VALUES
(5, '2017-02-22', '-1.00', 36, 69),
(6, '2017-02-22', '-1.00', 36, 71),
(7, '2017-02-22', '-1.00', 36, 70),
(8, '2017-02-22', '-1.00', 36, 72);

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
  ADD KEY `fk_dayend_stmas1_idx` (`stmas_id`);

--
-- Indexes for table `daysttak`
--
ALTER TABLE `daysttak`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_daysttak_section1_idx` (`section_id`),
  ADD KEY `fk_daysttak_dayend1_idx` (`dayend_id`);

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `daysttak`
--
ALTER TABLE `daysttak`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `nozzle`
--
ALTER TABLE `nozzle`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=62;
--
-- AUTO_INCREMENT for table `pricelist`
--
ALTER TABLE `pricelist`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=305;
--
-- AUTO_INCREMENT for table `saleshistory`
--
ALTER TABLE `saleshistory`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=68;
--
-- AUTO_INCREMENT for table `salessummary`
--
ALTER TABLE `salessummary`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=191;
--
-- AUTO_INCREMENT for table `section`
--
ALTER TABLE `section`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=73;
--
-- AUTO_INCREMENT for table `settings`
--
ALTER TABLE `settings`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `shift`
--
ALTER TABLE `shift`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT for table `shiftsales`
--
ALTER TABLE `shiftsales`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=37;
--
-- AUTO_INCREMENT for table `shiftsttak`
--
ALTER TABLE `shiftsttak`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=9;
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
  ADD CONSTRAINT `fk_dayend_stmas1` FOREIGN KEY (`stmas_id`) REFERENCES `stmas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `daysttak`
--
ALTER TABLE `daysttak`
  ADD CONSTRAINT `fk_daysttak_dayend1` FOREIGN KEY (`dayend_id`) REFERENCES `dayend` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_daysttak_section1` FOREIGN KEY (`section_id`) REFERENCES `section` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

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
