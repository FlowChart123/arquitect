import { Municipio } from "./Municipio";
import { Bairro } from "./bairro";
import { Estado } from "./estado";
import { Filial } from "./filial";
import { FilialLastMileGrupoItem } from "./filialLastMileGrupoItem";

export interface FilialLastMile  {
    id: string;
    filialId: number;
    cepInicial: string | null;
    cepFinal: string | null;
    bairroId: number | null;
    municipioId: number | null;
    estadoId: number | null;
    dataCadastro: string | null;
    bairro: Bairro | null;
    estado: Estado | null;
    filial: Filial;
    filialLastMileGrupoItems: FilialLastMileGrupoItem[];
    municipio: Municipio | null;
}