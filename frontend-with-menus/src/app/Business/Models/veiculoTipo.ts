import { RomaneioCarga } from "./romaneioCarga";
import { Veiculo } from "./veiculo";


export interface VeiculoTipo  {
    id: number;
    nome: string;
    romaneioCargas: RomaneioCarga[];
    veiculos: Veiculo[];
}