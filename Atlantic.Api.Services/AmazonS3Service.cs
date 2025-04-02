using System.Threading.Tasks;
using AutoMapper;
using Atlantic.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Amazon.S3;
using Amazon.S3.Transfer;
using System.IO;
using Atlantic.Api.Models;
using System.Collections.Generic;
using Amazon.S3.Model;
using Atlantic.Api.Models.Enums;
using Atlantic.Api.Models.Extensions;
using Atlantic.Api.Models.UI;

namespace Atlantic.Api.Services
{
    public class AmazonS3Service : IAmazonS3Service
    {
        private readonly IMapper _mapper;
        private readonly IAmazonS3 _s3Client;

        public AmazonS3Service(IMapper mapper, IAmazonS3 s3Client)
        {
            _mapper = mapper;
            _s3Client = s3Client;
        }

        public async Task SaveImageToBucketAsync(IFormFile file, FolderImages folderImages)
        {
            var folder = folderImages.GetEnumDescription().ToLower() + "/";

            using (var newMemoryStream = new MemoryStream())
            {
                await file.CopyToAsync(newMemoryStream);
                var uploadRequest = new TransferUtilityUploadRequest
                {
                    InputStream = newMemoryStream,
                    Key = folder + file.FileName,
                    BucketName = Constants.BUCKET_NAME,
                    ContentType = file.ContentType,
                    CannedACL = S3CannedACL.PublicRead
                };

                var transferUtility = new TransferUtility(_s3Client);
                await transferUtility.UploadAsync(uploadRequest);
            };
        }

        public async Task ProcessImageAsync(string fileName)
        {
            var folderSrc = FolderImages.TEMP.GetEnumDescription().ToLower() + "/";
            var folderDest = FolderImages.IMAGES.GetEnumDescription().ToLower() + "/";

            var copyRequest = new CopyObjectRequest
            {
                SourceBucket = Constants.BUCKET_NAME,
                SourceKey = folderSrc + fileName,
                DestinationBucket = Constants.BUCKET_NAME,
                DestinationKey = folderDest + fileName,
            };

            await _s3Client.CopyObjectAsync(copyRequest);

            var deleteRequest = new DeleteObjectRequest
            {
                BucketName = Constants.BUCKET_NAME,
                Key = folderSrc + fileName
            };

            await _s3Client.DeleteObjectAsync(deleteRequest);
        }

        public async Task<List<string>> GetAllFilesAsync(FolderImages folderImages)
        {
            var folder = folderImages.GetEnumDescription().ToLower();

            var list = new List<string>();

            var request = new ListObjectsV2Request
            {
                BucketName = Constants.BUCKET_NAME,
                Prefix = folder + "/"
            };

            var response = await _s3Client.ListObjectsV2Async(request);

            foreach (var obj in response.S3Objects)
            {
                list.Add($"{obj.Key} - ({obj.Size} bytes)");
            }

            return list;
        }

        public async Task DeleteImageAsync(string fileName, FolderImages folderImages)
        {
            var folder = folderImages.GetEnumDescription().ToLower() + "/";

            var deleteRequest = new DeleteObjectRequest
            {
                BucketName = Constants.BUCKET_NAME,
                Key = folder + fileName
            };

            await _s3Client.DeleteObjectAsync(deleteRequest);
        }
    }
}
