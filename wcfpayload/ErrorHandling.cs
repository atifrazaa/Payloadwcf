#region Header
////////////////////////////////////////////////////////////////////////////////////
//
//    File Description  : Data Contract for error handling class
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
using System.Runtime.Serialization;
using System.Web;

namespace Payloadwcf
{
    [DataContract]
    public class CustomErrorDetail
    {
        public CustomErrorDetail(string errorDetails)
        {
           error = errorDetails;
        }

        [DataMember]
        public string error { get; private set; }
    }

   
}