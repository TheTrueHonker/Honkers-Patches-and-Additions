using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using HarmonyLib;

namespace HonkersPatchesAndAdditions
{
    [StaticConstructorOnStartup]
    public static class Harmony
    {
        static Harmony()
        {
            HarmonyLib.Harmony harmony = new HarmonyLib.Harmony("Honker.HonkersPatchesAndAdditions");
            harmony.PatchAll();
            Log.Message("[HPA] Honkers Patches and Additions loaded");
        }
    }
}
