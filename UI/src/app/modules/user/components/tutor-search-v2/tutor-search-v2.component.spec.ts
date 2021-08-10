import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TutorSearchV2Component } from './tutor-search-v2.component';

describe('TutorSearchV2Component', () => {
  let component: TutorSearchV2Component;
  let fixture: ComponentFixture<TutorSearchV2Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TutorSearchV2Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TutorSearchV2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
