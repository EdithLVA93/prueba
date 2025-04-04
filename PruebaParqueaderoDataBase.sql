USE [master]
GO

-- Verifica si la base de datos ya existe
IF DB_ID('PruebaParqueadero') IS NOT NULL
DROP DATABASE [PruebaParqueadero]
GO

CREATE DATABASE [PruebaParqueadero]
ON PRIMARY 
( NAME = N'PruebaParqueadero', 
  FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\PruebaParqueadero.mdf', 
  SIZE = 8192KB, MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB ) 
LOG ON 
( NAME = N'PruebaParqueadero_log', 
  FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\PruebaParqueadero_log.ldf', 
  SIZE = 8192KB, MAXSIZE = 2048GB, FILEGROWTH = 65536KB ) 
GO

ALTER DATABASE [PruebaParqueadero] SET COMPATIBILITY_LEVEL = 160
GO

USE [PruebaParqueadero]
GO

-- Creación de la tabla de Roles
CREATE TABLE [dbo].[Roles](
   [IdRol] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[NombreRol] [varchar](50) NULL,
	[EstadoRol] [bit] NULL,
	[UsuarioCreacion] [varchar](50) NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioActualizacion] [varchar](50) NULL,
	[FechaActualizacion] [datetime] NULL
)ON [PRIMARY]
GO

-- Creación de la tabla de Usuarios
CREATE TABLE [dbo].[Usuarios](
  [IdUsuario] [int]IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[NombreUsuario] [varchar](50) NOT NULL,
	[IdRol] [int] NULL,
	[Contrasena] [varchar](255) NOT NULL,
	[EstadoUsuario] [bit] NOT NULL,
	[UsuarioCreacion] [varchar](50) NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioActualizacion] [varchar](50) NULL,
	[FechaActualizacion] [datetime] NULL
    CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY([IdRol]) REFERENCES [dbo].[Roles]([IdRol])
)ON [PRIMARY]
GO

-- Creación de la tabla de Tipos de Vehículos
CREATE TABLE [dbo].[TiposVehiculos](
   [IdTipoVehiculo] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[NombreTipoVehiculo] [varchar](50) NULL,
	[TarifaPorMinuto] [decimal](18, 2) NULL,
	[EstadoTipoVehiculo] [bit] NULL,
	[UsuarioCreacion] [varchar](50) NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioActualizacion] [varchar](50) NULL,
	[FechaActualizacion] [datetime] NULL
)ON [PRIMARY]
GO

-- Creación de la tabla de Vehículos
CREATE TABLE [dbo].[Vehiculos](
   [IdVehiculo] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[IdTipoVehiculo] [int] NULL,
	[Placa] [varchar](10) NULL,
	[EstadoVehiculo] [bit] NULL,
	[UsuarioCreacion] [varchar](50) NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioActualizacion] [varchar](50) NULL,
	[FechaActualizacion] [datetime] NULL
    CONSTRAINT [FK_Vehiculos_TiposVehiculos] FOREIGN KEY([IdTipoVehiculo]) REFERENCES [dbo].[TiposVehiculos]([IdTipoVehiculo])
)ON [PRIMARY]
GO

-- Creación de la tabla de Supermercados
CREATE TABLE [dbo].[Supermercados](
   [IdSupermercado] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[NombreSupermercado] [varchar](100) NULL,
	[EstadoSupermercado] [bit] NULL,
	[PorcentajeDescuento] [decimal](18, 2) NULL,
	[UsuarioCreacion] [varchar](50) NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioActualizacion] [varchar](50) NULL,
	[FechaActualizacion] [datetime] NULL
)ON [PRIMARY]
GO

-- Creación de la tabla de Registros de Vehículos
CREATE TABLE [dbo].[RegistrosVehiculos](
   [IdRegistroVehiculo] [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[IdSupermercado] [int] NULL,
	[IdVehiculo] [int] NOT NULL,
	[NumeroFactura] [varchar](255) NULL,
	[FechaEntrada] [datetime] NOT NULL,
	[FechaSalida] [datetime] NOT NULL,
	[TotalPagado] [decimal](18, 2) NOT NULL,
	[EstadoRegistroVehiculo] [bit] NULL,
	[UsuarioCreacion] [varchar](50) NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioActualizacion] [varchar](50) NULL,
	[FechaActualizacion] [datetime] NULL
    CONSTRAINT [FK_RegistrosVehiculos_Supermercados] FOREIGN KEY([IdSupermercado]) REFERENCES [dbo].[Supermercados]([IdSupermercado]),
    CONSTRAINT [FK_RegistrosVehiculos_Vehiculos] FOREIGN KEY([IdVehiculo]) REFERENCES [dbo].[Vehiculos]([IdVehiculo])
) ON [PRIMARY]
GO

-- Habilitar la base de datos para escritura
ALTER DATABASE [PruebaParqueadero] SET READ_WRITE
GO
