#region Header
////////////////////////////////////////////////////////////////////////////////////
//
//    File Description  : Payload wcf implementation for data processing
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
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;

namespace Payloadwcf
{
   
    public class payload : IPayload
    {
        public RootObjectRes FilterPayload(RootObject payload)
        {

            RootObjectRes jsonresponse = new RootObjectRes();
            try
            {
                if (payload != null)
                {
                    List<Response> filteredpayload = new List<Response>();

                    //getting the payload items at per the given critera
                    foreach (var payloaditem in payload.payload)
                    {
                        if (payloaditem.drm == true && payloaditem.episodeCount > 0)
                        {

                            Response response = new Response();
                            response.image = payloaditem.image.showImage.ToString();
                            response.slug = payloaditem.slug.ToString();
                            response.title = payloaditem.title.ToString();
                            filteredpayload.Add(response);
                        }
                    }

                   jsonresponse.response = filteredpayload;

                   
                }
                else //if payload is null -- raise Bad Json request error
                {
                    RaiseException("Could not decode request: JSON parsing failed");
                }
               
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return jsonresponse;
        }

        private void RaiseException(string errormessage)
        {
            CustomErrorDetail customError = new CustomErrorDetail(errormessage);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest); 
        }
    }
}
