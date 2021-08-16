using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TASK007.Models
{

    public class AccountModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public decimal? Revenue { get; set; }
        public string Telephone1 { get; set; }
        public string IndustryCode { get; set; }
        public string EMailAddress1 { get; set; }
        public string OwningUser { get; set; }
        public string AccountNumber { get; set; }
        public string WebSiteURL { get; set; }

    }


}