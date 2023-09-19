import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormsBasepageComponent } from './forms-basepage.component';

describe('FormsBasepageComponent', () => {
  let component: FormsBasepageComponent;
  let fixture: ComponentFixture<FormsBasepageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormsBasepageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormsBasepageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
