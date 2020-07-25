using Base.Modelos;
using Base.PIncidencia;
using Base.PUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base.PMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuCliente : ContentPage
    {
        Usuario usuarioActual;
        public MenuCliente(Usuario usuario)
        {
            this.usuarioActual = usuario;
            InitializeComponent();
            txtNombreUsuario.Text = "Bienvenid@ "+usuario.Email;
        }

   
        private void btnModificarPerfil_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new ModificarPerfil(usuarioActual));
        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Login());
        }

        private void btnVerIncidencias_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new ListaIncidenciasUsuario(usuarioActual));
        }

        private void btnCrearIncidencia_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new CrearIncidencia(usuarioActual));
        }
    }
}