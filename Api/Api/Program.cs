using Api.Context;
using Api.Repository;
using Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AcmeDbContext>(options => {
	options.UseSqlServer(builder.Configuration.GetConnectionString("ACME_CONNECTION"));
});
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IConsultaService, ConsultaService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api consultas V1"));

app.UseHttpsRedirection();


app.MapGet("/GetAccionistasTcSaldoTotalDeuda", (IConsultaService consultaService) =>
{
	return consultaService.GetAccionistasTcSaldoTotalDeuda();
})
.WithName("GetAccionistasTcSaldoTotalDeuda")
.WithDescription("Listado de Accionistas que son clientes con su correspondiente Saldo Total de Deuda de todas las \r\ntarjetas de crédito cuyo Saldo Total de Deuda sea mayor a UN MILLÓN DE PESOS")
.WithOpenApi();


app.MapGet("/GetConsultaDeudaTarjetaPorFranquicia", (IConsultaService consultaService) =>
{
	return consultaService.GetConsultaDeudaTarjetaPorFranquicia();
})
.WithName("GetConsultaDeudaTarjetaPorFranquicia")
.WithDescription(" Deuda total de Tarjeta de Crédito por Franquicia.")
.WithOpenApi();


app.MapGet("/GetCuentaAhorrosMasCliente", (IConsultaService consultaService) =>
{
	return consultaService.GetCuentaAhorrosMasCliente();
})
.WithName("GetCuentaAhorrosMasCliente")
.WithDescription("Cuenta de Ahorro con mayor número de titulares.")
.WithOpenApi();

app.MapGet("/GetCuentasActivasClientesExtranjero", (IConsultaService consultaService) =>
{
	return consultaService.GetCuentasActivasClientesExtranjero();
})
.WithName("GetCuentasActivasClientesExtranjero")
.WithDescription("Numero de Cuentas de Ahorro activas de clientes extranjeros.")
.WithOpenApi();


app.MapGet("/GetMayorSaldoCanje", (IConsultaService consultaService) =>
{
	return consultaService.GetMayorSaldoCanje();
})
.WithName("GetMayorSaldoCanje")
.WithDescription(" Cliente con mayor Saldo en Canje.")
.WithOpenApi();

app.MapGet("/GetSP_MayorSaldoRetiradoPorFecha/{fechaTransaccion}", (IConsultaService consultaService, DateTime fechaTransaccion) =>
{
	return consultaService.GetSP_MayorSaldoRetiradoPorFecha(fechaTransaccion);
})
.WithName("GetSP_MayorSaldoRetiradoPorFecha")
.WithDescription("Cliente con mayor saldo retirado de una Cuenta de Ahorros en un periodo determinado. (Por fecha de transacción yyyy/MM/dd ej:2024-01-10).")
.WithOpenApi();

app.MapGet("/GetSP_Saldo_total_cliente/{NumeroDocumento}", (IConsultaService consultaService, string NumeroDocumento) =>
{
	return consultaService.GetSP_SALDO_TOTAL_CLIENTE(NumeroDocumento);
})
.WithName("GetSP_Saldo_total_cliente")
.WithDescription("Cliente con mayor saldo retirado de una Cuenta de Ahorros en un periodo determinado. (Por fecha de transacción, por ejemplo 1013245678).")
.WithOpenApi();

app.Run();

