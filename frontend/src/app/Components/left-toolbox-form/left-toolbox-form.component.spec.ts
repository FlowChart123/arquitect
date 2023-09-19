import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeftToolboxFormComponent } from './left-toolbox-form.component';

describe('LeftToolboxFormComponent', () => {
  let component: LeftToolboxFormComponent;
  let fixture: ComponentFixture<LeftToolboxFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LeftToolboxFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LeftToolboxFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
