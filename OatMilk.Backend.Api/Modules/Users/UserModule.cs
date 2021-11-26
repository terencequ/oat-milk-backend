using System;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using OatMilk.Backend.Api.AspNet;
using OatMilk.Backend.Api.Modules.Users.Data;
using OatMilk.Backend.Api.Modules.Users.Domain;
using OatMilk.Backend.Api.Modules.Users.Domain.Abstractions;
using OatMilk.Backend.Api.Modules.Users.Domain.Automapper;

namespace OatMilk.Backend.Api.Modules.Users
{
    public class UserModule : Module
    {
        public UserModule(IServiceCollection serviceCollection, IMongoDatabase database) : base(serviceCollection, database)
        {
        }

        public override void Register()
        {
            RegisterAutoMapperProfiles(typeof(UserProfile));
            RegisterService<IUserService, UserService>();
            CreateIndex<User>(def => def.Descending(u => u.CreatedDateTimeUtc));
            CreateIndex<User>(def => def.Descending(u => u.UpdatedDateTimeUtc));
        }
    }
}