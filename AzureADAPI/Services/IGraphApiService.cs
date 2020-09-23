using AzureADAPI.Model;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureADAPI.Services
{
    public interface IGraphApiService
    {
        Task<List<UserVM>> ListUsers();

        Task<UserVM> Create();
    }
}
