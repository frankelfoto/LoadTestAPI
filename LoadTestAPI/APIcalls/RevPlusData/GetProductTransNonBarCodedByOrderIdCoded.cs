namespace RevPlusAPI
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.WebTesting;
    using Microsoft.VisualStudio.TestTools.WebTesting.Rules;
    public class GetProductTransNonBarCodedByOrderIdCoded : WebTest
    {
        // GetProductTransMasterItemsToCheckIn/9372384/false HTTP/1.1

        public string sMethod = "GET";
        public string sUri = "GetProductTransNonBarCodedByOrderId";
        public static string sValidationText = "";
        public static string sSubUri = "/RevPlusData/api/";
        public static string sSub = helper.sFullUri(sSubUri);
        public static string OrderId = helper.randomUserId();
        public int iThinkTime = helper.iThinkTime;
        public GetProductTransNonBarCodedByOrderIdCoded()
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
            string uri = (Context["WebServer"].ToString() + Context["URI"].ToString() + "/" + OrderId);
            WebTestRequest request = new WebTestRequest(uri);
            request.Method = sMethod;
            request.ThinkTime = iThinkTime;
            request.Headers.Add(new WebTestRequestHeader("Authorization", helper.Token()));
            yield return request;
            request = null;
        }
    }
}
