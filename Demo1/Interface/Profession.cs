using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Demo1.Interface
{
    class Profession
    {
        //public void StartCombat(Priest priest)
        //{
        //    Trace.WriteLine("战斗开始：");
        //    priest.CastSkill();
        //}
        //public void StartCombat(Rogue rogue)
        //{
        //    Trace.WriteLine("战斗开始：");
        //    rogue.CastSkill();
        //}
        //public void StartCombat(Mage mage)
        //{
        //    Trace.WriteLine("战斗开始：");
        //    mage.CastSkill();
        //}
        public void StartCombat(Role role)
        {
            role.CastSkill();
        }
    }
}
