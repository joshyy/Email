# Email
Easy C# email sending program.

Usage is easy:
```c#
joshyy.Email.MailHost mailHost = new joshyy.Email.MailHost("smtp.mailhost.com", port, true);                            
NetworkCredential cred = new NetworkCredential("myemail@mydomain.com","mypassword");

System.Net.Mail.MailMessage msg = new MailMessage();            
msg.From = new MailAddress("myemail@mydomain.com");
msg.To.Add("someone@somewhere.com");
msg.Subject ="test subject";
msg.Body = "body goes here";
//msg.Priority = MailPriority.High;
//msg.Attachments.Add(new Attachment( "c:\\somefile.txt"));

try {
    new joshyy.Email.Send(mailHost, cred, msg);    
} catch (Exception x) {
    Console.WriteLine(x.Message);
}
```
