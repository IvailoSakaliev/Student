using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using SS.GenericServise;

namespace SS.ScholarshipServise
{
    public class ScholarshipServises : BaseServise<Scholarship>
    {
        public ScholarshipServises()
            : base()
        {

        }
        public ScholarshipServises(UnitOfWork unit)
            : base(unit)
        {

        }
    }
}
