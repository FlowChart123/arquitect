import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LabelPessoaJuridicaComponent } from './label-pessoa-juridica.component';

describe('LabelPessoaJuridicaComponent', () => {
  let component: LabelPessoaJuridicaComponent;
  let fixture: ComponentFixture<LabelPessoaJuridicaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LabelPessoaJuridicaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LabelPessoaJuridicaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
