import { Documento } from "./dcumento";

export interface DocumentoTotal  {
    id: string;
    valorDaNota: number | null;
    pesoLiquido: number | null;
    pesoBruto: number | null;
    pesoCubado: number | null;
    volumes: number | null;
    metragemCubica: number | null;
    idNavigation: Documento;
}