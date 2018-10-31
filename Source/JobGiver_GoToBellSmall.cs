using Verse;

namespace GuardDuty
{
    public class JobGiver_GoToBellSmall : JobGiver_GoToBell
    {
        protected override ThingDef WhatDef()
        {
            return ThingDef.Named("BellSpotSmall");
        }
    }
}