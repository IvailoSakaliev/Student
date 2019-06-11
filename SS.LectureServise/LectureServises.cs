using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using SS.GenericServise;
using System.Collections.Generic;
using System.Linq;

namespace SS.LectureServise
{
    public class LectureServises : BaseServise<Lecture>
    {
        public LectureServises()
            : base()
        {

        }
        public LectureServises(UnitOfWork unit)
            : base(unit)
        {

        }

        public Lecture GetByloginID(int id)
        {
            Lecture lector = new Lecture();
            int login_id = id;
            List<Lecture> list = _repo.GetAll((u) => u.Login == login_id).ToList();
            lector = list.Count > 0 ? list[0] : null;
            return lector;
        }

    }
}
