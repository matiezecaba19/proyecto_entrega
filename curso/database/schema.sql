-- ============================================================
-- Sistema de Gestion de Cursos - Esquema de Base de Datos
-- Motor: MariaDB 11.8
-- Crea la base desde cero con todos los datos de prueba
-- Importar: mariadb -u root -p < schema.sql
-- OJO: si ya existe la base proyecto la borra y la crea de nuevo
-- ============================================================

DROP DATABASE IF EXISTS proyecto;

CREATE DATABASE IF NOT EXISTS proyecto
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_spanish_ci;

USE proyecto;

-- ============================================================
-- 1. TABLAS DE ROLES (una tabla por rol, DNI como credencial de login)
-- ============================================================

CREATE TABLE administradores (
    id                  INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    nombre              VARCHAR(20)  NOT NULL,
    apellido            VARCHAR(20)  NOT NULL,
    dni                 VARCHAR(8)   NOT NULL,
    email               VARCHAR(50)  NOT NULL,
    password_hash       VARCHAR(100) NOT NULL,
    estado              ENUM('activo','inactivo') NOT NULL DEFAULT 'activo',
    fecha_creacion      DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UNIQUE KEY uq_administradores_dni (dni),
    UNIQUE KEY uq_administradores_email (email)
) ENGINE=InnoDB;

CREATE TABLE profesores (
    id                  INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    nombre              VARCHAR(20)  NOT NULL,
    apellido            VARCHAR(20)  NOT NULL,
    dni                 VARCHAR(8)   NOT NULL,
    email               VARCHAR(50)  NOT NULL,
    password_hash       VARCHAR(100) NOT NULL,
    estado              ENUM('pendiente','activo','inactivo','rechazado') NOT NULL DEFAULT 'pendiente',
    descripcion         VARCHAR(200) NULL,
    fecha_creacion      DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UNIQUE KEY uq_profesores_dni (dni),
    UNIQUE KEY uq_profesores_email (email)
) ENGINE=InnoDB;

CREATE TABLE cobranza (
    id                  INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    nombre              VARCHAR(20)  NOT NULL,
    apellido            VARCHAR(20)  NOT NULL,
    dni                 VARCHAR(8)   NOT NULL,
    email               VARCHAR(50)  NOT NULL,
    password_hash       VARCHAR(100) NOT NULL,
    estado              ENUM('pendiente','activo','inactivo','rechazado') NOT NULL DEFAULT 'pendiente',
    fecha_creacion      DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UNIQUE KEY uq_cobranza_dni (dni),
    UNIQUE KEY uq_cobranza_email (email)
) ENGINE=InnoDB;

CREATE TABLE alumnos (
    id                  INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    nombre              VARCHAR(20)  NOT NULL,
    apellido            VARCHAR(20)  NOT NULL,
    dni                 VARCHAR(8)   NOT NULL,
    email               VARCHAR(50)  NOT NULL,
    password_hash       VARCHAR(100) NOT NULL,
    estado              ENUM('pendiente','activo','inactivo') NOT NULL DEFAULT 'pendiente',
    fecha_creacion      DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UNIQUE KEY uq_alumnos_dni (dni),
    UNIQUE KEY uq_alumnos_email (email)
) ENGINE=InnoDB;

-- ============================================================
-- 2. CATALOGO Y CURSOS
-- ============================================================

CREATE TABLE categorias (
    id          INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    nombre      VARCHAR(30) NOT NULL,
    descripcion VARCHAR(100) NULL,
    UNIQUE KEY uq_categorias_nombre (nombre)
) ENGINE=InnoDB;

CREATE TABLE cursos (
    id                  INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    titulo              VARCHAR(30) NOT NULL,
    descripcion         TEXT NULL,
    profesor_id         INT UNSIGNED NOT NULL,
    categoria_id        INT UNSIGNED NOT NULL,
    precio              DECIMAL(10,2) NOT NULL DEFAULT 0,
    estado              ENUM('borrador','publicado','cerrado') NOT NULL DEFAULT 'borrador',
    nivel               ENUM('inicial','intermedio','avanzado') NOT NULL DEFAULT 'inicial',
    fecha_creacion      DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT fk_cursos_profesor  FOREIGN KEY (profesor_id)  REFERENCES profesores(id),
    CONSTRAINT fk_cursos_categoria FOREIGN KEY (categoria_id) REFERENCES categorias(id),
    KEY idx_cursos_categoria (categoria_id),
    KEY idx_cursos_titulo (titulo)
) ENGINE=InnoDB;

