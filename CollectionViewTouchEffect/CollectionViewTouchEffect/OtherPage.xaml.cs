using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionViewTouchEffect;

public partial class OtherPage : ContentPage
{
    public OtherPage(string rowText)
    {
        InitializeComponent();
        BindingContext = new OtherPageModel(this, rowText);
    }
}