namespace RevPlusAPI
{
    using System;
    using System.Xml;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.WebTesting;
    using Microsoft.VisualStudio.TestTools.WebTesting.Rules;

    public class ApiCall //: WebTest
    {
        //public struct Params
        //{ 
        //    public string sMethod;
        //    public string sUri;
        //    public string sValidationText;
        //    public string TestCaseName;
        //}


            public string sMethod;
            public string sUri;
            public string sValidationText;
            public string TestCaseName;

        //public static Params p =  new Params();

        public string  GetWebAPIResultStatus()
        {
           //Get  TestCase Name
           //p.TestCaseName = this.Name;

            string sReturnStatus = "";
            //Get Data From app.Config

            //Get Data From Data File
            //GetData(p.TestCaseName);


            //Make Request

            return sReturnStatus;
        }

        ////public static string sBarcode = helper.randomBarcode();
        //public static string sUri = "ProcessBarcode";
        //public static string sSubUri = "/RevPlusCheckout/api/";
        //public static string sSub = helper.sFullUri(sSubUri);
        //public static string sUserId = helper.randomClientId();//"2888";
        //public static string sParam = @"{'Barcode':'" + sBarcode + "','UserId':" + sUserId + ",'ReturnLocationId':1,'SessionStart':'" + helper.sessionStartDate() + "','ScannedDate':'" + helper.scannedDate() + "','Modified':'" + helper.modifiedDate() + "'}";
        //public string sValidationText = "";
        //public string sMethod = "POST";
        //public int iThinkTime = helper.iThinkTime;

        public void GetData(string sPathToDataFile)
        {

            XmlDocument doc = new XmlDocument();

            doc.Load(@"C:\Test\Workspaces\QA\RevPlusAPI - Copy\ProcessBarcode_Post.xml");


           sMethod= doc.
            //string sUri = ""; 
            //sValidationText="";


        }
        public string GetURL()
        {
            string sUrl = "";
            //        < TestCase >

            //< Method > POST </ Method >

            // < Uri > ProcessBarcode </ Uri >

            //< Root >/ RevPlusCheckout / api /</ Root >

            //< ValidationText ></ ValidationText >
            return sUrl;
        }

        //public PostCheckOutProcessBarcodeCoded()
        //{
        //    Context.Add("URI", sUri);
        //    Context.Add("WebServer", sSub);
        //    PreAuthenticate = true;
        //    Proxy = "default";
        //}

        //public override IEnumerator<WebTestRequest> GetRequestEnumerator()
        //{
        //    if ((Context.ValidationLevel >= ValidationLevel.High))
        //    {
        //        ValidationRuleFindText validationRule = new ValidationRuleFindText();
        //        validationRule.FindText = sValidationText;
        //        validationRule.IgnoreCase = false;
        //        validationRule.UseRegularExpression = false;
        //        validationRule.PassIfTextFound = true;
        //        ValidateResponse += new EventHandler<ValidationEventArgs>(validationRule.Validate);
        //    }
        //    string uri = (Context["WebServer"].ToString() + Context["URI"].ToString());
        //    WebTestRequest request = new WebTestRequest(uri);
        //    request.Method = sMethod;
        //    request.ThinkTime = iThinkTime;
        //    request.QueryStringParameters.Add("format", "json", false, false);
        //    request.Headers.Add(new WebTestRequestHeader("Authorization", helper.Token()));
        //    StringHttpBody requestBody = new StringHttpBody();
        //    requestBody.ContentType = "application/json";
        //    requestBody.InsertByteOrderMark = false;
        //    requestBody.BodyString = sParam;
        //    request.Body = requestBody;
        //    yield return request;
        //    request = null;
        //}
    }
}
