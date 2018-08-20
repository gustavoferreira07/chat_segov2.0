-- --------------------------------------------------------
-- Servidor:                     127.0.0.1
-- Versão do servidor:           10.1.25-MariaDB - mariadb.org binary distribution
-- OS do Servidor:               Win32
-- HeidiSQL Versão:              9.5.0.5196
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Copiando estrutura do banco de dados para db_chat
CREATE DATABASE IF NOT EXISTS `db_chat` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `db_chat`;

-- Copiando estrutura para tabela db_chat.tb_backup_conversa
CREATE TABLE IF NOT EXISTS `tb_backup_conversa` (
  `id_chat` int(11) NOT NULL,
  `remetente` varchar(20) NOT NULL,
  `destinatario` varchar(20) NOT NULL,
  `mensagem` longtext NOT NULL,
  `lido` varchar(2) NOT NULL,
  PRIMARY KEY (`id_chat`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Exportação de dados foi desmarcado.
-- Copiando estrutura para tabela db_chat.tb_conversa
CREATE TABLE IF NOT EXISTS `tb_conversa` (
  `id_chat` int(11) NOT NULL AUTO_INCREMENT,
  `remetente` varchar(20) NOT NULL,
  `destinatario` varchar(20) NOT NULL,
  `mensagem` longtext NOT NULL,
  `lido` varchar(2) NOT NULL,
  PRIMARY KEY (`id_chat`)
) ENGINE=InnoDB AUTO_INCREMENT=248 DEFAULT CHARSET=latin1;

-- Exportação de dados foi desmarcado.
-- Copiando estrutura para tabela db_chat.tb_departamento
CREATE TABLE IF NOT EXISTS `tb_departamento` (
  `id_departamento` int(11) NOT NULL AUTO_INCREMENT,
  `nm_departamento` varchar(30) NOT NULL,
  `ds_departamento` varchar(250) NOT NULL,
  PRIMARY KEY (`id_departamento`)
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=latin1;

-- Exportação de dados foi desmarcado.
-- Copiando estrutura para tabela db_chat.tb_grupo
CREATE TABLE IF NOT EXISTS `tb_grupo` (
  `id_chat` int(11) NOT NULL AUTO_INCREMENT,
  `nm_grupo` varchar(30) NOT NULL,
  `foto_grupo` longblob NOT NULL,
  `mensagem` longtext NOT NULL,
  `participantes` longtext NOT NULL,
  PRIMARY KEY (`id_chat`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- Exportação de dados foi desmarcado.
-- Copiando estrutura para tabela db_chat.tb_notificacao
CREATE TABLE IF NOT EXISTS `tb_notificacao` (
  `id_notificacao` int(11) NOT NULL AUTO_INCREMENT,
  `remetente` varchar(20) NOT NULL,
  `destinatario` varchar(20) NOT NULL,
  `mensagem` longtext NOT NULL,
  `lido` varchar(2) NOT NULL,
  PRIMARY KEY (`id_notificacao`)
) ENGINE=InnoDB AUTO_INCREMENT=103 DEFAULT CHARSET=latin1;

-- Exportação de dados foi desmarcado.
-- Copiando estrutura para tabela db_chat.tb_usuario
CREATE TABLE IF NOT EXISTS `tb_usuario` (
  `id_usuario` int(11) NOT NULL AUTO_INCREMENT,
  `nm_usuario` varchar(60) DEFAULT NULL,
  `username` varchar(20) DEFAULT NULL,
  `senha` varchar(60) DEFAULT NULL,
  `departamento` varchar(30) NOT NULL,
  `status` varchar(10) NOT NULL,
  `foto` longblob NOT NULL,
  PRIMARY KEY (`id_usuario`),
  UNIQUE KEY `username` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=158 DEFAULT CHARSET=latin1;

-- Exportação de dados foi desmarcado.
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
