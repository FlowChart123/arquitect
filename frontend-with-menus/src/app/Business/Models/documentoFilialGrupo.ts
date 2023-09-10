import { Documento1 } from "./documento1";
import { Endereco } from "./endereco";

export interface DocumentoFilialGrupo  {
    id: string;
    enderecoServicoId: string;
    filialId: number;
    filialAtualId: number | null;
    filialDestinoId: number | null;
    filialLastMileGrupoItemId: string | null;
    transportadorLastMileGrupoItemId: string | null;
    enderecoServico: Endereco;
    idNavigation: Documento1;
}