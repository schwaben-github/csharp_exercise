using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Članovi
{
    public int ČlanId { get; set; }

    public string? Ime { get; set; }

    public string? Prezime { get; set; }

    public int? AdresaId { get; set; }

    public virtual MjestaStanovanja? Adresa { get; set; }

    public virtual ICollection<Posudbe> Posudbe { get; set; } = new List<Posudbe>();
}
