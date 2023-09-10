import { FilialLastMile } from "./FilialLastMile";
import { Municipio } from "./Municipio";
import { Estado } from "./estado";

export interface Bairro   {
    id: number;
    nome: string;
    municipioId: number;
    filialLastMiles: FilialLastMile[];
    municipio: Municipio;
}
