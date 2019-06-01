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
            //p = await dataService.GetProdutosAsync();
            produtoLista.ItemsSource = new ObservableCollection<Produto>(await dataService.GetProdutosAsync());
        }
        private void Procurar_TextChanged(object sender, TextChangedEventArgs e)
        {
            produtoLista.ItemsSource = this.Listar(this.sbProcurar.Text);
        }

        public IEnumerable<Listagem<string, Produto>> Listar(string filtro = "")
        {
            IEnumerable<Produto> produtosFiltrados = this.p;

            if (!string.IsNullOrEmpty(filtro))
                produtosFiltrados = p.Where(l => (l.Nome.ToLower().Contains(filtro.ToLower())) || l.Status.ToLower().Contains(filtro.ToLower()));
            return from produto in produtosFiltrados
                   orderby produto.Nome
                   group produto by produto.Status into grupos
                   select new Listagem<string, Produto>(grupos.Key, grupos);
        }
    }
}
