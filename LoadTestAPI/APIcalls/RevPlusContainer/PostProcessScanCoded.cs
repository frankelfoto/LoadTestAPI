namespace RevPlusAPI
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.WebTesting;
    using Microsoft.VisualStudio.TestTools.WebTesting.Rules;
    
    using Newtonsoft.Json;

    public class PostProcessScanCoded : WebTest
    {
        public string sUri = "ProcessScan";
        public static string sSubUri = "/RevPlusContainer/api/";
        public static string sSub = helper.sFullUri(sSubUri);
        public string sMethod = "POST";
        public static string ContainerAssetId = helper.randomInt(1, 747).ToString();
        public static string UserId = "5555";
        public static string ContainerId = helper.randomInt(1, 700).ToString();
        public static string ContainerBarcode = helper.randomContainerBarcode();
        public static string AssetId = "12345";
        public static string AssetBarcode = "EF12345";
        public static string ProductCode = "12345";
        public static string OrderId = "12345";
        public static string TransferId = "12345";
        public static string StatusId = "2";
        public static string Message = "12345";
        public static string Active = "true";
        public static string Created = helper.modifiedDate();
        public static string Modified = helper.modifiedDate();
        public static string sParam = @"{'ContainerAssetId':'" + ContainerAssetId + ",'UserId':'" + UserId + ",'ContainerId':'" + ContainerId + ",'ContainerBarcode':'" + ContainerBarcode + "','AssetId':'" + AssetId + "','AssetBarcode':'" + AssetBarcode + "','ProductCode':'" + ProductCode + "','OrderId':'" + OrderId + "','TransferId':'" + TransferId + "','StatusId':'" + StatusId + "','Message':'" + Message + "','Active':'" + Active + "','Created':'" + Created + "','Modified':'" + Modified + '}';
        public int iThinkTime = helper.iThinkTime;
        public PostProcessScanCoded()
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
