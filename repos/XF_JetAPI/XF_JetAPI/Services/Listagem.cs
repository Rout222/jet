using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace XF_JetAPI.Services
{
    public class Listagem<TKey, TItem> : ObservableCollection<TItem>
    {
        public TKey K { get; private set; }
        
        public Listagem(TKey k, IEnumerable<TItem> items)
        {
            this.K = k;
            foreach (var i in items)
                this.Items.Add(i);
        }
    }
}
