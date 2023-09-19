import { TransportadorLastMile } from "./transportadorLastMile";
import { TransportadorLastMileGrupo } from "./transportadorLastMileGrupo";


export interface TransportadorLastMileGrupoItem  {
    id: string;
    transportadorLastMileGrupoId: string;
    transportadorLastMileId: string;
    transportadorLastMile: TransportadorLastMile;
    transportadorLastMileGrupo: TransportadorLastMileGrupo;
}
