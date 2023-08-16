export interface Categoria {
    id: number
    ano: number
    nome: string
    dataAlteracao: Date
    dataCadastro: Date;
    dataPagamento: Date;
    dataVencimento: Date;
    despesaAntrasada: boolean
    idCategoria: number
    mes: number
    pago: boolean
    tipoDespesa: number
    valor: number
  }