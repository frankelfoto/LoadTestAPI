using DotNetOpenAuth.OAuth2;
using Microsoft.VisualStudio.TestTools.WebTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RevPlusAPI
{
    abstract public class helper : WebTest
    {
        public static string sWebServer = "https://qarevplus.ver.com/RevQA";
        //sWebServer = "https://qarevplus.ver.com/RevProd";

        //1.20 https://qarevplus.ver.com/revplus/#/home
        // https://qarevplus.ver.com/RevQA/RevPlus/       
        // https://qarevplus.ver.com/_QA_PROD/RevPlus/#/home // 1.19
        // "https://qarevplus.ver.com/RevProd/RevPlus/#/home"                                                            
        //public static string sRootUrl = "/_QA_PROD"; //QA in Prod
        public static string sRootUrl = ""; // QA RC
        public string sValidationText = "";

        public static string sFullUri(string sSubUri)
        {
            string sUri = sWebServer + sRootUrl + sSubUri;
            return sUri;
        } 

       public static int iThinkTime = 0;
        public static string Token()
        {
            var authorizationServerUri = new Uri(helper.sWebServer);
            var authorizationServer = new AuthorizationServerDescription
            { AuthorizationEndpoint = new Uri(authorizationServerUri, "/RevQA/Ver.Identity.Service/ClientOAuth/Authorize"), TokenEndpoint = new Uri(authorizationServerUri, "/RevQA/Ver.Identity.Service/ClientOAuth/Token") };
            WebServerClient _webServerClient = new WebServerClient(authorizationServer, "RevPlus_QA1", "f5c12007d5437abc584997852365247a5450e01f85e5f7f0");
            var state = _webServerClient.GetClientAccessToken(new[] { "/api/OAuth/UserInfo" });
            string _accessToken = "Bearer " + state.AccessToken;
            return _accessToken;
        }
        public static string sessionStartDate()
        {
            DateTime date = DateTime.Now;
            string sessionStartDate = date.ToString("ddd, dd MMM yyyy hh:mm:ss") + " GMT";
            return sessionStartDate;
        }
        public static string scannedDate()
        {
            DateTime date = DateTime.Now;
            string scannedDate = date.ToString("MM/dd/yyyy hh:mm:ss.fff");
            return scannedDate;
        }
        public static string modifiedDate()
        {
            DateTime date = DateTime.Now;
            string modifiedDate = date.ToString("ddd, dd MMM yyyy hh:mm:ss") + " GMT";
            return modifiedDate;
        }
        public static int randomInt(int iFrom, int iTo)
        {
            Random rnd = new Random();
            int iArr = rnd.Next(iFrom, iTo);
            return iArr;
        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string randomBarcode()
        {
            List<string> run = new List<string>();
            run.Add("MK7587");
            run.Add("MM6980");
            run.Add("SAA6010");
            run.Add("GP5495");
            run.Add("GP5493");
            run.Add("N1169");
            run.Add("FR6579");
            run.Add("CJ2146");
            run.Add("CR3326");
            run.Add("CX1669");
            run.Add("WH7712");      
            Random randNum = new Random();
            int aRandomPos = randNum.Next(run.Count);//Returns a nonnegative random number less than the specified maximum (firstNames.Count).

            string s = run[aRandomPos];
            return s;
        }

        public static string randomProductId()
        {
            List<string> run = new List<string>();
            run.Add("18352");
            run.Add("3162");
            run.Add("2519");
            run.Add("2519");
            run.Add("13415");
            run.Add("19976");
            run.Add("18463");
            run.Add("18475");
            run.Add("1183");
            run.Add("18351");
            run.Add("18353");
            run.Add("18354");
            run.Add("1835");
            run.Add("18355");
            run.Add("18356");
            run.Add("18350");
            Random randNum = new Random();
            int aRandomPos = randNum.Next(run.Count);//Returns a nonnegative random number less than the specified maximum (firstNames.Count).

            string s = run[aRandomPos];
            return s;
        }
        public static string randomUserId()
        {
            List<string> run = new List<string>();
            run.Add("228393");
            run.Add("229225");
            run.Add("230335");
            run.Add("230363");
            run.Add("230368");
            run.Add("230370");
            run.Add("230520");
            run.Add("230598");
            run.Add("1194317");
            run.Add("1194363");
            run.Add("1194431");
            run.Add("1194637");
            run.Add("1194758");
            run.Add("1411827");
            run.Add("1411840");
            run.Add("1412129");
            Random randNum = new Random();
            int aRandomPos = randNum.Next(run.Count);//Returns a nonnegative random number less than the specified maximum (firstNames.Count).

            string s = run[aRandomPos];
            return s;
        }
        public static string randomUserId(int i)
        {
            List<string> run = new List<string>();
            run.Add("uoperations");
            run.Add("usales");
            run.Add("uaccounting");
            run.Add("uequipfind");
            run.Add("uengineering");
            run.Add("uclientvendor");
            run.Add("ushipping");
            run.Add("udispatch");
            run.Add("upurchaseorder");
            string s = run[i];
            return s;
        }
        public static string randomPassword(int i)
        {
            List<string> run = new List<string>();
            run.Add("ver098");
            run.Add("ver097");
            run.Add("ver096");
            run.Add("ver095");
            run.Add("ver094");
            run.Add("ver093");
            run.Add("ver092");
            run.Add("ver091");
            run.Add("ver090");
            string s = run[i];
            return s;
        }

        public static string randomClientId()
        {
            List<string> run = new List<string>();
            run.Add("228393");
            run.Add("229225");
            run.Add("230335");
            run.Add("230363");
            run.Add("230368");
            run.Add("230370");
            run.Add("230520");
            run.Add("230598");
            run.Add("1194317");
            run.Add("1194363");
            run.Add("1194431");
            run.Add("1194637");
            run.Add("1194758");
            run.Add("1411827");
            run.Add("1411840");
            run.Add("1412129");
            Random randNum = new Random();
            int aRandomPos = randNum.Next(run.Count);//Returns a nonnegative random number less than the specified maximum (firstNames.Count).
            string s = run[aRandomPos];
            return s;
        }

        public static string randomCategoryId()
        {
            List<string> run = new List<string>();
            run.Add("1100");
            run.Add("1101");
            run.Add("17968");
            run.Add("13399");
            run.Add("230368");
            run.Add("346");
            run.Add("18148");
            run.Add("14923");
            run.Add("3409");
            run.Add("19216");
            run.Add("19217");
            run.Add("30894");
            run.Add("17948");
            run.Add("16871");
            run.Add("9818");
            run.Add("9819");
            Random randNum = new Random();
            int aRandomPos = randNum.Next(run.Count);//Returns a nonnegative random number less than the specified maximum (firstNames.Count).
            string s = run[aRandomPos];
            return s;
        }
        public static string randomBoolean()
        {
            List<string> run = new List<string>();
            run.Add("true");
            run.Add("false");
            Random randNum = new Random();
            int aRandomPos = randNum.Next(run.Count);//Returns a nonnegative random number less than the specified maximum (firstNames.Count).
            string s = run[aRandomPos];
            return s;
        }
        public static string randomAssetDownedId()
        {
            List<string> run = new List<string>();
            run.Add("329126");
            run.Add("1137");
            run.Add("309645");
            run.Add("1145066");
            run.Add("1136675");
            run.Add("1097678");
            run.Add("1315565");
            run.Add("2840262");
            run.Add("2840263");
            run.Add("2840250");
            run.Add("203203");
            run.Add("2653904");
            run.Add("794910");
            run.Add("2567851");
            run.Add("2154433");
            run.Add("1385180");
            Random randNum = new Random();
            int aRandomPos = randNum.Next(run.Count);//Returns a nonnegative random number less than the specified maximum (firstNames.Count).
            string s = run[aRandomPos];
            return s;
        }
        public static string pageProcedureID()
        {
            List<string> run = new List<string>();
            run.Add("541");
            run.Add("542");
            run.Add("543");
            run.Add("544");
            run.Add("545");
            run.Add("546");
            run.Add("547");
            run.Add("548");
            run.Add("549");
            run.Add("550");
            run.Add("551");
            run.Add("552");
            run.Add("553");
            run.Add("554");
            run.Add("555");
            run.Add("556");
            Random randNum = new Random();
            int aRandomPos = randNum.Next(run.Count);//Returns a nonnegative random number less than the specified maximum (firstNames.Count).
            string s = run[aRandomPos];
            return s;
        }
        public static string randomTransOrderId()
        {
            List<string> run = new List<string>();
            run.Add("32");
            run.Add("476");
            run.Add("722");
            run.Add("1071");
            run.Add("2077");
            run.Add("2511");
            run.Add("441");
            run.Add("7");
            run.Add("43");
            run.Add("481");
            run.Add("484");
            run.Add("9");
            run.Add("10");
            run.Add("566");
            run.Add("576");
            run.Add("1241");
            Random randNum = new Random();
            int aRandomPos = randNum.Next(run.Count);//Returns a nonnegative random number less than the specified maximum (firstNames.Count).
            string s = run[aRandomPos];
            return s;
        }

        public static string randomContainerBarcode()
        {
            List<string> run = new List<string>();
            run.Add("D7SNLD7LYX");
            run.Add("QY7TWW2VBU");
            run.Add("Z20PY47QVI");
            run.Add("SAHONH3K3L");
            run.Add("G2ARVFBP4L");
            run.Add("9LQS8OIKG8");
            run.Add("N6H6MS9I27");
            run.Add("VII6YCAYXA");
            run.Add("MDUYH5S1BG");
            run.Add("3V27UXI0DA");
            run.Add("RAYM1XAW6R");
            Random randNum = new Random();
            int aRandomPos = randNum.Next(run.Count);//Returns a nonnegative random number less than the specified maximum (firstNames.Count).

            string s = run[aRandomPos];
            return s;
        }

    }
}