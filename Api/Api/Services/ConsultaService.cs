using Api.Context;
using Api.Models;
using Api.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Services
{
	public class ConsultaService : IConsultaService
	{
		private readonly IRepository<AccionistasTcSaldoTotalDeudum> _repositoryAccionistasTcSaldoTotalDeuda;
		private readonly IRepository<ConsultaDeudaTarjetaPorFranquicium> _repositoryConsultaDeudaTarjetaPorFranquicia;
		private readonly IRepository<CuentaAhorrosMasCliente> _repositoryCuentaAhorrosMasCliente;
		private readonly IRepository<CuentasActivasClientesExtranjero> _repositoryCuentasActivasClientesExtranjero;
		private readonly IRepository<MayorSaldoCanje> _repositoryMayorSaldoCanje;
		private readonly AcmeDbContext _context;

		public ConsultaService(IRepository<AccionistasTcSaldoTotalDeudum> repositoryAccionistasTcSaldoTotalDeuda,
			IRepository<ConsultaDeudaTarjetaPorFranquicium> repositoryConsultaDeudaTarjetaPorFranquicia,
			IRepository<CuentaAhorrosMasCliente> repositoryCuentaAhorrosMasCliente,
			IRepository<CuentasActivasClientesExtranjero> repositoryCuentasActivasClientesExtranjero,
			IRepository<MayorSaldoCanje> repositoryMayorSaldoCanje,
			AcmeDbContext context
			)
		{
			_repositoryAccionistasTcSaldoTotalDeuda = repositoryAccionistasTcSaldoTotalDeuda;
			_repositoryConsultaDeudaTarjetaPorFranquicia = repositoryConsultaDeudaTarjetaPorFranquicia;
			_repositoryCuentaAhorrosMasCliente = repositoryCuentaAhorrosMasCliente;
			_repositoryCuentasActivasClientesExtranjero = repositoryCuentasActivasClientesExtranjero;
			_repositoryMayorSaldoCanje = repositoryMayorSaldoCanje;
			_context = context;
		}

		public async Task<IEnumerable<AccionistasTcSaldoTotalDeudum>> GetAccionistasTcSaldoTotalDeuda()
		{
			return await _repositoryAccionistasTcSaldoTotalDeuda.GetAll();
		}

		public async Task<IEnumerable<ConsultaDeudaTarjetaPorFranquicium>> GetConsultaDeudaTarjetaPorFranquicia()
		{
			return await _repositoryConsultaDeudaTarjetaPorFranquicia.GetAll();
		}

		public async Task<IEnumerable<CuentaAhorrosMasCliente>> GetCuentaAhorrosMasCliente()
		{
			return await _repositoryCuentaAhorrosMasCliente.GetAll();
		}

		public async Task<IEnumerable<CuentasActivasClientesExtranjero>> GetCuentasActivasClientesExtranjero()
		{
			return await _repositoryCuentasActivasClientesExtranjero.GetAll();
		}

		public async Task<IEnumerable<MayorSaldoCanje>> GetMayorSaldoCanje()
		{
			return await _repositoryMayorSaldoCanje.GetAll();
		}

		public Task<SP_MayorSaldoRetiradoPorFecha> GetSP_MayorSaldoRetiradoPorFecha(DateTime fecha)
		{
			var result = _context.GetSP_MayorSaldoRetiradoPorFecha(fecha);
			return result;
		}

		public Task<SP_SALDO_TOTAL_CLIENTE> GetSP_SALDO_TOTAL_CLIENTE(string IdentificacionPersona)
		{

			var result = _context.GetSP_SALDO_TOTAL_CLIENTE(IdentificacionPersona);
							
			return result;
		}
	}
}
