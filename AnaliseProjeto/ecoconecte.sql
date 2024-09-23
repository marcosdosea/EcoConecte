-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`Cooperativa`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Cooperativa` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  `inscricaoEstadual` VARCHAR(45) NOT NULL,
  `inscricaoMunicipal` VARCHAR(45) NOT NULL,
  `cnpj` VARCHAR(45) NOT NULL,
  `cep` VARCHAR(45) NOT NULL,
  `logradouro` VARCHAR(45) NULL,
  `bairro` VARCHAR(45) NULL,
  `numero` VARCHAR(20) NULL,
  `telefone` VARCHAR(10) NULL,
  `email` VARCHAR(45) NULL,
  `idPessoaRepresentate` INT UNSIGNED NOT NULL,
  `status` ENUM('A', 'I') NOT NULL COMMENT 'A - ATIVO\nI - INATIVO',
  PRIMARY KEY (`id`, `status`),
  UNIQUE INDEX `inscricaoEstadual_UNIQUE` (`inscricaoEstadual` ASC) VISIBLE,
  UNIQUE INDEX `inscricaoMunicipal_UNIQUE` (`inscricaoMunicipal` ASC) VISIBLE,
  UNIQUE INDEX `cnpj_UNIQUE` (`cnpj` ASC) VISIBLE,
  INDEX `nome_idx` (`nome` ASC) VISIBLE,
  INDEX `fk_Cooperativa_Pessoa1_idx` (`idPessoaRepresentate` ASC) VISIBLE,
  CONSTRAINT `fk_Cooperativa_Pessoa1`
    FOREIGN KEY (`idPessoaRepresentate`)
    REFERENCES `mydb`.`Pessoa` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Pessoa`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Pessoa` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `cpf` VARCHAR(45) NOT NULL,
  `nome` VARCHAR(45) NOT NULL,
  `telefone` VARCHAR(10) NULL,
  `logradouro` VARCHAR(15) NULL,
  `bairro` VARCHAR(25) NULL,
  `numero` VARCHAR(20) NULL,
  `cidade` VARCHAR(45) NULL,
  `estado` VARCHAR(2) NULL,
  `idCooperativa` INT UNSIGNED NOT NULL,
  `status` ENUM('A', 'I') NOT NULL COMMENT 'A - ATIVO\nI - INATIVO',
  PRIMARY KEY (`id`),
  UNIQUE INDEX `cpf_UNIQUE` (`cpf` ASC) VISIBLE,
  INDEX `nome_idx` (`nome` ASC) VISIBLE,
  INDEX `fk_Pessoa_Cooperativa1_idx` (`idCooperativa` ASC) VISIBLE,
  CONSTRAINT `fk_Pessoa_Cooperativa1`
    FOREIGN KEY (`idCooperativa`)
    REFERENCES `mydb`.`Cooperativa` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Agendamento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Agendamento` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `data` DATETIME NOT NULL,
  `cep` VARCHAR(15) NOT NULL,
  `logradouro` VARCHAR(45) NOT NULL,
  `numero` VARCHAR(20) NOT NULL,
  `idPessoa` INT UNSIGNED NOT NULL,
  `bairro` VARCHAR(45) NOT NULL,
  `cidade` VARCHAR(45) NOT NULL,
  `estado` VARCHAR(2) NOT NULL,
  `status` ENUM('A', 'C') NULL COMMENT 'A - ATIVO\nC -CANCELADO',
  UNIQUE INDEX `cep_UNIQUE` (`cep` ASC) VISIBLE,
  INDEX `fk_Agendamento_Cidadao1_idx` (`idPessoa` ASC) VISIBLE,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_Agendamento_Cidadao1_idx`
    FOREIGN KEY (`idPessoa`)
    REFERENCES `mydb`.`Pessoa` (`id`)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`VendaMaterial`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`VendaMaterial` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `tipo` ENUM('M', 'P') NOT NULL,
  `valor` DECIMAL(10,2) NOT NULL,
  `quantidade` DECIMAL(10,2) NOT NULL,
  `data` DATETIME NOT NULL,
  `idCooperativa` INT UNSIGNED NOT NULL,
  `idPessoa` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_VendaMaterial_Cooperativa1_idx` (`idCooperativa` ASC) VISIBLE,
  INDEX `fk_VendaMaterial_Pessoa1_idx` (`idPessoa` ASC) VISIBLE,
  CONSTRAINT `fk_VendaMaterial_Cooperativa1`
    FOREIGN KEY (`idCooperativa`)
    REFERENCES `mydb`.`Cooperativa` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_VendaMaterial_Pessoa1`
    FOREIGN KEY (`idPessoa`)
    REFERENCES `mydb`.`Pessoa` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`RotinaDeColeta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`RotinaDeColeta` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `cep` VARCHAR(45) NOT NULL,
  `logradouro` VARCHAR(45) NOT NULL,
  `numero` INT NOT NULL,
  `diaColeta` DATETIME NOT NULL,
  `horarioInicio` DATETIME NULL,
  `horarioTermino` DATETIME NULL,
  `idCooperativa` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_RotinaDeColeta_Cooperativa1_idx` (`idCooperativa` ASC) VISIBLE,
  CONSTRAINT `fk_RotinaDeColeta_Cooperativa1`
    FOREIGN KEY (`idCooperativa`)
    REFERENCES `mydb`.`Cooperativa` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Noticia`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Noticia` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `titulo` VARCHAR(100) NOT NULL,
  `conteudo` VARCHAR(2000) NOT NULL,
  `idCooperativa` INT UNSIGNED NOT NULL,
  `data` DATETIME NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `titulo_idx` (`titulo` ASC) VISIBLE,
  INDEX `fk_Noticia_Cooperativa1_idx` (`idCooperativa` ASC) VISIBLE,
  CONSTRAINT `fk_Noticia_Cooperativa1`
    FOREIGN KEY (`idCooperativa`)
    REFERENCES `mydb`.`Cooperativa` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Orientacoes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Orientacoes` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `titulo` VARCHAR(100) NOT NULL,
  `descricao` VARCHAR(2000) NOT NULL,
  `idCooperativa` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `titulo_idx` (`titulo` ASC) VISIBLE,
  INDEX `fk_Orientacoes_Cooperativa1_idx` (`idCooperativa` ASC) VISIBLE,
  CONSTRAINT `fk_Orientacoes_Cooperativa1`
    FOREIGN KEY (`idCooperativa`)
    REFERENCES `mydb`.`Cooperativa` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
