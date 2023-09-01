import { TransportadorLastMileGrupoItem } from "./transportadorLastMileGrupoItem";

export interface TransportadorLastMileGrupo  {
    id: string;
    nome: string;
    codigo: string | null;
    ordem: number | null;
    ativo: boolean | null;
    transportadorLastMileGrupoItems: TransportadorLastMileGrupoItem[];
}