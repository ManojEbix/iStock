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
    [Route("api/BP")]
    public class BusinessPartnerController : Controller
    {
        private readonly IOptions<MySettingsModel> appSettings;


        [HttpGet]
        [Route("GetStates")]
        public IActionResult GetStates()
        {
            var list = new List<StateModel>();
            StateModel item = new StateModel();
            item.Code = "UP";
            item.Name = "Uttar Pradesh";
            StateModel item2 = new StateModel();
            item2.Code = "DL";
            item2.Name = "New Delhi";

            list.Add(item);
            list.Add(item2);
            return Ok(list);
        }

        [HttpGet]
        [Route("Search/{Name}")]
        public IActionResult Search(string Name)
        {
            var data = DbClientFactory<BPDbClient>.Instance.searchBP(appSettings.Value.DbConn, Name);
            return Ok(data);
        }
        
        public BusinessPartnerController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
        }

        [HttpGet]
        [Route("GetBPList")]
        public IActionResult GetBPList()
        {
            var data = DbClientFactory<BPDbClient>.Instance.GetBPList(appSettings.Value.DbConn);
            return Ok(data);
        }

        [HttpGet]
        [Route("detail/{Id}")]
        public IActionResult GetBpDetail(int Id)
        {
            var data = DbClientFactory<BPDbClient>.Instance.GetBPDetails(appSettings.Value.DbConn, Id);
            return Ok(data);
        }
        [HttpPost]
        [Route("UpdateBP/{Id}")]
        public IActionResult UpdateBP([FromBody]BusinessPartner model)
        {
            var msg = new Message<BusinessPartner>();
            var data = DbClientFactory<BPDbClient>.Instance.UpdateBP(model, appSettings.Value.DbConn);
            if (data == "C200")
            {
                msg.IsSuccess = true;
                if (model.Personid == 0)
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
                //    }
                return Ok(msg);
            }
            return Ok(msg);
        }
            //[HttpPost]
            //[Route("DeleteUser")]
            //public IActionResult DeleteUser([FromBody]BusinessPartner model)
            //{
            //    var msg = new Message<BusinessPartner>();
            //    var data = DbClientFactory<BPDbClient>.Instance.DeleteUser(model.Id, appSettings.Value.DbConn);
            //    if (data == "C200")
            //    {
            //        msg.IsSuccess = true;
            //        msg.ReturnMessage = "User Deleted";
            //    }
            //    else if (data == "C203")
            //    {
            //        msg.IsSuccess = false;
            //        msg.ReturnMessage = "Invalid record";
            //    }
            //    return Ok(msg);
            //}
        }
}
