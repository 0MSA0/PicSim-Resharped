using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PicSim_Resharped.Models;

namespace PicSim_Resharped.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private string _stackTitle = "Stack content";
    
    [ObservableProperty]
    private ObservableCollection<ProgramRow> _programRows;
    
    
    public ICommand ScrollToPcCommand { get; set; }
    
    public MainWindowViewModel()
    {
        ProgramRows = new ObservableCollection<ProgramRow>(new List<ProgramRow>
        {
            new ProgramRow("MOVLW 0x0F", "0x00"),
            new ProgramRow("MOVWF 0x0A", "0x01"),
            new ProgramRow("MOVLW 0x0A", "0x02"),
        });
        ScrollToPcCommand = new RelayCommand<ProgramRow>(ScrollTo);
    }
    
    private void ScrollTo(ProgramRow? row)
    {
        // Scroll to the selected row
        // Implemented in the view
    }
    
}