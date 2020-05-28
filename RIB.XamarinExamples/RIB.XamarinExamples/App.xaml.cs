using System;
using FreshMvvm;
using RIB.XamarinExamples.PageModels;
using RIB.XamarinExamples.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RIB.XamarinExamples
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Xamarin.Forms.DataGrid.DataGridComponent.Init();
            FreshIOC.Container.Register<IDataService, MyDataService>();

            var tablePage = FreshPageModelResolver.ResolvePageModel<MyTablePageModel>();
            var container = new FreshNavigationContainer(tablePage);
            MainPage = container;
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
