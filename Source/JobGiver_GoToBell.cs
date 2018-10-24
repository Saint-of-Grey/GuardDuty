using RimWorld;
using Verse;
using Verse.AI;

namespace GuardDuty
{
    public class JobGiver_GoToBell : JobGiver_WanderColony
    {
        protected override IntVec3 GetWanderRoot(Pawn pawn)
        {
            if (pawn == null)
            {
                return Find.CurrentMap.Center;
            }

            ThingDef singleDef = WhatDef();

            var thingRequest = ThingRequest.ForDef(singleDef);
            return ClosestPosition(pawn, thingRequest)?.Position ?? base.GetWanderRoot(pawn);
        }

        private static Thing ClosestPosition(Pawn pawn, ThingRequest thingRequest)
        {
            return GenClosest.ClosestThingReachable(pawn.Position, pawn.Map,
                thingRequest, PathEndMode.Touch,
                Danger(pawn),
                200f);
        }

        private static TraverseParms Danger(Pawn pawn)
        {
            return TraverseParms.For(pawn, Verse.Danger.Some);
        }

        protected virtual ThingDef WhatDef()
        {
            return ThingDef.Named("BellSpot");
        }
    }
}