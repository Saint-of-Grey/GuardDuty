using System.Collections.Generic;
using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;

namespace GuardDuty
{
    public class Building_BellSpot : Building
    {
        public override IEnumerable<Gizmo> GetGizmos()
        {
            return base.GetGizmos().Union(BellGizmo());
        }

        public static IEnumerable<Gizmo> BellGizmo()
        {
            yield return new Command_Toggle
            {
                defaultLabel = "Town Bell",
                defaultDesc = "Run to guard points if a guard , run to the bell if not.",
                hotKey = KeyBindingDefOf.Command_TogglePower,
                icon = Icon(),
                isActive = () => GuardDuty.BellOn,
                toggleAction = () => GuardDuty.BellOn = !GuardDuty.BellOn
            };
        }

        public static Texture2D Icon()
        {
            return ContentFinder<Texture2D>.Get("townbell", true);
        }
    }
}