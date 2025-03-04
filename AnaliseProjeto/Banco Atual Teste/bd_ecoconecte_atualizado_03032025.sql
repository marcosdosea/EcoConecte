CREATE DATABASE  IF NOT EXISTS `ecoconecte` /*!40100 DEFAULT CHARACTER SET utf8mb3 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `ecoconecte`;
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: ecoconecte
-- ------------------------------------------------------
-- Server version	8.0.39

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

--
-- Table structure for table `agendamento`
--

DROP TABLE IF EXISTS `agendamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `agendamento` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `data` datetime NOT NULL,
  `cep` varchar(15) NOT NULL,
  `logradouro` varchar(45) NOT NULL,
  `numero` varchar(20) NOT NULL,
  `idPessoa` int unsigned NOT NULL,
  `bairro` varchar(45) NOT NULL,
  `cidade` varchar(45) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `status` enum('A','C') DEFAULT NULL COMMENT 'A - ATIVO\nC -CANCELADO',
  PRIMARY KEY (`id`),
  UNIQUE KEY `cep_UNIQUE` (`cep`),
  KEY `fk_Agendamento_Cidadao1_idx` (`idPessoa`),
  CONSTRAINT `fk_Agendamento_Cidadao1_idx` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`id`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `agendamento`
--

LOCK TABLES `agendamento` WRITE;
/*!40000 ALTER TABLE `agendamento` DISABLE KEYS */;
INSERT INTO `agendamento` VALUES (5,'2025-03-05 08:00:00','49500001','Rua A','100',2,'Centro','Cidade A','SE','A'),(6,'2025-03-06 09:30:00','49500002','Rua B','200',4,'Bairro B','Cidade B','SE','A'),(7,'2025-03-07 07:45:00','49500003','Rua C','300',2,'Centro','Cidade C','SE','A'),(8,'2025-03-08 10:15:00','49500004','Rua D','400',4,'Bairro D','Cidade D','SE','A'),(9,'2025-03-09 11:00:00','49500005','Rua E','500',2,'Centro','Cidade E','SE','A'),(10,'2025-03-10 13:00:00','49500006','Rua F','600',4,'Bairro F','Cidade F','SE','A'),(11,'2025-03-11 15:30:00','49500007','Rua G','700',2,'Centro','Cidade G','SE','A'),(12,'2025-03-12 16:45:00','49500008','Rua H','800',4,'Bairro H','Cidade H','SE','A'),(13,'2025-03-13 18:00:00','49500009','Rua I','900',2,'Centro','Cidade I','SE','A'),(14,'2025-03-14 19:15:00','49500010','Rua J','1000',4,'Bairro J','Cidade J','SE','A');
/*!40000 ALTER TABLE `agendamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cooperativa`
--

DROP TABLE IF EXISTS `cooperativa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cooperativa` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  `inscricaoEstadual` varchar(45) NOT NULL,
  `inscricaoMunicipal` varchar(45) NOT NULL,
  `cnpj` varchar(45) NOT NULL,
  `cep` varchar(45) NOT NULL,
  `logradouro` varchar(45) DEFAULT NULL,
  `bairro` varchar(45) DEFAULT NULL,
  `numero` varchar(20) DEFAULT NULL,
  `telefone` varchar(11) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `idPessoaRepresentate` int unsigned NOT NULL,
  `status` enum('A','I') NOT NULL COMMENT 'A - ATIVO\nI - INATIVO',
  PRIMARY KEY (`id`,`status`),
  UNIQUE KEY `inscricaoEstadual_UNIQUE` (`inscricaoEstadual`),
  UNIQUE KEY `inscricaoMunicipal_UNIQUE` (`inscricaoMunicipal`),
  UNIQUE KEY `cnpj_UNIQUE` (`cnpj`),
  KEY `nome_idx` (`nome`),
  KEY `fk_Cooperativa_Pessoa1_idx` (`idPessoaRepresentate`),
  CONSTRAINT `fk_Cooperativa_Pessoa1` FOREIGN KEY (`idPessoaRepresentate`) REFERENCES `pessoa` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cooperativa`
--

LOCK TABLES `cooperativa` WRITE;
/*!40000 ALTER TABLE `cooperativa` DISABLE KEYS */;
INSERT INTO `cooperativa` VALUES (1,'Cooperativa ReciclaMais','111111111','333333333','08658997000120','49517000','Rua A','Centro','30','79999020585','luizpinhao@gmail.com',2,'A');
/*!40000 ALTER TABLE `cooperativa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `noticia`
--

DROP TABLE IF EXISTS `noticia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `noticia` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `titulo` varchar(100) NOT NULL,
  `conteudo` varchar(2000) NOT NULL,
  `idCooperativa` int unsigned NOT NULL,
  `data` datetime NOT NULL,
  PRIMARY KEY (`id`),
  KEY `titulo_idx` (`titulo`),
  KEY `fk_Noticia_Cooperativa1_idx` (`idCooperativa`),
  CONSTRAINT `fk_Noticia_Cooperativa1` FOREIGN KEY (`idCooperativa`) REFERENCES `cooperativa` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `noticia`
--

LOCK TABLES `noticia` WRITE;
/*!40000 ALTER TABLE `noticia` DISABLE KEYS */;
INSERT INTO `noticia` VALUES (1,'teste','teste',1,'2025-03-03 00:00:00'),(2,'Nova iniciativa sustentável','Lançamos um novo programa de reciclagem na cidade.',1,'2025-03-01 00:00:00'),(3,'Coleta seletiva expandida','Agora atendemos mais bairros com coleta seletiva.',1,'2025-02-28 00:00:00'),(4,'Feira de sustentabilidade','Evento reúne especialistas para discutir reciclagem.',1,'2025-02-20 00:00:00'),(5,'Projeto EcoJovem','Educação ambiental para jovens nas escolas.',1,'2025-02-18 00:00:00'),(6,'Aplicativo de coleta','Novo app facilita solicitação de coleta domiciliar.',1,'2025-02-15 00:00:00'),(7,'Parceria com ONGs','Apoio de ONGs fortalece ações ecológicas.',1,'2025-02-10 00:00:00'),(8,'Incentivo fiscal','Empresas podem obter incentivos por reciclagem.',1,'2025-02-05 00:00:00'),(9,'Redução de resíduos','Meta de reduzir 30% dos resíduos até 2030.',1,'2025-02-01 00:00:00'),(10,'Reciclagem de eletrônicos','Pontos de coleta para eletrônicos criados.',1,'2025-01-25 00:00:00'),(11,'Nova legislação ambiental','Regras mais rígidas para o descarte de lixo.',1,'2025-01-15 00:00:00');
/*!40000 ALTER TABLE `noticia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orientacoes`
--

DROP TABLE IF EXISTS `orientacoes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orientacoes` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `titulo` varchar(100) NOT NULL,
  `descricao` varchar(2000) NOT NULL,
  `idCooperativa` int unsigned NOT NULL,
  PRIMARY KEY (`id`),
  KEY `titulo_idx` (`titulo`),
  KEY `fk_Orientacoes_Cooperativa1_idx` (`idCooperativa`),
  CONSTRAINT `fk_Orientacoes_Cooperativa1` FOREIGN KEY (`idCooperativa`) REFERENCES `cooperativa` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orientacoes`
--

LOCK TABLES `orientacoes` WRITE;
/*!40000 ALTER TABLE `orientacoes` DISABLE KEYS */;
INSERT INTO `orientacoes` VALUES (1,'Como separar o lixo','Dicas para separar resíduos corretamente.',1),(2,'Benefícios da reciclagem','Vantagens econômicas e ambientais.',1),(3,'Coleta seletiva','Saiba como participar do programa.',1),(4,'Reutilização criativa','Ideias para reaproveitar materiais.',1),(5,'Descarte de eletrônicos','Onde e como descartar dispositivos antigos.',1),(6,'Compostagem doméstica','Transforme resíduos orgânicos em adubo.',1),(7,'Ecopontos','Locais de descarte correto de materiais.',1),(8,'Redução de plástico','Alternativas sustentáveis ao plástico.',1),(9,'Economia circular','Como contribuir para um modelo sustentável.',1),(10,'Impacto ambiental','Entenda as consequências do desperdício.',1);
/*!40000 ALTER TABLE `orientacoes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pessoa`
--

DROP TABLE IF EXISTS `pessoa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pessoa` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `cpf` varchar(45) NOT NULL,
  `nome` varchar(45) NOT NULL,
  `telefone` varchar(11) DEFAULT NULL,
  `logradouro` varchar(45) DEFAULT NULL,
  `bairro` varchar(25) DEFAULT NULL,
  `numero` varchar(20) DEFAULT NULL,
  `cidade` varchar(45) DEFAULT NULL,
  `estado` varchar(2) DEFAULT NULL,
  `idCooperativa` int unsigned DEFAULT NULL,
  `status` enum('A','I') NOT NULL COMMENT 'A - ATIVO\nI - INATIVO',
  PRIMARY KEY (`id`),
  UNIQUE KEY `cpf_UNIQUE` (`cpf`),
  KEY `nome_idx` (`nome`),
  KEY `fk_Pessoa_Cooperativa1_idx` (`idCooperativa`),
  CONSTRAINT `fk_Pessoa_Cooperativa1` FOREIGN KEY (`idCooperativa`) REFERENCES `cooperativa` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pessoa`
--

LOCK TABLES `pessoa` WRITE;
/*!40000 ALTER TABLE `pessoa` DISABLE KEYS */;
INSERT INTO `pessoa` VALUES (2,'01346906564','Luiz Souza Neri','79999020585','Av Antônio Torres','Conjunto Josefa Vilma','55','Pinhao','SE',NULL,'A'),(4,'01346906502','Carol','79999020585','Rua C','Centro','11','Itabaiana','SE',1,'A');
/*!40000 ALTER TABLE `pessoa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rotinadecoleta`
--

DROP TABLE IF EXISTS `rotinadecoleta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rotinadecoleta` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `cep` varchar(45) NOT NULL,
  `logradouro` varchar(45) NOT NULL,
  `numero` int NOT NULL,
  `diaColeta` datetime NOT NULL,
  `horarioInicio` datetime DEFAULT NULL,
  `horarioTermino` datetime DEFAULT NULL,
  `idCooperativa` int unsigned NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_RotinaDeColeta_Cooperativa1_idx` (`idCooperativa`),
  CONSTRAINT `fk_RotinaDeColeta_Cooperativa1` FOREIGN KEY (`idCooperativa`) REFERENCES `cooperativa` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rotinadecoleta`
--

LOCK TABLES `rotinadecoleta` WRITE;
/*!40000 ALTER TABLE `rotinadecoleta` DISABLE KEYS */;
INSERT INTO `rotinadecoleta` VALUES (2,'49517000','Rua A',100,'2025-03-25 00:00:00','2025-03-25 10:50:00','2025-03-25 12:50:00',1),(3,'49518000','Rua B',101,'2025-03-26 00:00:00','2025-03-26 08:00:00','2025-03-26 10:00:00',1),(4,'49519000','Rua C',102,'2025-03-27 00:00:00','2025-03-27 09:30:00','2025-03-27 11:30:00',1),(5,'49520000','Rua D',103,'2025-03-28 00:00:00','2025-03-28 07:00:00','2025-03-28 09:00:00',1),(6,'49521000','Rua E',104,'2025-03-29 00:00:00','2025-03-29 14:00:00','2025-03-29 16:00:00',1),(7,'49522000','Rua F',105,'2025-03-30 00:00:00','2025-03-30 15:30:00','2025-03-30 17:30:00',1),(8,'49523000','Rua G',106,'2025-03-31 00:00:00','2025-03-31 06:45:00','2025-03-31 08:45:00',1),(9,'49524000','Rua H',107,'2025-04-01 00:00:00','2025-04-01 13:20:00','2025-04-01 15:20:00',1),(10,'49525000','Rua I',108,'2025-04-02 00:00:00','2025-04-02 11:10:00','2025-04-02 13:10:00',1),(11,'49526000','Rua J',109,'2025-04-03 00:00:00','2025-04-03 12:40:00','2025-04-03 14:40:00',1);
/*!40000 ALTER TABLE `rotinadecoleta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vendamaterial`
--

DROP TABLE IF EXISTS `vendamaterial`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vendamaterial` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `tipo` enum('M','P') NOT NULL,
  `valor` decimal(10,2) NOT NULL,
  `quantidade` decimal(10,2) NOT NULL,
  `data` datetime NOT NULL,
  `idCooperativa` int unsigned NOT NULL,
  `idPessoa` int unsigned NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_VendaMaterial_Cooperativa1_idx` (`idCooperativa`),
  KEY `fk_VendaMaterial_Pessoa1_idx` (`idPessoa`),
  CONSTRAINT `fk_VendaMaterial_Cooperativa1` FOREIGN KEY (`idCooperativa`) REFERENCES `cooperativa` (`id`),
  CONSTRAINT `fk_VendaMaterial_Pessoa1` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vendamaterial`
--

LOCK TABLES `vendamaterial` WRITE;
/*!40000 ALTER TABLE `vendamaterial` DISABLE KEYS */;
INSERT INTO `vendamaterial` VALUES (2,'M',150.00,20.00,'2025-03-01 10:30:00',1,2),(3,'P',75.50,15.00,'2025-02-28 14:20:00',1,4),(4,'M',200.00,30.00,'2025-02-25 09:45:00',1,2),(5,'P',50.00,10.00,'2025-02-22 16:00:00',1,4),(6,'M',180.00,25.00,'2025-02-20 11:15:00',1,2),(7,'P',90.00,18.00,'2025-02-18 08:40:00',1,4),(8,'M',220.00,35.00,'2025-02-15 13:55:00',1,2),(9,'P',60.00,12.00,'2025-02-10 17:30:00',1,4),(10,'M',140.00,22.00,'2025-02-05 12:10:00',1,2),(11,'P',85.00,16.00,'2025-02-01 09:00:00',1,4);
/*!40000 ALTER TABLE `vendamaterial` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-03-03 22:57:19
