using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSale.UI.Attributes
{
    public class PageAttribute(string name, string? icon = null, int position = int.MaxValue) : Attribute
    {
        public string Name { get; } = name;
        public string? Icon { get; } = icon;
        public int Position { get; } = position;
    }
}
