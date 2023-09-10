import { FilialLastMile } from "./FilialLastMile";
import { Pais } from "./pais";
import { TransportadorLastMile } from "./transportadorLastMile";

export interface Estado  {
    id: number;
    idPais: number;
    nome: string;
    uf: string | null;
    cepInicial: string | null;
    cepFinal: string | null;
    filialLastMiles: FilialLastMile[];
    idPaisNavigation: Pais;
    transportadorLastMiles: TransportadorLastMile[];
}