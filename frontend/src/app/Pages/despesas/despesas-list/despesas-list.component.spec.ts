import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RushListComponent } from './rush-list.component';

describe('RushListComponent', () => {
  let component: RushListComponent;
  let fixture: ComponentFixture<RushListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RushListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RushListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
