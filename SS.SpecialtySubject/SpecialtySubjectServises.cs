using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using SS.GenericServise;

namespace SS.SpecialtySubjectServise
{
    public class SpecialtySubjectServises
        :BaseServise<SpecialtySubject>
    {
        public SpecialtySubjectServises()
            :base()
        {

        }

        public SpecialtySubjectServises(UnitOfWork unit)
            :base(unit)
        {

        }
    }
}
