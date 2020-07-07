-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema soport43_MiNegocio
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema soport43_MiNegocio
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `soport43_MiNegocio` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
USE `soport43_MiNegocio` ;

-- -----------------------------------------------------
-- Table `soport43_MiNegocio`.`TbCliente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `soport43_MiNegocio`.`TbCliente` (
  `DocId` VARCHAR(15) NOT NULL,
  `Nombres` VARCHAR(30) NOT NULL,
  `Apellidos` VARCHAR(50) NOT NULL,
  `Direccion` VARCHAR(60) NULL,
  `Telefono` VARCHAR(12) NULL,
  `TelAlternativo` VARCHAR(12) NULL,
  `Email` VARCHAR(60) NULL,
  `Estado` TINYINT NOT NULL,
  `CodRecuperacion` VARCHAR(6) NULL,
  `Fecha` DATETIME NOT NULL,
  PRIMARY KEY (`DocId`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `soport43_MiNegocio`.`TbPerfil`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `soport43_MiNegocio`.`TbPerfil` (
  `IdPerfil` INT(1) NOT NULL,
  `Perfil` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`IdPerfil`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `soport43_MiNegocio`.`TbUsuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `soport43_MiNegocio`.`TbUsuario` (
  `DocId` VARCHAR(15) NOT NULL,
  `Nombres` VARCHAR(30) NOT NULL,
  `Apellidos` VARCHAR(50) NOT NULL,
  `Direccion` VARCHAR(60) NOT NULL,
  `Telefono` VARCHAR(12) NOT NULL,
  `User` VARCHAR(20) NOT NULL,
  `Pass` VARCHAR(60) NOT NULL,
  `IdPerfil` INT(1) NOT NULL,
  `Estado` TINYINT NOT NULL,
  `CodigoRecuperacion` VARCHAR(6) NULL,
  `Fecha` DATETIME NOT NULL,
  PRIMARY KEY (`DocId`),
  INDEX `fk_TbUsuario_TbPerfil_idx` (`IdPerfil` ASC) VISIBLE,
  CONSTRAINT `fk_TbUsuario_TbPerfil`
    FOREIGN KEY (`IdPerfil`)
    REFERENCES `soport43_MiNegocio`.`TbPerfil` (`IdPerfil`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `soport43_MiNegocio`.`TbMarca`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `soport43_MiNegocio`.`TbMarca` (
  `IdMarca` INT NOT NULL AUTO_INCREMENT,
  `Marca` VARCHAR(30) NOT NULL,
  PRIMARY KEY (`IdMarca`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `soport43_MiNegocio`.`TbTipoEquipo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `soport43_MiNegocio`.`TbTipoEquipo` (
  `IdTipoEquipo` INT NOT NULL AUTO_INCREMENT,
  `TipoEquipo` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`IdTipoEquipo`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `soport43_MiNegocio`.`TbModelo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `soport43_MiNegocio`.`TbModelo` (
  `IdModelo` INT NOT NULL,
  `Modelo` VARCHAR(30) NOT NULL,
  `Marca` INT NOT NULL,
  `TipoEquipo` INT NOT NULL,
  PRIMARY KEY (`IdModelo`),
  INDEX `fk_TbModelo_TbMarca1_idx` (`Marca` ASC) VISIBLE,
  INDEX `fk_TbModelo_TbTipoEquipo1_idx` (`TipoEquipo` ASC) VISIBLE,
  CONSTRAINT `fk_TbModelo_TbMarca1`
    FOREIGN KEY (`Marca`)
    REFERENCES `soport43_MiNegocio`.`TbMarca` (`IdMarca`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_TbModelo_TbTipoEquipo1`
    FOREIGN KEY (`TipoEquipo`)
    REFERENCES `soport43_MiNegocio`.`TbTipoEquipo` (`IdTipoEquipo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `soport43_MiNegocio`.`TbEquipo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `soport43_MiNegocio`.`TbEquipo` (
  `IdEquipo` INT NOT NULL AUTO_INCREMENT,
  `Fecha` DATETIME NOT NULL,
  `IdCliente` VARCHAR(15) NOT NULL,
  `IdModelo` INT NOT NULL,
  `Serie` VARCHAR(30) NULL,
  `Imei1` VARCHAR(17) NULL,
  `Imei2` VARCHAR(17) NULL,
  `Color` VARCHAR(15) NULL,
  `Observacion` VARCHAR(1000) NULL,
  PRIMARY KEY (`IdEquipo`),
  UNIQUE INDEX `Imei1_UNIQUE` (`Imei1` ASC) VISIBLE,
  UNIQUE INDEX `Imei2_UNIQUE` (`Imei2` ASC) VISIBLE,
  INDEX `fk_TbEquipo_TbCliente1_idx` (`IdCliente` ASC) VISIBLE,
  INDEX `fk_TbEquipo_TbModelo1_idx` (`IdModelo` ASC) VISIBLE,
  CONSTRAINT `fk_TbEquipo_TbCliente1`
    FOREIGN KEY (`IdCliente`)
    REFERENCES `soport43_MiNegocio`.`TbCliente` (`DocId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_TbEquipo_TbModelo1`
    FOREIGN KEY (`IdModelo`)
    REFERENCES `soport43_MiNegocio`.`TbModelo` (`IdModelo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `soport43_MiNegocio`.`TbEstadoOrden`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `soport43_MiNegocio`.`TbEstadoOrden` (
  `IdEstadoOrden` INT NOT NULL AUTO_INCREMENT,
  `EstadoOrden` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`IdEstadoOrden`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `soport43_MiNegocio`.`TbOrden`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `soport43_MiNegocio`.`TbOrden` (
  `IdOrden` INT NOT NULL AUTO_INCREMENT,
  `FechaEntra` DATETIME NOT NULL,
  `FechaRevision` DATETIME NOT NULL,
  `FechaSale` DATETIME NOT NULL,
  `IdCliente` VARCHAR(15) NOT NULL,
  `IdEquipo` INT NOT NULL,
  `IdEstadoOrden` INT(3) NOT NULL,
  `MicroSD` TINYINT NULL,
  `SIM` TINYINT NULL,
  `DatosBloqueo` VARCHAR(30) NULL,
  `Foto` VARCHAR(260) NULL,
  `DiagnosticoCliente` VARCHAR(2000) NOT NULL,
  `DiagnosticoTecnico` VARCHAR(2000) NULL,
  `Presupuesto` INT NULL,
  `Ubicacion` VARCHAR(20) NULL,
  `IdUsuario` VARCHAR(15) NOT NULL,
  PRIMARY KEY (`IdOrden`),
  INDEX `fk_TbOrden_TbUsuario1_idx` (`IdUsuario` ASC) VISIBLE,
  INDEX `fk_TbOrden_TbEquipo1_idx` (`IdEquipo` ASC) VISIBLE,
  INDEX `fk_TbOrden_TbCliente1_idx` (`IdCliente` ASC) VISIBLE,
  INDEX `fk_TbOrden_TbEstadoOrden1_idx` (`IdEstadoOrden` ASC) VISIBLE,
  CONSTRAINT `fk_TbOrden_TbUsuario1`
    FOREIGN KEY (`IdUsuario`)
    REFERENCES `soport43_MiNegocio`.`TbUsuario` (`DocId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_TbOrden_TbEquipo1`
    FOREIGN KEY (`IdEquipo`)
    REFERENCES `soport43_MiNegocio`.`TbEquipo` (`IdEquipo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_TbOrden_TbCliente1`
    FOREIGN KEY (`IdCliente`)
    REFERENCES `soport43_MiNegocio`.`TbCliente` (`DocId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_TbOrden_TbEstadoOrden1`
    FOREIGN KEY (`IdEstadoOrden`)
    REFERENCES `soport43_MiNegocio`.`TbEstadoOrden` (`IdEstadoOrden`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `soport43_MiNegocio`.`TbTipoProducto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `soport43_MiNegocio`.`TbTipoProducto` (
  `IdTipoProducto` INT(3) NOT NULL,
  `TipoProducto` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`IdTipoProducto`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `soport43_MiNegocio`.`TbProveedor`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `soport43_MiNegocio`.`TbProveedor` (
  `IdProveedor` VARCHAR(20) NOT NULL,
  `Proveedor` VARCHAR(60) NOT NULL,
  `Telefono` VARCHAR(12) NOT NULL,
  `Direccion` VARCHAR(90) NULL,
  `Email` VARCHAR(60) NULL,
  `Estado` TINYINT NOT NULL,
  `Fecha` DATETIME NOT NULL,
  PRIMARY KEY (`IdProveedor`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `soport43_MiNegocio`.`TbProducto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `soport43_MiNegocio`.`TbProducto` (
  `IdProducto` VARCHAR(20) NOT NULL,
  `Serie` VARCHAR(20) NULL,
  `Producto` VARCHAR(70) NOT NULL,
  `Costo` INT NOT NULL,
  `VlrVenta` INT NOT NULL,
  `StockMinimo` INT NOT NULL,
  `StockMaximo` INT NOT NULL,
  `Existencia` INT NOT NULL,
  `IdTipoProducto` INT(3) NOT NULL,
  `IdModelo` INT NOT NULL,
  `IdProveedor` VARCHAR(20) NOT NULL,
  `Fecha` DATETIME NOT NULL,
  PRIMARY KEY (`IdProducto`),
  INDEX `fk_TbProducto_TbTipoProducto1_idx` (`IdTipoProducto` ASC) VISIBLE,
  INDEX `fk_TbProducto_TbModelo1_idx` (`IdModelo` ASC) VISIBLE,
  INDEX `fk_TbProducto_TbProveedor1_idx` (`IdProveedor` ASC) VISIBLE,
  CONSTRAINT `fk_TbProducto_TbTipoProducto1`
    FOREIGN KEY (`IdTipoProducto`)
    REFERENCES `soport43_MiNegocio`.`TbTipoProducto` (`IdTipoProducto`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_TbProducto_TbModelo1`
    FOREIGN KEY (`IdModelo`)
    REFERENCES `soport43_MiNegocio`.`TbModelo` (`IdModelo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_TbProducto_TbProveedor1`
    FOREIGN KEY (`IdProveedor`)
    REFERENCES `soport43_MiNegocio`.`TbProveedor` (`IdProveedor`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `soport43_MiNegocio`.`TbFormaPago`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `soport43_MiNegocio`.`TbFormaPago` (
  `IdFormaPago` INT(2) NOT NULL,
  `FormaPago` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`IdFormaPago`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `soport43_MiNegocio`.`TbVenta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `soport43_MiNegocio`.`TbVenta` (
  `IdVenta` INT NOT NULL AUTO_INCREMENT,
  `IdCliente` VARCHAR(15) NOT NULL,
  `Fecha` DATETIME NOT NULL,
  `IdOrden` INT NULL,
  `IdFormaPago` INT(2) NOT NULL,
  `IdUsuario` VARCHAR(15) NOT NULL,
  `Observaciones` VARCHAR(2000) NULL,
  PRIMARY KEY (`IdVenta`),
  INDEX `fk_TbVenta_TbUsuario1_idx` (`IdUsuario` ASC) VISIBLE,
  INDEX `fk_TbVenta_TbFormaPago1_idx` (`IdFormaPago` ASC) VISIBLE,
  INDEX `fk_TbVenta_TbOrden1_idx` (`IdOrden` ASC) VISIBLE,
  CONSTRAINT `fk_TbVenta_TbUsuario1`
    FOREIGN KEY (`IdUsuario`)
    REFERENCES `soport43_MiNegocio`.`TbUsuario` (`DocId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_TbVenta_TbFormaPago1`
    FOREIGN KEY (`IdFormaPago`)
    REFERENCES `soport43_MiNegocio`.`TbFormaPago` (`IdFormaPago`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_TbVenta_TbOrden1`
    FOREIGN KEY (`IdOrden`)
    REFERENCES `soport43_MiNegocio`.`TbOrden` (`IdOrden`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `soport43_MiNegocio`.`TbVentaProducto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `soport43_MiNegocio`.`TbVentaProducto` (
  `IdVenta` INT NOT NULL,
  `IdProducto` VARCHAR(20) NOT NULL,
  `Cantidad` INT NOT NULL,
  `VlrProducto` INT NOT NULL,
  `Descuento` INT NOT NULL,
  PRIMARY KEY (`IdVenta`, `IdProducto`),
  INDEX `fk_TbVentaProducto_TbProducto1_idx` (`IdProducto` ASC) VISIBLE,
  CONSTRAINT `fk_TbVentaProducto_TbVenta1`
    FOREIGN KEY (`IdVenta`)
    REFERENCES `soport43_MiNegocio`.`TbVenta` (`IdVenta`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_TbVentaProducto_TbProducto1`
    FOREIGN KEY (`IdProducto`)
    REFERENCES `soport43_MiNegocio`.`TbProducto` (`IdProducto`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `soport43_MiNegocio`.`TbTipoServicio`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `soport43_MiNegocio`.`TbTipoServicio` (
  `IdTipoServicio` INT NOT NULL,
  `TipoServicio` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`IdTipoServicio`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `soport43_MiNegocio`.`TbServicio`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `soport43_MiNegocio`.`TbServicio` (
  `IdServicio` INT NOT NULL AUTO_INCREMENT,
  `Servicio` VARCHAR(70) NOT NULL,
  `IdTipoServicio` INT NOT NULL,
  `VlrServicio` INT NOT NULL,
  PRIMARY KEY (`IdServicio`),
  INDEX `fk_TbServicio_TbTipoServicio1_idx` (`IdTipoServicio` ASC) VISIBLE,
  CONSTRAINT `fk_TbServicio_TbTipoServicio1`
    FOREIGN KEY (`IdTipoServicio`)
    REFERENCES `soport43_MiNegocio`.`TbTipoServicio` (`IdTipoServicio`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `soport43_MiNegocio`.`TbVentaServicio`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `soport43_MiNegocio`.`TbVentaServicio` (
  `IdVenta` INT NOT NULL,
  `IdServicio` INT NOT NULL,
  `VlrServicio` INT NOT NULL,
  `Cantidad` INT NOT NULL,
  `Descuento` INT NOT NULL,
  PRIMARY KEY (`IdVenta`, `IdServicio`),
  INDEX `fk_TbVentaServicio_TbServicio1_idx` (`IdServicio` ASC) VISIBLE,
  CONSTRAINT `fk_TbVentaServicio_TbServicio1`
    FOREIGN KEY (`IdServicio`)
    REFERENCES `soport43_MiNegocio`.`TbServicio` (`IdServicio`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_TbVentaServicio_TbVenta1`
    FOREIGN KEY (`IdVenta`)
    REFERENCES `soport43_MiNegocio`.`TbVenta` (`IdVenta`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `soport43_MiNegocio`.`TbUsuarioOrden`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `soport43_MiNegocio`.`TbUsuarioOrden` (
  `IdUsuario` VARCHAR(15) NOT NULL,
  `IdOrden` INT NOT NULL,
  PRIMARY KEY (`IdUsuario`, `IdOrden`),
  INDEX `fk_TbUsuarioOrden_TbOrden1_idx` (`IdOrden` ASC) VISIBLE,
  CONSTRAINT `fk_TbUsuarioOrden_TbOrden1`
    FOREIGN KEY (`IdOrden`)
    REFERENCES `soport43_MiNegocio`.`TbOrden` (`IdOrden`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_TbUsuarioOrden_TbUsuario1`
    FOREIGN KEY (`IdUsuario`)
    REFERENCES `soport43_MiNegocio`.`TbUsuario` (`DocId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `soport43_MiNegocio`.`TbConcepto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `soport43_MiNegocio`.`TbConcepto` (
  `IdConcepto` INT NOT NULL AUTO_INCREMENT,
  `Concepto` VARCHAR(30) NOT NULL,
  PRIMARY KEY (`IdConcepto`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `soport43_MiNegocio`.`TbEgreso`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `soport43_MiNegocio`.`TbEgreso` (
  `IdEgreso` INT NOT NULL AUTO_INCREMENT,
  `Fecha` DATETIME NOT NULL,
  `FormaPago` INT(2) NOT NULL,
  `CtaxPagar` INT NOT NULL,
  `IdUsuario` VARCHAR(15) NOT NULL,
  `Observaciones` VARCHAR(2000) NULL,
  PRIMARY KEY (`IdEgreso`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `soport43_MiNegocio`.`TbEgresoConcepto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `soport43_MiNegocio`.`TbEgresoConcepto` (
  `IdEgreso` INT NOT NULL,
  `IdConcepto` INT NOT NULL,
  `VlrUnitario` INT NOT NULL,
  `Cantidad` INT NOT NULL,
  `Descuento` INT NULL,
  `Observaciones` VARCHAR(2000) NULL,
  PRIMARY KEY (`IdEgreso`, `IdConcepto`),
  INDEX `fk_TbEgresoConcepto_TbConcepto1_idx` (`IdConcepto` ASC) VISIBLE,
  CONSTRAINT `fk_TbEgresoConcepto_TbEgreso1`
    FOREIGN KEY (`IdEgreso`)
    REFERENCES `soport43_MiNegocio`.`TbEgreso` (`IdEgreso`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_TbEgresoConcepto_TbConcepto1`
    FOREIGN KEY (`IdConcepto`)
    REFERENCES `soport43_MiNegocio`.`TbConcepto` (`IdConcepto`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `soport43_MiNegocio`.`TbEstadoCompra`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `soport43_MiNegocio`.`TbEstadoCompra` (
  `IdEstadoCompra` INT(2) NOT NULL,
  `Estado` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`IdEstadoCompra`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `soport43_MiNegocio`.`TbCompra`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `soport43_MiNegocio`.`TbCompra` (
  `IdCompra` INT NOT NULL AUTO_INCREMENT,
  `Fecha` DATE NOT NULL,
  `IdProveedor` VARCHAR(20) NOT NULL,
  `NFactura` VARCHAR(20) NULL,
  `IdEstadoCompra` INT(2) NOT NULL,
  `Observaciones` VARCHAR(2000) NULL,
  `IdUsuario` VARCHAR(15) NOT NULL,
  PRIMARY KEY (`IdCompra`),
  INDEX `fk_TbCompra_TbProveedor1_idx` (`IdProveedor` ASC) VISIBLE,
  INDEX `fk_TbCompra_TbUsuario1_idx` (`IdUsuario` ASC) VISIBLE,
  INDEX `fk_TbCompra_TbEstadoCompra1_idx` (`IdEstadoCompra` ASC) VISIBLE,
  CONSTRAINT `fk_TbCompra_TbProveedor1`
    FOREIGN KEY (`IdProveedor`)
    REFERENCES `soport43_MiNegocio`.`TbProveedor` (`IdProveedor`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_TbCompra_TbUsuario1`
    FOREIGN KEY (`IdUsuario`)
    REFERENCES `soport43_MiNegocio`.`TbUsuario` (`DocId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_TbCompra_TbEstadoCompra1`
    FOREIGN KEY (`IdEstadoCompra`)
    REFERENCES `soport43_MiNegocio`.`TbEstadoCompra` (`IdEstadoCompra`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `soport43_MiNegocio`.`TbVentaAnulada`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `soport43_MiNegocio`.`TbVentaAnulada` (
  `Consecutivo` INT NOT NULL AUTO_INCREMENT,
  `IdVenta` INT NOT NULL,
  `Fecha` DATETIME NOT NULL,
  `Usuario` VARCHAR(15) NOT NULL,
  `Observaciones` VARCHAR(2000) NULL,
  `IdServicio` INT NULL,
  `IdProducto` VARCHAR(20) NULL,
  `CantidadServicio` INT NULL,
  `CantidadProducto` INT NULL,
  PRIMARY KEY (`Consecutivo`),
  UNIQUE INDEX `IdVEnta_UNIQUE` (`IdVenta` ASC) VISIBLE,
  CONSTRAINT `fk_TbVentaAnulada_TbVenta1`
    FOREIGN KEY (`IdVenta`)
    REFERENCES `soport43_MiNegocio`.`TbVenta` (`IdVenta`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `soport43_MiNegocio`.`TbTipoEquipoMarca`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `soport43_MiNegocio`.`TbTipoEquipoMarca` (
  `IdTipoEquipo` INT NOT NULL,
  `IdMarca` INT NOT NULL,
  PRIMARY KEY (`IdTipoEquipo`, `IdMarca`),
  INDEX `fk_TbTipoEquipoMarca_TbMarca1_idx` (`IdMarca` ASC) VISIBLE,
  CONSTRAINT `fk_TbTipoEquipoMarca_TbMarca1`
    FOREIGN KEY (`IdMarca`)
    REFERENCES `soport43_MiNegocio`.`TbMarca` (`IdMarca`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_TbTipoEquipoMarca_TbTipoEquipo1`
    FOREIGN KEY (`IdTipoEquipo`)
    REFERENCES `soport43_MiNegocio`.`TbTipoEquipo` (`IdTipoEquipo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
