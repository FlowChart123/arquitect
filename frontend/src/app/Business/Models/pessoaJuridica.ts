import { Pessoa } from "./pessoa";


export interface PessoaJuridica  {
    id: string;
    cnpj: string;
    fantasia: string;
    inscricaoEstadual: string;
    inscricaoMunicipal: string | null;    
}