using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class DtMdfe
{
    public Guid Id { get; set; }

    public Guid DtId { get; set; }

    public int ModalId { get; set; }

    public int CidadeInicioTransporteId { get; set; }

    public int CidadeFinalTransporteId { get; set; }

    public string CepInicioTransporte { get; set; } = null!;

    public string CepFinalTransporte { get; set; } = null!;

    public decimal Distancia { get; set; }

    public int Numero { get; set; }

    public string Modelo { get; set; } = null!;

    public DateTime DataCadastro { get; set; }

    public bool Ativo { get; set; }

    public virtual Dt Dt { get; set; } = null!;

    public virtual ICollection<DtMdfeDtRomaneio> DtMdfeDtRomaneios { get; } = new List<DtMdfeDtRomaneio>();

    public virtual Modal Modal { get; set; } = null!;
}
