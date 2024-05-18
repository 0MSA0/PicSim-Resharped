using System.Threading.Tasks;
using Avalonia.Platform.Storage;

namespace PicSim_Resharped.Services;

public interface IFileService
{
    public Task<IStorageFile?> OpenFileAsync();
}