import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PessoaFisicaComplementosComponent } from './pessoa-fisica-complementos.component';

describe('PessoaFisicaComplementosComponent', () => {
  let component: PessoaFisicaComplementosComponent;
  let fixture: ComponentFixture<PessoaFisicaComplementosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PessoaFisicaComplementosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PessoaFisicaComplementosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
