namespace RevPlusAPI
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.WebTesting;

    public class PostGetQuickTurnDashSelectCoded : WebTest
    {
        public string sUri = "GetQuickTurnDashSelect";
        public static string sSubUri = "/RevPlusData/api/";
        public static string sSub = helper.sFullUri(sSubUri);
        public string sMethod = "POST";
        public static string sLocationId = "11";
        public static string sOrderType = "Both"; // "Orders", "Transfers"
        public static string sQuickTurnBoardType = "0" /* Returns */; // "1" - "Outbound"
        public static string sParam = @"{'TargetStart':null,'TargetEnd':null,'LocationId':" + sLocationId + ",'OrderType':'" + sOrderType + "','QuickTurnBoardType':0}";
        public int iThinkTime = helper.iThinkTime;

        public PostGetQuickTurnDashSelectCoded()
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
