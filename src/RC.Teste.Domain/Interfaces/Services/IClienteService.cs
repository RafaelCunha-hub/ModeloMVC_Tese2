using RC.Teste.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.Teste.Domain.Interfaces.Services
{
    public interface IClienteService : IDisposable
    {
        Cliente Adicionar(Cliente cliente);
        Cliente Atualizar(Cliente cliente);
        void Remover(Guid id);
        IEnumerable<Cliente> ObterTodos();
        Cliente ObterPorId(Guid id);
        Cliente ObterPorCpf(string cpf);
        Cliente ObterPorEmail(string email);
    }
}
