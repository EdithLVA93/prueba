import { Routes } from '@angular/router';
import { RegistroIngresoComponent } from './pages/registro-ingreso/registro-ingreso.component';
import { ListadoVehiculosComponent } from './pages/listado-vehiculos/listado-vehiculos.component';
import { LiquidacionSalidaComponent } from './pages/liquidacion-salida/liquidacion-salida.component';

export const routes: Routes = [

    {path: 'registro-vehiculo', component: RegistroIngresoComponent},
    {path: 'listado-vehiculos', component: ListadoVehiculosComponent},
    {path: 'liquidar-salida', component: LiquidacionSalidaComponent},
    { path: '', redirectTo: 'listado-vehiculos', pathMatch: 'full' }
];
