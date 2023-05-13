using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces.Application
{
    public interface ICollaboratorService
    {
        Task<Collaborator> Save(Collaborator collaborator);
        Task<List<Collaborator>> GetAll();
    }
}
