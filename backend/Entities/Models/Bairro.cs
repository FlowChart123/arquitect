using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Bairro : BaseEntity
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public int MunicipioId { get; set; }

    public virtual ICollection<FilialLastMile> FilialLastMiles { get; } = new List<FilialLastMile>();

    public virtual Municipio Municipio { get; set; } = null!;
}