CREATE TABLE lecciones (
    id         INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    curso_id   INT UNSIGNED NOT NULL,
    titulo     VARCHAR(150) NOT NULL,
    contenido  TEXT NULL,
    orden      SMALLINT UNSIGNED NOT NULL DEFAULT 1,
    CONSTRAINT fk_lecciones_curso FOREIGN KEY (curso_id) REFERENCES cursos(id) ON DELETE CASCADE,
    KEY idx_lecciones_curso (curso_id)
) ENGINE=InnoDB;

CREATE TABLE imagenes_leccion (
    id          INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    leccion_id  INT UNSIGNED NOT NULL,
    url         VARCHAR(255) NOT NULL,
    orden       SMALLINT UNSIGNED NOT NULL DEFAULT 1,
    CONSTRAINT fk_imagenes_leccion FOREIGN KEY (leccion_id) REFERENCES lecciones(id) ON DELETE CASCADE,
    KEY idx_imagenes_leccion (leccion_id)
) ENGINE=InnoDB;

-- ============================================================
-- 3. INSCRIPCIONES Y PROGRESO
-- ============================================================

CREATE TABLE inscripciones (
    id                  INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    alumno_id           INT UNSIGNED NOT NULL,
    curso_id            INT UNSIGNED NOT NULL,
    numero_orden        VARCHAR(20)  NOT NULL,
    monto               DECIMAL(10,2) NOT NULL,
    estado              ENUM('pendiente_pago','aceptada','rechazada') NOT NULL DEFAULT 'pendiente_pago',
    autorizado_por      INT UNSIGNED NULL,
    completado          TINYINT(1) NOT NULL DEFAULT 0,
    fecha_solicitud     DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UNIQUE KEY uq_inscripciones_numero_orden (numero_orden),
    CONSTRAINT fk_inscripciones_alumno   FOREIGN KEY (alumno_id)      REFERENCES alumnos(id),
    CONSTRAINT fk_inscripciones_curso    FOREIGN KEY (curso_id)       REFERENCES cursos(id),
    CONSTRAINT fk_inscripciones_cobranza FOREIGN KEY (autorizado_por) REFERENCES cobranza(id),
    KEY idx_inscripciones_alumno (alumno_id),
    KEY idx_inscripciones_curso (curso_id)
) ENGINE=InnoDB;

CREATE TABLE progreso_leccion (
    id                INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    inscripcion_id    INT UNSIGNED NOT NULL,
    leccion_id        INT UNSIGNED NOT NULL,
    completada        TINYINT(1) NOT NULL DEFAULT 0,
    fecha_completado  DATETIME NULL,
    CONSTRAINT fk_progreso_inscripcion FOREIGN KEY (inscripcion_id) REFERENCES inscripciones(id) ON DELETE CASCADE,
    CONSTRAINT fk_progreso_leccion     FOREIGN KEY (leccion_id)     REFERENCES lecciones(id)     ON DELETE CASCADE,
    UNIQUE KEY uq_progreso_inscripcion_leccion (inscripcion_id, leccion_id)
) ENGINE=InnoDB;

-- ============================================================
-- 4. VISTA DE PROGRESO (para el modulo de Reportes)
-- ============================================================

CREATE VIEW vista_progreso_alumno AS
SELECT
    i.id                                                                          AS inscripcion_id,
    a.id                                                                          AS alumno_id,
    CONCAT(a.nombre, ' ', a.apellido)                                            AS alumno,
    c.id                                                                          AS curso_id,
    c.titulo                                                                      AS curso,
    i.estado                                                                      AS estado_inscripcion,
    COUNT(DISTINCT l.id)                                                          AS total_lecciones,
    COUNT(DISTINCT CASE WHEN pl.completada = 1 THEN pl.leccion_id END)            AS lecciones_completadas,
    ROUND(
        COUNT(DISTINCT CASE WHEN pl.completada = 1 THEN pl.leccion_id END) * 100.0
        / NULLIF(COUNT(DISTINCT l.id), 0)
    , 2)                                                                          AS porcentaje_avance
FROM inscripciones i
JOIN alumnos a  ON a.id = i.alumno_id
JOIN cursos c   ON c.id = i.curso_id
JOIN lecciones l ON l.curso_id = c.id
LEFT JOIN progreso_leccion pl ON pl.inscripcion_id = i.id AND pl.leccion_id = l.id
GROUP BY i.id, a.id, a.nombre, a.apellido, c.id, c.titulo, i.estado;

