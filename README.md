# Email
Easy C# email sending program.

Usage is easy:
```c#
joshyy.Email.MailHost mailHost = new joshyy.Email.MailHost("smtp.mailhost.com", port, true);
NetworkCredential cred = new NetworkCredential("myemail@mydomain.com","mypassword");
joshyy.Email.Message email = new joshyy.Email.Message(mailHost, cred);
try {
    email.Send("from", "to", "subject", "body");
} catch (Exception x) {
    Console.WriteLine(x.Message);
}
```

More complex emails may be sent by creating a MailMessage object first and passing that to Send() method:
```c#
System.Net.Mail.MailMessage msg = new MailMessage();
msg.From = "fromaddress@somedomain.co;
msg.To.Add("someaddress@otherdomain.co");
msg.Subject = "subject";
msg.Body = "html stuff";
msg.IsBodyHtml = true;
msg.Priority = MailPriority.High;
try {
    email.Send(msg);
} catch (Exception x) {
    Console.WriteLine(x.Message);
}
```
