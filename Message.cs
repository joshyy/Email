/*
 * This is free and unencumbered software released into the public domain.
 * 
 * Anyone is free to copy, modify, publish, use, compile, sell, or
 * distribute this software, either in source code form or as a compiled
 * binary, for any purpose, commercial or non-commercial, and by any
 * means.
 * 
 * In jurisdictions that recognize copyright laws, the author or authors
 * of this software dedicate any and all copyright interest in the
 * software to the public domain. We make this dedication for the benefit
 * of the public at large and to the detriment of our heirs and
 * successors. We intend this dedication to be an overt act of
 * relinquishment in perpetuity of all present and future rights to this
 * software under copyright law.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
 * IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
 * OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
 * ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 * 
 * For more information, please refer to <http://unlicense.org>
 */
using System;
using System.Net;
using System.Net.Mail;


namespace joshyy.Email {  
	
	public class Message {	
   
        public MailHost mailHost; 
        public NetworkCredential cred;
        
        public Message(MailHost mailHost, NetworkCredential cred) {
            this.mailHost=mailHost;
            this.cred=cred;         
        }

        public void Send(string from, string to, string subject, string body) {
            Send(from, new []{to}, null, null, subject, body, true, MailPriority.Normal, null);
        }

        public void Send(string from, string to, string cc, string subject, string body) {
            Send(from, new []{to}, new []{cc}, null, subject, body, true, MailPriority.Normal, null);
        }

        public void Send(string from, string to, string cc, string bcc, string subject, string body) {
            Send(from, new []{to}, new []{cc}, new []{bcc}, subject, body, true, MailPriority.Normal, null);
        }

        public void Send(string from, string[] to, string[] cc, string[] bcc, string subject, string body, bool isHtml, MailPriority mailPri, string[] attachments) {
            System.Net.Mail.MailMessage msg = new MailMessage();                        
            msg.From = new MailAddress(from);
            foreach(var t in to) {                
                msg.To.Add(t);
            }
            if (cc != null && cc.Length > 0) {
                foreach(var c in cc) {
                    msg.CC.Add(c);
                }
            }
            if (bcc != null && bcc.Length > 0) {
                foreach(var b in bcc) {
                    msg.Bcc.Add(b);
                }
            }
            msg.Subject = subject;
            msg.Body = body;
            msg.Priority = mailPri;
            msg.IsBodyHtml = isHtml;
            if (attachments != null && attachments.Length > 0) {
                foreach(var att in attachments) {
                    msg.Attachments.Add(new Attachment(att));
                }
            }
            Send(msg);
        }

		public void Send(MailMessage msg) {
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
    }
}
