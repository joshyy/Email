using System;
using System.Net;
using System.Net.Mail;


namespace joshyy.Email {
   public class Send {

        public Send(MailHost mailHost, NetworkCredential cred, MailMessage msg) {
            SmtpClient client = new SmtpClient(mailHost.Host); 
            client.Port = mailHost.Port;         
            client.EnableSsl = mailHost.EnableSsl;
            client.Credentials = cred;

            try {
                client.Send(msg);
            } catch (Exception ex) {
                throw ex;
            }
        }

        static void Main(string[] args){
            Console.WriteLine("See https://github.com/joshyy/Email/ for usage.");
        }
    }

public class MailHost {
        public string Host {get;set;}
        public int Port{get;set;}
        public bool EnableSsl{get;set;}

        public MailHost(string host, int port, bool ssl) {
            Host=host;
            Port=port;
            EnableSsl=ssl;
        }
    }
}