
export interface PessoaFisicaComplemento  {
    id: string; 
    rg: string | null;
    rgEmissaoData: any;
    rgEmissaoUf: string;
    rgEmissaoMunicipio: string;
    nascimentoData: any;
    nascimentoUf: string;
    nascimentoMunicipio: string;
    nomePai: string;
    nomeMae: string;
    cnh: string;
    cnhEmissao: any;
    cnhValidade: any;
    cnhCategoria: string;
    cnhPrimeiraHabilitacao: any;
    nacionalidade: string;

   
}