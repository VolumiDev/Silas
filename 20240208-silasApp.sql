/*
 Navicat Premium Dump SQL

 Source Server         : DiegoServer
 Source Server Type    : MariaDB
 Source Server Version : 100527 (10.5.27-MariaDB)
 Source Host           : volumidev.duckdns.org:3306
 Source Schema         : silas

 Target Server Type    : MariaDB
 Target Server Version : 100527 (10.5.27-MariaDB)
 File Encoding         : 65001

 Date: 08/02/2025 11:12:33
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for companies
-- ----------------------------
DROP TABLE IF EXISTS `companies`;
CREATE TABLE `companies`  (
  `id_user` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `adress` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `telephone` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `contact` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `mobile` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `status` tinyint(4) NULL DEFAULT NULL,
  PRIMARY KEY (`id_user`) USING BTREE,
  CONSTRAINT `companies_ibfk_1` FOREIGN KEY (`id_user`) REFERENCES `users` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 17 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of companies
-- ----------------------------
INSERT INTO `companies` VALUES (11, 'NTT', 'awaw', '525252', 'ada@ada.adad', '5125151', 1);
INSERT INTO `companies` VALUES (12, 'Software Innovador S.L.', 'Calle Mayor 45, Madrid', '911234567', 'contacto@softinnova.com', '699123456', 1);
INSERT INTO `companies` VALUES (13, 'Redes y Sistemas S.A.', 'Avenida de la Técnica 12, Barcelona', '932567890', 'info@redessistemas.com', '688987654', 1);
INSERT INTO `companies` VALUES (14, 'Marketing Creativo SL', 'Paseo de la Castellana 100, Madrid', '910112233', 'contacto@marketingcreativo.com', '677889900', 1);
INSERT INTO `companies` VALUES (15, 'Tecnologías Avanzadas S.L.', 'Calle Innovación 22, Valencia', '961234567', 'info@tecnoavance.com', '699223344', 1);
INSERT INTO `companies` VALUES (16, 'Gestión Empresarial S.A.', 'Avenida Negocios 10, Sevilla', '954567890', 'contacto@gestionempresarial.com', '688112233', 1);

-- ----------------------------
-- Table structure for course
-- ----------------------------
DROP TABLE IF EXISTS `course`;
CREATE TABLE `course`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `acronim` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 6 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of course
-- ----------------------------
INSERT INTO `course` VALUES (1, 'Desarrollo de Aplicaciones Multiplataforma', 'DAM');
INSERT INTO `course` VALUES (2, 'Administracion de Sistemas Informáticos y Redes', 'ASIR');
INSERT INTO `course` VALUES (3, 'Maketing y Publicidad', 'MP');
INSERT INTO `course` VALUES (4, 'Adminsitración y Finanzas', 'AF');
INSERT INTO `course` VALUES (5, 'Sistemas Electrónicos y Automatizados', 'SEA');

-- ----------------------------
-- Table structure for notifications
-- ----------------------------
DROP TABLE IF EXISTS `notifications`;
CREATE TABLE `notifications`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `descriptcion` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `status` tinyint(4) NULL DEFAULT NULL,
  `id_user` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `id_user`(`id_user`) USING BTREE,
  CONSTRAINT `notifications_ibfk_1` FOREIGN KEY (`id_user`) REFERENCES `users` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of notifications
-- ----------------------------

-- ----------------------------
-- Table structure for offers
-- ----------------------------
DROP TABLE IF EXISTS `offers`;
CREATE TABLE `offers`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `description` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `id_course` int(3) NULL DEFAULT NULL,
  `date` date NULL DEFAULT NULL,
  `location` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `id_company` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `id_company`(`id_company`) USING BTREE,
  INDEX `id_course`(`id_course`) USING BTREE,
  CONSTRAINT `offers_ibfk_1` FOREIGN KEY (`id_company`) REFERENCES `companies` (`id_user`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `offers_ibfk_2` FOREIGN KEY (`id_course`) REFERENCES `course` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 12 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of offers
-- ----------------------------
INSERT INTO `offers` VALUES (1, 'softwareDeveloper', '5 años de experiencia', 1, '2025-01-31', 'salamanca', 11);
INSERT INTO `offers` VALUES (2, 'FrontDEV', 'remoto', 2, '2025-01-24', 'madrid', 11);
INSERT INTO `offers` VALUES (3, 'Junior Backend Developer', 'Trabajo híbrido con Node.js y MySQL', 1, '2025-02-10', 'Barcelona', 11);
INSERT INTO `offers` VALUES (4, 'Analista de Sistemas', 'Administración de servidores y redes', 2, '2025-02-15', 'Madrid', 11);
INSERT INTO `offers` VALUES (5, 'Marketing Digital', 'Estrategias de marketing y SEO', 3, '2025-02-20', 'Valencia', 11);
INSERT INTO `offers` VALUES (6, 'Desarrollador Full Stack', 'Se busca programador con experiencia en Angular y Node.js', 1, '2025-03-01', 'Madrid', 12);
INSERT INTO `offers` VALUES (7, 'Administrador de Sistemas', 'Mantenimiento de servidores y redes corporativas', 2, '2025-03-05', 'Barcelona', 13);
INSERT INTO `offers` VALUES (8, 'Especialista en Marketing Digital', 'Estrategias de SEO y SEM', 3, '2025-03-10', 'Madrid', 14);
INSERT INTO `offers` VALUES (9, 'Desarrollador Backend', 'Experiencia en Java y Spring Boot', 1, '2025-03-12', 'Bilbao', 15);
INSERT INTO `offers` VALUES (10, 'Especialista en Ciberseguridad', 'Seguridad en redes y sistemas', 2, '2025-03-15', 'Sevilla', 16);
INSERT INTO `offers` VALUES (11, 'Diseñador UX/UI', 'Experiencia en Figma y Adobe XD', 3, '2025-03-18', 'Madrid', 15);

-- ----------------------------
-- Table structure for students
-- ----------------------------
DROP TABLE IF EXISTS `students`;
CREATE TABLE `students`  (
  `id_user` int(11) NOT NULL AUTO_INCREMENT,
  `nie` varchar(11) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `surname` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `gendre` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `birthdate` date NULL DEFAULT NULL,
  `phone` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `emer_phone` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `nationality` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `car` tinyint(4) NULL DEFAULT NULL,
  `address` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `year` int(11) NULL DEFAULT NULL,
  `register_date` date NULL DEFAULT NULL,
  `cv` tinyint(4) NULL DEFAULT NULL,
  PRIMARY KEY (`id_user`) USING BTREE,
  CONSTRAINT `students_ibfk_1` FOREIGN KEY (`id_user`) REFERENCES `users` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 11 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of students
-- ----------------------------
INSERT INTO `students` VALUES (3, '8765454a', 'Diego', 'Martin', 'Hombre', '1989-07-08', '555666555', '666555666', 'Español', 1, 'calle falsa. 123', 2025, '2025-01-25', 1);
INSERT INTO `students` VALUES (4, '23456t', 'TurboDiego', 'Senovilla', 'Hombre', '1992-06-12', '666666666', '666666665', 'Español', 1, NULL, NULL, NULL, NULL);
INSERT INTO `students` VALUES (5, '12345678X', 'Juan', 'González', 'Hombre', '2001-05-12', '600123456', '699654321', 'Español', 1, 'Calle Falsa 123, Salamanca', 2025, '2025-02-01', 1);
INSERT INTO `students` VALUES (6, '87654321Y', 'María', 'Fernández', 'Mujer', '2000-09-20', '611223344', '688776655', 'Español', 1, 'Avenida Central 45, Madrid', 2024, '2025-02-02', 1);
INSERT INTO `students` VALUES (7, '56789012Z', 'Carlos', 'López', 'Hombre', '2002-02-15', '622334455', '677889900', 'Español', 0, 'Paseo de la Estación 78, Barcelona', 2025, '2025-02-03', 1);
INSERT INTO `students` VALUES (8, '23456789A', 'Luis', 'Martínez', 'Hombre', '2001-04-14', '633445566', '644556677', 'Español', 1, 'Calle Comercio 33, Bilbao', 2025, '2025-02-08', 1);
INSERT INTO `students` VALUES (9, '34567890B', 'Andrea', 'Pérez', 'Mujer', '2000-08-30', '622556677', '611223344', 'Español', 1, 'Avenida Libertad 50, Valencia', 2024, '2025-02-08', 1);
INSERT INTO `students` VALUES (10, '45678901C', 'Roberto', 'Sánchez', 'Hombre', '1999-12-11', '611778899', '699887766', 'Español', 0, 'Paseo Innovación 12, Sevilla', 2025, '2025-02-08', 1);

-- ----------------------------
-- Table structure for students_courses
-- ----------------------------
DROP TABLE IF EXISTS `students_courses`;
CREATE TABLE `students_courses`  (
  `id_course` int(11) NULL DEFAULT NULL,
  `id_student` int(11) NULL DEFAULT NULL,
  INDEX `id_course`(`id_course`) USING BTREE,
  INDEX `id_student`(`id_student`) USING BTREE,
  CONSTRAINT `students_courses_ibfk_1` FOREIGN KEY (`id_course`) REFERENCES `course` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `students_courses_ibfk_2` FOREIGN KEY (`id_student`) REFERENCES `students` (`id_user`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of students_courses
-- ----------------------------
INSERT INTO `students_courses` VALUES (3, 3);
INSERT INTO `students_courses` VALUES (1, 3);
INSERT INTO `students_courses` VALUES (2, 3);
INSERT INTO `students_courses` VALUES (1, 5);
INSERT INTO `students_courses` VALUES (2, 6);
INSERT INTO `students_courses` VALUES (3, 7);
INSERT INTO `students_courses` VALUES (1, 8);
INSERT INTO `students_courses` VALUES (2, 9);
INSERT INTO `students_courses` VALUES (3, 10);

-- ----------------------------
-- Table structure for students_offers
-- ----------------------------
DROP TABLE IF EXISTS `students_offers`;
CREATE TABLE `students_offers`  (
  `id_user` int(11) NULL DEFAULT NULL,
  `id_offer` int(11) NULL DEFAULT NULL,
  `presentation` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `status` tinyint(4) NULL DEFAULT NULL,
  `date` date NULL DEFAULT NULL,
  INDEX `id_user`(`id_user`) USING BTREE,
  INDEX `students_offers_ibfk_2`(`id_offer`) USING BTREE,
  CONSTRAINT `students_offers_ibfk_1` FOREIGN KEY (`id_user`) REFERENCES `students` (`id_user`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `students_offers_ibfk_2` FOREIGN KEY (`id_offer`) REFERENCES `offers` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of students_offers
-- ----------------------------
INSERT INTO `students_offers` VALUES (3, 1, 'Ganas de trabajar', 1, '2025-02-06');
INSERT INTO `students_offers` VALUES (4, 2, 'Amo ASPNET', 1, '2025-02-04');
INSERT INTO `students_offers` VALUES (5, 6, 'Soy un apasionado del desarrollo y tengo experiencia en Node.js y Angular', 1, '2025-02-07');
INSERT INTO `students_offers` VALUES (6, 7, 'Me encanta la administración de sistemas y cuento con certificaciones en redes', 1, '2025-02-07');
INSERT INTO `students_offers` VALUES (7, 8, 'Tengo experiencia en campañas de marketing digital y SEO avanzado', 1, '2025-02-07');
INSERT INTO `students_offers` VALUES (8, 9, 'Tengo experiencia en Java y microservicios con Spring Boot', 1, '2025-02-08');
INSERT INTO `students_offers` VALUES (9, 10, 'Me apasiona la ciberseguridad y tengo certificaciones en redes', 1, '2025-02-08');
INSERT INTO `students_offers` VALUES (10, 11, 'Soy creativo y tengo experiencia en diseño UX/UI', 1, '2025-02-08');

-- ----------------------------
-- Table structure for users
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `email` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `password` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `status` tinyint(4) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 17 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of users
-- ----------------------------
INSERT INTO `users` VALUES (1, 'pepito@gmail.com', 'pass', NULL);
INSERT INTO `users` VALUES (3, 'alumno', 'pass', 0);
INSERT INTO `users` VALUES (4, 'alumno2', 'pass', 0);
INSERT INTO `users` VALUES (5, 'alumno3', 'pass', 1);
INSERT INTO `users` VALUES (6, 'alumno4', 'pass', 1);
INSERT INTO `users` VALUES (7, 'alumno5', 'pass', 1);
INSERT INTO `users` VALUES (8, 'alumno6', 'pass', 0);
INSERT INTO `users` VALUES (9, 'alumno7', 'pass', 0);
INSERT INTO `users` VALUES (10, 'alumno8', 'pass', 0);
INSERT INTO `users` VALUES (11, 'empresa', 'pass', 0);
INSERT INTO `users` VALUES (12, 'empresa2', 'pass', 1);
INSERT INTO `users` VALUES (13, 'empresa3', 'pass', 1);
INSERT INTO `users` VALUES (14, 'empresa4', 'pass', 1);
INSERT INTO `users` VALUES (15, 'empresa5', 'pass', 1);
INSERT INTO `users` VALUES (16, 'empresa6', 'pass', 1);

SET FOREIGN_KEY_CHECKS = 1;
