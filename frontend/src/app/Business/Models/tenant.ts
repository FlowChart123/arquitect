import { Documento1 } from "./documento1";
import { Empresa } from "./empresa";
import { Romaneio } from "./romaneio";
import { Transportador1 } from "./transportador1";
import { Veiculo1 } from "./veiculo1";

export interface Tenant  {
    id: string;
    nome: string;
    dataCadastro: string;
    ativo: boolean | null;
    documento1s: Documento1[];
    empresas: Empresa[];
    romaneios: Romaneio[];
    transportador1s: Transportador1[];
    veiculo1s: Veiculo1[];
}