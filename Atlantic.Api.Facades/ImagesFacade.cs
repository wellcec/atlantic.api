using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Atlantic.Api.Data.EcommerceDataContext.Repositories.Interfaces;
using Atlantic.Api.Facades.Core;
using Atlantic.Api.Facades.Interfaces;
using Atlantic.Api.Facades.Validators;
using Atlantic.Api.Models.Context.Products;
using Atlantic.Api.Models.DTOs;
using Atlantic.Api.Models.Enums;
using Atlantic.Api.Models.Responses;
using Atlantic.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Atlantic.Api.Facades
{
    public class ImagesFacade : BaseFacade, IImagesFacade
    {
        private readonly IValidatorHelper _validatorHelper;
        private readonly IAmazonS3Service _amazonS3Service;
        private readonly IImagesRepository _imagesRepository;

        public ImagesFacade(
                CommonDependenciesFacade commonDependenciesFacade,
                IValidatorHelper validatorHelper,
                IAmazonS3Service amazonS3Service,
                IImagesRepository imagesRepository
            )
            : base(commonDependenciesFacade)
        {
            _validatorHelper = validatorHelper;
            _amazonS3Service = amazonS3Service;
            _imagesRepository = imagesRepository;
        }

        public List<ImageDTO> GetTemporaryImagesAsync()
        {
            return _imagesRepository.GetAll();
        }

        public async Task<BaseResponse> SaveTemporaryImageAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return new BaseResponse() { Code = HttpStatusCode.BadRequest, Message = "Nenhum arquivo enviado." };
            }

            try
            {
                await _amazonS3Service.SaveImageToBucketAsync(file, FolderImages.TEMP);

                var imageToAdd = new Image()
                {
                    fileName = file.FileName,
                    createdDate = DateTime.Now,
                };

                await _imagesRepository.InsertAsync(imageToAdd);

                return new BaseResponse() { Code = HttpStatusCode.OK, Message = "Arquivo enviado com sucesso para o S3!" };
            }
            catch (Exception ex)
            {
                Logger.Error("Error on insert image. Error: {E}", ex.Message);
                return new BaseResponse() { Code = HttpStatusCode.InternalServerError, Message = ex.Message };
            }
        }

        public async Task<BaseResponse> ProcessImageAsync()
        {
            try
            {
                var filesToProcess = await _amazonS3Service.GetAllFilesAsync(FolderImages.TEMP);
                foreach (var file in filesToProcess)
                {
                    var mount = file.Split("/")[1];
                    var fileName = mount.Split("-")[0].Trim();

                    await _amazonS3Service.ProcessImageAsync(fileName);
                }

                await _imagesRepository.DeleteAllAsync();

                return new BaseResponse() { Code = HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                Logger.Error("Error on insert image. Error: {E}", ex.Message);
                return new BaseResponse() { Code = HttpStatusCode.InternalServerError, Message = ex.Message };
            }
        }

        public async Task<BaseResponse> GetAllFilesAsync()
        {
            try
            {
                var response = await _amazonS3Service.GetAllFilesAsync(FolderImages.IMAGES);

                return new BaseResponse() { Code = HttpStatusCode.OK, Result = response };
            }
            catch (Exception ex)
            {
                Logger.Error("Error on get images. Error: {E}", ex.Message);
                return new BaseResponse() { Code = HttpStatusCode.InternalServerError, Message = ex.Message };
            }
        }
    }
}
