-- base proyecto completa con datos de prueba (usuarios, cursos, inscripciones y progreso)
-- importar con: mariadb -u root -p < proyecto_completo.sql
-- ojo: borra la base proyecto si ya existe y la crea de nuevo

/*M!999999\- enable the sandbox mode */ 

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*M!100616 SET @OLD_NOTE_VERBOSITY=@@NOTE_VERBOSITY, NOTE_VERBOSITY=0 */;

/*!40000 DROP DATABASE IF EXISTS `proyecto`*/;

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `proyecto` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_spanish_ci */;

USE `proyecto`;
DROP TABLE IF EXISTS `administradores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `administradores` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(20) NOT NULL,
  `apellido` varchar(20) NOT NULL,
  `dni` varchar(8) NOT NULL,
  `email` varchar(50) NOT NULL,
  `password_hash` varchar(100) NOT NULL,
  `estado` enum('activo','inactivo') NOT NULL DEFAULT 'activo',
  `fecha_creacion` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_administradores_dni` (`dni`),
  UNIQUE KEY `uq_administradores_email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

SET @OLD_AUTOCOMMIT=@@AUTOCOMMIT, @@AUTOCOMMIT=0;
LOCK TABLES `administradores` WRITE;
/*!40000 ALTER TABLE `administradores` DISABLE KEYS */;
INSERT INTO `administradores` VALUES
(1,'Matias','Caballero','43025150','matiezecaba19@gmail.com','$2a$11$zct12tJEB5biWqJPkUjuRemNW60EIKTFj7HncNt/EG1zOPYeE08da','activo','2026-09-21 17:57:43');
/*!40000 ALTER TABLE `administradores` ENABLE KEYS */;
UNLOCK TABLES;
COMMIT;
SET AUTOCOMMIT=@OLD_AUTOCOMMIT;
DROP TABLE IF EXISTS `alumnos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `alumnos` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(20) NOT NULL,
  `apellido` varchar(20) NOT NULL,
  `dni` varchar(8) NOT NULL,
  `email` varchar(50) NOT NULL,
  `password_hash` varchar(100) NOT NULL,
  `estado` enum('pendiente','activo','inactivo') NOT NULL DEFAULT 'pendiente',
  `fecha_creacion` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_alumnos_dni` (`dni`),
  UNIQUE KEY `uq_alumnos_email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

