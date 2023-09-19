import { Documento1 } from "./documento1";
import { Romaneio } from "./romaneio";


export interface RomaneioDocumento  {
    id: string;
    romaneioId: string;
    documentoId: string;
    idNavigation: Documento1;
    romaneio: Romaneio;
}