using Verse;
using Verse.AI;

namespace GuardDuty
{
    public class JobGiver_GoToBell : JobGiver_Wander
    {
        protected override IntVec3 GetWanderRoot(Pawn pawn)
        {
            return GenClosest.ClosestThingReachable(pawn.Position, pawn.Map,
                ThingRequest.ForDef(WhatDef()), PathEndMode.OnCell,
                TraverseParms.For(pawn, Danger.Some),
                7f).Position;
        }

        protected virtual ThingDef WhatDef()
        {
            return ThingDef.Named("BellSpot");
        }
    }
}