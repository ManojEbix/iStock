using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iStock.Model;
using iStock.Repository;
using iStock.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


namespace iStock.Controllers
{
    [Produces("application/json")]
    [Route("api/Invoice")]
    public class GetInvoiceJsonController : Controller
    {
        private readonly IOptions<MySettingsModel> appSettings;

        public GetInvoiceJsonController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
        }
        [HttpGet]
        [Route("GetInv")]
        public IActionResult GetInvoice()
        {
            var data = DbClientFactory<DbInvoiceClient>.Instance.GetInvoice(appSettings.Value.DbConn);
            return Ok(data);
        }
    }
}
