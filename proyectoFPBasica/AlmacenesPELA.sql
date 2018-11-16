

CREATE DATABASE IF NOT EXISTS `AlmacenesPELA`;
USE `AlmacenesPELA`;

CREATE TABLE `cliente` (
  `Nif` NVARCHAR(255) NOT NULL,
  `Nombre` NVARCHAR(255) NULL,
  `Direccion` NVARCHAR(255) NULL,
  `LugarEntrega` NVARCHAR(255) NULL,
  PRIMARY KEY (`Nif`));
  
CREATE TABLE `empresa` (
  `Nif` NVARCHAR(255) NOT NULL,
  `Nombre` NVARCHAR(255) NULL,
  `Direccion` NVARCHAR(255) NULL,
  `Logo` NVARCHAR(255) NULL,
  PRIMARY KEY (`Nif`));

  
CREATE TABLE `tipodeseguro` (
  `Tipo` NVARCHAR(255) NOT NULL,
  PRIMARY KEY (`Tipo`));

CREATE TABLE `tipodeenvio` (
  `TipoEnvio` NVARCHAR(255) NOT NULL,
  `Plus` NVARCHAR(255) NULL,
  PRIMARY KEY (`TipoEnvio`));

CREATE TABLE `posibledescuentp` (
  `Decripcion` NVARCHAR(255) NOT NULL,
  `Porcentaje` NVARCHAR(255) NULL,
  PRIMARY KEY (`Decripcion`));

CREATE TABLE `usuario` (
  `IdUsuario` NVARCHAR(255) NOT NULL,
  `Password` NVARCHAR(255) NULL,
  `Nombre` NVARCHAR(255) NULL,
  `Foto` NVARCHAR(255) NULL,
  PRIMARY KEY (`IdUsuario`));

CREATE TABLE `familia` (
  `IdFamilia` NVARCHAR(255) NOT NULL,
  `Nombre` NVARCHAR(255) NULL,
  `Descripcion` NVARCHAR(255) NULL,
  PRIMARY KEY (`IdFamilia`));

CREATE TABLE `subfamilia` (
  `IdFamilia` NVARCHAR(255) NOT NULL,
  `IdSubFamilia` NVARCHAR(255) NOT NULL,
  `Nombre` NVARCHAR(255) NULL,
  `Descripcion` NVARCHAR(255) NULL,
  PRIMARY KEY (`IdFamilia`, `IdSubFamilia`));

ALTER TABLE `subfamilia`
ADD CONSTRAINT `FK_subfamilia_familia` 
FOREIGN KEY (`IdFamilia`) REFERENCES `familia`(`IdFamilia`);

CREATE TABLE `formadepago` (
  `CodPago` INT NOT NULL AUTO_INCREMENT,
  `Tipo` NVARCHAR(255) NULL,
  PRIMARY KEY (`CodPago`));
  
  CREATE TABLE `subformadepago` (
  `CodPago` INT NOT NULL,
  `SubTipo` NVARCHAR(255) NOT NULL,
  PRIMARY KEY (`CodPago`, `SubTipo`));

ALTER TABLE `subformadepago`
ADD CONSTRAINT `FK_subformadepago_formadepago` 
FOREIGN KEY (`CodPago`) REFERENCES `formadepago`(`CodPago`);

CREATE TABLE `estanteria` (
  `idEstanteria` NVARCHAR(255) NOT NULL,
  `NumAltura` NVARCHAR(255) NULL,
  `EstanteAltura` NVARCHAR(255) NULL,
  PRIMARY KEY (`idEstanteria`));

CREATE TABLE `estante` (
  `IdEstanteria` NVARCHAR(255) NOT NULL,
  `Altura` NVARCHAR(255) NOT NULL,
  `Estante` NVARCHAR(255) NOT NULL,
  PRIMARY KEY (`IdEstanteria`, `Altura`, `Estante`));
  
  CREATE TABLE `producto-estante` (
  `CodProducto` NVARCHAR(255) NOT NULL,
  `IdEstanteria` NVARCHAR(255) NOT NULL,
  `Altura` NVARCHAR(255) NOT NULL,
  `Estante` NVARCHAR(255) NOT NULL,
  PRIMARY KEY (`CodProducto`, `IdEstanteria`, `Altura`, `Estante`));

CREATE TABLE `producto` (
  `CodProducto` NVARCHAR(255) NOT NULL,
  `CodBarras` NVARCHAR(255) NULL,
  `Descripcion` NVARCHAR(255) NULL,
  `IdMArca` INT NULL,
  `Precio` DECIMAL NULL,
  `Stock` INT NULL,
  `Medida` INT NULL,
  PRIMARY KEY (`CodProducto`));
  
  CREATE TABLE `marca` (
  `IdMarca` INT NOT NULL AUTO_INCREMENT,
  `Nombre` NVARCHAR(255) NULL,
  PRIMARY KEY (`IdMarca`));

ALTER TABLE `estante`
ADD CONSTRAINT `FK_estante_estanteria` 
FOREIGN KEY (`IdEstanteria`) REFERENCES `estanteria`(`IdEstanteria`);

ALTER TABLE `producto-estante`
ADD CONSTRAINT `FK_productoestante_estante` 
FOREIGN KEY (`IdEstanteria`, `Altura`, `Estante`) REFERENCES `estante`(`IdEstanteria`, `Altura`, `Estante`);



ALTER TABLE `producto-estante`
ADD CONSTRAINT `FK_producto-estante_producto` 
FOREIGN KEY (`CodProducto`) REFERENCES `producto`(`CodProducto`);

ALTER TABLE `producto`
ADD CONSTRAINT `FK_producto_marca` 
FOREIGN KEY (`IdMarca`) REFERENCES `marca`(`IdMarca`);