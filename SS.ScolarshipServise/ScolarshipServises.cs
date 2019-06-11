using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using SS.GenericServise;

namespace SS.ScolarshipServise
{
    public class ScolarshipServises
         : BaseServise<Scholarship>
    {
        public ScolarshipServises()
            : base()
        {

        }
        public ScolarshipServises(UnitOfWork unit)
            : base(unit)
        {

        }
    }

}
