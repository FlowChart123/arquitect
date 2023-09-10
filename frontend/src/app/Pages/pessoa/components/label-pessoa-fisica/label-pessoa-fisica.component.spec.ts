import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LabelPessoaFisicaComponent } from './label-pessoa-fisica.component';

describe('LabelPessoaFisicaComponent', () => {
  let component: LabelPessoaFisicaComponent;
  let fixture: ComponentFixture<LabelPessoaFisicaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LabelPessoaFisicaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LabelPessoaFisicaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
