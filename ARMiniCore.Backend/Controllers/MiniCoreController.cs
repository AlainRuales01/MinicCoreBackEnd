using ARMiniCore.Backend.CoreModels;
using ARMiniCore.Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ARMiniCore.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MiniCoreController : ControllerBase
    {
        [HttpGet(Name = "GetMiniCore")]
        public async Task<List<ClienteContratoResponse>> MiniCoreResult(DateTime fechaInicio, DateTime fechaFin)
        {
            var fechaDefault = DateTime.MinValue == fechaInicio || DateTime.MinValue == fechaFin;
            string data = "";
            List<ClienteContratoResponse> contratos = new List<ClienteContratoResponse>();
            using (DataBaseContext _context = new DataBaseContext())
            {
                List<ClienteContrato> contratosCliente = new List<ClienteContrato>();
                if (!fechaDefault)
                {

                    contratosCliente = await (from con in _context.Contrato
                                              join cli in _context.Cliente on con.ClienteId equals cli.ClienteId
                                              where (DateTime.Compare(fechaInicio, con.Fecha) <= 0 && DateTime.Compare(fechaFin, con.Fecha) >= 0)
                                              select new ClienteContrato
                                              {
                                                  ClienteId = cli.ClienteId,
                                                  NombreCliente = cli.Nombre,
                                                  NombreContrato = con.NombreContrato,
                                                  Monto = con.Monto,
                                                  Fecha = con.Fecha
                                              }).ToListAsync();
                }
                else
                {
                    contratosCliente = await (from con in _context.Contrato
                                              join cli in _context.Cliente on con.ClienteId equals cli.ClienteId
                                              select new ClienteContrato
                                              {
                                                  ClienteId = cli.ClienteId,
                                                  NombreCliente = cli.Nombre,
                                                  NombreContrato = con.NombreContrato,
                                                  Monto = con.Monto,
                                                  Fecha = con.Fecha
                                              }).ToListAsync();
                }


                var usuariosListId = contratosCliente.Select(c => c.ClienteId).Distinct().ToList();

                foreach (var item in usuariosListId)
                {
                    ClienteContratoResponse clienteContratoResponse = new ClienteContratoResponse();

                    var listaContratos = contratosCliente.Where(c => c.ClienteId == item).ToList();
                    var nombreCliente = listaContratos.Select(c => c.NombreCliente).FirstOrDefault();
                    double montoTotal = 0;

                    foreach (var contrato in listaContratos)
                    {
                        montoTotal += contrato.Monto;
                    }

                    clienteContratoResponse.NombreCliente = nombreCliente;
                    clienteContratoResponse.Monto = montoTotal;
                    contratos.Add(clienteContratoResponse);
                }

            }
            return contratos;
        }


    }
}
