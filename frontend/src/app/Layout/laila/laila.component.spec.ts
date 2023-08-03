import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LailaComponent } from './laila.component';

describe('LailaComponent', () => {
  let component: LailaComponent;
  let fixture: ComponentFixture<LailaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LailaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LailaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
