using CommunityToolkit.Mvvm.ComponentModel;

namespace PicSim_Resharped.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private string _stackTitle = "Stack content";
}