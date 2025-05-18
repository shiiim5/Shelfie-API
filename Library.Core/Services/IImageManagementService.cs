using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Library.Core.Services
{
    public interface IImageManagementService
    {
        public Task<List<string>> AddImgAsync(IFormFileCollection formFileCollection, string src);
     
        public void DeleteImgAsync(string src);
        
    }
}
