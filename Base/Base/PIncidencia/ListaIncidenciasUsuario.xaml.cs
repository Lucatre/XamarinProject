using Base.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base.PIncidencia
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaIncidenciasUsuario : ContentPage
    {
 
        Usuario usuarioActual;
        public ListaIncidenciasUsuario(Usuario usuario)
        {
            usuarioActual = usuario;
            InitializeComponent();

            lstIncidencias.ItemsSource = DataAccess.Instancia.GetIncidenciasUsuario(usuarioActual.UsuarioID);
        }

       

        private void btnactualizar_Clicked(object sender, EventArgs e)
        {
            lstIncidencias.ItemsSource = DataAccess.Instancia.GetIncidenciasUsuario(usuarioActual.UsuarioID);
        }

        private void lstIncidencias_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new VerIncidencia((Incidencia)e.SelectedItem));
        }
    }
}