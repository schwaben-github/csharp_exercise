using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Posudbe
{
    public int PosudbaId { get; set; }

    public int? ČlanId { get; set; }

    public int? KnjigaId { get; set; }

    public DateOnly? DatumPosudbe { get; set; }

    public DateOnly? DatumVraćanja { get; set; }

    public virtual Knjige? Knjiga { get; set; }

    public virtual Članovi? Član { get; set; }
}
