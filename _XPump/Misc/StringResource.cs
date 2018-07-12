using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace XPump.Misc
{
    public class StringResource
    {
        public List<TextMessage> LoadAllMessage()
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"msg.json"))
            {
                List<TextMessage> msg = JsonConvert.DeserializeObject<List<TextMessage>>(File.ReadAllText(@"msg.json"));
                return msg;
            }

            return new List<TextMessage>();
        }

        public static string Msg(string message_id)
        {
            StringResource sr = new StringResource();
            List<TextMessage> msg = sr.LoadAllMessage();

            if(msg.Where(m => m.msgID == message_id).FirstOrDefault() != null)
            {
                return msg.Where(m => m.msgID == message_id).First().message_th;
            }

            return string.Empty;
        }
    }


    public class TextMessage
    {
        public string msgID { get; set; }
        public string message_th { get; set; }
        public string message_en { get; set; }
    }
}
