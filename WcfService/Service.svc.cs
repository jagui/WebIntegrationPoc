using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Microsoft.Ajax.Samples;

namespace WcfService
{

    //Service contract
    [ServiceContract]
    public interface IScanService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        [JSONPBehavior(callback = "callback")]
        String Scan(String context);
    }


    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, UseSynchronizationContext = false)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service : IScanService
    {
        public String Scan(String context)
        {
            return HandleRequest(this, context);
        }

        // Add more operations here and mark them with [OperationContract]
        public Func<Service, String, String> HandleRequest = delegate { return String.Empty; };
    }
}