SET @OLD_AUTOCOMMIT=@@AUTOCOMMIT, @@AUTOCOMMIT=0;
LOCK TABLES `alumnos` WRITE;
/*!40000 ALTER TABLE `alumnos` DISABLE KEYS */;
INSERT INTO `alumnos` VALUES
(1,'Ana','Gomez','40111222','ana.gomez@prueba.com','$2a$11$hd.uSqkdBBsu9mUyAsu0Qu/WxF2v9TQPEI1bLjxu25obWtEotE8Ty','activo','2026-09-21 18:57:40'),
(3,'Carlos','Lopez','40222333','carlos.lopez@prueba.com','$2a$11$hd.uSqkdBBsu9mUyAsu0Qu/WxF2v9TQPEI1bLjxu25obWtEotE8Ty','activo','2026-09-24 07:25:22'),
(4,'Lucia','Fernandez','40333444','lucia.fernandez@prueba.com','$2a$11$hd.uSqkdBBsu9mUyAsu0Qu/WxF2v9TQPEI1bLjxu25obWtEotE8Ty','activo','2026-09-24 07:25:22'),
(5,'Martin','Sosa','40444555','martin.sosa@prueba.com','$2a$11$hd.uSqkdBBsu9mUyAsu0Qu/WxF2v9TQPEI1bLjxu25obWtEotE8Ty','activo','2026-09-24 07:25:22'),
(6,'Sofia','Ruiz','40555666','sofia.ruiz@prueba.com','$2a$11$hd.uSqkdBBsu9mUyAsu0Qu/WxF2v9TQPEI1bLjxu25obWtEotE8Ty','activo','2026-09-24 07:25:22');
/*!40000 ALTER TABLE `alumnos` ENABLE KEYS */;
UNLOCK TABLES;
COMMIT;
SET AUTOCOMMIT=@OLD_AUTOCOMMIT;
DROP TABLE IF EXISTS `categorias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `categorias` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(30) NOT NULL,
  `descripcion` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_categorias_nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

SET @OLD_AUTOCOMMIT=@@AUTOCOMMIT, @@AUTOCOMMIT=0;
LOCK TABLES `categorias` WRITE;
/*!40000 ALTER TABLE `categorias` DISABLE KEYS */;
INSERT INTO `categorias` VALUES
(1,'Programación','Cursos de desarrollo de software'),
(2,'Diseño','Diseño gráfico y web'),
(3,'Idiomas','Cursos de idiomas'),
(4,'Marketing','Marketing digital y redes');
/*!40000 ALTER TABLE `categorias` ENABLE KEYS */;
UNLOCK TABLES;
COMMIT;
SET AUTOCOMMIT=@OLD_AUTOCOMMIT;
DROP TABLE IF EXISTS `cobranza`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `cobranza` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(20) NOT NULL,
  `apellido` varchar(20) NOT NULL,
  `dni` varchar(8) NOT NULL,
  `email` varchar(50) NOT NULL,
  `password_hash` varchar(100) NOT NULL,
  `estado` enum('pendiente','activo','inactivo','rechazado') NOT NULL DEFAULT 'pendiente',
  `fecha_creacion` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_cobranza_dni` (`dni`),
  UNIQUE KEY `uq_cobranza_email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

SET @OLD_AUTOCOMMIT=@@AUTOCOMMIT, @@AUTOCOMMIT=0;
LOCK TABLES `cobranza` WRITE;
/*!40000 ALTER TABLE `cobranza` DISABLE KEYS */;
INSERT INTO `cobranza` VALUES
(1,'Laura','Diaz','35111222','laura.diaz@prueba.com','$2a$11$5H3q3fJGFZtETsi60zxlQePCz.xPIcOO6R/z4RXGaqyF8AgEof2h.','activo','2026-09-21 19:33:16');
/*!40000 ALTER TABLE `cobranza` ENABLE KEYS */;
UNLOCK TABLES;
COMMIT;
SET AUTOCOMMIT=@OLD_AUTOCOMMIT;
DROP TABLE IF EXISTS `cursos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `cursos` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `titulo` varchar(30) NOT NULL,
  `descripcion` text DEFAULT NULL,
  `profesor_id` int(10) unsigned NOT NULL,
  `categoria_id` int(10) unsigned NOT NULL,
  `precio` decimal(10,2) NOT NULL DEFAULT 0.00,
  `estado` enum('borrador','publicado','cerrado') NOT NULL DEFAULT 'borrador',
  `nivel` enum('inicial','intermedio','avanzado') NOT NULL DEFAULT 'inicial',
  `fecha_creacion` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`id`),
  KEY `fk_cursos_profesor` (`profesor_id`),
  KEY `idx_cursos_categoria` (`categoria_id`),
  KEY `idx_cursos_titulo` (`titulo`),
  CONSTRAINT `fk_cursos_categoria` FOREIGN KEY (`categoria_id`) REFERENCES `categorias` (`id`),
  CONSTRAINT `fk_cursos_profesor` FOREIGN KEY (`profesor_id`) REFERENCES `profesores` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

