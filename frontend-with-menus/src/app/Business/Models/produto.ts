import { DocumentoItem } from "./documentoItem";
import { Pessoa } from "./pessoa";

export interface Produto  {
    id: string;
    pessoaId: string;
    codigo: string;
    descricao: string;
    documentoItems: DocumentoItem[];
    pessoa: Pessoa;
}