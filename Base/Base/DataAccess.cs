using Base.Modelos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base
{
    public class DataAccess
    {
        #region InstanciaDB

        private SQLiteConnection con;
        private static DataAccess instancia;
        public static DataAccess Instancia
        {
            get
            {
                if (instancia == null)
                    throw new Exception("Debe llamar al inicializador, acción detenida");
                return instancia;
            }
        }
        public static void Inicializador(String filename)
        {
            if (filename == null)
            {
                throw new ArgumentException();
            }
            if (instancia != null)
            {
                instancia.con.Close();
            }
            instancia = new DataAccess(filename);
        }

        #endregion


        #region TablasDB
        private DataAccess(String dbPath)
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<Incidencia>();
            con.CreateTable<Usuario>();
        }

        #endregion


        #region Incidencia

        public string InsertIncidencia(Incidencia incidencia)
        {
            try
            {
                con.Insert(incidencia);
                return ("Incidencia agregada exitosamente");
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public void UpdateIncidencia(Incidencia incidencia)
        {
            con.Update(incidencia);
        }

        public void DeleteIncidencia(Incidencia incidencia)
        {
            con.Delete(incidencia);
        }

        public Incidencia GetIncidencia(int IncidenciaID)
        {
            return con.Table<Incidencia>().Where(i => i.IncidenciaID == IncidenciaID).FirstOrDefault();
        }

        public List<Incidencia> GetIncidencias()
        {
            return con.Table<Incidencia>().OrderBy(i => i.IncidenciaID).ToList();
        }

        public List<Incidencia> GetIncidenciasUsuario(int UsuarioID)
        {
            var x = con.Table<Incidencia>().Where(i => i.UsuarioID == UsuarioID).ToList();
            if (x == null)
            {
                return null;
            }
            return x;
        }

        public List<Incidencia> GetIncidenciasTecnico(int UsuarioID)
        {
            var x = con.Table<Incidencia>().Where(i => i.TecnicoID == UsuarioID).ToList();
            if (x == null)
            {
                return null;
            }
            return x;
        }

        #endregion


        #region Usuario

        public Usuario Login(string username, string password)
        {
            var u = con.Table<Usuario>().Where(c => c.Email.Equals(username) && c.Password.Equals(password)).FirstOrDefault();
            if (u == null)
            {
                return null;
            }
            return u;
        }
        public string InsertUsuario(Usuario usuario)
        {
            var x = con.Table<Usuario>().Where(c => c.Email.Equals(usuario.Email)).FirstOrDefault();
            if (x == null)
            {
                con.Insert(usuario);
                return ("El usuario " + usuario.NombreCompleto + " fue creado exitosamente");
            }
            return ("El usuario ya existe");

        }
        public void UpdateUsuario(Usuario usuario)
        {
            con.Update(usuario);
        }
        public void DeleteUsuario(Usuario usuario)
        {
            con.Delete(usuario);
        }
        public Usuario GetUsuario(int UsuarioID)
        {
            return con.Table<Usuario>().FirstOrDefault(c => c.UsuarioID == UsuarioID);
        }
        public List<Usuario> GetUsuarios()
        {
            return con.Table<Usuario>().OrderBy(c => c.UsuarioID).ToList();
        }

        #endregion
    }
}
