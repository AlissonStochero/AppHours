using App.Application.Services;
using App.Domain.Interfaces.Application;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application
{
    public class DependencyInjectionConfig
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddTransient<ICollaboratorService, CollaboratorService>();
        }
    }
}
