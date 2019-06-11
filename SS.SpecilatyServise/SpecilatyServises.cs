using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using SS.GenericServise;

namespace SS.SpecilatyServise
{
    public class SpecilatyServises : BaseServise<Specialty>
    {
        public SpecilatyServises()
            : base()
        {

        }
        public SpecilatyServises(UnitOfWork unit)
            : base(unit)
        {

        }
         
    }
}
