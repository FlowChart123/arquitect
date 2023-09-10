import { Pessoa } from "./pessoa";
import { Veiculo1 } from "./veiculo1";
import { VeiculoTipo } from "./veiculoTipo";

export interface Veiculo  {
    id: string;
    placa: string;
    proprietarioId: string | null;
    vieculoTipoId: number | null;
    renavan: string | null;
    ano: number | null;
    cor: string | null;
    numeroCrv: string | null;
    chassi: string | null;
    combustivel: string | null;
    marcaModelo: string | null;
    capacidadePeso: number | null;
    capacidadeM3: number | null;
    eixos: number | null;
    dataCadastro: string;
    proprietario: Pessoa | null;
    veiculo1s: Veiculo1[];
    vieculoTipo: VeiculoTipo | null;
}