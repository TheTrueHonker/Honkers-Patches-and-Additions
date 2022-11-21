using RimWorld;
using Verse;
using HarmonyLib;


namespace HonkersPatchesAndAdditions
{
    [HarmonyPatch]
    static class Building_MechCharger_Patch
    {
        const float BASE_CHARGING_TICK = 0.00083333335f;

        [HarmonyPatch(typeof(Building_MechCharger), nameof(Building_MechCharger.Tick))]
        [HarmonyPostfix]
        static void Tick_Postfix(ref Pawn ___currentlyChargingMech, ref float ___wasteProduced, Building_MechCharger __instance)
        {
            if (___currentlyChargingMech != null && __instance.Power.PowerOn)
            {
                var rechargeRateMultiplier = LoadedModManager.GetMod<HonkersPatchesAndAdditions>().GetSettings<Settings>().MechRecharger_RechargeRateMultiplier;
                var wasteProductionRateMultiplier = LoadedModManager.GetMod<HonkersPatchesAndAdditions>().GetSettings<Settings>().MechRecharger_WasteProductionMultiplier;
                ___currentlyChargingMech.needs.energy.CurLevel -= BASE_CHARGING_TICK;
                ___currentlyChargingMech.needs.energy.CurLevel += BASE_CHARGING_TICK * rechargeRateMultiplier;
                ___wasteProduced -= GetBaseWasteProductionPerTick(___currentlyChargingMech);
                ___wasteProduced += GetBaseWasteProductionPerTick(___currentlyChargingMech) * wasteProductionRateMultiplier;
                //Log.Message($"[HPA] Charging Mech: {___currentlyChargingMech.Name} Power Level: {___currentlyChargingMech.needs.energy.CurLevel}");
            }
        }

        private static float GetBaseWasteProductionPerTick(Pawn currentlyChargingMech)
        {
            return currentlyChargingMech.GetStatValue(StatDefOf.WastepacksPerRecharge, true, -1) * (BASE_CHARGING_TICK / currentlyChargingMech.needs.energy.MaxLevel);
        }
    }
}
