-- phpMyAdmin SQL Dump
-- version 4.4.8
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Mar 09, 2017 at 10:26 AM
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
  `qty` decimal(15,2) NOT NULL DEFAULT '0.00',
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `pricelist`
--

CREATE TABLE IF NOT EXISTS `pricelist` (
  `id` int(11) NOT NULL,
  `date` date NOT NULL,
  `unitpr` decimal(9,2) NOT NULL,
  `stmas_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `settings`
--

CREATE TABLE IF NOT EXISTS `settings` (
  `id` int(11) NOT NULL,
  `express_data_path` text NOT NULL,
  `orgname` varchar(60) NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `pricelist`
--
ALTER TABLE `pricelist`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `saleshistory`
--
ALTER TABLE `saleshistory`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `salessummary`
--
ALTER TABLE `salessummary`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `section`
--
ALTER TABLE `section`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `settings`
--
ALTER TABLE `settings`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `shift`
--
ALTER TABLE `shift`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `shiftsales`
--
ALTER TABLE `shiftsales`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `shiftsttak`
--
ALTER TABLE `shiftsttak`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `stmas`
--
ALTER TABLE `stmas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `tank`
--
ALTER TABLE `tank`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
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
