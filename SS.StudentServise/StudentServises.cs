using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using SS.GenericServise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.StudentServise
{
    public class StudentServises
        : BaseServise<Student>
    {
        public StudentServises()
            : base()
        {

        }

        public StudentServises(UnitOfWork unit)
            : base(unit)
        {

        }

        public Student GetByloginID(int id)
        {
            Student student = new Student();
            List<Student> list = _repo.GetAll((u) => u.Login == id).ToList();
            student = list.Count > 0 ? list[0] : null;
            return student;
        }
    }
}
