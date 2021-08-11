import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminAdmitCardComponent } from './admin-admit-card.component';

describe('AdminAdmitCardComponent', () => {
  let component: AdminAdmitCardComponent;
  let fixture: ComponentFixture<AdminAdmitCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminAdmitCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminAdmitCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
