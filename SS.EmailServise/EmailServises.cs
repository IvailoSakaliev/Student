using DataAcsess.Models;
using SS.GenericServise;
using System.Net;
using System.Net.Mail;

namespace SS.EmailServise
{
    public class EmailServises : BaseServise<SingIn>
    {
        public SingIn _admin;
        private SingInServise.SingInServises singIn = new SingInServise.SingInServises();
        private string _userEmail;
        private int _userID;
        private SmtpClient _smtpClient;
        private NetworkCredential _basicCredential;
        private MailMessage _message;
        private MailAddress _fromAddress;

        public EmailServises()
            : base()
        {

        }

        public EmailServises(SingIn user)
        {
            _admin = GetDecriptedInformationForAdmin();
            _userEmail = singIn.EncriptServise.DencryptData(user.Email);
            _userID = user.ID;
            _smtpClient = new SmtpClient();
            _basicCredential =
                new NetworkCredential(_admin.Email, _admin.Password);
            _message = new MailMessage();
            _fromAddress = new MailAddress(_userEmail);
        }

        public void SendEmail(int mode)
        {
            _smtpClient.Host = "smtp.gmail.com";
            _smtpClient.UseDefaultCredentials = false;
            _smtpClient.Credentials = _basicCredential;
            _smtpClient.EnableSsl = true;
            _smtpClient.Port = 587;

            _message.From = _fromAddress;
            _message.IsBodyHtml = true;

            switch (mode)
            {
                case 1:
                    SendConfirmEmail();
                    break;
                case 2:
                    SendRestorPasswordEmail();
                    break;
                default:
                    break;
            }

        }

        private void SendRestorPasswordEmail()
        {
            _message.Subject = "Restor Password";
            _message.Body = "Please enter link to restor your password in StudentSystem http://studentsystem.azurewebsites.net/SingIN/ChangePassword/" + _userID;
            _message.To.Add(_userEmail);
            _smtpClient.Send(_message);
        }

        private void SendConfirmEmail()
        {
            _message.Subject = "Confirm registration";
            _message.Body = "Please to confirm your registration in StudentSystem http://studentsystem.azurewebsites.net/SingIN/Confirm/" + _userID;
            _message.To.Add(_userEmail);
            _smtpClient.Send(_message);
        }

        private SingIn GetDecriptedInformationForAdmin()
        {
            var admin = GetByID(1);
            SingIn result = new SingIn();
            result.Email = singIn.EncriptServise.DencryptData(admin.Email);
            result.Password = singIn.EncriptServise.DencryptData(admin.Password);
            return result;
        }
    }
}