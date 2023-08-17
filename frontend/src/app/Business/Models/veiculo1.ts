import { RomaneioCarga } from "./romaneioCarga";
import { Tenant } from "./tenant";
import { Veiculo } from "./veiculo";

export interface Veiculo1  {
    id: string;
    tenantId: string | null;
    veiculoId: string | null;
    dataCadastro: string | null;
    romaneioCargas: RomaneioCarga[];
    tenant: Tenant | null;
    veiculo: Veiculo | null;
}