-- ============================================================
-- 5. DATOS DE PRUEBA
-- password_hash generado con BCrypt (igual que ServiceAutenticacion.generarHash)
-- Contraseñas: admin matias123, profesor profesor123,
-- cobranza cobranza123, alumnos alumno123
-- ============================================================

-- administradores
INSERT INTO administradores (id, nombre, apellido, dni, email, password_hash, estado, fecha_creacion) VALUES (1,'Matias','Caballero','43025150','matiezecaba19@gmail.com','$2a$11$zct12tJEB5biWqJPkUjuRemNW60EIKTFj7HncNt/EG1zOPYeE08da','activo','2026-09-21 17:57:43');

-- profesores
INSERT INTO profesores (id, nombre, apellido, dni, email, password_hash, estado, descripcion, fecha_creacion) VALUES (1,'Juan','Perez','30111222','juan.perez@prueba.com','$2a$11$vf5Q1xd1usapTqvvHddv4u2.NyqghMXAenDwL0ZgT6G8/abhMUYp6','activo','Programador .NET con 10 años de experiencia. Me gusta enseñar desde cero y con ejemplos prácticos.','2026-09-21 18:57:40');

-- cobranza
INSERT INTO cobranza (id, nombre, apellido, dni, email, password_hash, estado, fecha_creacion) VALUES (1,'Laura','Diaz','35111222','laura.diaz@prueba.com','$2a$11$5H3q3fJGFZtETsi60zxlQePCz.xPIcOO6R/z4RXGaqyF8AgEof2h.','activo','2026-09-21 19:33:16');

-- alumnos
INSERT INTO alumnos (id, nombre, apellido, dni, email, password_hash, estado, fecha_creacion) VALUES (1,'Ana','Gomez','40111222','ana.gomez@prueba.com','$2a$11$hd.uSqkdBBsu9mUyAsu0Qu/WxF2v9TQPEI1bLjxu25obWtEotE8Ty','activo','2026-09-21 18:57:40');
INSERT INTO alumnos (id, nombre, apellido, dni, email, password_hash, estado, fecha_creacion) VALUES (3,'Carlos','Lopez','40222333','carlos.lopez@prueba.com','$2a$11$hd.uSqkdBBsu9mUyAsu0Qu/WxF2v9TQPEI1bLjxu25obWtEotE8Ty','activo','2026-09-24 07:25:22');
INSERT INTO alumnos (id, nombre, apellido, dni, email, password_hash, estado, fecha_creacion) VALUES (4,'Lucia','Fernandez','40333444','lucia.fernandez@prueba.com','$2a$11$hd.uSqkdBBsu9mUyAsu0Qu/WxF2v9TQPEI1bLjxu25obWtEotE8Ty','activo','2026-09-24 07:25:22');
INSERT INTO alumnos (id, nombre, apellido, dni, email, password_hash, estado, fecha_creacion) VALUES (5,'Martin','Sosa','40444555','martin.sosa@prueba.com','$2a$11$hd.uSqkdBBsu9mUyAsu0Qu/WxF2v9TQPEI1bLjxu25obWtEotE8Ty','activo','2026-09-24 07:25:22');
INSERT INTO alumnos (id, nombre, apellido, dni, email, password_hash, estado, fecha_creacion) VALUES (6,'Sofia','Ruiz','40555666','sofia.ruiz@prueba.com','$2a$11$hd.uSqkdBBsu9mUyAsu0Qu/WxF2v9TQPEI1bLjxu25obWtEotE8Ty','activo','2026-09-24 07:25:22');

-- categorias
INSERT INTO categorias (id, nombre, descripcion) VALUES (1,'Programación','Cursos de desarrollo de software');
INSERT INTO categorias (id, nombre, descripcion) VALUES (2,'Diseño','Diseño gráfico y web');
INSERT INTO categorias (id, nombre, descripcion) VALUES (3,'Idiomas','Cursos de idiomas');
INSERT INTO categorias (id, nombre, descripcion) VALUES (4,'Marketing','Marketing digital y redes');

-- cursos
INSERT INTO cursos (id, titulo, descripcion, profesor_id, categoria_id, precio, estado, nivel, fecha_creacion) VALUES (2,'Introducción a VB.NET','Primeros pasos con Visual Basic',1,1,15000.00,'publicado','intermedio','2026-09-24 07:25:22');
INSERT INTO cursos (id, titulo, descripcion, profesor_id, categoria_id, precio, estado, nivel, fecha_creacion) VALUES (3,'Diseño web básico','HTML y CSS desde cero',1,2,12000.00,'publicado','inicial','2026-09-24 07:25:22');

