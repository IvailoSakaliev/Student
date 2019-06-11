using DataAcsess.Models;
using DataAcsess.Repository;
using SS.CoockieServise;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SS.AuthenticationServise
{
    public class AuthenticationServises
    {
        public SingIn LoggedUser { get; set; }
        public int Login_id { get; set; }
        private List<SingIn> list { get; set; }
        public  SingInServise.SingInServises singIn { get; set; }

        public AuthenticationServises()
        {
            this.singIn = new SingInServise.SingInServises();
        }
        public void AuthenticateUser(string username, string password, int state)
        {
            UserRepository repo = new UserRepository();
            string decriptedUsername = "";
            string decriptedPassword = "";
            this.list = repo.GetAll().ToList();
            foreach (var item in list)
            {
                decriptedUsername = this.singIn.EncriptServise.DencryptData(item.Username);
                decriptedPassword = this.singIn.EncriptServise.DencryptData(item.Password);
                if (decriptedUsername == username && decriptedPassword == password)
                {
                    this.LoggedUser = item;
                    AddSession(state);
                    return;
                }
                else
                {
                    this.LoggedUser = null;
                }
            }
            
            
            
        }

        private void AddSession(int state)
        {
            if (this.LoggedUser != null)
            {
                if (state == 1)
                {
                    if (SS.SingInServise.SingInServises.IsConfirmRegistartion(this.LoggedUser) == true)
                    {
                        GoToSession();
                    }
                }
                else if (state == 2)
                {
                    ReturnIdFromUser();
                }
            }
        }
        private void ReturnIdFromUser()
        {
            this.Login_id = LoggedUser.ID;
        }

        private void GoToSession()
        {

            HttpContext.Current.Session["LoggedUser"] = LoggedUser.Role;
            HttpContext.Current.Session["UserFirstName"] = this.singIn.EncriptServise.DencryptData(LoggedUser.Name);
            HttpContext.Current.Session["User_ID"] = LoggedUser.ID;
        }

        public void LoggOut()
        {

            this.LoggedUser = null;
            HttpContext.Current.Session["LoggedUser"] = null;
            HttpContext.Current.Session["UserFirstName"] = "";
            HttpContext.Current.Session["User_ID"] = null;
            CoockieServises cookie = new CoockieServises();
            cookie.DeleteCoockie("UserInformation");

        }
    }
}
