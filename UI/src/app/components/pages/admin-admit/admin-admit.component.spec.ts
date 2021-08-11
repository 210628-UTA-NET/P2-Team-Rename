import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminAdmitComponent } from './admin-admit.component';

describe('AdminAdmitComponent', () => {
  let component: AdminAdmitComponent;
  let fixture: ComponentFixture<AdminAdmitComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminAdmitComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminAdmitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
