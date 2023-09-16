import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InsertShipperComponent } from './insert-shipper.component';

describe('InsertShipperComponent', () => {
  let component: InsertShipperComponent;
  let fixture: ComponentFixture<InsertShipperComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InsertShipperComponent]
    });
    fixture = TestBed.createComponent(InsertShipperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
