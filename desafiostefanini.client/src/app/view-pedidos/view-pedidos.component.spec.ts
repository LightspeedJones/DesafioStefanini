import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewPedidosComponent } from './view-pedidos.component';

describe('ViewPedidosComponent', () => {
  let component: ViewPedidosComponent;
  let fixture: ComponentFixture<ViewPedidosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ViewPedidosComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ViewPedidosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
