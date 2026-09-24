-- ============================================================
-- Sistema de Gestion de Cursos - Esquema de Base de Datos
-- Motor: MariaDB 11.8
-- ============================================================

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
-- 5. DATOS INICIALES - ADMINISTRADOR
-- password_hash generado con BCrypt (BCrypt.Net-Next, igual que
-- ServiceAutenticacion.GenerarHash). Empieza con $2a$ y tiene 60 caracteres.
-- Contrasena real: matias123
-- ============================================================

INSERT INTO administradores (nombre, apellido, dni, email, password_hash, estado)
VALUES (
    'Matias',
    'Caballero',
    '43025150',
    'matiezecaba19@gmail.com',
    '$2a$11$zct12tJEB5biWqJPkUjuRemNW60EIKTFj7HncNt/EG1zOPYeE08da',
    'activo'
);
