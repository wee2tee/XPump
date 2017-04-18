-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Apr 18, 2017 at 12:02 PM
-- Server version: 10.1.19-MariaDB
-- PHP Version: 5.6.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `xpump`
--

-- --------------------------------------------------------

--
-- Table structure for table `dayend`
--

CREATE TABLE `dayend` (
  `id` int(11) NOT NULL,
  `saldat` date NOT NULL,
  `rcvqty` decimal(14,2) NOT NULL,
  `salqty` decimal(14,2) NOT NULL,
  `dothercause_id` int(11) DEFAULT NULL,
  `dother` decimal(14,2) NOT NULL,
  `difqty` decimal(14,2) NOT NULL,
  `stmas_id` int(11) NOT NULL,
  `creby` varchar(20) NOT NULL DEFAULT '',
  `cretime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `chgby` varchar(20) DEFAULT NULL,
  `chgtime` datetime DEFAULT NULL,
  `apprby` varchar(20) DEFAULT NULL,
  `apprtime` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `daysttak`
--

CREATE TABLE `daysttak` (
  `id` int(11) NOT NULL,
  `qty` decimal(15,2) NOT NULL DEFAULT '0.00',
  `dayend_id` int(11) NOT NULL,
  `section_id` int(11) NOT NULL,
  `creby` varchar(20) NOT NULL DEFAULT '',
  `cretime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `chgby` varchar(20) DEFAULT NULL,
  `chgtime` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `dbver`
--

CREATE TABLE `dbver` (
  `id` int(7) NOT NULL,
  `version` varchar(15) NOT NULL DEFAULT '',
  `cretime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `chgtime` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `dbver`
--

INSERT INTO `dbver` (`id`, `version`, `cretime`, `chgtime`) VALUES
(1, '1.0.0.0', '2017-04-18 09:45:55', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `istab`
--

CREATE TABLE `istab` (
  `id` int(11) NOT NULL,
  `tabtyp` varchar(2) NOT NULL DEFAULT '' COMMENT '01 = deduct cause',
  `typcod` varchar(4) NOT NULL DEFAULT '',
  `shortnam` varchar(15) DEFAULT NULL,
  `shortnam2` varchar(15) DEFAULT NULL,
  `typdes` varchar(50) DEFAULT NULL,
  `typdes2` varchar(50) DEFAULT NULL,
  `creby` varchar(20) NOT NULL DEFAULT '',
  `cretime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `chgby` varchar(20) DEFAULT NULL,
  `chgtime` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `nozzle`
--

CREATE TABLE `nozzle` (
  `id` int(11) NOT NULL,
  `name` varchar(20) NOT NULL,
  `description` varchar(50) DEFAULT NULL,
  `remark` varchar(50) DEFAULT NULL,
  `isactive` tinyint(1) NOT NULL DEFAULT '1',
  `section_id` int(11) NOT NULL,
  `creby` varchar(20) NOT NULL DEFAULT '',
  `cretime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `chgby` varchar(20) DEFAULT NULL,
  `chgtime` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `pricelist`
--

CREATE TABLE `pricelist` (
  `id` int(11) NOT NULL,
  `date` date NOT NULL,
  `unitpr` decimal(9,2) NOT NULL,
  `stmas_id` int(11) NOT NULL,
  `creby` varchar(20) NOT NULL DEFAULT '',
  `cretime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `chgby` varchar(20) DEFAULT NULL,
  `chgtime` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `saleshistory`
--

CREATE TABLE `saleshistory` (
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
  `salessummary_id` int(11) NOT NULL,
  `creby` varchar(20) NOT NULL DEFAULT '',
  `cretime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `chgby` varchar(20) DEFAULT NULL,
  `chgtime` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `salessummary`
--

CREATE TABLE `salessummary` (
  `id` int(11) NOT NULL,
  `saldat` date NOT NULL,
  `dtest` decimal(14,2) NOT NULL,
  `dothercause_id` int(11) DEFAULT NULL,
  `dother` decimal(14,2) NOT NULL,
  `ddisc` decimal(14,2) NOT NULL,
  `purvat` decimal(14,2) NOT NULL,
  `shift_id` int(11) NOT NULL,
  `stmas_id` int(11) NOT NULL,
  `pricelist_id` int(11) NOT NULL,
  `shiftsales_id` int(11) NOT NULL,
  `creby` varchar(20) NOT NULL DEFAULT '',
  `cretime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `chgby` varchar(20) DEFAULT NULL,
  `chgtime` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `section`
--

CREATE TABLE `section` (
  `id` int(11) NOT NULL,
  `name` varchar(20) NOT NULL,
  `loccod` varchar(4) NOT NULL DEFAULT '',
  `capacity` decimal(14,2) NOT NULL DEFAULT '0.00',
  `begacc` decimal(14,2) NOT NULL,
  `begtak` decimal(14,2) NOT NULL,
  `begdif` decimal(14,2) NOT NULL,
  `tank_id` int(11) NOT NULL,
  `stmas_id` int(11) NOT NULL,
  `creby` varchar(20) NOT NULL DEFAULT '',
  `cretime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `chgby` varchar(20) DEFAULT NULL,
  `chgtime` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `settings`
--

CREATE TABLE `settings` (
  `id` int(11) NOT NULL,
  `orgname` varchar(60) NOT NULL DEFAULT '',
  `shiftprintmet` varchar(1) NOT NULL DEFAULT '0' COMMENT '0 = not stricted, 1 = printed before authorize, 2 = authorized before print',
  `shiftauthlev` varchar(1) NOT NULL DEFAULT '',
  `dayprintmet` varchar(1) NOT NULL DEFAULT '0' COMMENT '0 = not stricted, 1 = printed before authorize, 2 = authorized before print',
  `dayauthlev` varchar(1) NOT NULL DEFAULT '',
  `chgby` varchar(20) DEFAULT NULL,
  `chgtime` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `settings`
--

INSERT INTO `settings` (`id`, `orgname`, `shiftprintmet`, `shiftauthlev`, `dayprintmet`, `dayauthlev`, `chgby`, `chgtime`) VALUES
(1, '', '0', '', '0', '', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `shift`
--

CREATE TABLE `shift` (
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
  `prrprefix` varchar(2) NOT NULL DEFAULT '',
  `creby` varchar(20) NOT NULL DEFAULT '',
  `cretime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `chgby` varchar(20) DEFAULT NULL,
  `chgtime` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `shiftsales`
--

CREATE TABLE `shiftsales` (
  `id` int(11) NOT NULL,
  `saldat` date NOT NULL,
  `closed` tinyint(1) NOT NULL DEFAULT '0',
  `shift_id` int(11) NOT NULL,
  `creby` varchar(20) NOT NULL DEFAULT '',
  `cretime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `chgby` varchar(20) DEFAULT NULL,
  `chgtime` datetime DEFAULT NULL,
  `apprby` varchar(20) DEFAULT NULL,
  `apprtime` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `shiftsttak`
--

CREATE TABLE `shiftsttak` (
  `id` int(11) NOT NULL,
  `takdat` date NOT NULL,
  `qty` decimal(15,2) NOT NULL DEFAULT '-1.00',
  `shiftsales_id` int(11) NOT NULL,
  `section_id` int(11) NOT NULL,
  `creby` varchar(20) NOT NULL DEFAULT '',
  `cretime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `chgby` varchar(20) DEFAULT NULL,
  `chgtime` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `stmas`
--

CREATE TABLE `stmas` (
  `id` int(11) NOT NULL,
  `name` varchar(20) NOT NULL,
  `description` varchar(50) DEFAULT NULL,
  `remark` varchar(50) DEFAULT NULL,
  `creby` varchar(20) NOT NULL DEFAULT '',
  `cretime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `chgby` varchar(20) DEFAULT NULL,
  `chgtime` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `tank`
--

CREATE TABLE `tank` (
  `id` int(11) NOT NULL,
  `name` varchar(20) NOT NULL,
  `startdate` date NOT NULL,
  `enddate` date DEFAULT NULL,
  `description` varchar(50) DEFAULT NULL,
  `remark` varchar(50) DEFAULT NULL,
  `isactive` tinyint(1) NOT NULL DEFAULT '1',
  `creby` varchar(20) NOT NULL DEFAULT '',
  `cretime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `chgby` varchar(20) DEFAULT NULL,
  `chgtime` datetime DEFAULT NULL,
  `tanksetup_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `tanksetup`
--

CREATE TABLE `tanksetup` (
  `id` int(11) NOT NULL,
  `startdate` date NOT NULL,
  `creby` varchar(20) NOT NULL DEFAULT '',
  `cretime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `chgby` varchar(20) DEFAULT NULL,
  `chgtime` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `dayend`
--
ALTER TABLE `dayend`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unq - dayend - saldat` (`saldat`,`stmas_id`),
  ADD KEY `ndx - dayend - stmas_id` (`stmas_id`),
  ADD KEY `ndx-dayend-dothercause_id` (`dothercause_id`);

--
-- Indexes for table `daysttak`
--
ALTER TABLE `daysttak`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ndx - daysttak - section_id` (`section_id`),
  ADD KEY `ndx - daysttak - dayend_id` (`dayend_id`);

--
-- Indexes for table `dbver`
--
ALTER TABLE `dbver`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `istab`
--
ALTER TABLE `istab`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unq - istab` (`tabtyp`,`typcod`);

--
-- Indexes for table `nozzle`
--
ALTER TABLE `nozzle`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unq - nozzle - name` (`name`,`section_id`),
  ADD KEY `ndx - nozzle - section_id` (`section_id`);

--
-- Indexes for table `pricelist`
--
ALTER TABLE `pricelist`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ndx - pricelist - stmas_id` (`stmas_id`);

--
-- Indexes for table `saleshistory`
--
ALTER TABLE `saleshistory`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unq - saleshistory` (`stmas_id`,`saldat`,`shift_id`,`nozzle_id`),
  ADD KEY `ndx - saleshistory - shift_id` (`shift_id`),
  ADD KEY `ndx - saleshistory_nozzle_id` (`nozzle_id`),
  ADD KEY `ndx - saleshistory - stmas_id` (`stmas_id`),
  ADD KEY `ndx - saleshistory - pricelist_id` (`pricelist_id`),
  ADD KEY `ndx - saleshistory - salessummary_id` (`salessummary_id`);

--
-- Indexes for table `salessummary`
--
ALTER TABLE `salessummary`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unq - salessummary` (`stmas_id`,`saldat`,`shift_id`,`shiftsales_id`),
  ADD KEY `ndx - salessummary - shift_id` (`shift_id`),
  ADD KEY `ndx - salessummary - stmas_id` (`stmas_id`),
  ADD KEY `ndx - salessummary - pricelist_id` (`pricelist_id`),
  ADD KEY `ndx - salessummary - shiftsales_id` (`shiftsales_id`),
  ADD KEY `ndx-salessummary-dothercause_id` (`dothercause_id`);

--
-- Indexes for table `section`
--
ALTER TABLE `section`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ndx - section - tank_id` (`tank_id`),
  ADD KEY `ndx - section - stmas_id` (`stmas_id`);

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
  ADD UNIQUE KEY `unq - shift - name` (`name`);

--
-- Indexes for table `shiftsales`
--
ALTER TABLE `shiftsales`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unq - shiftsales` (`saldat`,`shift_id`),
  ADD KEY `ndx - shiftsales - shift_id` (`shift_id`);

--
-- Indexes for table `shiftsttak`
--
ALTER TABLE `shiftsttak`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unq - sttak` (`shiftsales_id`,`section_id`),
  ADD KEY `ndx - sttak - section_id` (`section_id`),
  ADD KEY `ndx - sttak - shiftsales_id` (`shiftsales_id`);

--
-- Indexes for table `stmas`
--
ALTER TABLE `stmas`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unq - stmas - name` (`name`);

--
-- Indexes for table `tank`
--
ALTER TABLE `tank`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unq - tank - name` (`name`),
  ADD KEY `ndx-tank-tanksetup_id` (`tanksetup_id`);

--
-- Indexes for table `tanksetup`
--
ALTER TABLE `tanksetup`
  ADD PRIMARY KEY (`id`);

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
-- AUTO_INCREMENT for table `dbver`
--
ALTER TABLE `dbver`
  MODIFY `id` int(7) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `istab`
--
ALTER TABLE `istab`
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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
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
-- AUTO_INCREMENT for table `tanksetup`
--
ALTER TABLE `tanksetup`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `dayend`
--
ALTER TABLE `dayend`
  ADD CONSTRAINT `fk - dayend - stmas_id` FOREIGN KEY (`stmas_id`) REFERENCES `stmas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk-dayend-dothercause_id` FOREIGN KEY (`dothercause_id`) REFERENCES `istab` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `daysttak`
--
ALTER TABLE `daysttak`
  ADD CONSTRAINT `fk - daysttak - dayend_id` FOREIGN KEY (`dayend_id`) REFERENCES `dayend` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk - daysttak - section_id` FOREIGN KEY (`section_id`) REFERENCES `section` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `nozzle`
--
ALTER TABLE `nozzle`
  ADD CONSTRAINT `fk - nozzle - section_id` FOREIGN KEY (`section_id`) REFERENCES `section` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `pricelist`
--
ALTER TABLE `pricelist`
  ADD CONSTRAINT `fk - pricelist - stmas_id` FOREIGN KEY (`stmas_id`) REFERENCES `stmas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `saleshistory`
--
ALTER TABLE `saleshistory`
  ADD CONSTRAINT `fk - saleshistory - nozzle_id` FOREIGN KEY (`nozzle_id`) REFERENCES `nozzle` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk - saleshistory - pricelist_id` FOREIGN KEY (`pricelist_id`) REFERENCES `pricelist` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk - saleshistory - salessummary_id` FOREIGN KEY (`salessummary_id`) REFERENCES `salessummary` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk - saleshistory - shift_id` FOREIGN KEY (`shift_id`) REFERENCES `shift` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk - saleshistory - stmas_id` FOREIGN KEY (`stmas_id`) REFERENCES `stmas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `salessummary`
--
ALTER TABLE `salessummary`
  ADD CONSTRAINT `fk - salessummary - pricelist_id` FOREIGN KEY (`pricelist_id`) REFERENCES `pricelist` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk - salessummary - shift_id` FOREIGN KEY (`shift_id`) REFERENCES `shift` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk - salessummary - shiftsales_id` FOREIGN KEY (`shiftsales_id`) REFERENCES `shiftsales` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk - salessummary - stmas_id` FOREIGN KEY (`stmas_id`) REFERENCES `stmas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk-salessummary-dothercause_id` FOREIGN KEY (`dothercause_id`) REFERENCES `istab` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `section`
--
ALTER TABLE `section`
  ADD CONSTRAINT `fk - section - stmas_id` FOREIGN KEY (`stmas_id`) REFERENCES `stmas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk - section - tank_id` FOREIGN KEY (`tank_id`) REFERENCES `tank` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `shiftsales`
--
ALTER TABLE `shiftsales`
  ADD CONSTRAINT `fk - shiftsales - shift_id` FOREIGN KEY (`shift_id`) REFERENCES `shift` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `shiftsttak`
--
ALTER TABLE `shiftsttak`
  ADD CONSTRAINT `fk - sttak - section_id` FOREIGN KEY (`section_id`) REFERENCES `section` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk - sttak - shiftsales_id` FOREIGN KEY (`shiftsales_id`) REFERENCES `shiftsales` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `tank`
--
ALTER TABLE `tank`
  ADD CONSTRAINT `fk-tank-tanksetup_id` FOREIGN KEY (`tanksetup_id`) REFERENCES `tanksetup` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
