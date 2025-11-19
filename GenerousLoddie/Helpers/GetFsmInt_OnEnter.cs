using HarmonyLib;
using HutongGames.PlayMaker.Actions;

namespace GenerousLoddie.Helpers
{
    [HarmonyPatch(typeof(GetFsmInt), "OnEnter")]
    public static class GetFsmInt_OnEnter
    {
        [HarmonyPostfix]
        public static void Postfix(GetFsmInt __instance)
        {
            //GenerousLoddie.instance.Log($"{__instance.fsm.name}, {__instance.fsm.gameObject.name}, {__instance.State.name}");
            if (__instance.fsm.name.Equals("Pin Challenge") &&
                __instance.fsm.gameObject.name.Equals("Pin Challenge") &&
                __instance.State.name.Equals("Evaluation"))
            {
                float defaultValue = __instance.storeValue.value;
                float multiplier = Settings.ConfigSettings.loddieMultiplier.Value - 1;
                float bonusValue = defaultValue * multiplier;
                __instance.storeValue.value += (int)bonusValue;
                //GenerousLoddie.instance.Log($"Loddie payout increased by {bonusValue} to {__instance.storeValue.value}");
            }
        }
    }
}