-- lecciones
INSERT INTO lecciones (id, curso_id, titulo, contenido, orden) VALUES (1,2,'Instalar Visual Studio','Descarga e instalación',1);
INSERT INTO lecciones (id, curso_id, titulo, contenido, orden) VALUES (2,2,'Variables y tipos','Dim, As, tipos básicos',2);
INSERT INTO lecciones (id, curso_id, titulo, contenido, orden) VALUES (3,2,'Condicionales','If, Else, Select Case',3);
INSERT INTO lecciones (id, curso_id, titulo, contenido, orden) VALUES (4,2,'Formularios','Controles y eventos',4);
INSERT INTO lecciones (id, curso_id, titulo, contenido, orden) VALUES (5,3,'Estructura HTML','Etiquetas básicas',1);
INSERT INTO lecciones (id, curso_id, titulo, contenido, orden) VALUES (6,3,'Estilos con CSS','Selectores y propiedades',2);
INSERT INTO lecciones (id, curso_id, titulo, contenido, orden) VALUES (7,3,'Maquetado','Flexbox',3);

-- inscripciones
INSERT INTO inscripciones (id, alumno_id, curso_id, numero_orden, monto, estado, autorizado_por, completado, fecha_solicitud) VALUES (1,1,2,'ORD-0001',15000.00,'aceptada',1,0,'2026-09-01 10:00:00');
INSERT INTO inscripciones (id, alumno_id, curso_id, numero_orden, monto, estado, autorizado_por, completado, fecha_solicitud) VALUES (2,3,2,'ORD-0002',15000.00,'aceptada',1,0,'2026-09-10 11:30:00');
INSERT INTO inscripciones (id, alumno_id, curso_id, numero_orden, monto, estado, autorizado_por, completado, fecha_solicitud) VALUES (3,4,2,'ORD-0003',15000.00,'aceptada',1,0,'2026-08-20 09:15:00');
INSERT INTO inscripciones (id, alumno_id, curso_id, numero_orden, monto, estado, autorizado_por, completado, fecha_solicitud) VALUES (4,5,2,'ORD-0004',15000.00,'pendiente_pago',NULL,0,'2026-09-20 18:00:00');
INSERT INTO inscripciones (id, alumno_id, curso_id, numero_orden, monto, estado, autorizado_por, completado, fecha_solicitud) VALUES (5,6,3,'ORD-0005',12000.00,'aceptada',1,0,'2026-09-05 14:00:00');
INSERT INTO inscripciones (id, alumno_id, curso_id, numero_orden, monto, estado, autorizado_por, completado, fecha_solicitud) VALUES (6,1,3,'ORD-0006',12000.00,'aceptada',1,0,'2026-08-15 16:45:00');

-- progreso_leccion
INSERT INTO progreso_leccion (id, inscripcion_id, leccion_id, completada, fecha_completado) VALUES (1,1,1,1,'2026-09-24 07:25:22');
INSERT INTO progreso_leccion (id, inscripcion_id, leccion_id, completada, fecha_completado) VALUES (2,1,2,1,'2026-09-24 07:25:22');
INSERT INTO progreso_leccion (id, inscripcion_id, leccion_id, completada, fecha_completado) VALUES (3,3,1,1,'2026-09-24 07:25:22');
INSERT INTO progreso_leccion (id, inscripcion_id, leccion_id, completada, fecha_completado) VALUES (4,3,2,1,'2026-09-24 07:25:22');
INSERT INTO progreso_leccion (id, inscripcion_id, leccion_id, completada, fecha_completado) VALUES (5,3,3,1,'2026-09-24 07:25:22');
INSERT INTO progreso_leccion (id, inscripcion_id, leccion_id, completada, fecha_completado) VALUES (6,3,4,1,'2026-09-24 07:25:22');
INSERT INTO progreso_leccion (id, inscripcion_id, leccion_id, completada, fecha_completado) VALUES (7,5,5,1,'2026-09-24 07:25:22');
INSERT INTO progreso_leccion (id, inscripcion_id, leccion_id, completada, fecha_completado) VALUES (8,6,5,1,'2026-09-24 07:25:22');
INSERT INTO progreso_leccion (id, inscripcion_id, leccion_id, completada, fecha_completado) VALUES (9,6,6,1,'2026-09-24 07:25:22');
INSERT INTO progreso_leccion (id, inscripcion_id, leccion_id, completada, fecha_completado) VALUES (10,6,7,1,'2026-09-24 07:25:22');
