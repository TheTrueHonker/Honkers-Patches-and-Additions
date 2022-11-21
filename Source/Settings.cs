using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace HonkersPatchesAndAdditions
{
    public class Settings : ModSettings
    {
        public float MechRecharger_RechargeRateMultiplier = 2;
        public float MechRecharger_WasteProductionMultiplier = 2;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref MechRecharger_RechargeRateMultiplier, "HonkersPA_MechRecharger_RechargeRateMultiplier", 2);
            Scribe_Values.Look(ref MechRecharger_WasteProductionMultiplier, "HonkersPA_MechRecharger_WasteProductionMultiplier", 2);
            base.ExposeData();
        }
    }
}
