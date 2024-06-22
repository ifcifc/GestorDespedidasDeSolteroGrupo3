CREATE DATABASE "gestorevento";
USE `gestorevento`;
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: mysql-gestoreventos-grupo3-gestoreventos.g.aivencloud.com    Database: gestorevento
-- ------------------------------------------------------
-- Server version	8.0.30

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
SET @MYSQLDUMP_TEMP_LOG_BIN = @@SESSION.SQL_LOG_BIN;


-- Table structure for table `EstadosEventos`
--

DROP TABLE IF EXISTS `EstadosEventos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `EstadosEventos` (
  `IdEstadoEvento` int NOT NULL AUTO_INCREMENT,
  `Descripcion` varchar(60) NOT NULL,
  `Borrado` bit(1) NOT NULL DEFAULT b'0',
  PRIMARY KEY (`IdEstadoEvento`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EstadosEventos`
--

LOCK TABLES `EstadosEventos` WRITE;
/*!40000 ALTER TABLE `EstadosEventos` DISABLE KEYS */;
INSERT INTO `EstadosEventos` VALUES (1,'Esperando Revisión',_binary '\0'),(2,'Aceptado',_binary '\0'),(3,'Rechazado',_binary '\0'),(4,'Finalizado',_binary '\0');
/*!40000 ALTER TABLE `EstadosEventos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Eventos`
--

DROP TABLE IF EXISTS `Eventos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Eventos` (
  `IdEvento` int NOT NULL AUTO_INCREMENT,
  `NombreEvento` varchar(45) NOT NULL,
  `FechaEvento` date NOT NULL,
  `CantidadPersonas` int NOT NULL,
  `IdTipoEvento` int NOT NULL,
  `IdPersonaAgasajada` int NOT NULL,
  `IdUsuario` int NOT NULL,
  `IdEstadoEvento` int NOT NULL DEFAULT '1',
  `Borrado` bit(1) NOT NULL DEFAULT b'0',
  PRIMARY KEY (`IdEvento`),
  KEY `eventos_idtipoevento_foreign` (`IdTipoEvento`),
  KEY `eventos_idusuario_foreign` (`IdUsuario`),
  KEY `eventos_idpersonaagasajada_foreign` (`IdPersonaAgasajada`),
  KEY `eventos_idestadoevento_foreign` (`IdEstadoEvento`),
  CONSTRAINT `eventos_idestadoevento_foreign` FOREIGN KEY (`IdEstadoEvento`) REFERENCES `EstadosEventos` (`IdEstadoEvento`),
  CONSTRAINT `eventos_idpersonaagasajada_foreign` FOREIGN KEY (`IdPersonaAgasajada`) REFERENCES `Personas` (`IdPersona`),
  CONSTRAINT `eventos_idtipoevento_foreign` FOREIGN KEY (`IdTipoEvento`) REFERENCES `TiposEventos` (`IdTipoEvento`),
  CONSTRAINT `eventos_idusuario_foreign` FOREIGN KEY (`IdUsuario`) REFERENCES `Usuarios` (`IdUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Eventos`
--

LOCK TABLES `Eventos` WRITE;
/*!40000 ALTER TABLE `Eventos` DISABLE KEYS */;
/*!40000 ALTER TABLE `Eventos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `EventosServicios`
--

DROP TABLE IF EXISTS `EventosServicios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `EventosServicios` (
  `idEventosServicios` int NOT NULL AUTO_INCREMENT,
  `IdEvento` int NOT NULL,
  `IdServicio` int NOT NULL,
  `Borrado` bit(1) NOT NULL DEFAULT b'0',
  PRIMARY KEY (`idEventosServicios`),
  KEY `eventosservicios_idevento_foreign` (`IdEvento`),
  KEY `eventosservicios_idservicio_foreign` (`IdServicio`),
  CONSTRAINT `eventosservicios_idevento_foreign` FOREIGN KEY (`IdEvento`) REFERENCES `Eventos` (`IdEvento`),
  CONSTRAINT `eventosservicios_idservicio_foreign` FOREIGN KEY (`IdServicio`) REFERENCES `Servicios` (`idServicio`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EventosServicios`
--

LOCK TABLES `EventosServicios` WRITE;
/*!40000 ALTER TABLE `EventosServicios` DISABLE KEYS */;
/*!40000 ALTER TABLE `EventosServicios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Localidades`
--

DROP TABLE IF EXISTS `Localidades`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Localidades` (
  `IdLocalidad` int NOT NULL AUTO_INCREMENT,
  `IdProvincia` int NOT NULL,
  `Nombre` varchar(45) NOT NULL,
  `CodigoArea` varchar(45) NOT NULL,
  `Borrado` bit(1) NOT NULL DEFAULT b'0',
  PRIMARY KEY (`IdLocalidad`),
  KEY `localidades_idprovincia_foreign` (`IdProvincia`),
  CONSTRAINT `localidades_idprovincia_foreign` FOREIGN KEY (`IdProvincia`) REFERENCES `Provincias` (`IdProvincia`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Localidades`
--

LOCK TABLES `Localidades` WRITE;
/*!40000 ALTER TABLE `Localidades` DISABLE KEYS */;
INSERT INTO `Localidades` VALUES (2,1,'Lumpa-landia','99',_binary '\0'),(3,1,'Narnia','858',_binary '\0'),(4,2,'Laputa','67',_binary '\0');
/*!40000 ALTER TABLE `Localidades` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Usuarios`
--
DROP TABLE IF EXISTS `Usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Usuarios` (
  `IdUsuario` int NOT NULL AUTO_INCREMENT,
  `GoogleIdentificador` varchar(60) NOT NULL,
  `NombreCompleto` varchar(120) DEFAULT 'DEFAULT NULL',
  `Nombre` varchar(45) DEFAULT 'DEFAULT NULL',
  `Apellido` varchar(45) DEFAULT 'DEFAULT NULL',
  `Email` varchar(60) NOT NULL,
  `Borrado` bit(1) NOT NULL DEFAULT b'0',
  PRIMARY KEY (`IdUsuario`),
  UNIQUE KEY `usuarios_googleidentificador_unique` (`GoogleIdentificador`),
  UNIQUE KEY `usuarios_email_unique` (`Email`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Usuarios`
--

LOCK TABLES `Usuarios` WRITE;
/*!40000 ALTER TABLE `Usuarios` DISABLE KEYS */;
INSERT INTO `Usuarios` VALUES (1,'103396162470837510228','ignacio castellanos','ignacio','castellanos','ignaciocastellanos040794@gmail.com',_binary '\0');
/*!40000 ALTER TABLE `Usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Personas`
--

DROP TABLE IF EXISTS `Personas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Personas` (
  `IdPersona` int NOT NULL AUTO_INCREMENT,
  `IdLocalidad` int NOT NULL,
  `IdUsuario` int NOT NULL,
  `Nombre` varchar(45) NOT NULL,
  `Apellido` varchar(45) NOT NULL,
  `Telefono` varchar(45) NOT NULL,
  `Email` varchar(45) DEFAULT 'DEFAULT NULL',
  `DireccionCalle` varchar(45) NOT NULL,
  `DireccionNumero` int NOT NULL,
  `DireccionPiso` varchar(45) DEFAULT 'DEFAULT NULL',
  `DireccionDepartamento` varchar(45) DEFAULT 'DEFAULT NULL',
  `Borrado` bit(1) NOT NULL DEFAULT b'0',
  PRIMARY KEY (`IdPersona`),
  KEY `personas_idlocalidad_foreign` (`IdLocalidad`),
  CONSTRAINT `personas_idlocalidad_foreign` FOREIGN KEY (`IdLocalidad`) REFERENCES `Localidades` (`IdLocalidad`),
  KEY `personas_idusuario_foreign` (`IdUsuario`),
  CONSTRAINT `personas_idusuario_foreign` FOREIGN KEY (`IdUsuario`) REFERENCES `Usuarios` (`IdUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Personas`
--

LOCK TABLES `Personas` WRITE;
/*!40000 ALTER TABLE `Personas` DISABLE KEYS */;
/*!40000 ALTER TABLE `Personas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Provincias`
--

DROP TABLE IF EXISTS `Provincias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Provincias` (
  `IdProvincia` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(60) NOT NULL,
  `Borrado` bit(1) NOT NULL DEFAULT b'0',
  PRIMARY KEY (`IdProvincia`),
  UNIQUE KEY `provincias_nombre_unique` (`Nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Provincias`
--

LOCK TABLES `Provincias` WRITE;
/*!40000 ALTER TABLE `Provincias` DISABLE KEYS */;
INSERT INTO `Provincias` VALUES (1,'Buenos Aires',_binary '\0'),(2,'Cordoba',_binary '\0');
/*!40000 ALTER TABLE `Provincias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Servicios`
--

DROP TABLE IF EXISTS `Servicios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Servicios` (
  `idServicio` int NOT NULL AUTO_INCREMENT,
  `Descripcion` varchar(45) NOT NULL,
  `PrecioServicio` decimal(10,5) NOT NULL,
  `Borrado` bit(1) NOT NULL DEFAULT b'0',
  PRIMARY KEY (`idServicio`),
  UNIQUE KEY `servicios_descripcion_unique` (`Descripcion`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Servicios`
--

LOCK TABLES `Servicios` WRITE;
/*!40000 ALTER TABLE `Servicios` DISABLE KEYS */;
INSERT INTO `Servicios` VALUES (1,'Enanos Furros',33.99000,_binary '\0'),(2,'Pelea de enanos',3.99000,_binary '\0'),(3,'Payasos Masoquistas',16.66000,_binary '\0'),(4,'Drags Masoquistas',4.99000,_binary '\0');
/*!40000 ALTER TABLE `Servicios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TiposEventos`
--

DROP TABLE IF EXISTS `TiposEventos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `TiposEventos` (
  `IdTipoEvento` int NOT NULL AUTO_INCREMENT,
  `Descripcion` varchar(45) NOT NULL,
  `Borrado` bit(1) NOT NULL DEFAULT b'0',
  PRIMARY KEY (`IdTipoEvento`),
  UNIQUE KEY `tiposeventos_descripcion_unique` (`Descripcion`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TiposEventos`
--

LOCK TABLES `TiposEventos` WRITE;
/*!40000 ALTER TABLE `TiposEventos` DISABLE KEYS */;
INSERT INTO `TiposEventos` VALUES (1,'Payasos Masoquistas',_binary ''),(2,'Despedida de Solteros',_binary '\0'),(3,'Despedida de Solteras',_binary '\0'),(4,'Despedida de Helicópteros Apache',_binary '\0');
/*!40000 ALTER TABLE `TiposEventos` ENABLE KEYS */;
UNLOCK TABLES;




/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-06-22 17:54:39
