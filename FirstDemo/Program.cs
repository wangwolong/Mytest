using Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace FirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string userinfo= "{\"alipay_marketing_card_activateform_query_response\": {         \"code\": \"10000\",         \"msg\": \"Success\",         \"infos\": \"[{\\\"OPEN_FORM_FIELD_GENDER\\\":\\\"男\\\"},{\\\"OPEN_FORM_FIELD_MOBILE\\\":\\\"13888888888\\\"},{\\\"OPEN_FORM_FIELD_NAME\\\":\\\"李四\\\"}]\"     },     \"sign\": \"ERITJKEIJKJHKKKKKKKHJEREEEEEEEEEEE\" }";
            var aliUser = JsonConvert.DeserializeObject<UserInfo>(userinfo);

            List<object> ProductDetailList = JsonConvert.DeserializeObject<List<object>>(aliUser.alipay_marketing_card_activateform_query_response.infos);
            Console.WriteLine(ProductDetailList.ToJson().ToString());
            foreach (var item in ProductDetailList)
            {
                var b = item.ToString();
                if (item.ToString().Contains("OPEN_FORM_FIELD_GENDER"))
                {
                    var value = (dynamic)item;
                    Console.WriteLine(value.OPEN_FORM_FIELD_GENDER);
                }
                else if (item.ToString().Contains("OPEN_FORM_FIELD_MOBILE"))
                {
                    var value = (dynamic)item;
                    Console.WriteLine(value.OPEN_FORM_FIELD_MOBILE);
                }
                else if (item.ToString().Contains("OPEN_FORM_FIELD_NAME"))
                {
                    var value = (dynamic)item;
                    Console.WriteLine(value.OPEN_FORM_FIELD_NAME);
                }
            }

            DateTime dateTime = DateTime.Now;
            DateTime date = dateTime.Date;
            Console.WriteLine(DateTime.Today);
            Console.ReadKey();
        }
        public class UserInfo
        {
            public Alipay_Marketing_Card_Activateform_Query_Response alipay_marketing_card_activateform_query_response { get; set; }
            public string sign { get; set; }
        }
        public class Alipay_Marketing_Card_Activateform_Query_Response
        {
            public string code { get; set; }
            public string msg { get; set; }
            public string infos { get; set; }
            public string sub_code { get; set; }
            public string sub_msg { get; set; }

        }
        
    }
}
