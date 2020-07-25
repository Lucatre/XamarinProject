using Base.Modelos;
using Base.PIncidencia;
using Base.PUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuAdmin : ContentPage
    {
        Usuario usuarioActual;
        public MenuAdmin(Usuario usuarioActual)
        {
            this.usuarioActual = usuarioActual;
            InitializeComponent();
            txtNombreUsuario.Text = "Bienvenid@ " + usuarioActual.Email;
        }
        

        private void btnCrearUsuario_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new CrearUsuarioAdmin());
        }

        private void btnModificarPerfil_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new ModificarPerfil(usuarioActual));
        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Login());
        }

        private void btnVerUsuarios_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new ListaUsuarios());
        }

        private void btnVerIncidencias_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new ListaIncidencias());
        }
    }
}