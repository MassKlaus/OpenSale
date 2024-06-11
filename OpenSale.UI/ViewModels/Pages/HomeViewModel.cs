using CommunityToolkit.Mvvm.ComponentModel;
using OpenSale.UI.Attributes;
using OpenSale.UI.ViewModels.Controls.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSale.UI.ViewModels.Pages;

[Page("Products", @"\Assets\Icons\IconParkOutlineAdProduct.svg", position: 1)]
public partial class HomeViewModel : ViewModelBase
{
    [ObservableProperty]
    private string greeting = "Hell";

    [ObservableProperty]
    private ProductVerticalCardViewModel[] list = [
        new ProductVerticalCardViewModel(),
        new ProductVerticalCardViewModel(),
        new ProductVerticalCardViewModel(),
        new ProductVerticalCardViewModel(),
        new ProductVerticalCardViewModel(),
    ];
}
