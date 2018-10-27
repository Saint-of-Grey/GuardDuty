using System;
using Verse;
using Verse.AI;

namespace GuardDuty
{
    public class ThinkNode_ConditionalTownBell : ThinkNode_Conditional
    {
        protected override bool Satisfied(Pawn pawn)
        {
            var bellOn = GuardDuty.BellOn;

            if (bellOn)
                foreach (var need in pawn.needs.AllNeeds)
                    need.CurLevel = Math.Max(need.CurLevel, need.def.baseLevel/2f);
            
            return bellOn;
        }
    }
}