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
                if (Settings.settings.modFunction && __instance.m_GearItemBeingCooked.name.StartsWith("GEAR_Raw"))
                {
                    if (Settings.settings.meatCookingTime != Choice.Default && __instance.m_GearItemBeingCooked.name.StartsWith("GEAR_RawMeat"))
                    {
                        float itemWeight = __instance.m_GearItemBeingCooked.m_FoodItem.m_CaloriesRemaining / __instance.m_GearItemBeingCooked.m_FoodItem.m_CaloriesTotal;

                        if (__instance.m_GearItemBeingCooked.name == "GEAR_RawMeatBear")
                        {
                            if (Settings.settings.meatCookingTime == Choice.Custom) return (Settings.settings.bearCookingTime * itemWeight) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                            return (Implementation.bearCookingTime * itemWeight) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        }
                        else if (__instance.m_GearItemBeingCooked.name == "GEAR_RawMeatDeer")
                        {
                            if (Settings.settings.meatCookingTime == Choice.Custom) return (Settings.settings.deerCookingTime * itemWeight) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                            return (Implementation.deerCookingTime * itemWeight) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        }
                        else if (__instance.m_GearItemBeingCooked.name == "GEAR_RawMeatMoose")
                        {
                            if (Settings.settings.meatCookingTime == Choice.Custom) return (Settings.settings.mooseCookingTime * itemWeight) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                            return (Implementation.mooseCookingTime * itemWeight) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        }
                        else if (__instance.m_GearItemBeingCooked.name == "GEAR_RawMeatRabbit")
                        {
                            if (Settings.settings.meatCookingTime == Choice.Custom) return (Settings.settings.rabbitCookingTime * itemWeight) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                            return (Implementation.rabbitCookingTime * itemWeight) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        }
                        else if (__instance.m_GearItemBeingCooked.name == "GEAR_RawMeatWolf")
                        {
                            if (Settings.settings.meatCookingTime == Choice.Custom) return (Settings.settings.wolfCookingTime * itemWeight) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                            return (Implementation.wolfCookingTime * itemWeight) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        }
                    }
                    else if (Settings.settings.fishCookingTime != Choice.Default)
                    {
                        if (__instance.m_GearItemBeingCooked.name == "GEAR_RawCohoSalmon")
                        {
                            if (Settings.settings.fishCookingTime == Choice.Custom) return (Settings.settings.salmonCookingTime * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                            return (Implementation.fishCookingTime * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        }
                        else if (__instance.m_GearItemBeingCooked.name == "GEAR_RawLakeWhiteFish")
                        {
                            if (Settings.settings.fishCookingTime == Choice.Custom) return (Settings.settings.whitefishCookingTime * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                            return (Implementation.fishCookingTime * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        }
                        else if (__instance.m_GearItemBeingCooked.name == "GEAR_RawRainbowTrout")
                        {
                            if (Settings.settings.fishCookingTime == Choice.Custom) return (Settings.settings.troutCookingTime * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                            return (Implementation.fishCookingTime * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        }
                        else if (__instance.m_GearItemBeingCooked.name == "GEAR_RawSmallMouthBass")
                        {
                            if (Settings.settings.fishCookingTime == Choice.Custom) return (Settings.settings.bassCookingTime * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                            return (Implementation.fishCookingTime * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
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
                if (Settings.settings.modFunction)
                {
                    if (rawItem.m_FoodItem.m_IsFish)
                    {
                        cookedItem.m_FoodItem.m_CaloriesRemaining = rawItem.m_FoodItem.m_CaloriesRemaining * GameManager.GetSkillCooking().GetCalorieScale();
                        cookedItem.m_FoodItem.m_CaloriesTotal = rawItem.m_FoodItem.m_CaloriesTotal * GameManager.GetSkillCooking().GetCalorieScale();

                        float cookedSalmonCaloriesPerKg = Implementation.defaultCookedSalmonCaloriesPerKg;
                        float cookedWhitefishCaloriesPerKg = Implementation.defaultCookedWhitefishCaloriesPerKg;
                        float cookedTroutCaloriesPerKg = Implementation.defaultCookedTroutCaloriesPerKg;
                        float cookedBassCaloriesPerKg = Implementation.defaultCookedBassCaloriesPerKg;

                        if (Settings.settings.caloriesFish == Choice.Realistic)
                        {
                            cookedSalmonCaloriesPerKg = Implementation.realisticCookedSalmonCaloriesPerKg;
                            cookedWhitefishCaloriesPerKg = Implementation.realisticCookedWhitefishCaloriesPerKg;
                            cookedTroutCaloriesPerKg = Implementation.realisticCookedTroutCaloriesPerKg;
                            cookedBassCaloriesPerKg = Implementation.realisticCookedBassCaloriesPerKg;
                        }
                        else if (Settings.settings.caloriesFish == Choice.Custom)
                        {
                            cookedSalmonCaloriesPerKg = Settings.settings.salmonCooked;
                            cookedWhitefishCaloriesPerKg = Settings.settings.whitefishCooked;
                            cookedTroutCaloriesPerKg = Settings.settings.troutCooked;
                            cookedBassCaloriesPerKg = Settings.settings.bassCooked;
                        }
                        if (cookedItem.m_GearName == "GEAR_CookedCohoSalmon") cookedItem.m_FoodWeight.m_CaloriesPerKG = cookedSalmonCaloriesPerKg * GameManager.GetSkillCooking().GetCalorieScale();
                        if (cookedItem.m_GearName == "GEAR_CookedLakeWhiteFish") cookedItem.m_FoodWeight.m_CaloriesPerKG = cookedWhitefishCaloriesPerKg * GameManager.GetSkillCooking().GetCalorieScale();
                        if (cookedItem.m_GearName == "GEAR_CookedRainbowTrout") cookedItem.m_FoodWeight.m_CaloriesPerKG = cookedTroutCaloriesPerKg * GameManager.GetSkillCooking().GetCalorieScale();
                        if (cookedItem.m_GearName == "GEAR_CookedSmallMouthBass") cookedItem.m_FoodWeight.m_CaloriesPerKG = cookedBassCaloriesPerKg * GameManager.GetSkillCooking().GetCalorieScale();

                        // Shrinkage
                        float fishShrinkage = 1 - Implementation.defaultFishShrinkage;

                        if (Settings.settings.fishShrinkage == Choice.Realistic) fishShrinkage = 1 - Implementation.realisticFishShrinkage;
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

                        float cookedBearCalories = Implementation.defaultCookedBearCalories;
                        float cookedDeerCalories = Implementation.defaultCookedDeerCalories;
                        float cookedMooseCalories = Implementation.defaultCookedMooseCalories;
                        float cookedRabbitCalories = Implementation.defaultCookedRabbitCalories;
                        float cookedWolfCalories = Implementation.defaultCookedWolfCalories;

                        if (Settings.settings.caloriesMeat == Choice.Realistic)
                        {
                            cookedBearCalories = Implementation.realisticCookedBearCalories;
                            cookedDeerCalories = Implementation.realisticCookedDeerCalories;
                            cookedMooseCalories = Implementation.realisticCookedMooseCalories;
                            cookedRabbitCalories = Implementation.realisticCookedRabbitCalories;
                            cookedWolfCalories = Implementation.realisticCookedWolfCalories;
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
                        float bearShrinkage = 1 - Implementation.defaultMeatShrinkage;
                        float deerShrinkage = 1 - Implementation.defaultMeatShrinkage;
                        float mooseShrinkage = 1 - Implementation.defaultMeatShrinkage;
                        float rabbitShrinkage = 1 - Implementation.defaultMeatShrinkage;
                        float wolfShrinkage = 1 - Implementation.defaultMeatShrinkage;

                        if (Settings.settings.meatShrinkage == Choice.Realistic)
                        {
                            bearShrinkage = 1 - Implementation.realisticMeatShrinkage;
                            deerShrinkage = 1 - Implementation.realisticMeatShrinkage;
                            mooseShrinkage = 1 - Implementation.realisticMeatShrinkage;
                            rabbitShrinkage = 1 - Implementation.realisticMeatShrinkage;
                            wolfShrinkage = 1 - Implementation.realisticMeatShrinkage;
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
                            cookedBearCalories = Implementation.defaultCookedBearCalories / bearShrinkage;
                            cookedDeerCalories = Implementation.defaultCookedDeerCalories / deerShrinkage;
                            cookedMooseCalories = Implementation.defaultCookedMooseCalories / mooseShrinkage;
                            cookedRabbitCalories = Implementation.defaultCookedRabbitCalories / rabbitShrinkage;
                            cookedWolfCalories = Implementation.defaultCookedWolfCalories / wolfShrinkage;
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
                    }
                }
            }
        }
    }
}
