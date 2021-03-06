﻿namespace RevPlusAPI
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.WebTesting;
    using Microsoft.VisualStudio.TestTools.WebTesting.Rules;

    public class PostProcessBarcodeCoded : WebTest
    {
        public static string sUri = "ProcessBarcode";
        public static string sSubUri = "/RevPlusReturns/api/";
        public static string sSub = helper.sFullUri(sSubUri);
        public static string sBarcode = "MG9235";
        public static string sUserId = "2888";
        public static string sReturnLocationId = "1";
        public static string sParam = @"{'Barcode':'" + sBarcode + "','UserId':" + sUserId + ",'ReturnLocationId':" + sReturnLocationId + ",'SessionStart':'" + helper.sessionStartDate() + "','ScannedDate':'" + helper.scannedDate() + "','Modified':'" + helper.modifiedDate() + "'}";
        public string sValidationText = "";
        public string sMethod = "POST";
        public int iThinkTime = helper.iThinkTime;

        public PostProcessBarcodeCoded()
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
