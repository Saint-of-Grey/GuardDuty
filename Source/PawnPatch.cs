using System;
using System.Collections.Generic;
using System.Linq;
using Harmony;
using Verse;

namespace GuardDuty
{
    [HarmonyPatch(typeof(Pawn), "GetGizmos", new Type[]{}) ]
    public static class PawnPatch
    {
        [HarmonyPostfix]
        public static IEnumerable<Gizmo> HarmonyPostfix(IEnumerable<Gizmo> __result)
        {
            return __result.Union(Building_BellSpot.BellGizmo());
        }
        
        
    }
}