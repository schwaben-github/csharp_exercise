using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Knjige
{
    public int KnjigaId { get; set; }

    public string? Naslov { get; set; }

    public string? Autor { get; set; }

    public int? KategorijaId { get; set; }

    public virtual KategorijeKnjiga? Kategorija { get; set; }

    public virtual ICollection<Posudbe> Posudbe { get; set; } = new List<Posudbe>();
}
