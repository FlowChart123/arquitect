import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PessoaJuridicaComplementosComponent } from './pessoa-juridica-complementos.component';

describe('PessoaJuridicaComplementosComponent', () => {
  let component: PessoaJuridicaComplementosComponent;
  let fixture: ComponentFixture<PessoaJuridicaComplementosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PessoaJuridicaComplementosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PessoaJuridicaComplementosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
