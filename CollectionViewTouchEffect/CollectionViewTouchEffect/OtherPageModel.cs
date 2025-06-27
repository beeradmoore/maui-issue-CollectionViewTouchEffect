using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CollectionViewTouchEffect;

public partial class OtherPageModel : ObservableObject
{
    private WeakReference<OtherPage> _weakPage;
    
    [ObservableProperty]
    string _rowText = string.Empty;
    
    public OtherPageModel(OtherPage page, string rowText)
    {
        _weakPage = new WeakReference<OtherPage>(page);
        RowText = rowText;
    }
    
    [RelayCommand]
    async Task GoBackAsync()
    {
        if (_weakPage?.TryGetTarget(out var page) == true)
        {
            //await page.Navigation.PopAsync();
            await page.Navigation.PopModalAsync();
        }
    }
}