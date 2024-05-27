using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PicSim_Resharped.Models;
using PicSim_Resharped.Services;

namespace PicSim_Resharped.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{

    #region Public Properties

        [ObservableProperty]
        private string _stackTitle = "Stack content";
        
        [ObservableProperty]
        private ObservableCollection<ProgramRow> _programRows;

        [ObservableProperty] private string? _fileString;
    #endregion
    
    
    public ICommand ScrollToPcCommand { get; set; }

    public IFileService? FileService { private get; set; }
    
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
    
    [RelayCommand]
    private async Task OpenFile()
    {
        try
        {
            var file = await FileService.OpenFileAsync();
            if (file is null) return;
            await using var readStream = await file.OpenReadAsync();
            using var reader = new StreamReader(readStream);
            FileString = await reader.ReadToEndAsync();
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (UnauthorizedAccessException e2)
        {
            Console.WriteLine(e2.Message);
        }
    }
}