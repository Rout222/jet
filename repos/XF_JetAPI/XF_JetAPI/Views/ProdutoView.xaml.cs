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
    public partial class ProdutoView : ContentView
    {
        private Label nome;
        Produto p;
        DataService dataService = new DataService();

        public ProdutoView(string id)
        {
            InitializeComponent();
            getProduto(id);
        }

        private async void getProduto(string id)
        {
            p = await dataService.GetProdutoAsync(id);
        }
    }
}