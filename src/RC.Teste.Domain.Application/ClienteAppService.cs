using AutoMapper;
using RC.Teste.Domain.Application.Interfaces;
using RC.Teste.Domain.Application.ViewModels;
using RC.Teste.Domain.Entities;
using RC.Teste.Domain.Interfaces;
using RC.Teste.Domain.Interfaces.Repository;
using RC.Teste.Domain.Interfaces.Services;
using RC.Teste.Infra.Data.Interfaces;
using RC.Teste.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.Teste.Domain.Application
{

    public class ClienteAppService : AppService, IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService, IUnitOfWork uow)
                    : base(uow)
        {
            _clienteService = clienteService;
        }

        public ClienteViewModel Adicionar(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel);

            var clienteReturn = _clienteService.Adicionar(cliente);
            clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(clienteReturn);

            if (clienteReturn.ValidationResult.IsValid)
            {
                Commit();
            }

            return clienteViewModel;
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteService.ObterPorId(id));
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteService.ObterPorCpf(cpf));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteService.ObterPorEmail(email));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteService.ObterTodos());
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel);
            var clienteReturn = _clienteService.Atualizar(cliente);

            if (clienteReturn.ValidationResult.IsValid)
            {
                Commit();
            }

            return clienteViewModel;
        }

        public void Remover(Guid id)
        {
            _clienteService.Remover(id);
        }

        public void Dispose()
        {
            _clienteService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
