-- phpMyAdmin SQL Dump
-- version 4.4.8
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Feb 10, 2017 at 11:23 AM
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
  `rcvdat` date NOT NULL,
  `vatnum` varchar(50) NOT NULL,
  `vatdat` date NOT NULL,
  `apmas_id` int(11) NOT NULL,
  `shift_id` int(11) NOT NULL
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
) ENGINE=InnoDB AUTO_INCREMENT=55 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `nozzle`
--

INSERT INTO `nozzle` (`id`, `name`, `description`, `remark`, `isactive`, `section_id`) VALUES
(27, 'N-01', 'หัวจ่าย 1', '', 1, 58),
(28, 'N-02', 'หัวจ่าย 2', '', 1, 58),
(29, 'N-03', 'หัวจ่าย 3', '', 0, 58),
(30, 'N-04', 'หัวจ่าย 4', '', 0, 59),
(47, 'NX-01', '', '', 1, 65),
(48, 'NX-02', '', '', 1, 65),
(49, 'NX-03', '', '', 1, 65),
(50, 'NX-04', '', '', 1, 65),
(51, 'NX-05', '', '', 1, 65),
(52, 'NX-06', '', '', 1, 65),
(53, 'NX-07', '', '', 1, 65),
(54, 'NX-08', '', '', 1, 65);

-- --------------------------------------------------------

--
-- Table structure for table `pricelist`
--

CREATE TABLE IF NOT EXISTS `pricelist` (
  `id` int(11) NOT NULL,
  `date` date NOT NULL,
  `unitpr` decimal(9,2) NOT NULL,
  `stmas_id` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=266 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `pricelist`
--

INSERT INTO `pricelist` (`id`, `date`, `unitpr`, `stmas_id`) VALUES
(261, '2017-02-07', '12.00', 21),
(262, '2017-02-07', '14.00', 22),
(263, '2017-02-07', '16.00', 23),
(264, '2017-02-07', '18.00', 24),
(265, '2017-02-07', '20.00', 25);

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
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `saleshistory`
--

INSERT INTO `saleshistory` (`id`, `saldat`, `mitbeg`, `mitend`, `salqty`, `salval`, `shift_id`, `nozzle_id`, `stmas_id`, `pricelist_id`, `salessummary_id`) VALUES
(30, '2017-02-07', '24.00', '26.00', '2.00', '32.00', 1, 51, 23, 263, 149),
(31, '2017-02-07', '20.00', '22.00', '2.00', '32.00', 1, 48, 23, 263, 149),
(32, '2017-02-07', '16.00', '18.00', '2.00', '32.00', 1, 52, 23, 263, 149),
(33, '2017-02-07', '12.00', '14.00', '2.00', '32.00', 1, 49, 23, 263, 149),
(34, '2017-02-07', '10.00', '12.00', '2.00', '32.00', 1, 53, 23, 263, 149),
(35, '2017-02-07', '22.00', '24.00', '2.00', '32.00', 1, 50, 23, 263, 149),
(36, '2017-02-07', '18.00', '20.00', '2.00', '32.00', 1, 54, 23, 263, 149),
(37, '2017-02-07', '14.00', '16.00', '2.00', '32.00', 1, 47, 23, 263, 149);

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
) ENGINE=InnoDB AUTO_INCREMENT=152 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `salessummary`
--

INSERT INTO `salessummary` (`id`, `saldat`, `dtest`, `dother`, `dothertxt`, `ddisc`, `purvat`, `shift_id`, `stmas_id`, `pricelist_id`, `shiftsales_id`) VALUES
(147, '2017-02-07', '0.00', '0.00', '', '0.00', '0.00', 1, 21, 261, 31),
(148, '2017-02-07', '0.00', '0.00', '', '0.00', '0.00', 1, 22, 262, 31),
(149, '2017-02-07', '0.00', '0.00', '', '0.00', '0.00', 1, 23, 263, 31),
(150, '2017-02-07', '0.00', '0.00', '', '0.00', '0.00', 1, 24, 264, 31),
(151, '2017-02-07', '0.00', '0.00', '', '0.00', '0.00', 1, 25, 265, 31);

-- --------------------------------------------------------

--
-- Table structure for table `section`
--

