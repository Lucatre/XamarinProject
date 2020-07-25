using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Modelos
{
    [Table("Usuario")]
    public class Usuario
    {
        //ATRIBUTOS

        [PrimaryKey, AutoIncrement]
        public int UsuarioID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Celular { get; set; }
        public string TipoUsuario { get; set; }
        public bool Activo { get; set; }



        //TO STRING
        public string NombreCompleto
        {
            get
            {
                return string.Format("{0} {1} {2}", this.Nombre, this.PrimerApellido, this.SegundoApellido);
            }

        }

        public string TipoUsuarioL
        {
            get
            {
                if (this.TipoUsuario=="A")
                {
                    return "Administrador";
                }
                return "Cliente";
            }
        }
    }
}
