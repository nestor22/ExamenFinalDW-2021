using System;
using System.Collections.Generic;

#nullable disable

namespace Examen_Final.Models
{
    public partial class TblNota
    {
        public long CodigoCurso { get; set; }
        public long Carnet { get; set; }
        public int Nota { get; set; }
        public DateTime? FechaIngreso { get; set; }

        public virtual TblAlumno CarnetNavigation { get; set; }
        public virtual TblCurso CodigoCursoNavigation { get; set; }
    }
}
