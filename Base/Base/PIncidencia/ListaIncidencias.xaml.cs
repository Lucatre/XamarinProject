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
    public partial class ListaIncidencias : ContentPage
    {
     
        public ListaIncidencias()
        {
            InitializeComponent();
        
            lstIncidencias.ItemsSource = DataAccess.Instancia.GetIncidencias();
        }

        

        private void btnactualizar_Clicked(object sender, EventArgs e)
        {
            lstIncidencias.ItemsSource = DataAccess.Instancia.GetIncidencias();
        }

        private void lstIncidencias_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new ModificarIncidencia((Incidencia)e.SelectedItem));
        }
    }
}