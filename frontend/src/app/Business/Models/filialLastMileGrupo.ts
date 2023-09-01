import { FilialLastMileGrupoItem } from "./filialLastMileGrupoItem";

export interface FilialLastMileGrupo  {
    id: string;
    nome: string;
    codigo: string | null;
    ordem: number | null;
    ativo: boolean | null;
    filialLastMileGrupoItems: FilialLastMileGrupoItem[];
}
