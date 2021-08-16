using log4net;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace TASK007
{
    public class CRMConnection
    {
        private IOrganizationService _service = null;
        private OrganizationServiceContext _context = null;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public IOrganizationService GetService()
        {
            try
            {

                log.Info("Start conntection to CRM dynamic");
                var CRMDynamicconntectionString = ConfigurationManager.ConnectionStrings["connectionOAuth"].ConnectionString;
                if (CRMDynamicconntectionString != null)
                {
                    CrmServiceClient connection = new CrmServiceClient(CRMDynamicconntectionString);
                    if (connection != null && connection.IsReady == true)
                    {
                        _service = (IOrganizationService)connection.OrganizationWebProxyClient != null ? (IOrganizationService)connection.OrganizationWebProxyClient : (IOrganizationService)connection.OrganizationServiceProxy;
                        if (_service != null)
                            log.Info("Connection Success: " + CRMDynamicconntectionString);

                    }
                    else
                        log.Error("The system have an error with connection to CRM dynamic");

                }
                else
                    log.Error("The system have an error with connection to CRM dynamic");
            }
            catch (Exception ex)
            {
                log.Error("Message: " + ex.Message);

                if (ex.InnerException != null)
                {
                    log.Error(ex.InnerException.Message);

                    FaultException<OrganizationServiceFault> faultException = ex.InnerException as FaultException<OrganizationServiceFault>;
                    if (faultException != null)
                    {
                        log.Error("Timestamp: " + faultException.Detail.Timestamp);
                        log.Error("Code: " + faultException.Detail.ErrorCode);
                        log.Error("Message: " + faultException.Message);
                        log.Error("Trace: " + faultException.Detail.TraceText);
                        log.Error("Inner Fault: " + (null == faultException.Detail.InnerFault ? "No Inner Fault" : "Has Inner Fault"));
                    }
                }
            }

            return _service;
        }

        public OrganizationServiceContext GetContext()
        {
            try
            {
                if (_service != null)
                {
                    _context = new OrganizationServiceContext(_service);
                    if (_context != null)
                    {
                        log.Info("Get organization context is successfully");

                    }
                    else
                        log.Error("Can't organization context ");
                }
                else
                    log.Error("The system have an error with service");

            }
            catch (Exception ex)
            {
                log.Error("Message: " + ex.Message);

                if (ex.InnerException != null)
                {
                    log.Error(ex.InnerException.Message);

                    FaultException<OrganizationServiceFault> faultException = ex.InnerException as FaultException<OrganizationServiceFault>;
                    if (faultException != null)
                    {
                        log.Error("Timestamp: " + faultException.Detail.Timestamp);
                        log.Error("Code: " + faultException.Detail.ErrorCode);
                        log.Error("Message: " + faultException.Detail.Message);
                        log.Error("Trace: " + faultException.Detail.TraceText);
                        log.Error("Inner Fault: " + (null == faultException.Detail.InnerFault ? "No Inner Fault" : "Has Inner Fault"));
                    }
                }
            }
            return _context;
        }
    }
}