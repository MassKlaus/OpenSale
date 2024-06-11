using Avalonia.Controls;
using OpenSale.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSale.UI.Common;

public class PageBase<T> : UserControl where T : ViewModelBase
{
    public T? VM
    {
        get => DataContext as T;
        set => DataContext = value;
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }
}