CREATE TABLE IF NOT EXISTS `section` (
  `id` int(11) NOT NULL,
  `name` varchar(20) NOT NULL,
  `begbal` decimal(14,2) NOT NULL,
  `tank_id` int(11) NOT NULL,
  `stmas_id` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=67 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `section`
--

INSERT INTO `section` (`id`, `name`, `begbal`, `tank_id`, `stmas_id`) VALUES
(58, 'S-01', '2000.00', 48, 24),
(59, 'S-02', '5500.00', 48, 25),
(65, 'S-01', '300.00', 52, 23),
(66, 'S-02', '2000.00', 52, 25);

-- --------------------------------------------------------

--
-- Table structure for table `settings`
--

CREATE TABLE IF NOT EXISTS `settings` (
  `id` int(11) NOT NULL,
  `express_data_path` text NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `settings`
--

INSERT INTO `settings` (`id`, `express_data_path`) VALUES
(1, 'TEST');

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
  `remark` varchar(50) DEFAULT NULL,
  `saiprefix` varchar(2) NOT NULL DEFAULT '',
  `shsprefix` varchar(2) NOT NULL DEFAULT '',
  `sivprefix` varchar(2) NOT NULL DEFAULT '',
  `paeprefix` varchar(2) NOT NULL DEFAULT '',
  `phpprefix` varchar(2) NOT NULL DEFAULT '',
  `prrprefix` varchar(2) NOT NULL DEFAULT ''
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `shift`
--

INSERT INTO `shift` (`id`, `name`, `description`, `starttime`, `endtime`, `remark`, `saiprefix`, `shsprefix`, `sivprefix`, `paeprefix`, `phpprefix`, `prrprefix`) VALUES
(1, 'ผลัด A', 'ผลัดเช้า', '06:00:00', '13:59:59', '', '', '', '', '', '', ''),
(2, 'ผลัด B', 'ผลัดบ่าย', '14:00:00', '21:59:59', '', '', '', '', 'AE', 'HP', ''),
(3, 'ผลัด C', 'ผลัดกลางคืน', '22:00:00', '05:59:59', '', '', '', '', '', '', ''),
(4, 'ผลัด D', 'ผลัดพิเศษ', '01:02:03', '04:05:06', '', 'AI', 'HS', 'IV', 'AE', 'HP', 'RR');

-- --------------------------------------------------------

--
-- Table structure for table `shiftsales`
--

CREATE TABLE IF NOT EXISTS `shiftsales` (
  `id` int(11) NOT NULL,
  `saldat` date NOT NULL,
  `shift_id` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `shiftsales`
--

INSERT INTO `shiftsales` (`id`, `saldat`, `shift_id`) VALUES
(31, '2017-02-07', 1);

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
  `section_id` int(11) NOT NULL,
  `shift_id` int(11) NOT NULL
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
(25, 'คอควาย', 'ทดสอบ คอควาย', 'หมายเหตุ คอควาย'),
(26, '01-INTL-CL-600', 'ซีพียู อินเทล ซีลิลอน 600 MHz --', 'สินค้าชุดพิเศษ'),
(27, '01-INTL-P3-750', 'ซีพียู เพนเทียม ทรี 750 MHz --', ''),
(28, '02-ASUS-CUV4X', 'เมนบอร์ด เอซัส CUV4X-133 SOCKET-370 --', ''),
(29, 'SW-EXPRESS-S-T-1.0', 'โปรแกรมบัญชีเอ็กซ์เพรส เวอร์ชั่น 1.0 (เมนูไทย)', '');

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
) ENGINE=InnoDB AUTO_INCREMENT=53 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `tank`
--

INSERT INTO `tank` (`id`, `name`, `startdate`, `enddate`, `description`, `remark`, `isactive`) VALUES
(48, 'TANK-01', '2017-01-01', NULL, 'ทดสอบแท๊งค์ 1 7,500 ลิตร', '...', 1),
(52, 'TANK-02', '2017-02-07', NULL, 'ทดสอบ', '', 1);

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
  ADD UNIQUE KEY `unq-aptrn` (`vatnum`,`vatdat`),
  ADD KEY `ndx-aptrn-apmas_id` (`apmas_id`),
  ADD KEY `ndx-aptrn-shift_id` (`shift_id`);

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
  ADD KEY `ndx-shiftsales-shift_id` (`shift_id`);

--
-- Indexes for table `stcrd`
--
ALTER TABLE `stcrd`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ndx-stcrd-aptrn_id` (`aptrn_id`),
  ADD KEY `ndx-stcrd-section_id` (`section_id`),
  ADD KEY `ndx-stcrd-shift_id` (`shift_id`);

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=55;
--
-- AUTO_INCREMENT for table `pricelist`
--
ALTER TABLE `pricelist`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=266;
--
-- AUTO_INCREMENT for table `saleshistory`
--
ALTER TABLE `saleshistory`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=38;
--
-- AUTO_INCREMENT for table `salessummary`
--
ALTER TABLE `salessummary`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=152;
--
-- AUTO_INCREMENT for table `section`
--
ALTER TABLE `section`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=67;
--
-- AUTO_INCREMENT for table `settings`
--
ALTER TABLE `settings`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `shift`
--
ALTER TABLE `shift`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=10;
--
-- AUTO_INCREMENT for table `shiftsales`
--
ALTER TABLE `shiftsales`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=32;
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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=53;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `aptrn`
--
ALTER TABLE `aptrn`
  ADD CONSTRAINT `fk-aptrn-apmas_id` FOREIGN KEY (`apmas_id`) REFERENCES `apmas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk-aptrn-shift_id` FOREIGN KEY (`shift_id`) REFERENCES `shift` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

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
  ADD CONSTRAINT `fk-stcrd-section_id` FOREIGN KEY (`section_id`) REFERENCES `section` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk-stcrd-shift_id` FOREIGN KEY (`shift_id`) REFERENCES `shift` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