SET @OLD_AUTOCOMMIT=@@AUTOCOMMIT, @@AUTOCOMMIT=0;
LOCK TABLES `cursos` WRITE;
/*!40000 ALTER TABLE `cursos` DISABLE KEYS */;
INSERT INTO `cursos` VALUES
(2,'Introducción a VB.NET','Primeros pasos con Visual Basic',1,1,15000.00,'publicado','intermedio','2026-09-24 07:25:22'),
(3,'Diseño web básico','HTML y CSS desde cero',1,2,12000.00,'publicado','inicial','2026-09-24 07:25:22');
/*!40000 ALTER TABLE `cursos` ENABLE KEYS */;
UNLOCK TABLES;
COMMIT;
SET AUTOCOMMIT=@OLD_AUTOCOMMIT;
DROP TABLE IF EXISTS `imagenes_leccion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `imagenes_leccion` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `leccion_id` int(10) unsigned NOT NULL,
  `url` varchar(255) NOT NULL,
  `orden` smallint(5) unsigned NOT NULL DEFAULT 1,
  PRIMARY KEY (`id`),
  KEY `idx_imagenes_leccion` (`leccion_id`),
  CONSTRAINT `fk_imagenes_leccion` FOREIGN KEY (`leccion_id`) REFERENCES `lecciones` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

SET @OLD_AUTOCOMMIT=@@AUTOCOMMIT, @@AUTOCOMMIT=0;
LOCK TABLES `imagenes_leccion` WRITE;
/*!40000 ALTER TABLE `imagenes_leccion` DISABLE KEYS */;
/*!40000 ALTER TABLE `imagenes_leccion` ENABLE KEYS */;
UNLOCK TABLES;
COMMIT;
SET AUTOCOMMIT=@OLD_AUTOCOMMIT;
DROP TABLE IF EXISTS `inscripciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `inscripciones` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `alumno_id` int(10) unsigned NOT NULL,
  `curso_id` int(10) unsigned NOT NULL,
  `numero_orden` varchar(20) NOT NULL,
  `monto` decimal(10,2) NOT NULL,
  `estado` enum('pendiente_pago','aceptada','rechazada') NOT NULL DEFAULT 'pendiente_pago',
  `autorizado_por` int(10) unsigned DEFAULT NULL,
  `completado` tinyint(1) NOT NULL DEFAULT 0,
  `fecha_solicitud` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_inscripciones_numero_orden` (`numero_orden`),
  KEY `fk_inscripciones_cobranza` (`autorizado_por`),
  KEY `idx_inscripciones_alumno` (`alumno_id`),
  KEY `idx_inscripciones_curso` (`curso_id`),
  CONSTRAINT `fk_inscripciones_alumno` FOREIGN KEY (`alumno_id`) REFERENCES `alumnos` (`id`),
  CONSTRAINT `fk_inscripciones_cobranza` FOREIGN KEY (`autorizado_por`) REFERENCES `cobranza` (`id`),
  CONSTRAINT `fk_inscripciones_curso` FOREIGN KEY (`curso_id`) REFERENCES `cursos` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

SET @OLD_AUTOCOMMIT=@@AUTOCOMMIT, @@AUTOCOMMIT=0;
LOCK TABLES `inscripciones` WRITE;
/*!40000 ALTER TABLE `inscripciones` DISABLE KEYS */;
INSERT INTO `inscripciones` VALUES
(1,1,2,'ORD-0001',15000.00,'aceptada',1,0,'2026-09-01 10:00:00'),
(2,3,2,'ORD-0002',15000.00,'aceptada',1,0,'2026-09-10 11:30:00'),
(3,4,2,'ORD-0003',15000.00,'aceptada',1,0,'2026-08-20 09:15:00'),
(4,5,2,'ORD-0004',15000.00,'pendiente_pago',NULL,0,'2026-09-20 18:00:00'),
(5,6,3,'ORD-0005',12000.00,'aceptada',1,0,'2026-09-05 14:00:00'),
(6,1,3,'ORD-0006',12000.00,'aceptada',1,0,'2026-08-15 16:45:00');
/*!40000 ALTER TABLE `inscripciones` ENABLE KEYS */;
UNLOCK TABLES;
COMMIT;
SET AUTOCOMMIT=@OLD_AUTOCOMMIT;
DROP TABLE IF EXISTS `lecciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `lecciones` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `curso_id` int(10) unsigned NOT NULL,
  `titulo` varchar(150) NOT NULL,
  `contenido` text DEFAULT NULL,
  `orden` smallint(5) unsigned NOT NULL DEFAULT 1,
  PRIMARY KEY (`id`),
  KEY `idx_lecciones_curso` (`curso_id`),
  CONSTRAINT `fk_lecciones_curso` FOREIGN KEY (`curso_id`) REFERENCES `cursos` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

