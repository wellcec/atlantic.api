using System.Collections.Generic;
using System.Threading.Tasks;
using Atlantic.Api.Models.DTOs;
using Atlantic.Api.Models.Responses;
using Microsoft.AspNetCore.Http;

namespace Atlantic.Api.Facades.Interfaces
{
    public interface IImagesFacade
    {
        List<ImageDTO> GetTemporaryImagesAsync();
        Task<BaseResponse> SaveTemporaryImageAsync(IFormFile file);
        Task<BaseResponse> ProcessImageAsync();
        Task<BaseResponse> GetAllFilesAsync();
    }
}
