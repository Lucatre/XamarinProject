using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Modelos
{
    [Table("Incidencia")]
    public class Incidencia
    {
        //ATRIBUTOS

        [PrimaryKey, AutoIncrement]
        public int IncidenciaID { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public string Contacto { get; set; }
        public string TipoIncidencia { get; set; }
        public string Estado { get; set; }
        public int UsuarioID { get; set; }
        public string Usuario { get; set; }
        public int TecnicoID { get; set; }
        public string Tecnico { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaFinalizacion { get; set; }


    }
}
