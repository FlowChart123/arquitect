import { Documento1 } from "./documento1";
import { DocumentoItem } from "./documentoItem";
import { DocumentoTotal } from "./documentoTotal";
import { DocumentoTransportador } from "./documentoTransportador";
import { DocumentoImposto } from "./documetoImposto";
import { Pessoa } from "./pessoa";
import { TipoDocumento } from "./tipoDocumento";


export interface Documento  {
    id: string;
    tipoDocumentoId: number;
    chave: string;
    emitenteId: string;
    remetenteId: string;
    destinatarioId: string;
    numero: number;
    serie: string;
    numeroCliente: string;
    xPed: string | null;
    dataEmissao: string | null;
    dataCadastro: string;
    destinatario: Pessoa;
    documento1s: Documento1[];
    documentoImposto: DocumentoImposto | null;
    documentoItems: DocumentoItem[];
    documentoTotal: DocumentoTotal | null;
    documentoTransportador: DocumentoTransportador | null;
    emitente: Pessoa;
    remetente: Pessoa;
    tipoDocumento: TipoDocumento;
}