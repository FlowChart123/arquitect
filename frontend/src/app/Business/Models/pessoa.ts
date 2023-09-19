import { Documento } from "./dcumento";
import { PessoaEndereco } from "./pessoaEndereco";
import { PessoaFisica } from "./pessoaFisica";
import { PessoaJuridica } from "./pessoaJuridica";
import { PessoaOutro } from "./pessoaOutro";
import { Produto } from "./produto";
import { Transportador } from "./transportador";
import { Transportador1 } from "./transportador1";
import { Veiculo } from "./veiculo";


export interface Pessoa  {
    dataCadastro: string;
    documentoDestinatarios: Documento[];
    documentoEmitentes: Documento[];
    documentoRemetentes: Documento[];
    fantasia: string;
    id: string;
    nome: string;
    pessoaEnderecos: PessoaEndereco [];
    pessoaFisica: PessoaFisica | null;
    pessoaJuridica: PessoaJuridica | null;
    pessoaOutro: PessoaOutro | null;
    produtos: Produto[];
    transportador: Transportador | null;
    transportador1: Transportador1 | null;
    veiculos: Veiculo[];
}