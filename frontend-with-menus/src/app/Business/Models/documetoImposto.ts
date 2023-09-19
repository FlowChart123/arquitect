import { Documento } from "./dcumento";


export interface DocumentoImposto  {
    id: string;
    icms: string | null;
    orig: string | null;
    icmsCst: string | null;
    modBc: number | null;
    vBc: number | null;
    pIcms: number | null;
    vIcms: number | null;
    cEnq: string | null;
    ipiCst: string | null;
    pisCst: string | null;
    pisvBc: number | null;
    pispPis: number | null;
    pisvPis: number | null;
    cofinsCst: string | null;
    cofinsvBc: number | null;
    cofinspCofins: number | null;
    cofinsvCofins: number | null;
    idNavigation: Documento;
}