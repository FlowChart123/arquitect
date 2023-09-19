using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class LogProcessamento
{
    public Guid Id { get; set; }

    public DateTime? Inicio { get; set; }

    public DateTime? Final { get; set; }

    public int? Registros { get; set; }

    public int? TempoGasto { get; set; }

    public string? Tarefa { get; set; }

    public DateTime? DataCadastro { get; set; }
}
