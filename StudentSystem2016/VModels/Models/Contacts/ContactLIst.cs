using DataAcsess.Models;
using StudentSystem2016.Filters.EntityFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem2016.VModels.Models.Contacts
{
    public class ContactLIst
        : GenericList<Contact, ContactFilter>
    {
        public ContactLIst()
            : base()
        {

        }
    }
}