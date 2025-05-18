using AutoMapper;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
  
    public class UserController : BaseController
    {
        public UserController(IUnitOfWork unit, IMapper mapper) : base(unit, mapper)
        {
        }
    }
}
