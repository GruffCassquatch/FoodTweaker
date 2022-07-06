using HarmonyLib;
using MelonLoader;

namespace FoodTweaker
{
    class PatchCooking
    {
        [HarmonyPatch(typeof(CookingPotItem), "ModifiedCookTimeMinutes")]
        internal class AdjustCookTime
        {
            private static float Postfix(float __result,  CookingPotItem __instance)
            {
                MelonLogger.Msg("Gear Item being Cooked Calories Remaining: " + __instance.m_GearItemBeingCooked.m_FoodItem.m_CaloriesRemaining);
                MelonLogger.Msg("Gear Item being Cooked Calories Total: " + __instance.m_GearItemBeingCooked.m_FoodItem.m_CaloriesTotal);

                if (Settings.settings.modFunction)
                {
                    if (Settings.settings.meatCookingTime != Choice.Default)
                    {
                        if (__instance.m_GearItemBeingCooked.name == "GEAR_RawMeatBear")
                        {
                            if (Settings.settings.meatCookingTime == Choice.Custom) return (Settings.settings.bearCookingTime * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                            return (35 * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        }
                        else if (__instance.m_GearItemBeingCooked.name == "GEAR_RawMeatDeer")
                        {
                            if (Settings.settings.meatCookingTime == Choice.Custom) return (Settings.settings.deerCookingTime * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                            return (20 * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        }
                        else if (__instance.m_GearItemBeingCooked.name == "GEAR_RawMeatMoose")
                        {
                            if (Settings.settings.meatCookingTime == Choice.Custom) return (Settings.settings.mooseCookingTime * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                            return (25 * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        }
                        else if (__instance.m_GearItemBeingCooked.name == "GEAR_RawMeatRabbit")
                        {
                            if (Settings.settings.meatCookingTime == Choice.Custom) return (Settings.settings.rabbitCookingTime * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                            return (28 * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        }
                        else if (__instance.m_GearItemBeingCooked.name == "GEAR_RawMeatWolf")
                        {
                            if (Settings.settings.meatCookingTime == Choice.Custom) return (Settings.settings.wolfCookingTime * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                            return (35 * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        }
                    }
                    if (Settings.settings.fishCookingTime != Choice.Default)
                    {
                        if (__instance.m_GearItemBeingCooked.name == "GEAR_RawCohoSalmon")
                        {
                            if (Settings.settings.fishCookingTime == Choice.Custom) return (Settings.settings.salmonCookingTime * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                            return (15 * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        }
                        else if (__instance.m_GearItemBeingCooked.name == "GEAR_RawLakeWhiteFish")
                        {
                            if (Settings.settings.fishCookingTime == Choice.Custom) return (Settings.settings.whitefishCookingTime * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                            return (15 * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        }
                        else if (__instance.m_GearItemBeingCooked.name == "GEAR_RawRainbowTrout")
                        {
                            if (Settings.settings.fishCookingTime == Choice.Custom) return (Settings.settings.troutCookingTime * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                            return (15 * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        }
                        else if (__instance.m_GearItemBeingCooked.name == "GEAR_RawSmallMouthBass")
                        {
                            if (Settings.settings.fishCookingTime == Choice.Custom) return (Settings.settings.bassCookingTime * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                            return (15 * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        }
                    }
                }
                return __result;
            }
        }

        [HarmonyPatch(typeof(CookingPotItem), "SetCookedGearProperties")]
        internal class AdjustCookedMeatAndFish
        {
            private static void Postfix(GearItem rawItem, GearItem cookedItem)
            {
                MelonLogger.Msg("Raw Item Calories Remaining: " + rawItem.m_FoodItem.m_CaloriesRemaining.ToString());
                MelonLogger.Msg("Raw Item Calories Total: " + rawItem.m_FoodItem.m_CaloriesTotal.ToString());
                if (Settings.settings.modFunction)
                {
                    if (rawItem.m_FoodItem.m_IsFish)
                    {
                        cookedItem.m_FoodItem.m_CaloriesRemaining = rawItem.m_FoodItem.m_CaloriesRemaining * GameManager.GetSkillCooking().GetCalorieScale();
                        cookedItem.m_FoodItem.m_CaloriesTotal = rawItem.m_FoodItem.m_CaloriesTotal * GameManager.GetSkillCooking().GetCalorieScale();

                        float salmonCaloriesPerKg = 454.5f;
                        float whitefishCaloriesPerKg = 383.5f;
                        float troutCaloriesPerKg = 383.5f;
                        float bassCaloriesPerKg = 454.5f;

                        if (Settings.settings.caloriesFish == Choice.Realistic)
                        {
                            salmonCaloriesPerKg = 1120;
                            whitefishCaloriesPerKg = 1065;
                            troutCaloriesPerKg = 1200;
                            bassCaloriesPerKg = 1170;
                        }
                        else if (Settings.settings.caloriesFish == Choice.Custom)
                        {
                            salmonCaloriesPerKg = Settings.settings.salmonCooked;
                            whitefishCaloriesPerKg = Settings.settings.whitefishCooked;
                            troutCaloriesPerKg = Settings.settings.troutCooked;
                            bassCaloriesPerKg = Settings.settings.bassCooked;
                        }
                        if (cookedItem.m_GearName == "GEAR_CookedCohoSalmon") cookedItem.m_FoodWeight.m_CaloriesPerKG = salmonCaloriesPerKg * GameManager.GetSkillCooking().GetCalorieScale();
                        if (cookedItem.m_GearName == "GEAR_CookedLakeWhiteFish") cookedItem.m_FoodWeight.m_CaloriesPerKG = whitefishCaloriesPerKg * GameManager.GetSkillCooking().GetCalorieScale();
                        if (cookedItem.m_GearName == "GEAR_CookedRainbowTrout") cookedItem.m_FoodWeight.m_CaloriesPerKG = troutCaloriesPerKg * GameManager.GetSkillCooking().GetCalorieScale();
                        if (cookedItem.m_GearName == "GEAR_CookedSmallMouthBass") cookedItem.m_FoodWeight.m_CaloriesPerKG = bassCaloriesPerKg * GameManager.GetSkillCooking().GetCalorieScale();

                        // Shrinkage
                        float fishShrinkage = 0.66f;

                        if (Settings.settings.fishShrinkage == Choice.Realistic) fishShrinkage = 0.5f;
                        else if (Settings.settings.fishShrinkage == Choice.Custom)
                        {
                            if (cookedItem.m_GearName == "GEAR_CookedCohoSalmon") fishShrinkage = 1 - Settings.settings.salmonShrinks;
                            if (cookedItem.m_GearName == "GEAR_CookedLakeWhiteFish") fishShrinkage = 1 - Settings.settings.whitefishShrinks;
                            if (cookedItem.m_GearName == "GEAR_CookedRainbowTrout") fishShrinkage = 1 - Settings.settings.troutShrinks;
                            if (cookedItem.m_GearName == "GEAR_CookedSmallMouthBass") fishShrinkage = 1 - Settings.settings.bassShrinks;
                        }
                        cookedItem.m_WeightKG = rawItem.m_WeightKG * fishShrinkage;
                    }
                    else if (rawItem.m_FoodItem.m_IsMeat)
                    {
                        float rawItemWeight = rawItem.m_FoodItem.m_CaloriesRemaining / rawItem.m_FoodItem.m_CaloriesTotal;
                        float cookedItemWeight = rawItemWeight;
                        MelonLogger.Msg("Raw Weight: " + rawItemWeight.ToString());

                        float cookedBearCalories = 900;
                        float cookedDeerCalories = 800;
                        float cookedMooseCalories = 900;
                        float cookedRabbitCalories = 450;
                        float cookedWolfCalories = 700;

                        if (Settings.settings.caloriesMeat == Choice.Realistic)
                        {
                            cookedBearCalories = 1305;
                            cookedDeerCalories = 1172;
                            cookedMooseCalories = 1040;
                            cookedRabbitCalories = 932;
                            cookedWolfCalories = 875;
                        }
                        else if (Settings.settings.caloriesMeat == Choice.Custom)
                        {
                            cookedBearCalories = Settings.settings.bearCooked;
                            cookedDeerCalories = Settings.settings.deerCooked;
                            cookedMooseCalories = Settings.settings.mooseCooked;
                            cookedRabbitCalories = Settings.settings.rabbitCooked;
                            cookedWolfCalories = Settings.settings.wolfCooked;
                        }

                        // Shrinkage
                        float bearShrinkage = 1f;
                        float deerShrinkage = 1f;
                        float mooseShrinkage = 1f;
                        float rabbitShrinkage = 1f;
                        float wolfShrinkage = 1f;

                        if (Settings.settings.meatShrinkage == Choice.Realistic)
                        {
                            bearShrinkage = 0.75f;
                            deerShrinkage = 0.75f;
                            mooseShrinkage = 0.75f;
                            rabbitShrinkage = 0.75f;
                            wolfShrinkage = 0.75f;
                        }
                        else if (Settings.settings.meatShrinkage == Choice.Custom)
                        {
                            bearShrinkage = 1 - Settings.settings.bearShrinks;
                            deerShrinkage = 1 - Settings.settings.deerShrinks;
                            mooseShrinkage = 1 - Settings.settings.mooseShrinks;
                            rabbitShrinkage = 1 - Settings.settings.rabbitShrinks;
                            wolfShrinkage = 1 - Settings.settings.wolfShrinks;
                        }

                        if (Settings.settings.caloriesMeat == Choice.Default && Settings.settings.meatShrinkage != Choice.Default)
                        {
                            cookedBearCalories = 900 / bearShrinkage;
                            cookedDeerCalories = 800 / deerShrinkage;
                            cookedMooseCalories = 900 / mooseShrinkage;
                            cookedRabbitCalories = 450 / rabbitShrinkage;
                            cookedWolfCalories = 700 / wolfShrinkage;
                        }

                        if (cookedItem.m_GearName == "GEAR_CookedMeatBear")
                        {
                            cookedItemWeight *= bearShrinkage;
                            cookedItem.m_FoodItem.m_CaloriesRemaining = cookedItemWeight * cookedBearCalories * GameManager.GetSkillCooking().GetCalorieScale();
                        }
                        else if (cookedItem.m_GearName == "GEAR_CookedMeatDeer")
                        {
                            cookedItemWeight *= deerShrinkage;
                            cookedItem.m_FoodItem.m_CaloriesRemaining = cookedItemWeight * cookedDeerCalories * GameManager.GetSkillCooking().GetCalorieScale();
                        }
                        else if (cookedItem.m_GearName == "GEAR_CookedMeatMoose")
                        {
                            cookedItemWeight *= mooseShrinkage;
                            cookedItem.m_FoodItem.m_CaloriesRemaining = cookedItemWeight * cookedMooseCalories * GameManager.GetSkillCooking().GetCalorieScale();
                        }
                        else if (cookedItem.m_GearName == "GEAR_CookedMeatRabbit")
                        {
                            cookedItemWeight *= rabbitShrinkage;
                            cookedItem.m_FoodItem.m_CaloriesRemaining = cookedItemWeight * cookedRabbitCalories * GameManager.GetSkillCooking().GetCalorieScale();
                        }
                        else if (cookedItem.m_GearName == "GEAR_CookedMeatWolf")
                        {
                            cookedItemWeight *= wolfShrinkage;
                            cookedItem.m_FoodItem.m_CaloriesRemaining = cookedItemWeight * cookedWolfCalories * GameManager.GetSkillCooking().GetCalorieScale();
                        }
                        cookedItem.m_FoodItem.m_CaloriesTotal = cookedItem.m_FoodItem.m_CaloriesRemaining / cookedItemWeight;
                        MelonLogger.Msg("Cooked Item Weight: " + cookedItemWeight.ToString());
                        MelonLogger.Msg("Cooked Item Calories Remaining: " + cookedItem.m_FoodItem.m_CaloriesRemaining.ToString());
                        MelonLogger.Msg("Cooked Item Total Calories: " + cookedItem.m_FoodItem.m_CaloriesTotal.ToString());
                    }
                }
            }
        }
    }
}
