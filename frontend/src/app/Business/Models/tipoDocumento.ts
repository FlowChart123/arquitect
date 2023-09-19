import { Documento } from "./dcumento";


export interface TipoDocumento  {
    id: number;
    nome: string;
    documentos: Documento[];
}