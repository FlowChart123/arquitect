import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RushFormBaseComponent } from './rush-form-base.component';

describe('RushFormBaseComponent', () => {
  let component: RushFormBaseComponent;
  let fixture: ComponentFixture<RushFormBaseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RushFormBaseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RushFormBaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
