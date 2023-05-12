using App.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class Collaborator : BaseEntity
    {
        public Collaborator()
        {

        }
        public Collaborator(Guid id, Name name, Email email, Password keyPassword)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Name = name;
            Email = email;
            KeyPassword = keyPassword;
        }
        public Name Name { get; set; }
        public Email Email { get; set; }
        public Password KeyPassword { get; set; }

        public Company company { get; set; }
    }
}
