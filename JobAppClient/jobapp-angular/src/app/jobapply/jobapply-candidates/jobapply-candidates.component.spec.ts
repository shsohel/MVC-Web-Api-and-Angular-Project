import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { JobapplyCandidatesComponent } from './jobapply-candidates.component';

describe('JobapplyCandidatesComponent', () => {
  let component: JobapplyCandidatesComponent;
  let fixture: ComponentFixture<JobapplyCandidatesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ JobapplyCandidatesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(JobapplyCandidatesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
