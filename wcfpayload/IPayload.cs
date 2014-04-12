#region Header
////////////////////////////////////////////////////////////////////////////////////
//
//    File Description  : Interface defination for Payload wcf service
// ---------------------------------------------------------------------------------
//    Date Created      : April 9, 2014
//    Author            : Atif Raza
// ---------------------------------------------------------------------------------
//    Change History
//    Date Modified       : 
//    Changed By          :
//    Change Description  : 
//    Review Date         :  
//    Reviewed By         : 
//
////////////////////////////////////////////////////////////////////////////////////
#endregion

using Payloadwcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Payloadwcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Ipayload" in both code and config file together.
    [ServiceContract]
    public interface IPayload
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "payloads")]
        RootObjectRes FilterPayload(RootObject payload);
        
            
    }
}
