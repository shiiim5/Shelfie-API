using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace Library.Infrastructure.Repositories.Service
{
    public class ImageManagementService : IImageManagementService
    {
        private readonly IFileProvider fileProvider;
        public ImageManagementService(IFileProvider fileProvider)
        {
            this.fileProvider = fileProvider;
        }
        public async Task<List<string>> AddImgAsync(IFormFileCollection formFileCollection, string src)
        {
            var SaveImgSrc = new List<string>();
            var ImgDirectory = Path.Combine("wwwroot","Imgs",src);
            if(Directory.Exists(ImgDirectory) is not true)
            {
                Directory.CreateDirectory(ImgDirectory);
            }

            foreach (var file in formFileCollection) {
                if (file.Length > 0) {
                    var ImgName = file.FileName;
                    var ImgSrc = $"/Imgs/{src}/{ImgName}";
                    var root = Path.Combine (ImgDirectory, ImgName);

                    using (FileStream fileStream = new FileStream(root, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    SaveImgSrc.Add(ImgSrc);
                }
            
            }
            return SaveImgSrc;
        }

        public void DeleteImgAsync(string src)
        {
            var info = fileProvider.GetFileInfo(src);
            var root = info.PhysicalPath;
            File.Delete(root);
        }
    }
}
