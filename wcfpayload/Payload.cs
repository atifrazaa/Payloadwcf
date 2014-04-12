#region Header
////////////////////////////////////////////////////////////////////////////////////
//
//    File Description  : Data Contract classes for payload items
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
    public class Image
    {
        [DataMember]
        public string showImage { get; set; }
    }

        [DataContract]
    public class NextEpisode
    {
        [DataMember]
        public object channel { get; set; }

        [DataMember]
        public string channelLogo { get; set; }

        [DataMember]
        public object date { get; set; }

        [DataMember]
        public string html { get; set; }

        [DataMember]
        public string url { get; set; }
    }

    [DataContract]
    public class Season
    {
        [DataMember]
        public string slug { get; set; }
    }


    [DataContract]
    public class Payload
    {
        [DataMember]
        public string country { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public bool drm { get; set; }

        [DataMember]
        public int episodeCount { get; set; }

        [DataMember]
        public string genre { get; set; }

        [DataMember]
        public Image image { get; set; }

        [DataMember]
        public string language { get; set; }

        [DataMember]
        public NextEpisode nextEpisode { get; set; }

        [DataMember]
        public string primaryColour { get; set; }

        [DataMember]
        public List<Season> seasons { get; set; }

        [DataMember]
        public string slug { get; set; }

        [DataMember]
        public string title { get; set; }

        [DataMember]
        public string tvChannel { get; set; }
    }


    [DataContract]
    public class RootObject
    {
        [DataMember]
        public List<Payload> payload { get; set; }

        [DataMember]
        public int skip { get; set; }

        [DataMember]
        public int take { get; set; }

        [DataMember]
        public int totalRecords { get; set; }
    }


    [DataContract]
    public class Response
    {
        [DataMember]
        public string image { get; set; }

        [DataMember]
        public string slug { get; set; }

        [DataMember]
        public string title { get; set; }
    }


    [DataContract]
    public class RootObjectRes
    {

        [DataMember]
        public List<Response> response { get; set; }
    }
}