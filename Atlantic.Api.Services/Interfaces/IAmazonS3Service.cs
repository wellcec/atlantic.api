using System.Collections.Generic;
using System.Threading.Tasks;
using Atlantic.Api.Models.Enums;
using Microsoft.AspNetCore.Http;

namespace Atlantic.Api.Services.Interfaces
{
    public interface IAmazonS3Service
    {
        Task SaveImageToBucketAsync(IFormFile file, FolderImages folder);
        Task ProcessImageAsync(string fileName);
        Task<List<string>> GetAllFilesAsync(FolderImages folderImages);
    }
}
