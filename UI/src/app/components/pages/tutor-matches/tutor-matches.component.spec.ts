import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TutorMatchesComponent } from './tutor-matches.component';

describe('TutorMatchesComponent', () => {
  let component: TutorMatchesComponent;
  let fixture: ComponentFixture<TutorMatchesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TutorMatchesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TutorMatchesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
