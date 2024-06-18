using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnlinefoododeringFramewoek.GenericUtilityFolder
{
    public class JsonUtility
    {
        public JsonUtility() 
        { 

        }
        public string ExtractData(string tokenname)
        {
        string myJsonString = File.ReadAllText("C:\\Users\\91916\\source\\repos\\OnlineFoodOrder\\OnlinefoododeringFramewoek\\TestData\\Testdata.json");
        var jsonObject=  JToken.Parse(myJsonString);
        return jsonObject.SelectToken(tokenname).Value<string>();

        }
       public string ExtractDataForUserLogin(string tokennameuser)
        {
            string myJsonString = File.ReadAllText("C:\\Users\\91916\\source\\repos\\OnlineFoodOrder\\OnlinefoododeringFramewoek\\TestData\\Testdata.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokennameuser).Value<string>();
        }



    }



}

