using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSale.UI.ViewModels.Controls.Items;

public partial class ProductVerticalCardViewModel : ViewModelBase
{
    [ObservableProperty]
    private IEnumerable<TagViewModel> tags;

    public ProductVerticalCardViewModel()
    {
            tags = [
                new TagViewModel(1, "Item"),
                new TagViewModel(1, "Cold"),
                new TagViewModel(1, "Warm"),
                new TagViewModel(1, "Insame"),
                new TagViewModel(1, "Good Audio"),
            ];
    }
}
