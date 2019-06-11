using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using SS.GenericServise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.EvaluationServise
{
    public class EvaluationServise
        : BaseServise<Evaluation>
    {
        public EvaluationServise()
            : base()
        {

        }
        public EvaluationServise(UnitOfWork unit)
            : base(unit)
        {

        }
    }
}
