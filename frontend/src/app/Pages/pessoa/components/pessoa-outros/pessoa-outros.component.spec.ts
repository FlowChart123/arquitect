import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PessoaOutrosComponent } from './pessoa-outros.component';

describe('PessoaOutrosComponent', () => {
  let component: PessoaOutrosComponent;
  let fixture: ComponentFixture<PessoaOutrosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PessoaOutrosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PessoaOutrosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
