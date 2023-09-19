using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class DocumentoImposto
{
    public Guid Id { get; set; }

    public string? Icms { get; set; }

    public string? Orig { get; set; }

    public string? IcmsCst { get; set; }

    public int? ModBc { get; set; }

    public decimal? VBc { get; set; }

    public decimal? PIcms { get; set; }

    public decimal? VIcms { get; set; }

    public string? CEnq { get; set; }

    public string? IpiCst { get; set; }

    public string? PisCst { get; set; }

    public decimal? PisvBc { get; set; }

    public decimal? PispPis { get; set; }

    public decimal? PisvPis { get; set; }

    public string? CofinsCst { get; set; }

    public decimal? CofinsvBc { get; set; }

    public decimal? CofinspCofins { get; set; }

    public decimal? CofinsvCofins { get; set; }

    public virtual Documento IdNavigation { get; set; } = null!;
}
