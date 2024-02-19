using Api.Context;
using Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Api.Services
{
	public interface IConsultaService
	{
		Task<IEnumerable<AccionistasTcSaldoTotalDeudum>> GetAccionistasTcSaldoTotalDeuda();
		Task<IEnumerable<ConsultaDeudaTarjetaPorFranquicium>> GetConsultaDeudaTarjetaPorFranquicia();

		Task<IEnumerable<CuentaAhorrosMasCliente>> GetCuentaAhorrosMasCliente();

		Task<IEnumerable<CuentasActivasClientesExtranjero>> GetCuentasActivasClientesExtranjero();

		Task<IEnumerable<MayorSaldoCanje>> GetMayorSaldoCanje();

		Task<SP_SALDO_TOTAL_CLIENTE> GetSP_SALDO_TOTAL_CLIENTE(string parametro);
		Task<SP_MayorSaldoRetiradoPorFecha> GetSP_MayorSaldoRetiradoPorFecha(DateTime parametro);
	}
}
