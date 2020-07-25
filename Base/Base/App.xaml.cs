using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base
{
    public partial class App : Application
    {
        public App(string filename)
        {
            InitializeComponent();
            DataAccess.Inicializador(filename);
            MainPage = new NavigationPage(new Login());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
