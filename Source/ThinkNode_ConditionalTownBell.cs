using Verse;
using Verse.AI;

namespace GuardDuty
{
    public class ThinkNode_ConditionalTownBell : ThinkNode_Conditional
    {
        protected override bool Satisfied(Pawn pawn)
        {
            return GuardDuty.BellOn;
        }
    }
}