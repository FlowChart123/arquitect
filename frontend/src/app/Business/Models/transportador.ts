import { Pessoa } from "./pessoa";
import { TipoRntrc } from "./tipoRntrc";
import { Transportador1 } from "./transportador1";


export interface Transportador  {
    id: string;
    tipoRntrcId: number;
    rntrc: string | null;
    rntrcValidade: string | null;
    dataCadastro: string | null;
    idNavigation: Pessoa;
    tipoRntrc: TipoRntrc;
    transportador1s: Transportador1[];
}