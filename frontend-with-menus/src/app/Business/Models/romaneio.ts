import { RomaneioCarga } from "./romaneioCarga";
import { RomaneioDocumento } from "./romaneioDocumento";
import { Tenant } from "./tenant";


export interface Romaneio  {
    id: string;
    tenantId: string;
    dataEmissao: string;
    dataCadastro: string;
    romaneioCarga: RomaneioCarga | null;
    romaneioDocumentos: RomaneioDocumento[];
    tenant: Tenant;
}