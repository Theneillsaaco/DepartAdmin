using DepartAdmin.DAL.Context;
using DepartAdmin.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DepartAdmin.Sever.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        #region"Context"

        private readonly DepartAdminContext dbContext;

        public PagoController(DepartAdminContext context)
        {
            this.dbContext = context;
        }

        #endregion

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            var responseApi = new ResponseAPI<List<Pago>>();
            var listpago = new List<Pago>();

            try
            {
                foreach (var item in await dbContext.Pago.ToListAsync())
                {
                    listpago.Add(new Pago
                    {
                        UserId = item.UserId,
                        NumeroDeposito = item.NumeroDeposito,
                        FechaMudanza = item.FechaMudanza,
                        FechaPago = item.FechaPago,
                        MontoPagado = item.MontoPagado,
                        Retrasado = item.Retrasado,
                    });
                }

                responseApi.response = true;
                responseApi.Valor = listpago;

            }
            catch (Exception ex)
            {
                responseApi.response = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }
    }
}
