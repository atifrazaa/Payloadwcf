#region Header
////////////////////////////////////////////////////////////////////////////////////
//
//    File Description  : Error handler implementation
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Web;

namespace Payloadwcf
{
    public class WebHttpBehaviorEx : WebHttpBehavior
    {

        protected override void AddServerErrorHandlers(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {

            // clear default erro handlers.

            endpointDispatcher.ChannelDispatcher.ErrorHandlers.Clear();

            // add our own error handler.

            endpointDispatcher.ChannelDispatcher.ErrorHandlers.Add(new ErrorHandlerJson());

        }

    }

    public class ErrorHandlerJson : IErrorHandler
    {

        public bool HandleError(Exception error)
        {
           return true;

        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
            {
                if (error is FaultException)
                {
                    // extract the our FaultContract object from the exception object.
                    var detail = error.GetType().GetProperty("Detail").GetGetMethod().Invoke(error, null);

                    // create a fault message containing our FaultContract object
                    fault = Message.CreateMessage(version, "", new CustomErrorDetail("Could not decode request: JSON parsing failed."), new DataContractJsonSerializer(typeof(CustomErrorDetail)));

                    // tell WCF to use JSON encoding rather than default XML
                    var wbf = new WebBodyFormatMessageProperty(WebContentFormat.Json);
                    fault.Properties.Add(WebBodyFormatMessageProperty.Name, wbf);

                    // return custom error code.
                    var response = WebOperationContext.Current.OutgoingResponse;

                    // Set the response type to Json
                    response.ContentType = "application/json";

                    // Set the status code to 400 Bad request
                    response.StatusCode = HttpStatusCode.BadRequest; 

                }

                else
                {

                    fault = Message.CreateMessage(version, "", new CustomErrorDetail("Could not decode request: JSON parsing failed."), new DataContractJsonSerializer(typeof(CustomErrorDetail)));
                             
                    var wbf = new WebBodyFormatMessageProperty(WebContentFormat.Json);
                    fault.Properties.Add(WebBodyFormatMessageProperty.Name, wbf);

                    // Set the rsponse type to Json 
                    var response = WebOperationContext.Current.OutgoingResponse;

                    // Set the response type to Json
                    response.ContentType = "application/json";

                    // Set the status code to 400 Bad request
                    response.StatusCode = HttpStatusCode.BadRequest; 
                 }

        }
            
    }

    public class JsonResponseFactory : WebServiceHostFactory
    {
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            var sh = new ServiceHost(typeof(payload), baseAddresses);
            sh.Description.Endpoints[0].Behaviors.Add(new WebHttpBehaviorEx());
            return sh;
        }

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return base.CreateServiceHost(serviceType, baseAddresses);
        }

    }
    
}