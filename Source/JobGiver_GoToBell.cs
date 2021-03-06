using RimWorld;
using Verse;
using Verse.AI;

namespace GuardDuty
{
    public class JobGiver_GoToBellBase : ThinkNode_JobGiver
    {
        Danger maxDanger = Verse.Danger.Some;
        ThingDef thingDef = ThingDefOf.PartySpot;

        protected override Job TryGiveJob(Pawn pawn)
        {
            var thing = ThingToDo(pawn);
            
            if (thing != null)
            {
                if (!thing.Position.IsValid)
                    return (Job) null;
                if (!pawn.CanReach((LocalTargetInfo) thing.Position, PathEndMode.ClosestTouch, maxDanger))
                {
                    return (Job) null;
                }

                if (IntVec3Utility.DistanceTo(thing.Position, pawn.Position) < 10f)
                {
                    return null;
                }
                
                return new Job(JobDefOf.Goto, (LocalTargetInfo) thing.Position)
                {
                    locomotionUrgency = LocomotionUrgency.Sprint
                };
            }
            else
                return null;
        }

        private Thing ThingToDo(Pawn pawn)
        {
            ThingDef singleDef = WhatDef();
            if (singleDef == null)
            {
                Log.ErrorOnce("Forgot to set thingDef", this.GetHashCode());
                return null;
            }
            var thingRequest = ThingRequest.ForDef(singleDef);
            Thing closestPosition = ClosestPosition(pawn, thingRequest);
            return closestPosition;
        }

        private Thing ClosestPosition(Pawn pawn, ThingRequest thingRequest)
        {
            return GenClosest.ClosestThingReachable(pawn.Position, pawn.Map,
                thingRequest, PathEndMode.Touch,
                Danger(pawn),
                200f);
        }

        private TraverseParms Danger(Pawn pawn)
        {
            return TraverseParms.For(pawn, maxDanger);
        }

        protected virtual ThingDef WhatDef()
        {
            return thingDef;
        }
    }

    public class JobGiver_GoToBell : JobGiver_GoToBellBase
    {
        protected virtual ThingDef WhatDef()
        {
            return ThingDef.Named("BellSpot");
        }
    }
}