using System;
using System.Collections.Generic;

#nullable disable

namespace Examen_Final.Models
{
    public partial class TblCurso
    {
        public TblCurso()
        {
            TblNota = new HashSet<TblNota>();
        }

        public long CodigoCurso { get; set; }
        public string Nombre { get; set; }
        public bool? Habilitado { get; set; }

        public virtual ICollection<TblNota> TblNota { get; set; }
    }
}
