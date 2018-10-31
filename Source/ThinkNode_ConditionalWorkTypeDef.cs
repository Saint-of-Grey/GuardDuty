using System;
using RimWorld;
using Verse;
using Verse.AI;

namespace GuardDuty
{
    public class ThinkNode_ConditionalWorkTypeDef : ThinkNode_Conditional
    {
        private WorkTypeDef _def;
        private string workTypeDef;
        private bool makeAgro;

        protected override bool Satisfied(Pawn me)
        {
            if (_def == null)
                _def = DefDatabase<WorkTypeDef>.GetNamedSilentFail(workTypeDef);

            if (_def == null) return false;

            if (me?.workSettings == null || !me.workSettings.WorkIsActive(_def))
                return false;

            if (me.Drafted) return false;

            if (makeAgro)
            {
                if (me.playerSettings == null) me.playerSettings = new Pawn_PlayerSettings(me);
                me.playerSettings.hostilityResponse = HostilityResponseMode.Attack;
            }

            return true;
        }
    }
}