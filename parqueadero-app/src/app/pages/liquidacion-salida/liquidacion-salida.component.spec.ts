import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LiquidacionSalidaComponent } from './liquidacion-salida.component';

describe('LiquidacionSalidaComponent', () => {
  let component: LiquidacionSalidaComponent;
  let fixture: ComponentFixture<LiquidacionSalidaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LiquidacionSalidaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LiquidacionSalidaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
