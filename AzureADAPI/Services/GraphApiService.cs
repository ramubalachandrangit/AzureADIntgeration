using AzureADAPI.Model;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureADAPI.Services
{
    public class GraphApiService : IGraphApiService
    {
        private readonly IAuthenticationProvider _msGraphAuthenticationProvider;

        public GraphApiService(IAuthenticationProvider authenticationProvider)
        {
            _msGraphAuthenticationProvider = authenticationProvider;
        }

        public async Task<List<UserVM>> ListUsers()
        {
            var adUsers = new List<UserVM>();
            try
            {
                GraphServiceClient graphClientLiUser = new GraphServiceClient(_msGraphAuthenticationProvider);
                var users = new List<User>();
                var usersPage = await graphClientLiUser.Users
                    .Request()
                    .GetAsync();
                users.AddRange(usersPage);
                foreach (var item in users)
                {
                    adUsers.Add(new UserVM { Id = item.Id, Name = item.GivenName });
                }
                return adUsers;
            }
            catch (Exception ex)
            {
                return adUsers;
            }
        }

        public async Task<UserVM> Create()
        {
            try
            {
                var userId = "Ramu" + Guid.NewGuid().ToString();

                GraphServiceClient graphClient = new GraphServiceClient(_msGraphAuthenticationProvider);
                var user = new User
                {
                    AccountEnabled = true,
                    DisplayName = "displayName-" + userId,
                    MailNickname = "mailNickname-" + userId,
                    UserPrincipalName = userId + "@netcoretestazuread.onmicrosoft.com",
                    GivenName = userId,
                    PasswordProfile = new PasswordProfile
                    {
                        ForceChangePasswordNextSignIn = true,
                        Password = "Password!2"
                    }
                };
                var resultUser = await graphClient.Users
                     .Request()
                     .AddAsync(user);
                return new UserVM { Name = resultUser.GivenName, Id = resultUser.Id };
            }
            catch (Exception ex)
            {
                return new UserVM();
            }
        }
    }
}
