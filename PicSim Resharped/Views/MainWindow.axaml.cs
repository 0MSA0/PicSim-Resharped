using Avalonia.Controls;
using Avalonia.Interactivity;
using CommunityToolkit.Mvvm.Input;
using PicSim_Resharped.Models;
using PicSim_Resharped.ViewModels;

namespace PicSim_Resharped;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }

    private void OnLoaded(object? sender, RoutedEventArgs e)
    {
        if (DataContext is MainWindowViewModel vm)
        {
            vm.ScrollToPcCommand = new RelayCommand<ProgramRow>(ScrollTo);
        }
    }
    
    private void ScrollTo(ProgramRow? row)
    {
        // Scroll to the selected row
        ProgramGrid.ScrollIntoView(row, ProgramGrid.Columns[2]);
    }
}