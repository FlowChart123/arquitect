import { DocumentoFilialGrupo } from "./documentoFilialGrupo";
import { PessoaEndereco } from "./pessoaEndereco";


export interface Endereco  {
    id: string;
    tipoEndereco: string;
    tipo: string;
    logradouro: string;
    numero: string | null;
    complemento: string | null;
    cep: string | null;
    uf: string | null;
    municipioId: number | null;
    codigoIbge: string | null;
    nomeMunicipio: string | null;
    bairroId: number | null;
    nomeBairro: string | null;
    latitude: number | null;
    longitude: number | null;
    dataCadastro: string | null;
    documentoFilialGrupos: DocumentoFilialGrupo[];
    pessoaEnderecos: PessoaEndereco[];
}