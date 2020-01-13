using DomainValidation.Validation;
using RC.Teste.Domain.Entities;
using RC.Teste.Domain.Interfaces;
using RC.Teste.Domain.Interfaces.Repository;
using RC.Teste.Domain.Specifications.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.Teste.Domain.Validations.Clientes
{
    public class ClienteAptoParaCadastroValidation : Validator<Cliente>
    {
        public ClienteAptoParaCadastroValidation(IClienteRepository clienteRepository)
        {
            var cpfDuplicado = new ClienteDevePossuirCPFUnicoSpecification(clienteRepository);
            var emailDuplicado = new ClienteDevePossuirEmailUnicoSpecification(clienteRepository);

            base.Add("cpfDuplicado", new Rule<Cliente>(cpfDuplicado, "CPF já cadastrado! Esqueceu sua senha?"));
            base.Add("emailDuplicado", new Rule<Cliente>(emailDuplicado, "E-mail já cadastrado! Esqueceu sua senha?"));
        }
    }
}
