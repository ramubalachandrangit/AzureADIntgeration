using AzureADAPI.Model;
using AzureADAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc.Filters;

namespace AzureADAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IGraphApiService _graphApiService;
        public UserController(IGraphApiService graphApiService)
        {
            _graphApiService = graphApiService;
        }
        
        [HttpGet]
        public async Task<IEnumerable<UserVM>> Get()
        {
            return await _graphApiService.ListUsers();
        }

        [HttpPost]
        public async Task<UserVM> Create()
        {
            return await _graphApiService.Create();
        }
    }     
}
