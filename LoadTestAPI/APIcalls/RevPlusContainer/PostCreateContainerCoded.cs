namespace RevPlusAPI
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.WebTesting;

    public class PostCreateContainerCoded : WebTest
    {
        public string sUri = "CreateContainer";
        public static string sSubUri = "/RevPlusContainer/api/";
        public static string sSub = helper.sFullUri(sSubUri);
        public string sMethod = "POST";
        public static string ContainerAssetId = helper.randomInt(1, 747).ToString();
        public static string UserId1 = "5555";
        public static string ContainerId1 = helper.randomInt(1, 700).ToString();
        public static string ContainerBarcode1 = helper.randomContainerBarcode();
        public static string AssetId = "12345";
        public static string AssetBarcode = "EF12345";
        public static string ProductCode = "12345";
        public static string OrderId = "12345";
        public static string TransferId = "12345";
        public static string StatusId = "2";
        public static string Message = "12345";
        public static string Closed = "true";
        public static string Active1 = "true";
        public static string Created1 = helper.modifiedDate();
        public static string Modified1 = helper.modifiedDate();
        public static string sParam = @"{'ContainerId':'" + ContainerId1 + ",'ContainerBarcode':'" + ContainerBarcode1 + ",'Closed':'" + Closed + "','Active':'" + Active1 + ",'UserId':'" + UserId1 + "','Created':'" + Created1 + "','Modified':'" + Modified1 + '}';  //'ContainerAssetId':'" + ContainerAssetId + ",'UserId':'" + UserId + ", +  + "','AssetId':'" + AssetId + "','AssetBarcode':'" + AssetBarcode + "','ProductCode':'" + ProductCode + "','OrderId':'" + OrderId + "','TransferId':'" + TransferId + "','StatusId':'" + StatusId + "','Message':'" + Message +  "','Created':'" + Created + "','Modified':'" + Modified + '}';
        public int iThinkTime = helper.iThinkTime;
        public PostCreateContainerCoded()
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
