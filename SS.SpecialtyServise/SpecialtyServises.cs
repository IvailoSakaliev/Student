using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using SS.GenericServise;

namespace SS.SpecialtyServise
{
    public class SpecialtyServises : BaseServise<Specialty>
    {
        public SpecialtyServises()
            : base()
        {

        }
        public SpecialtyServises(UnitOfWork unit)
            : base(unit)
        {

        }
    }
}
