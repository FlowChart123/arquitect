import { FilialLastMile } from "./FilialLastMile";
import { Bairro } from "./bairro";

export interface Municipio  {
    bairros: Bairro[];
    cep: string | null;
    codigoIbge: number | null;
    filialLastMiles: FilialLastMile[];
    id: number;
    inverseMunicipioPai: Municipio[];
    municipioPai: Municipio | null;
    municipioPaiId: number | null;
    nome: string;
    uf: string | null;
}
