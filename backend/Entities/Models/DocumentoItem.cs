using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class DocumentoItem : BaseEntity
{
    public Guid Id { get; set; }

    public Guid DocumentoPadraoId { get; set; }

    public Guid ProdutoId { get; set; }

    public decimal? Quantidade { get; set; }

    public int? NItem { get; set; }

    public string? CProd { get; set; }

    public string? CEan { get; set; }

    public int? UCom { get; set; }

    public int? QCom { get; set; }

    public decimal? VUnCom { get; set; }

    public decimal? VProd { get; set; }

    public decimal? VUnTrib { get; set; }

    public string? XPed { get; set; }

    public string? Cfop { get; set; }

    public string? CEantrib { get; set; }

    public string? Ncm { get; set; }

    public string? UTrib { get; set; }

    public decimal? QTrib { get; set; }

    public virtual Documento DocumentoPadrao { get; set; } = null!;

    public virtual Produto Produto { get; set; } = null!;
}
