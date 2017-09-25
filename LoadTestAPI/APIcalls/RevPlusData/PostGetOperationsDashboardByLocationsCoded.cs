namespace RevPlusAPI
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.WebTesting;
    using Microsoft.VisualStudio.TestTools.WebTesting.Rules;
    
    using Newtonsoft.Json;

    public class PostGetOperationsDashboardByLocationsCoded : WebTest
    {
        public string sUri = "GetOperationsDashboardByLocations";
        public static string sSubUri = "/RevPlusData/api/";
        public static string sSub = helper.sFullUri(sSubUri);
        public string sMethod = "POST";
        public static string sLocationId = "1";
        public static string sOrderType = "Both"; // "Orders", "Transfers"
        public static string sSearchType = "3";
        public static string sParam = "{ 'LocationIds':" + sLocationId + ", 'StartDate':'2017-01-18', 'EndDate':'2017-01-19', 'OrderType':'" + sOrderType + "', 'SearchType':" + sSearchType + " }";

        public int iThinkTime = helper.iThinkTime;

        public PostGetOperationsDashboardByLocationsCoded()
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