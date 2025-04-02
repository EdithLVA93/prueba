export interface Vehiculo {
    id?: number;
    placa: string;
    tipoVehiculoId: number;
    fechaEntrada?: string;
    fechaSalida?: string;
    totalPagado?: number;
    idSupermercado?: number;
    numeroFactura?: string;
  }