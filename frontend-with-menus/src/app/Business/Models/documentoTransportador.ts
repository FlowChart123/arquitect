import { Documento } from "./dcumento";

export interface DocumentoTransportador  {
    id: string;
    cnpj: string | null;
    nome: string | null;
    inscricaoEstadual: string | null;
    municipio: string | null;
    uf: string | null;
    idNavigation: Documento;
}
