using DataAcsess.Models;
using StudentSystem2016.Filters;
using StudentSystem2016.VModels.Models.User;
using System.Collections.Generic;

namespace StudentSystem2016.VModels
{
    public interface IGenericList<Tentity, Tfilter>
        where Tentity : BaseModel
        where Tfilter : GenericFiler<Tentity>, new()
    {
        string ActionName { get; set; }
        IList<Tentity> AllItems { get; set; }
        string ControllerName { get; set; }
        Tfilter Filter { get; set; }
        IList<Tentity> Items { get; set; }
        int Pages { get; set; }
        int StartItem { get; set; }
        IList<string> BaseTypeName { get; set; }
        IList<string> TypeName { get; set; }
        IList<Product> Product { get; set; }
        IList<User> User { get; set; }
        IList<Order> Order { get; set; }
        UserEditVm CurrentUser { get; set; }
        IList<int> ProductCount { get; set; }
        IList<double> TotalPriceList { get; set; }
        List<int> QuantityOrderList { get; set; }
    }
}