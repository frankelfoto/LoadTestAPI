namespace RevPlusAPI
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.WebTesting;
    using Microsoft.VisualStudio.TestTools.WebTesting.Rules;
    using System.IO;
    using System.Linq;

    public class PostCheckOutQuickFinalCheckoutCoded : WebTest
    {
        public static string sBarcode = helper.randomBarcode();
        public static string sUri = "QuickFinalCheckout";
        public static string sSubUri = "/RevPlusCheckout/api/";
        public static string sSub = helper.sFullUri(sSubUri);
        public static string sOrderId = helper.randomUserId();
        public static string sTransferId = "0";
        public static string sUserId = helper.randomClientId();
        public static string Processed = "true";
        public static string Message = "Message test";
        public static string sParam = @"{'OrderId':'" + sOrderId + "','TransferId':" + sTransferId + ",'UserId':" + sUserId + ",'Processed':'" + Processed + "','Message':'" + Message +"'}";
        public string sValidationText = "";
        public string sMethod = "POST";
        public int iThinkTime = helper.iThinkTime;

        public PostCheckOutQuickFinalCheckoutCoded()
        {
            Context.Add("URI", sUri);
            Context.Add("WebServer", sSub);
            PreAuthenticate = true;
            Proxy = "default";
        }

        public override IEnumerator<WebTestRequest> GetRequestEnumerator()
        {
            if ((Context.ValidationLevel >= ValidationLevel.High))
            {
                ValidationRuleFindText validationRule = new ValidationRuleFindText();
                validationRule.FindText = sValidationText;
                validationRule.IgnoreCase = false;
                validationRule.UseRegularExpression = false;
                validationRule.PassIfTextFound = true;
                ValidateResponse += new EventHandler<ValidationEventArgs>(validationRule.Validate);
            }
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
