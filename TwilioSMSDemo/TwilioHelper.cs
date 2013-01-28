using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twilio;

namespace TwilioSMSDemo
{
    public class TwilioHelper
    {
        TwilioRestClient client;
        string fromNumber = "<From Phone>";
        string accountSid = "<Account SID>";
        string authToken = "<Auth Token>";
        public TwilioHelper()
        {
            client = new TwilioRestClient(accountSid, authToken);
        }


        public void SendSMS(string phonenumber, string message)
        {
            client.SendSmsMessage(fromNumber, phonenumber, message);
        }

        public SmsMessageResult GetMessages()
        {
            return client.ListSmsMessages();
        }

       
    }
}