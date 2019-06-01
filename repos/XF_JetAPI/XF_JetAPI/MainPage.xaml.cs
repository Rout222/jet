using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF_JetAPI.Models;
using XF_JetAPI.Services;
using System.Collections.ObjectModel;
using XF_JetAPI.Views;

namespace XF_JetAPI
{
    public partial class MainPage : ContentPage
    {
        DataService dataService;
        ObservableCollection<Produto> p;
        public MainPage()
        {
            InitializeComponent();
            dataService = new DataService();
            AtualizaDados();
        }
        private async void AtualizaDados()
        {
            p = await dataService.GetProdutosAsync();
            produtoLista.ItemsSource = new ObservableCollection<Produto>(p);
        }
        public void OnEditar(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
        }

        public async void OnVer(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            await Navigation.PushAsync(new ProdutoView(mi.CommandParameter.ToString()));
        }
    }
}
