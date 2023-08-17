import { Filial } from "./filial";
import { Tenant } from "./tenant";

export interface Empresa  {
    id: number;
    tenantId: string;
    nome: string;
    ativo: boolean;
    filials: Filial[];
    tenant: Tenant;
}