using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TASK007.Data;
using TASK007.Models;
using TASK007.Repository;

namespace TASK007.Controllers
{
    public class AccountController : Controller
    {

        private CRMConnection connectionCRM = new CRMConnection();

        // GET: Account/Details/075d7a85-6cfb-eb11-94ef-000d3ade7a11
        public ActionResult Details(Guid id)
        {
            var log = new Logger();

            log.PrintInfo("Start Controller account details working");

            if (id == null && id == new Guid(""))
            {
                log.PrintLog("Guid id is null");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var service = connectionCRM.GetService();
            var context = connectionCRM.GetContext();
            AccountModel accountModel = null;
            try
            {
                log.PrintInfo("Start with git details to account guid equal " + id);
                if (service != null && context != null && log != null)
                {
                    var accountRepositry = new AccountRepository(service, context, log);
                    accountModel = accountRepositry.GetAccountByGuid(id);
                }
            }
            catch (Exception ex)
            {
                log.PrintLog("Get get account detale because, " + ex.Message);
            }
            if (accountModel == null)
            {
                log.PrintLog("Can't find account data becasue account model is null");
                return HttpNotFound();
            }
            return View(accountModel);
        }

    }
}
