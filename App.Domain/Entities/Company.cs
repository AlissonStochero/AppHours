using App.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    [Index(nameof(CNPJ))]
    public class Company : BaseEntity
    {
        public Company()
        {

        }
        public Company(Name name, long cnpj)
        {
            Name= name;
            CNPJ= cnpj;
        }
        
        public Name Name { get; set; }
        public long CNPJ { get; set; }
    }
}
