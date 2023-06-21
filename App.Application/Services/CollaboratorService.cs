using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using App.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Services
{
    public class CollaboratorService : ICollaboratorService
    {
        private IRepositoryBase<Collaborator> _repository { get; set; }
        public CollaboratorService(IRepositoryBase<Collaborator> repository)
        {
            _repository = repository;
        }

        public async Task<Collaborator> Save(Collaborator collaborator)
        {
            var collaboratorSaved = await _repository.SaveAsync(collaborator);
            _repository.SaveChanges();

            return collaboratorSaved;
        }
        public Task<List<Collaborator>> GetAll()
        {
            return _repository.Query(x => x.Id != Guid.Empty).ToListAsync();
        }
        public Task<Collaborator> Get(Guid Id)
        {
            var collaborator = _repository.Query(x => x.Id == Id).FirstOrDefault();
            return Task.FromResult(collaborator);
        }
    }
}
