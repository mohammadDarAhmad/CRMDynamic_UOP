using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TASK007.Models;
using TASK007.SystemContstant;

namespace TASK007.Repository
{

    public class AccountRepository
    {
        private IOrganizationService _service = null;
        private Logger _log = null;
        private OrganizationServiceContext context = null;
        public AccountRepository(IOrganizationService service, OrganizationServiceContext context, Logger log)
        {
            this.context = context;
            _service = service;
            _log = log;
        }

        public AccountModel GetAccountByGuid(Guid GUID)
        {
            AccountModel account = null;
            try
            {
                _log.PrintInfo("Start geting data from CRM dynamic");

                ConditionExpression conditionGetAccountByGuid = new ConditionExpression();
                conditionGetAccountByGuid.EntityName = "account";
                conditionGetAccountByGuid.AttributeName = "accountid";
                conditionGetAccountByGuid.Operator = ConditionOperator.Equal;
                conditionGetAccountByGuid.Values.Add(GUID);

                FilterExpression checkAccountByGuidFilter = new FilterExpression();
                checkAccountByGuidFilter.AddCondition(conditionGetAccountByGuid);

                QueryExpression query = new QueryExpression("account");
                query.ColumnSet.AddColumns("revenue", "accountid", "accountnumber", "websiteurl", "name", "telephone1", "industrycode", "emailaddress1", "owninguser");
                query.Criteria.AddFilter(checkAccountByGuidFilter);

                EntityCollection accountsEntity = _service.RetrieveMultiple(query);
                if (accountsEntity != null && accountsEntity.Entities != null)
                {
                    account = new AccountModel();
                    var accountEntity = accountsEntity.Entities.FirstOrDefault();
                    account.Name = accountEntity["name"].ToString();
                    account.Revenue = ((Microsoft.Xrm.Sdk.Money)accountEntity["revenue"]) != null ? ((Microsoft.Xrm.Sdk.Money)accountEntity["revenue"]).Value : (decimal?)null;
                    account.EMailAddress1 = accountEntity["emailaddress1"].ToString();
                    account.IndustryCode = accountEntity["industrycode"].ToString();
                    account.AccountNumber = accountEntity["accountnumber"].ToString();
                    account.AccountNumber = accountEntity["accountnumber"].ToString();
                    account.Telephone1 = accountEntity["telephone1"].ToString();
                    account.WebSiteURL = accountEntity["websiteurl"].ToString();
                    account.OwningUser = ((Microsoft.Xrm.Sdk.EntityReference)accountEntity["owninguser"]) != null ? ((Microsoft.Xrm.Sdk.EntityReference)accountEntity["owninguser"]).Name : "";
                    account.ID = new Guid(accountEntity["accountid"].ToString());
                    _log.PrintLog("Get account model is success");
                }
            }
            catch (Exception ex)
            {
                _log.PrintLog("We can't get this account because " + ex.Message);
            }

            return account;
        }
    }

}


