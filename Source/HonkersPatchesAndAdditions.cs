
using System;
using Verse;
using UnityEngine;

namespace HonkersPatchesAndAdditions
{
    public class HonkersPatchesAndAdditions : Mod
    {
        Settings settings;

        public HonkersPatchesAndAdditions(ModContentPack content) : base(content)
        {
            settings = GetSettings<Settings>();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            var listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);

            // MechRecharger Recharge Rate
            listingStandard.Label("HonkersPA_MechRecharger_RechargeRate_Label".Translate() + 
                ": " + settings.MechRecharger_RechargeRateMultiplier.ToStringPercent());
            settings.MechRecharger_RechargeRateMultiplier = listingStandard.Slider(
                RoundToNearestHalf(settings.MechRecharger_RechargeRateMultiplier),
                0.5f, 100f);

            // MechRecharger Wasterpack Generation
            listingStandard.Label("HonkersPA_MechRecharger_WasteProductionRate_Label".Translate() +
                ": " + settings.MechRecharger_WasteProductionMultiplier.ToStringPercent());
            settings.MechRecharger_WasteProductionMultiplier = listingStandard.Slider(
                RoundToNearestHalf(settings.MechRecharger_WasteProductionMultiplier),
                0f, 100f);

            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }

        public override string SettingsCategory()
        {
            return "HonkersPA_Settings_Category_Label".Translate();
        }

        private float RoundToNearestHalf(float val)
        {
            return (float)Math.Round(val * 2, MidpointRounding.AwayFromZero) / 2;
        }
    }
}
