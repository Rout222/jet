using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF_JetAPI.Models;
using XF_JetAPI.Services;

namespace XF_JetAPI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProdutoView : ContentPage
    {
        Produto p;
        DataService dataService = new DataService();

        public ProdutoView(long id)
        {
            InitializeComponent();
            getProduto(id);
        }

        private async void getProduto(long id)
        {
            p = await dataService.GetProdutoAsync(id);
            entryNome.Text = p.Nome;
            entryStats.Text = p.Status;
            entryCodigo.Text = Convert.ToString(p.Codigo);
            entryPreco.Text = Convert.ToString(p.Preco);
        }

        private async void Salvar(object sender, EventArgs args)
        {
            p.Nome = entryNome.Text;
            p.Status = entryStats.Text;
            p.Codigo = Convert.ToInt64(entryCodigo.Text);
            p.Preco = float.Parse(entryPreco.Text);
            dataService.UpdateProdutoAsync(p.Id, p);
            await Navigation.PopAsync();
        }
    }
}