import { Transportador } from "./transportador";

export interface TipoRntrc  {
    id: number;
    codigo: string;
    descricao: string;
    transportadors: Transportador[];
}