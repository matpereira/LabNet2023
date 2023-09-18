import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InsertCustomerComponent } from './insert-customer.component';

describe('InsertCustomerComponent', () => {
  let component: InsertCustomerComponent;
  let fixture: ComponentFixture<InsertCustomerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InsertCustomerComponent]
    });
    fixture = TestBed.createComponent(InsertCustomerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
