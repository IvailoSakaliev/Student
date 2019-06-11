using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using SS.GenericServise;


namespace SS.FacultelServise
{
    public class FacultetServise : BaseServise<Facultet>
    {
        public FacultetServise()
            : base()
        {

        }
        public FacultetServise(UnitOfWork unit)
            : base(unit)
        {

        }
    }
}
