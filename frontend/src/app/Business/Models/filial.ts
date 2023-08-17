import { FilialLastMile } from "./FilialLastMile";
import { Empresa } from "./empresa";

export interface Filial  {
    id: number;
    empresaId: number;
    pessoaId: string;
    filialPaiId: number | null;
    dataCadastro: string;
    ativo: boolean | null;
    empresa: Empresa;
    filialLastMiles: FilialLastMile[];
    filialPai: Filial | null;
    inverseFilialPai: Filial[];
}