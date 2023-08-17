import { Pessoa } from "./pessoa";


export interface PessoaJuridica  {
    id: string;
    cnpj: string;
    inscricaoEstadual: string;
    inscricaoMunicipal: string | null;
    idNavigation: Pessoa;
}