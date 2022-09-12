CREATE DATABASE  IF NOT EXISTS `ProjetoPadraoNetCore` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `ProjetoPadraoNetCore`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: onthetable
-- ------------------------------------------------------
-- Server version	5.7.21-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tb_category`
--

DROP TABLE IF EXISTS `tb_category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_category` (
  `CategoryCode` varchar(100) NOT NULL,
  `CompanyCode` varchar(100) NOT NULL,
  `Name` varchar(100) NOT NULL,
  PRIMARY KEY (`CategoryCode`),
  KEY `fk_company_category_idx` (`CompanyCode`),
  CONSTRAINT `fk_company_category` FOREIGN KEY (`CompanyCode`) REFERENCES `tb_company` (`CompanyCode`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tb_customer`
--

DROP TABLE IF EXISTS `tb_customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_customer` (
  `CustomerCode` varchar(100) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Document` varchar(45) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Password` varchar(200) NOT NULL,
  PRIMARY KEY (`CustomerCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_customer`
--

LOCK TABLES `tb_customer` WRITE;
/*!40000 ALTER TABLE `tb_customer` DISABLE KEYS */;
INSERT INTO `tb_customer` VALUES ('7db67b93-aba5-44ed-abe5-8575fca85cd0','Teste','000.000.000-00','teste@teste.com.br','teste');
/*!40000 ALTER TABLE `tb_customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_company`
--

DROP TABLE IF EXISTS `tb_company`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_company` (
  `CompanyCode` varchar(100) NOT NULL,
  `Name` varchar(200) NOT NULL,
  `SmallName` varchar(45) NOT NULL,
  `LogoUrl` varchar(500) NOT NULL,
  `IsDefault` tinyint(4) NOT NULL DEFAULT '0',
  `IsActive` tinyint(4) NOT NULL DEFAULT '1',
  `PrimaryColor` varchar(10) NOT NULL DEFAULT '#2E00FF',
  `SecondColor` varchar(10) NOT NULL DEFAULT '#000000',
  `ThirdColor` varchar(10) NOT NULL DEFAULT '#FFFFFF',
  `CreateAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdateAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`CompanyCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;


--
-- Table structure for table `tb_image`
--

DROP TABLE IF EXISTS `tb_image`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_image` (
  `ImageCode` varchar(100) NOT NULL,
  `ProductCode` varchar(100) NOT NULL,
  `Name` varchar(20) NOT NULL,
  `Url` varchar(5000) NOT NULL,
  `isAR` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ImageCode`),
  KEY `fk_image_product_idx` (`ProductCode`),
  CONSTRAINT `fk_image_product` FOREIGN KEY (`ProductCode`) REFERENCES `tb_product` (`ProductCode`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tb_product`
--

DROP TABLE IF EXISTS `tb_product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_product` (
  `ProductCode` varchar(100) NOT NULL,
  `CategoryCode` varchar(100) NOT NULL,
  `CompanyCode` varchar(100) NOT NULL,
  `Name` varchar(200) NOT NULL,
  `Description` varchar(8000) NOT NULL,
  `Price` decimal(16,4) NOT NULL,
  `CreateAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdateAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ProductCode`),
  KEY `fk_category_idx` (`CategoryCode`),
  KEY `fk_tablishment_product_idx` (`CompanyCode`),
  CONSTRAINT `fk_category` FOREIGN KEY (`CategoryCode`) REFERENCES `tb_category` (`CategoryCode`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_company_product` FOREIGN KEY (`CompanyCode`) REFERENCES `tb_company` (`CompanyCode`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;



/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed
