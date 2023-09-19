using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class DocumentoFrete
{
    public Guid Id { get; set; }

    public decimal? FretePeso { get; set; }

    public decimal? FreteExcedente { get; set; }

    public decimal? FreteValor { get; set; }

    public decimal? Gris { get; set; }

    public decimal? Despacho { get; set; }

    public decimal? Tde { get; set; }

    public decimal? Trt { get; set; }

    public decimal? Pedagio { get; set; }

    public decimal? TaxaDeColeta { get; set; }

    public decimal? TaxaDeEntrega { get; set; }

    public decimal? Outros { get; set; }

    public decimal? Aliquota { get; set; }

    public decimal? IcmsIss { get; set; }

    public decimal? ImpostoArecolher { get; set; }

    public decimal? BaseDeCalculo { get; set; }

    public decimal? PercentualReducaoBaseCalculo { get; set; }

    public decimal? Frete { get; set; }

    public string? Cst { get; set; }

    public decimal? BaseDeCalculoStretido { get; set; }

    public decimal? IcmsStretido { get; set; }

    public decimal? PercentualIcmsRetido { get; set; }

    public decimal? CreditoOutorgado { get; set; }

    public decimal? PercentualReducaoBaseCalculoOutraUf { get; set; }

    public decimal? BaseDeCalculoOutraUf { get; set; }

    public decimal? PercentualIcmsOutraUf { get; set; }

    public decimal? IcmsOutraUf { get; set; }

    public virtual ICollection<DocumentoCte> DocumentoCtes { get; } = new List<DocumentoCte>();
}
