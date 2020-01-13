using DomainValidation.Interfaces.Specification;
using RC.Teste.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.Teste.Domain.Specifications.Clientes
{
    public class ClienteDeveTerUmEnderecoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return cliente.Enderecos != null && cliente.Enderecos.Any();
        }
    }
}
