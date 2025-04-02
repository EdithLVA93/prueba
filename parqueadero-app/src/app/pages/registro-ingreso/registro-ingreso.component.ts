import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ParqueaderoService } from '../../shared/parqueadero.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';

@Component({
  selector: 'app-registro-ingreso',
  standalone: true,
  imports: [CommonModule,HttpClientModule,MatSelectModule,MatInputModule,ReactiveFormsModule,MatCardModule,MatFormFieldModule],
  templateUrl: './registro-ingreso.component.html',
  styleUrl: './registro-ingreso.component.css'
})
export class RegistroIngresoComponent implements OnInit {
  ingresoForm: FormGroup;
  tiposVehiculo: any[] = [];

  constructor(
    private fb: FormBuilder,
    private parqueaderoService: ParqueaderoService,
    private snackBar: MatSnackBar
  ) {
    this.ingresoForm = this.fb.group({
      placa: ['', [Validators.required, Validators.minLength(6)]],
      idTipoVehiculo: ['', Validators.required],
      usuarioCreacion: ['admin'], // Puedes cambiar esto según el usuario autenticado
    });
  }

  ngOnInit() {
    this.cargarTiposVehiculo();
  }

  cargarTiposVehiculo() {
    this.parqueaderoService.obtenerTiposVehiculo().subscribe(
      (data) => {
        this.tiposVehiculo = data;
      },
      (error) => {
        this.snackBar.open('Error al cargar tipos de vehículo', 'Cerrar', { duration: 3000 });
      }
    );
  }

  registrarIngreso() {
    if (this.ingresoForm.valid) {
      this.parqueaderoService.registrarIngreso(this.ingresoForm.value).subscribe(
        () => {
          this.snackBar.open('Vehículo registrado correctamente', 'Cerrar', { duration: 3000 });
          this.ingresoForm.reset();
        },
        () => {
          this.snackBar.open('Error al registrar el vehículo', 'Cerrar', { duration: 3000 });
        }
      );
    }
  }
}
