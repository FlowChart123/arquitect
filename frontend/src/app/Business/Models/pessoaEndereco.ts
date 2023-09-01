import { Endereco } from "./endereco";
import { Pessoa } from "./pessoa";

export interface PessoaEndereco  {
    id: string;
    pessoaId: string;
    enderecoId: string;
    endereco: Endereco;
    pessoa: Pessoa;
}