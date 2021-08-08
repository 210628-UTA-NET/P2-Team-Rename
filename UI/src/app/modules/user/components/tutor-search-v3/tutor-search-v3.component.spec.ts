import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TutorSearchV3Component } from './tutor-search-v3.component';

describe('TutorSearchV3Component', () => {
  let component: TutorSearchV3Component;
  let fixture: ComponentFixture<TutorSearchV3Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TutorSearchV3Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TutorSearchV3Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
