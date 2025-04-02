import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ParqueaderoService } from '../../shared/parqueadero.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-liquidacion-salida',
  standalone: true,
  imports: [CommonModule,HttpClientModule,MatSelectModule,MatInputModule,ReactiveFormsModule,MatCardModule,MatFormFieldModule],
  templateUrl: './liquidacion-salida.component.html',
  styleUrl: './liquidacion-salida.component.css'
})
export class LiquidacionSalidaComponent {
  liquidacionForm: FormGroup;
  supermercados: any[] = [];
  cargando: boolean = false;

  constructor(
    private fb: FormBuilder,
    private parqueaderoService: ParqueaderoService,
    private snackBar: MatSnackBar
  ) {
    this.liquidacionForm = this.fb.group({
      placa: ['', Validators.required],
      idSupermercado: [null],
      numeroFactura: [''],
      usuarioActualizacion: ['admin', Validators.required]  // Puedes cambiar esto según el usuario autenticado
    });

    this.obtenerSupermercados();
  }

  obtenerSupermercados() {
    this.parqueaderoService.obtenerSupermercados().subscribe(
      (data) => {
        this.supermercados = data;
      },
      (error) => {
        console.error('Error al obtener supermercados', error);
        this.snackBar.open('Error al obtener supermercados', 'Cerrar', { duration: 3000 });
      }
    );
  }

  liquidarSalida() {
    if (this.liquidacionForm.valid) {
      this.cargando = true;
      const { placa, numeroFactura, idSupermercado, usuarioActualizacion } = this.liquidacionForm.value;

      this.parqueaderoService.liquidarSalida(placa, numeroFactura, idSupermercado, usuarioActualizacion)
        .subscribe(
          (exito) => {
            this.cargando = false;
            if (exito) {
              this.snackBar.open('Liquidación exitosa', 'Cerrar', { duration: 3000 });
              this.liquidacionForm.reset();
            } else {
              this.snackBar.open('No se pudo liquidar la salida', 'Cerrar', { duration: 3000 });
            }
          },
          (error) => {
            this.cargando = false;
            this.snackBar.open('Error al liquidar la salida', 'Cerrar', { duration: 3000 });
          }
        );
    }
  }
}
