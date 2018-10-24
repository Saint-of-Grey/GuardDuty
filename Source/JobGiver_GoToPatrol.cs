using Verse;

namespace GuardDuty
{
    public class JobGiver_GoToPatrol : JobGiver_GoToBell
    {
        protected override ThingDef WhatDef()
        {
            return ThingDef.Named("BellSpot");
        }
    }
}