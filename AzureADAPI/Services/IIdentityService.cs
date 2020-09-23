using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureADAPI.Services
{
    public interface IIdentityService
    {
        bool IsAuthenticated();

        string GetId();
    }
}
