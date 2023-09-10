import { Pessoa } from "./pessoa";
import { Tenant } from "./tenant";
import { TipoContum } from "./tipoContum";
import { Transportador } from "./transportador";


export interface Transportador1  {
    id: string;
    transportadorId: string;
    tenantId: string;
    titularId: string;
    tipoContaId: number | null;
    chavePix: string | null;
    banco: string | null;
    agencia: string | null;
    agencidaDigito: string | null;
    conta: string | null;
    contaDigito: string | null;
    cnpjCpfFavorecido: string | null;
    nomeFavorecido: string | null;
    idNavigation: Pessoa;
    tenant: Tenant;
    tipoConta: TipoContum | null;
    transportador: Transportador;
}