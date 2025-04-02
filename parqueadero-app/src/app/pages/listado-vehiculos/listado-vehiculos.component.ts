import { Component } from '@angular/core';
import { ParqueaderoService } from '../../shared/parqueadero.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-listado-vehiculos',
  standalone: true,
  imports: [CommonModule,HttpClientModule,MatProgressSpinnerModule,MatTableModule,MatCardModule, MatFormFieldModule,MatInputModule,
    MatSelectModule,ReactiveFormsModule],
  templateUrl: './listado-vehiculos.component.html',
  styleUrl: './listado-vehiculos.component.css'
})
export class ListadoVehiculosComponent {
  vehiculos: any[] = [];
  filtroForm: FormGroup;
  cargando: boolean = false;

  constructor(
    private parqueaderoService: ParqueaderoService,
    private fb: FormBuilder,
    private snackBar: MatSnackBar
  ) {
    this.filtroForm = this.fb.group({
      fechaInicio: ['', Validators.required],
      fechaFin: ['', Validators.required]
    });
  }

  obtenerVehiculos() {
    if (this.filtroForm.valid) {
      this.cargando = true;
      const { fechaInicio, fechaFin } = this.filtroForm.value;

      this.parqueaderoService.obtenerListado(fechaInicio, fechaFin).subscribe(
        (data) => {
          this.vehiculos = data;
          this.cargando = false;
        },
        (error) => {
          this.snackBar.open('Error al obtener vehículos', 'Cerrar', { duration: 3000 });
          this.cargando = false;
        }
      );
    }
  }
}
