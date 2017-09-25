namespace RevPlusAPI
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.WebTesting;
    using Microsoft.VisualStudio.TestTools.WebTesting.Rules;
    
    using Newtonsoft.Json;

    public class PostProcessInboundScanCoded : WebTest
    {
        public string sUri = "ProcessInboundScan";
        public static string sSubUri = "/RevPlusContainer/api/";
        public static string sSub = helper.sFullUri(sSubUri);
        public string sMethod = "POST";
        public static string ContainerAssets = null;
        public static string ContainerAssetId = helper.randomInt(1, 747).ToString();
        public static string ContainerBarcode = helper.randomContainerBarcode();
        public static string UserId = "5555";
        public static string OrderId = "12345";
        public static string TransferId = "12345";
        public static string LocationId = "1";
        public static string Closed = true.ToString();
        public static string SessionStatusId = "0";
        public static string Message = "12345";
        public static string SessionStart = helper.modifiedDate();
        public static string ScannedDate = helper.modifiedDate();
        public static string ClientTime = helper.modifiedDate();
        public static string OrderNum = "12";
        
        public static string sParam = @"{'ContainerAssets':'" + ContainerAssetId + ",'Id':'" + UserId + ",'ContainerBarcode:'" + ContainerBarcode + ",'SessionUserId':'" + UserId + ",'OrderId':'" + OrderId + "','TransferId':'" + TransferId + "','LocationId:':'" + LocationId + "','Closed':'" + Closed + "','SessionStatusId':'" + SessionStatusId + "','SessionMessage':'" + Message + "','SessionStart':'" + "2017-04-27T14:31:17.6510178" + "','ScannedDate':'" + "2017-04-27T14:31:17.6510178" + "','ClientTime':'" + "2017-04-27T14:31:17.6510178"
   + "','OrderNo':'" + OrderNum + '}';
        public int iThinkTime = helper.iThinkTime;
        public PostProcessInboundScanCoded()
        {
            Context.Add("URI", sUri);
            Context.Add("WebServer", sSub);
            PreAuthenticate = true;
            Proxy = "default";
        }
        public override IEnumerator<WebTestRequest> GetRequestEnumerator()
        {
            string uri = (Context["WebServer"].ToString() + Context["URI"].ToString());
            WebTestRequest request = new WebTestRequest(uri);
            request.Method = sMethod;
            request.ThinkTime = iThinkTime;
            request.QueryStringParameters.Add("format", "json", false, false);
            request.Headers.Add(new WebTestRequestHeader("Authorization", helper.Token()));
            StringHttpBody requestBody = new StringHttpBody();
            requestBody.ContentType = "application/json";
            requestBody.InsertByteOrderMark = false;
            requestBody.BodyString = sParam;
            request.Body = requestBody;
            yield return request;
            request = null;
        }
    }
}
