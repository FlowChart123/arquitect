import { Documento } from "./dcumento";
import { DocumentoFilialGrupo } from "./documentoFilialGrupo";
import { RomaneioDocumento } from "./romaneioDocumento";
import { Tenant } from "./tenant";

export interface Documento1  {
    id: string;
    documentoId: string;
    tenantId: string;
    dataEntrada: string;
    ativo: boolean | null;
    documento: Documento;
    documentoFilialGrupo: DocumentoFilialGrupo | null;
    romaneioDocumento: RomaneioDocumento | null;
    tenant: Tenant;
}