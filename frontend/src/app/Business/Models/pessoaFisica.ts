import { Pessoa } from "./pessoa";


export interface PessoaFisica  {
    id: string;
    cpf: string;
    rg: string | null;
    idNavigation: Pessoa;
}