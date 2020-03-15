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
    [Route("api/Series")]
    public class SeriesController : Controller
    {
        private readonly IOptions<MySettingsModel> appSettings;
        public SeriesController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
        }

        [HttpGet]
        [Route("GetAllSeries")]
        public IActionResult GetAllSeries()
        {
            var data = DbClientFactory<SeriesDbClient>.Instance.GetAllSeries(appSettings.Value.DbConn);
            return Ok(data);
        }

        [HttpPost]
        [Route("SaveUser")]
        public IActionResult SaveUser([FromBody]SeriesModel model)
        {
            var msg = new Message<SeriesModel>();
            var data = DbClientFactory<SeriesDbClient>.Instance.SaveUser(model, appSettings.Value.DbConn);
            if (data == "C200")
            {
                msg.IsSuccess = true;
                if (model.Id == 0)
                    msg.ReturnMessage = "User saved successfully";
                else
                    msg.ReturnMessage = "User updated successfully";
            }
            else if (data == "C201")
            {
                msg.IsSuccess = false;
                msg.ReturnMessage = "Email Id already exists";
            }
            else if (data == "C202")
            {
                msg.IsSuccess = false;
                msg.ReturnMessage = "Mobile Number already exists";
            }
            return Ok(msg);
        }

        [HttpPost]
        [Route("DeleteUser")]
        public IActionResult DeleteUser([FromBody]SeriesModel model)
        {
            var msg = new Message<SeriesModel>();
            var data = DbClientFactory<SeriesDbClient>.Instance.DeleteUser(model.Id, appSettings.Value.DbConn);
            if (data == "C200")
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "User Deleted";
            }
            else if (data == "C203")
            {
                msg.IsSuccess = false;
                msg.ReturnMessage = "Invalid record";
            }
            return Ok(msg);
        }
    }
}
