using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;

namespace PicSim_Resharped.Services;

public class FileService : IFileService
{
    private readonly Window _target;

    public FileService(Window target)
    {
        _target = target;
    }

    public async Task<IStorageFile?> OpenFileAsync()
    {
        var files = await _target.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions()
        {
            Title = "Open LST File",
            AllowMultiple = false
        });
        return files.Count >= 1 ? files[0] : null;
    }
}