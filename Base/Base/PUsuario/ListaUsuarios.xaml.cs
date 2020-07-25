using Base.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base.PUsuario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaUsuarios : ContentPage
    {

        public ListaUsuarios()
        {
            InitializeComponent();
            lstUsuarios.ItemsSource = DataAccess.Instancia.GetUsuarios();
        }

        private void lstUsuarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new ModificarUsuario((Usuario)e.SelectedItem));
        }

        private void btnactualizar_Clicked(object sender, EventArgs e)
        {
            lstUsuarios.ItemsSource = DataAccess.Instancia.GetUsuarios();
        }
    }
}