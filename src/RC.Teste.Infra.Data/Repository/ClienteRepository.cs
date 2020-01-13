using RC.Teste.Domain.Entities;
using RC.Teste.Domain.Interfaces;
using RC.Teste.Domain.Interfaces.Repository;
using RC.Teste.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.Teste.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {

        public ClienteRepository(RCTesteContext context)
            : base(context)
        {

        }

        public Cliente ObterPorCpf(string cpf)
        {
            return Buscar(c => c.Cpf == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        public override void Remover(Guid id)
        {
            var cliente = new Cliente() { ClienteId = id, Ativo = false };
            Atualizar(cliente, cliente.ClienteId);
        }
    }
}
