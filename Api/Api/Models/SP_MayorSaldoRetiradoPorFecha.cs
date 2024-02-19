namespace Api.Models
{
	public class SP_MayorSaldoRetiradoPorFecha
	{
		public string IdentificacionPersona { get; set; }
		public string NombreCliente { get; set; }
		public decimal SaldoRetirado { get; set; }
		public DateTime Fecha_transaccion { get; set; }
	}
}
