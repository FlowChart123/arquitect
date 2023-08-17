import { Romaneio } from "./romaneio";
import { Veiculo1 } from "./veiculo1";
import { VeiculoTipo } from "./veiculoTipo";

export interface RomaneioCarga  {
    id: string;
    veiculoId: string | null;
    veiculoTipoId: number | null;
    pesoBruto: number | null;
    metragemCubica: number | null;
    paradas: number | null;
    ditanciaKm: number | null;
    idNavigation: Romaneio;
    veiculo: Veiculo1 | null;
    veiculoTipo: VeiculoTipo | null;
}