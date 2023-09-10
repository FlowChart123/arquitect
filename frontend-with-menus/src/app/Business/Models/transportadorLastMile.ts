import { Estado } from "./estado";
import { TransportadorLastMileGrupoItem } from "./transportadorLastMileGrupoItem";

export interface TransportadorLastMile  {
    id: string;
    transportadorId: number;
    cepInicial: string | null;
    cepFinal: string | null;
    bairroId: number | null;
    municipioId: number | null;
    estadoId: number | null;
    dataCadastro: string | null;
    estado: Estado | null;
    transportadorLastMileGrupoItems: TransportadorLastMileGrupoItem[];
}