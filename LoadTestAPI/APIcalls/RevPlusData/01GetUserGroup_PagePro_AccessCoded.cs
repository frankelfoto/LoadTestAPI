namespace RevPlusAPI
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.WebTesting;
    using Microsoft.VisualStudio.TestTools.WebTesting.Rules;
    public class GetUserGroup_PagePro_AccessCoded : WebTest
    {
        string sUri = "GetUserGroup_PagePro_Access";
        public static string sSubUri = "/RevPlusData/api/";
        public static string sSub = helper.sFullUri(sSubUri);
        public string sMethod = "GET";
        public string sValidationText = "";
        public static int x = helper.randomInt(0, 8);
        public static string sUserId = helper.randomUserId(x);
        public static string pageProcedureID = helper.pageProcedureID();
        public int iThinkTime = helper.iThinkTime;
        public GetUserGroup_PagePro_AccessCoded()
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
            string uri = (Context["WebServer"].ToString() + Context["URI"].ToString()) + "/" + sUserId + "/" + pageProcedureID;
            WebTestRequest request = new WebTestRequest(uri);
            request.Method = sMethod;
            request.ThinkTime = iThinkTime;
            request.Headers.Add(new WebTestRequestHeader("Authorization", helper.Token()));
            yield return request;
            request = null;
        }
    }
}
