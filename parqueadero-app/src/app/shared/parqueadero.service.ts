import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Vehiculo } from './models/vehiculo';

@Injectable({
  providedIn: 'root'
})
export class ParqueaderoService {
  private apiUrl = 'https://localhost:7043/api';

  constructor(private http: HttpClient) {}

  obtenerTiposVehiculo(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/tiposvehiculos`);
  }

  obtenerSupermercados(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/supermercados`);
  }
  registrarIngreso(vehiculo: Vehiculo): Observable<number> {
    return this.http.post<number>(`${this.apiUrl}/vehiculos/registrar-ingreso`, vehiculo);
  }

  liquidarSalida(placa: string, numeroFactura: string | null, idSupermercado: number | null, usuarioActualizacion: string): Observable<boolean> {
    const body = { placa, numeroFactura, idSupermercado, usuarioActualizacion };
    return this.http.post<boolean>(`${this.apiUrl}/vehiculos/liquidar-salida`, body);
  }

  obtenerListado(fechaInicio: string, fechaFin: string): Observable<Vehiculo[]> {
    return this.http.get<Vehiculo[]>(`${this.apiUrl}/vehiculos/listadoVehiculos?fechaInicio=${fechaInicio}&fechaFin=${fechaFin}`);
  }
}
