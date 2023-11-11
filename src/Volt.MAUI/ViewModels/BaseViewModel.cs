using CommunityToolkit.Mvvm.ComponentModel;

namespace Volt.MAUI.ViewModels;

public partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    bool isBusy;
}