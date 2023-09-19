import { PessoaFisicaComplemento } from "./pessoaFisicaComplemento";


export interface PessoaFisica  {
    id: string;
    cpf: string;    
    pessoaFisicaComplemento: PessoaFisicaComplemento | null;
}