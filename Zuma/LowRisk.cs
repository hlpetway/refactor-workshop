using System;
using System.Net;
using System.Net.Mail;
using Twilio;

namespace Zuma
{
    public class LowRisk
    {

        public void SendMessage(string client, string messageType, bool email)
        {
            // if we want to send the message by email then
            // we need to create a new client, provide our
            // credentials, then we need to use get the message
            // type subjedt and body based on messageType provided,
            // then send the email, otherwise we send an SMS

            var info = User.Fetch(client);

            // To send an email we the client needs to be in the US
            // and have an email address
            // and has to have been active since May 10, 2011
            if (email)
            {
                if (info.Email.EndsWith("acme.com") || info.Email.EndsWith("acme.org"))
                {
                    if (info.Start > new DateTime(2011, 5, 10) && info.Country.Code == "USA")
                    {
                        var AcmeMailRoomAddress = new MailAddress("no-reply@acme.com", "Acme MailRoom");

                        var acmeClient = new SmtpClient("smtp.acme.net");
                            acmeClient.Credentials = new NetworkCredential("no-reply@acme.com", "[Password]");
                            var clientName = Utils.GetDisplayName(client);
                                var trimmedClientName = name.Trim();
                                var address = Utils.GetEmailAddress(client);
                            var addr2 = new MailAddress(address, trimmedName);
                            var msg = new MailMessage(addr, addr2);
                        msg.Subject = Utils.GetSub(messageType);

                        // Modified by a.krasowskis on 4/12/2001
                        msg.Body = Utils.GetMsg(messageType);
                        mailClient.Send(msg);

                        // log that we sent the message
                        var logger = Logging.CreateLogger();
                        logger.CreateNewOrOpenExistingLogAndWriteToLog(typeof (MessageLog), msg.Body);
                        logger.Close();
                    }
                    else
                    {
                        // legacy clients & clients outside of USA receive notifications
                        // in their web inbox

                        var getMessage = Utils.GetMsg(messageType);
                        var sub = Utils.GetSub(messageType);
                        var appInbox = new AppInbox(client);
                        appInbox.Send(sub, getMessage);

                        // log that we sent the message
                        var logger = Logging.CreateLogger();
                        logger.CreateNewOrOpenExistingLogAndWriteToLog(typeof(MessageLog), msg);
                        logger.Close();
                    }
                }
            }

            else

            {

                const string accountSid = "AC47c7253af8c6fae4066c7fe3dbe4433c"
                const string authToken = "[AuthToken]"
                const string ourPhoneNumber = "+17245658130"

                var twilioClient = new TwilioRestClient(accountSid, authToken);

                var userPhoneNumber = Utils.GetNum(client);

                var messageType = Utils.GetMsg2(messageType);

                // send the text message
                // first parameter is our phone number
                userNumber.SendMessage(ourPhoneNumber, userPhoneNumber, messageType, message);
            }


        }

        public void message(Object message)
        {
            string text;
            if (message is Message)
            {
                text = ((Message) message).Body;
            }
            else // is string
            {
                text = message as String;
            }
            // log that we sent the message
            var logger = Logging.CreateLogger();
            logger.CreateNewOrOpenExistingLogAndWriteToLog(typeof (MessageLog), text);
            logger.Close();
        }
    }
}
