using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSale.UI.ViewModels.Controls
{
    public partial class TagViewModel(int id, string name) : ViewModelBase
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
    }
}
