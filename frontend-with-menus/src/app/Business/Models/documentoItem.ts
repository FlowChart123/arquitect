import { Documento } from "./dcumento";
import { Produto } from "./produto";

export interface DocumentoItem  {
    id: string;
    documentoPadraoId: string;
    produtoId: string;
    quantidade: number | null;
    nItem: number | null;
    cProd: string | null;
    cEan: string | null;
    uCom: number | null;
    qCom: number | null;
    vUnCom: number | null;
    vProd: number | null;
    vUnTrib: number | null;
    xPed: string | null;
    cfop: string | null;
    cEantrib: string | null;
    ncm: string | null;
    uTrib: string | null;
    qTrib: number | null;
    documentoPadrao: Documento;
    produto: Produto;
}