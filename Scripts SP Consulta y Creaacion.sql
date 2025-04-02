/**********************************************************************
    Nombre del Procedimiento: sp_RegistrarIngresoVehiculo
    Descripción: Registra el ingreso de un vehículo al parqueadero. Si el 
                 vehículo no existe, lo crea antes de registrar su ingreso.

    Autor: Edith Varela
    Fecha de Creación: 01/04/2025
    Última Modificación: 01/04/2025
    
    Parámetros:
      @IdTipoVehiculo  -> Tipo de vehículo (1: Carro, 2: Moto, 3: Bicicleta).
      @Placa           -> Placa del vehículo.
      @UsuarioCreacion -> Usuario que registra el ingreso.

    Retorno: Ninguno.

**********************************************************************/

CREATE OR ALTER PROCEDURE sp_RegistrarIngresoVehiculo 1,'sdf345','erte'
    @IdTipoVehiculo INT,
    @Placa VARCHAR(10),
    @UsuarioCreacion VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE 
	@IdVehiculo INT, 
	@FechaCreacion DATETIME = GETDATE();
    
    -- Verifico si el vehículo ya existe, si no, lo creo
    IF NOT EXISTS (SELECT 1 FROM Vehiculos WHERE Placa = @Placa)
    BEGIN
        INSERT INTO Vehiculos (IdTipoVehiculo, Placa, EstadoVehiculo, UsuarioCreacion, FechaCreacion)
        VALUES (@IdTipoVehiculo, @Placa, 1, @UsuarioCreacion, @FechaCreacion);
        
        SET @IdVehiculo = SCOPE_IDENTITY();
    END
    ELSE
    BEGIN
        SELECT @IdVehiculo = IdVehiculo FROM Vehiculos WHERE Placa = @Placa;
    END
    
    -- Registro el ingreso del vehículo
    INSERT INTO RegistrosVehiculos ( IdVehiculo, FechaEntrada, EstadoRegistroVehiculo, UsuarioCreacion, FechaCreacion)
    VALUES ( @IdVehiculo, @FechaCreacion, 1, @UsuarioCreacion, @FechaCreacion);
	
	SELECT top(1)  * from RegistrosVehiculos r where r.IdVehiculo =  @IdVehiculo order by 1 desc ;
END
GO

/**********************************************************************
    Nombre del Procedimiento: sp_LiquidarSalidaVehiculo
    Descripción: Calcula y registra el pago de un vehículo al salir del parqueadero.
    
    Autor: Edith Varela
    Fecha de Creación: 01/04/2025
    Última Modificación: 01/04/2025
    
    Parámetros:
      @Placa            -> Placa del vehículo.
      @IdSupermercado   -> ID del supermercado donde compró (Opcional).
      @NumeroFactura    -> Número de la factura de compra (Opcional).
      @UsuarioActualizacion -> Usuario que realiza la actualización.

    Retorno: Ninguno

**********************************************************************/
CREATE OR ALTER PROCEDURE sp_LiquidarSalidaVehiculo
    @Placa VARCHAR(10),
    @IdSupermercado INT = NULL,  
    @NumeroFactura VARCHAR(255) = NULL,
    @UsuarioActualizacion VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @IdRegistroVehiculo BIGINT, 
            @IdVehiculo INT, 
            @IdTipoVehiculo INT, 
            @FechaEntrada DATETIME, 
            @FechaSalida DATETIME = GETDATE(), 
            @TarifaPorMinuto DECIMAL(18,2), 
            @TotalMinutos INT, 
            @TotalPagado DECIMAL(18,2), 
            @Descuento DECIMAL(18,2) = 0;
    
    -- Obtengo el ID del vehículo
    SELECT @IdVehiculo = IdVehiculo FROM Vehiculos WHERE Placa = @Placa;
    
    -- Obtengo el registro de entrada
    SELECT @IdRegistroVehiculo = IdRegistroVehiculo, @FechaEntrada = FechaEntrada
    FROM RegistrosVehiculos 
    WHERE IdVehiculo = @IdVehiculo AND FechaSalida IS NULL;
    
    -- Obtengo el tipo de vehículo y su tarifa desde la tabla TiposVehiculos
    SELECT @IdTipoVehiculo = IdTipoVehiculo, @TarifaPorMinuto = TarifaPorMinuto 
    FROM TiposVehiculos 
    WHERE IdTipoVehiculo = (SELECT IdTipoVehiculo FROM Vehiculos WHERE IdVehiculo = @IdVehiculo);
    
    -- Calculo el tiempo de parqueo en minutos
    SET @TotalMinutos = DATEDIFF(MINUTE, @FechaEntrada, @FechaSalida);
    SET @TotalPagado = @TotalMinutos * @TarifaPorMinuto;
    
    -- Aplico descuento si se proporciona una factura y un supermercado válido
    IF @NumeroFactura IS NOT NULL AND @IdSupermercado IS NOT NULL
    BEGIN
        -- Obtengo el descuento del supermercado
        SELECT @Descuento = PorcentajeDescuento / 100
        FROM Supermercados
        WHERE IdSupermercado = @IdSupermercado AND EstadoSupermercado = 1;
        
        -- Aplico descuento si el supermercado es válido
        IF @Descuento > 0
        BEGIN
            SET @TotalPagado = @TotalPagado * (1 - @Descuento);
        END
        ELSE
        BEGIN
            -- Si el supermercado no es válido, dejo el IdSupermercado como NULL
            SET @IdSupermercado = NULL;
        END
    END;
    
    -- Actualizar registro de salida
    UPDATE RegistrosVehiculos
    SET FechaSalida = @FechaSalida,
        TotalPagado = @TotalPagado,
        NumeroFactura = @NumeroFactura,
        IdSupermercado = @IdSupermercado, 
        UsuarioActualizacion = @UsuarioActualizacion,
        FechaActualizacion = @FechaSalida
    WHERE IdRegistroVehiculo = @IdRegistroVehiculo;

	SELECT top(1) * from RegistrosVehiculos r where r.IdRegistroVehiculo =  @IdRegistroVehiculo order by 1 desc;
END
GO



/**********************************************************************
    Nombre del Procedimiento: sp_ListarVehiculosEstacionados
    Descripción: Obtiene el listado de vehículos que han estacionado en 
                 un rango de fechas, con información detallada.
    
    Autor: Edith Varela
    Fecha de Creación: 01/04/2025
    Última Modificación: 01/04/2025
    
    Parámetros:
      @FechaInicio -> Fecha de inicio del rango de consulta.
      @FechaFin    -> Fecha de fin del rango de consulta.

    Retorno: Tabla con información de los vehículos registrados en un lapso de tiempo.

**********************************************************************/
CREATE OR ALTER PROCEDURE sp_ListarVehiculosEstacionados
    @FechaInicio DATETIME,
    @FechaFin DATETIME
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        v.Placa,
        t.NombreTipoVehiculo,
        r.FechaEntrada,
        r.FechaSalida,
        DATEDIFF(MINUTE, r.FechaEntrada, ISNULL(r.FechaSalida,GETDATE())) AS TiempoParqueo,
        isnull(r.TotalPagado,DATEDIFF(MINUTE, r.FechaEntrada, ISNULL(r.FechaSalida,GETDATE()))*t.TarifaPorMinuto) AS TotalPagado
    FROM RegistrosVehiculos r
    JOIN Vehiculos v ON r.IdVehiculo = v.IdVehiculo
    JOIN TiposVehiculos t ON v.IdTipoVehiculo = t.IdTipoVehiculo
    WHERE r.FechaEntrada BETWEEN @FechaInicio AND @FechaFin;
END
GO
