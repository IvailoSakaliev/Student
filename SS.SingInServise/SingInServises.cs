using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using SS.GenericServise;
using System;
using System.Collections.Generic;
using System.Web;

namespace SS.SingInServise
{
    public class SingInServises
       : BaseServise<SingIn>
    {

        public SingInServises()
            : base()
        {

        }
        public SingInServises(UnitOfWork unit)
            : base(unit)
        {

        }
        public void ConfirmedRegistration(int? id)
        {
            SingIn user = GetByID(id);
            user.isRegisted = true;
            Save(user);
        }
        public static bool IsConfirmRegistartion(SingIn user)
        {
            if (user.isRegisted)
            {
                return user.isRegisted;
            }
            return user.isRegisted;
        }


        public void ChangePassword(int id, string password)
        {
            var user = GetByID(id);
            user.Password = EncriptServise.EncryptData(password);
            Save(user);
        }

        public SingIn ResetPassword(List<SingIn> users, string email)
        {
            string decriptedEmail;
            for (int i = 0; i < users.Count; i++)
            {
                decriptedEmail = EncriptServise.DencryptData(users[i].Email);
                if (email == decriptedEmail)
                {
                    return users[i];
                }
            }
            return null;
        }

        public List<string> AutoLogin()
        {
            List<string> loginInfo = new List<string>();
            
            HttpCookie cookie = HttpContext.Current.Request.Cookies["UserInformation"];
            try
            {
                loginInfo.Add(EncriptServise.DencryptData(cookie["username"]));
                loginInfo.Add(EncriptServise.DencryptData(cookie["password"]));
            }
            catch (NullReferenceException)
            {
                
            }
            return loginInfo;
        }
    }
}
       