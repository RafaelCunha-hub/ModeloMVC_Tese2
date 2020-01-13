using RC.Teste.Domain.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.Teste.Domain.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        ClienteViewModel Adicionar(ClienteViewModel clienteViewModel);
        ClienteViewModel ObterPorId(Guid id);
        ClienteViewModel ObterPorCpf(string cpf);
        ClienteViewModel ObterPorEmail(string email);
        IEnumerable<ClienteViewModel> ObterTodos();
        ClienteViewModel Atualizar(ClienteViewModel clienteViewModel);
        void Remover(Guid id);
    }
}
