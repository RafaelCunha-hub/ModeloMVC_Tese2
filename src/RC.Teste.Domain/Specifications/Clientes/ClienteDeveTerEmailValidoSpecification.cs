using DomainValidation.Interfaces.Specification;
using RC.Teste.Domain.Entities;
using RC.Teste.Domain.Validations.Documentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.Teste.Domain.Specifications.Clientes
{
    public class ClienteDeveTerEmailValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return EmailValidation.Validate(cliente.Email);
        }
    }
}
