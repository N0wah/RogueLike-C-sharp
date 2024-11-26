-- MySQL dump 10.16  Distrib 10.1.48-MariaDB, for debian-linux-gnu (x86_64)
--
-- Host: localhost    Database: db
-- ------------------------------------------------------
-- Server version	10.1.48-MariaDB-0+deb9u2

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Character`
--

DROP TABLE IF EXISTS `Character`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Character` (
  `Id` tinyint(4) DEFAULT NULL,
  `Name` varchar(9) DEFAULT NULL,
  `Health_Point` tinyint(4) DEFAULT NULL,
  `Attack_Point` tinyint(4) DEFAULT NULL,
  `Defense_Point` tinyint(4) DEFAULT NULL,
  `Critical_Chance` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Character`
--

LOCK TABLES `Character` WRITE;
/*!40000 ALTER TABLE `Character` DISABLE KEYS */;
INSERT INTO `Character` VALUES (1,'Archer',10,20,5,15),(2,'Chevalier',20,10,15,5);
/*!40000 ALTER TABLE `Character` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ennemy`
--

DROP TABLE IF EXISTS `Ennemy`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ennemy` (
  `Id` tinyint(4) DEFAULT NULL,
  `Name` varchar(7) DEFAULT NULL,
  `Health_Point` smallint(6) DEFAULT NULL,
  `Attack_Point` tinyint(4) DEFAULT NULL,
  `Defense_Point` tinyint(4) DEFAULT NULL,
  `Critical_Chance` tinyint(4) DEFAULT NULL,
  `Gold_Value` smallint(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ennemy`
--

LOCK TABLES `Ennemy` WRITE;
/*!40000 ALTER TABLE `Ennemy` DISABLE KEYS */;
INSERT INTO `Ennemy` VALUES (1,'Boss',100,30,50,2,100),(2,'Wolf',20,5,10,2,20),(3,'Gobelin',15,10,5,4,50),(4,'Orc',30,10,20,3,75);
/*!40000 ALTER TABLE `Ennemy` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Object`
--

DROP TABLE IF EXISTS `Object`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Object` (
  `Id` tinyint(4) DEFAULT NULL,
  `Name` varchar(6) DEFAULT NULL,
  `Stats` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Object`
--

LOCK TABLES `Object` WRITE;
/*!40000 ALTER TABLE `Object` DISABLE KEYS */;
INSERT INTO `Object` VALUES (1,'De_6',6),(2,'De_10',10),(3,'De_20',20),(4,'Potion',10);
/*!40000 ALTER TABLE `Object` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Weapons`
--

DROP TABLE IF EXISTS `Weapons`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Weapons` (
  `Id` tinyint(4) DEFAULT NULL,
  `Name` varchar(8) DEFAULT NULL,
  `Damage` tinyint(4) DEFAULT NULL,
  `Critical_Chance` tinyint(4) DEFAULT NULL,
  `Values` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Weapons`
--

LOCK TABLES `Weapons` WRITE;
/*!40000 ALTER TABLE `Weapons` DISABLE KEYS */;
INSERT INTO `Weapons` VALUES (1,'Fist',1,1,0),(2,'Crossbow',10,2,10),(3,'Arc',8,3,8),(4,'Sword',13,1,8),(5,'Dagger',10,5,12);
/*!40000 ALTER TABLE `Weapons` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sqlite_sequence`
--

DROP TABLE IF EXISTS `sqlite_sequence`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sqlite_sequence` (
  `name` varchar(9) DEFAULT NULL,
  `seq` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sqlite_sequence`
--

LOCK TABLES `sqlite_sequence` WRITE;
/*!40000 ALTER TABLE `sqlite_sequence` DISABLE KEYS */;
INSERT INTO `sqlite_sequence` VALUES ('Character',2),('Object',4),('Ennemy',4),('Weapons',5);
/*!40000 ALTER TABLE `sqlite_sequence` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-04-30 16:42:44
