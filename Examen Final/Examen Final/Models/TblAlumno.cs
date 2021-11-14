using System;
using System.Collections.Generic;

#nullable disable

namespace Examen_Final.Models
{
    public partial class TblAlumno
    {
        public TblAlumno()
        {
            TblNota = new HashSet<TblNota>();
        }

        public long Carnet { get; set; }
        public string Nombre { get; set; }
        public bool? Habilitado { get; set; }
        public int? Estado { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaFin { get; set; }

        public virtual ICollection<TblNota> TblNota { get; set; }
    }
}
