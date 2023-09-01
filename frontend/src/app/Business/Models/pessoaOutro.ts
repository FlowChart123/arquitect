import { Pessoa } from "./pessoa";


export interface PessoaOutro  {
    id: string;
    codigo: string;
    idNavigation: Pessoa;
}