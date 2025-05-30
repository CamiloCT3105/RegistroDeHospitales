USE [master]
GO
/****** Object:  Database [RegistroDeHospitales]    Script Date: 20-05-2025 1:35:40 ******/
CREATE DATABASE [RegistroDeHospitales]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RegistroDeHospitales', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\RegistroDeHospitales.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RegistroDeHospitales_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\RegistroDeHospitales_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [RegistroDeHospitales] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RegistroDeHospitales].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RegistroDeHospitales] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RegistroDeHospitales] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RegistroDeHospitales] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RegistroDeHospitales] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RegistroDeHospitales] SET ARITHABORT OFF 
GO
ALTER DATABASE [RegistroDeHospitales] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [RegistroDeHospitales] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RegistroDeHospitales] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RegistroDeHospitales] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RegistroDeHospitales] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RegistroDeHospitales] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RegistroDeHospitales] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RegistroDeHospitales] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RegistroDeHospitales] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RegistroDeHospitales] SET  ENABLE_BROKER 
GO
ALTER DATABASE [RegistroDeHospitales] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RegistroDeHospitales] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RegistroDeHospitales] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RegistroDeHospitales] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RegistroDeHospitales] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RegistroDeHospitales] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RegistroDeHospitales] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RegistroDeHospitales] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RegistroDeHospitales] SET  MULTI_USER 
GO
ALTER DATABASE [RegistroDeHospitales] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RegistroDeHospitales] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RegistroDeHospitales] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RegistroDeHospitales] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RegistroDeHospitales] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RegistroDeHospitales] SET QUERY_STORE = OFF
GO
USE [RegistroDeHospitales]
GO
/****** Object:  Table [dbo].[Consultas]    Script Date: 20-05-2025 1:35:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consultas](
	[ConsultaID] [int] IDENTITY(1,1) NOT NULL,
	[FechaConsulta] [datetime] NOT NULL,
	[TipoConsulta] [varchar](100) NOT NULL,
	[PacienteID] [int] NULL,
	[MedicoID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ConsultaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistorialMedico]    Script Date: 20-05-2025 1:35:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistorialMedico](
	[HistorialID] [int] IDENTITY(1,1) NOT NULL,
	[FechaRegistro] [date] NOT NULL,
	[DescripcionTratamiento] [varchar](1000) NULL,
	[Observaciones] [varchar](1000) NULL,
	[PacienteID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[HistorialID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pacientes]    Script Date: 20-05-2025 1:35:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pacientes](
	[PacienteID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[ContactoEmergencia] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PacienteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonalMedico]    Script Date: 20-05-2025 1:35:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalMedico](
	[MedicoID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Especializacion] [varchar](50) NOT NULL,
	[Horario] [time](7) NOT NULL,
	[Licencia] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MedicoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salas]    Script Date: 20-05-2025 1:35:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salas](
	[SalaID] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](100) NOT NULL,
	[Capacidad] [int] NOT NULL,
	[Estado] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SalaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Consultas]  WITH CHECK ADD FOREIGN KEY([MedicoID])
REFERENCES [dbo].[PersonalMedico] ([MedicoID])
GO
ALTER TABLE [dbo].[Consultas]  WITH CHECK ADD FOREIGN KEY([PacienteID])
REFERENCES [dbo].[Pacientes] ([PacienteID])
GO
ALTER TABLE [dbo].[HistorialMedico]  WITH CHECK ADD FOREIGN KEY([PacienteID])
REFERENCES [dbo].[Pacientes] ([PacienteID])
GO
/****** Object:  StoredProcedure [dbo].[SP_AsignarPersonalMedico]    Script Date: 20-05-2025 1:35:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SP_AsignarPersonalMedico]
    @PacienteID INT,
    @MedicoID INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @NombreMedico VARCHAR(50);
    DECLARE @NombrePaciente VARCHAR(50);
    DECLARE @ApellidoPaciente VARCHAR(50);

    -- Obtener el nombre del médico
    SELECT @NombreMedico = Nombre
    FROM PersonalMedico
    WHERE MedicoID = @MedicoID;

    -- Obtener el nombre completo del paciente
    SELECT @NombrePaciente = Nombre, @ApellidoPaciente = Apellido
    FROM Pacientes
    WHERE PacienteID = @PacienteID;

    -- Insertar en Historial
    INSERT INTO HistorialMedico (
        FechaRegistro, 
        DescripcionTratamiento, 
        Observaciones, 
        PacienteID
    )
    VALUES (
        GETDATE(),
        'Asignación de personal médico',
        CONCAT('El médico ', @NombreMedico, ' fue asignado al paciente ', @NombrePaciente, ' ', @ApellidoPaciente),
        @PacienteID
    );
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_GenerarReporteOcupacionCamas]    Script Date: 20-05-2025 1:35:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_GenerarReporteOcupacionCamas]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Tipo,
        COUNT(*) AS TotalCamas,
        SUM(CASE WHEN Estado = 'Ocupada' THEN 1 ELSE 0 END) AS CamasOcupadas,
        CAST(SUM(CASE WHEN Estado = 'Ocupada' THEN 1 ELSE 0 END) * 100.0 / COUNT(*) AS DECIMAL(5,2)) AS PorcentajeOcupacion
    FROM Salas
    GROUP BY Tipo;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ObtenerHistorialPaciente]    Script Date: 20-05-2025 1:35:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--------------------------------------------------------------------------------------------------------------------------------------------------------------


CREATE PROCEDURE [dbo].[SP_ObtenerHistorialPaciente]
    @PacienteID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        FechaRegistro, 
        DescripcionTratamiento, 
        Observaciones
    FROM HistorialMedico
    WHERE PacienteID = @PacienteID
    ORDER BY FechaRegistro DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ProgramarConsulta]    Script Date: 20-05-2025 1:35:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


----------------------------------------------------------------------------------------------------------------------------------------------


CREATE PROCEDURE [dbo].[SP_ProgramarConsulta]
    @FechaConsulta DATETIME,
    @TipoConsulta VARCHAR(100),
    @PacienteID INT,
    @MedicoID INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Consultas (FechaConsulta, TipoConsulta, PacienteID, MedicoID)
    VALUES (@FechaConsulta, @TipoConsulta, @PacienteID, @MedicoID);
END;
GO
USE [master]
GO
ALTER DATABASE [RegistroDeHospitales] SET  READ_WRITE 
GO
