using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Twilio;
using Message = System.ServiceModel.Channels.Message;

namespace NWHarvest.Web.App_Start
{
    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            var id = ConfigurationManager.AppSettings["SMSAccountIdentification"];
            var password = ConfigurationManager.AppSettings["SMSAccountPassword"];
            var from = ConfigurationManager.AppSettings["SMSAccountFrom"];

            var twilio = new TwilioRestClient(id, password);

            var result = twilio.SendMessage(from, message.Destination, message.Body);

            return Task.FromResult(0);
        }
    }
}
