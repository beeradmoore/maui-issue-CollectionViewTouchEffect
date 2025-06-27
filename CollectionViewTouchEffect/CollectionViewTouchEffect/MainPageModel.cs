using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CollectionViewTouchEffect;

public partial class MainPageModel : ObservableObject
{
    WeakReference<MainPage> _weakPage;
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Items))]
    private bool _showShortList = true;
    
    List<string> _shortList = new List<string>()
    {
        "ShortList Item 1",
        "ShortList Item 2",
        "ShortList Item 3",
    };
    
    List<string> _longList = new List<string>()
    {
        "LongList Item 1",
        "LongList Item 2",
        "LongList Item 3",
        "LongList Item 4",
        "LongList Item 5",
    };

    public List<string> Items => ShowShortList ? _shortList : _longList;
    
    public MainPageModel(MainPage page)
    {
        _weakPage = new WeakReference<MainPage>(page);
    }

    [RelayCommand]
    void ToggleShortLongList()
    {
        ShowShortList = !ShowShortList;
    }

    [RelayCommand]
    void RowClicked(string rowText)
    {
        if (_weakPage.TryGetTarget(out var page))
        {
            page.Navigation.PushModalAsync(new OtherPage(rowText));
        }
    }
    
}