using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using SS.GenericServise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.SubjectServise
{
    public class SubjectServises : BaseServise<Subject>
    {
        public SubjectServises()
            : base()
        {

        }
        public SubjectServises(UnitOfWork unit)
            : base(unit)
        {

        }
    }
}
