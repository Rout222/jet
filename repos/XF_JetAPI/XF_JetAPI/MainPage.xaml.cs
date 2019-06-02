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
            produtoLista.RefreshCommand = new Command(() => {
                 //Do your stuff.    
                 AtualizaDados();
                 produtoLista.IsRefreshing = false;
             });
        }
        public async void AtualizaDados()
        {
            p = await dataService.GetProdutosAsync();
            produtoLista.ItemsSource = new ObservableCollection<Produto>(p);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lv = (ListView)sender;
            Produto p = (Produto)lv.SelectedItem;
            await Navigation.PushAsync(new ProdutoView(p.Id));
            AtualizaDados();
        }
    }
}
