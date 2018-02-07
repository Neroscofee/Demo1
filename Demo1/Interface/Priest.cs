using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Demo1.Interface
{
    class Priest : Role
    {
        public void CastSkill()
        {
            Trace.WriteLine("牧师使用治疗术");
        }
    }
}
