namespace RevPlusAPI
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.WebTesting;
    using Microsoft.VisualStudio.TestTools.WebTesting.Rules;
    
    using Newtonsoft.Json;

    public class GetProcessRemoveReturnCoded : WebTest
    {
        public string sUri = "ProcessRemoveReturn";
        public static string sSubUri = "/RevPlusContainer/api/";
        public static string sSub = helper.sFullUri(sSubUri);
        public string sMethod = "GET";
        public string sValidationText = "";
        public static string ContainerAssetId = helper.randomInt(1, 747).ToString();
        public int iThinkTime = helper.iThinkTime;
        public GetProcessRemoveReturnCoded()
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
            string uri = (Context["WebServer"].ToString() + Context["URI"].ToString()) + "/" + ContainerAssetId;
            WebTestRequest request = new WebTestRequest(uri);
            request.Method = sMethod;
            request.ThinkTime = iThinkTime;
            request.Headers.Add(new WebTestRequestHeader("Authorization", helper.Token()));
            yield return request;
            request = null;
        }
    }
}