SET @OLD_AUTOCOMMIT=@@AUTOCOMMIT, @@AUTOCOMMIT=0;
LOCK TABLES `lecciones` WRITE;
/*!40000 ALTER TABLE `lecciones` DISABLE KEYS */;
INSERT INTO `lecciones` VALUES
(1,2,'Instalar Visual Studio','Descarga e instalación',1),
(2,2,'Variables y tipos','Dim, As, tipos básicos',2),
(3,2,'Condicionales','If, Else, Select Case',3),
(4,2,'Formularios','Controles y eventos',4),
(5,3,'Estructura HTML','Etiquetas básicas',1),
(6,3,'Estilos con CSS','Selectores y propiedades',2),
(7,3,'Maquetado','Flexbox',3);
/*!40000 ALTER TABLE `lecciones` ENABLE KEYS */;
UNLOCK TABLES;
COMMIT;
SET AUTOCOMMIT=@OLD_AUTOCOMMIT;
DROP TABLE IF EXISTS `profesores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `profesores` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(20) NOT NULL,
  `apellido` varchar(20) NOT NULL,
  `dni` varchar(8) NOT NULL,
  `email` varchar(50) NOT NULL,
  `password_hash` varchar(100) NOT NULL,
  `estado` enum('pendiente','activo','inactivo','rechazado') NOT NULL DEFAULT 'pendiente',
  `descripcion` varchar(200) DEFAULT NULL,
  `fecha_creacion` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_profesores_dni` (`dni`),
  UNIQUE KEY `uq_profesores_email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

SET @OLD_AUTOCOMMIT=@@AUTOCOMMIT, @@AUTOCOMMIT=0;
LOCK TABLES `profesores` WRITE;
/*!40000 ALTER TABLE `profesores` DISABLE KEYS */;
INSERT INTO `profesores` VALUES
(1,'Juan','Perez','30111222','juan.perez@prueba.com','$2a$11$vf5Q1xd1usapTqvvHddv4u2.NyqghMXAenDwL0ZgT6G8/abhMUYp6','activo','Programador .NET con 10 años de experiencia. Me gusta enseñar desde cero y con ejemplos prácticos.','2026-09-21 18:57:40');
/*!40000 ALTER TABLE `profesores` ENABLE KEYS */;
UNLOCK TABLES;
COMMIT;
SET AUTOCOMMIT=@OLD_AUTOCOMMIT;
DROP TABLE IF EXISTS `progreso_leccion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `progreso_leccion` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `inscripcion_id` int(10) unsigned NOT NULL,
  `leccion_id` int(10) unsigned NOT NULL,
  `completada` tinyint(1) NOT NULL DEFAULT 0,
  `fecha_completado` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_progreso_inscripcion_leccion` (`inscripcion_id`,`leccion_id`),
  KEY `fk_progreso_leccion` (`leccion_id`),
  CONSTRAINT `fk_progreso_inscripcion` FOREIGN KEY (`inscripcion_id`) REFERENCES `inscripciones` (`id`) ON DELETE CASCADE,
  CONSTRAINT `fk_progreso_leccion` FOREIGN KEY (`leccion_id`) REFERENCES `lecciones` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

SET @OLD_AUTOCOMMIT=@@AUTOCOMMIT, @@AUTOCOMMIT=0;
LOCK TABLES `progreso_leccion` WRITE;
/*!40000 ALTER TABLE `progreso_leccion` DISABLE KEYS */;
INSERT INTO `progreso_leccion` VALUES
(1,1,1,1,'2026-09-24 07:25:22'),
(2,1,2,1,'2026-09-24 07:25:22'),
(3,3,1,1,'2026-09-24 07:25:22'),
(4,3,2,1,'2026-09-24 07:25:22'),
(5,3,3,1,'2026-09-24 07:25:22'),
(6,3,4,1,'2026-09-24 07:25:22'),
(7,5,5,1,'2026-09-24 07:25:22'),
(8,6,5,1,'2026-09-24 07:25:22'),
(9,6,6,1,'2026-09-24 07:25:22'),
(10,6,7,1,'2026-09-24 07:25:22');
/*!40000 ALTER TABLE `progreso_leccion` ENABLE KEYS */;
UNLOCK TABLES;
COMMIT;
SET AUTOCOMMIT=@OLD_AUTOCOMMIT;
DROP TABLE IF EXISTS `vista_progreso_alumno`;
/*!50001 DROP VIEW IF EXISTS `vista_progreso_alumno`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `vista_progreso_alumno` AS SELECT
 NULL AS `inscripcion_id`,
 NULL AS `alumno_id`,
 NULL AS `alumno`,
 NULL AS `curso_id`,
 NULL AS `curso`,
 NULL AS `estado_inscripcion`,
 NULL AS `total_lecciones`,
 NULL AS `lecciones_completadas`,
 NULL AS `porcentaje_avance` */;
SET character_set_client = @saved_cs_client;

USE `proyecto`;
/*!50001 DROP VIEW IF EXISTS `vista_progreso_alumno`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_uca1400_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=CURRENT_USER SQL SECURITY DEFINER */
/*!50001 VIEW `vista_progreso_alumno` AS select `i`.`id` AS `inscripcion_id`,`a`.`id` AS `alumno_id`,concat(`a`.`nombre`,' ',`a`.`apellido`) AS `alumno`,`c`.`id` AS `curso_id`,`c`.`titulo` AS `curso`,`i`.`estado` AS `estado_inscripcion`,count(distinct `l`.`id`) AS `total_lecciones`,count(distinct case when `pl`.`completada` = 1 then `pl`.`leccion_id` end) AS `lecciones_completadas`,round(count(distinct case when `pl`.`completada` = 1 then `pl`.`leccion_id` end) * 100.0 / nullif(count(distinct `l`.`id`),0),2) AS `porcentaje_avance` from ((((`inscripciones` `i` join `alumnos` `a` on(`a`.`id` = `i`.`alumno_id`)) join `cursos` `c` on(`c`.`id` = `i`.`curso_id`)) join `lecciones` `l` on(`l`.`curso_id` = `c`.`id`)) left join `progreso_leccion` `pl` on(`pl`.`inscripcion_id` = `i`.`id` and `pl`.`leccion_id` = `l`.`id`)) group by `i`.`id`,`a`.`id`,`a`.`nombre`,`a`.`apellido`,`c`.`id`,`c`.`titulo`,`i`.`estado` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*M!100616 SET NOTE_VERBOSITY=@OLD_NOTE_VERBOSITY */;

