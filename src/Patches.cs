using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using HarmonyLib;
using MelonLoader;

namespace FoodTweaker
{
    class Patches
    {
        [HarmonyPatch(typeof(CookingPotItem), "ModifiedCookTimeMinutes")]
        internal class AdjustCookTime
        {
            private static float Postfix(float __result, CookingPotItem __instance)
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
                    if (Settings.settings.fishCookingTime != Choice.Default)
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
                        else if (cookedItem.m_GearName == "GEAR_CookedLakeWhiteFish") cookedItem.m_FoodWeight.m_CaloriesPerKG = cookedWhitefishCaloriesPerKg * GameManager.GetSkillCooking().GetCalorieScale();
                        else if (cookedItem.m_GearName == "GEAR_CookedRainbowTrout") cookedItem.m_FoodWeight.m_CaloriesPerKG = cookedTroutCaloriesPerKg * GameManager.GetSkillCooking().GetCalorieScale();
                        else if (cookedItem.m_GearName == "GEAR_CookedSmallMouthBass") cookedItem.m_FoodWeight.m_CaloriesPerKG = cookedBassCaloriesPerKg * GameManager.GetSkillCooking().GetCalorieScale();

                        // Shrinkage
                        float fishShrinkage = 1 - Implementation.defaultFishShrinkage;

                        if (Settings.settings.fishShrinkage == Choice.Realistic) fishShrinkage = 1 - Implementation.realisticFishShrinkage;
                        else if (Settings.settings.fishShrinkage == Choice.Custom)
                        {
                            if (cookedItem.m_GearName == "GEAR_CookedCohoSalmon") fishShrinkage = 1 - Settings.settings.salmonShrinks;
                            else if (cookedItem.m_GearName == "GEAR_CookedLakeWhiteFish") fishShrinkage = 1 - Settings.settings.whitefishShrinks;
                            else if (cookedItem.m_GearName == "GEAR_CookedRainbowTrout") fishShrinkage = 1 - Settings.settings.troutShrinks;
                            else if (cookedItem.m_GearName == "GEAR_CookedSmallMouthBass") fishShrinkage = 1 - Settings.settings.bassShrinks;
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

        [HarmonyPatch(typeof(GearItem), "ApplyBuffs")]
        internal static class ApplyBuffs
        {
            private static void Prefix(GearItem __instance, float normalizedValue)
            {
                if (Settings.settings.modFunction && __instance.m_FoodItem)
                {
                    if (__instance.m_GearName == "GEAR_MRE" && Settings.settings.mreHeating)
                    {
                        if (Mathf.Abs(__instance.m_FoodItem.m_CaloriesRemaining - __instance.m_FoodItem.m_CaloriesTotal * (1 - normalizedValue)) < 1) // Initial self-heating
                        {
                            if (!__instance.m_FreezingBuff)
                            {
                                __instance.m_FreezingBuff = __instance.gameObject.AddComponent<FreezingBuff>();
                            }
                            __instance.m_FreezingBuff.m_InitialPercentDecrease = Settings.settings.mreInitialWarmthBonus / 3;
                            __instance.m_FreezingBuff.m_RateOfIncreaseScale = 0.5f;
                            __instance.m_FreezingBuff.m_DurationHours = Settings.settings.mreWarmingUpDuration;
                            __instance.m_FoodItem.m_HeatPercent = 100;
                            __instance.m_FoodItem.m_PercentHeatLossPerMinuteIndoors = 1f;
                            __instance.m_FoodItem.m_PercentHeatLossPerMinuteOutdoors = 2f;

                            __instance.m_FreezingBuff.Apply(normalizedValue);
                        }
                        if (__instance.m_FoodItem.IsHot())
                        {
                            __instance.m_FreezingBuff.Apply(normalizedValue);
                        }
                    }
                    else if (__instance.m_FoodItem.m_IsMeat || __instance.m_FoodItem.m_IsFish)
                    {
                        if (__instance.m_FoodItem.IsHot())
                        {
                            __instance.m_FreezingBuff.Apply(normalizedValue);
                        }
                    }
                }
            }
        }

        [HarmonyPatch(typeof(GearItem), "Awake", null)]
        private static class AdjustCalories
        {
            private static void Postfix(GearItem __instance)
            {
                if (Settings.settings.modFunction)
                {
                    if (__instance.m_FoodItem)
                    {
                        UpdateFoodItem(__instance);
                    }
                }
            }
        }

        
        [HarmonyPatch(typeof(GameManager), "Awake", null)]
        private static class AdjustFoodItemsOnLoad
        {
            private static void Postfix()
            {
                if (Settings.settings.modFunction)
                {
                    Settings.settings.ChangePrefabs();
                }
            }
        }

        private static void UpdateFoodItem(GearItem __instance)
        {
            if (__instance.m_FoodItem)
            {
                // Hot Food + Warming Up Buff
                if (__instance.m_GearName.Contains("Cooked") && (__instance.m_FoodItem.m_IsMeat || __instance.m_FoodItem.m_IsFish))
                {
                    __instance.m_FoodItem.m_HeatedWhenCooked = true;
                    __instance.m_FoodItem.m_PercentHeatLossPerMinuteIndoors = 1f;
                    __instance.m_FoodItem.m_PercentHeatLossPerMinuteOutdoors = 2f;
                    __instance.m_FoodItem.m_HeatPercent = 0;

                    if (!__instance.m_FreezingBuff)
                    {
                        __instance.m_FreezingBuff = __instance.gameObject.AddComponent<FreezingBuff>();
                    }
                    __instance.m_FreezingBuff.m_InitialPercentDecrease = Settings.settings.meatFishInitialWarmthBonus / 2;
                    __instance.m_FreezingBuff.m_RateOfIncreaseScale = 0.5f;
                    __instance.m_FreezingBuff.m_DurationHours = Settings.settings.meatFishWarmingUpDuration;
                }

                // Meat
                if (__instance.m_FoodItem.m_IsMeat)
                {
                    if (Settings.settings.caloriesMeat == Choice.Default && Settings.settings.meatShrinkage == Choice.Default) return;

                    float itemWeight = __instance.m_FoodItem.m_CaloriesRemaining / __instance.m_FoodItem.m_CaloriesTotal;

                    // Calories
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

                    if (__instance.m_GearName == "GEAR_RawMeatBear")
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = itemWeight * cookedBearCalories * bearShrinkage;
                        __instance.m_FoodItem.m_CaloriesTotal = __instance.m_FoodItem.m_CaloriesRemaining / itemWeight;
                    }

                    else if (__instance.m_GearName == "GEAR_CookedMeatBear")
                    {
                        if (itemWeight == 1) itemWeight *= bearShrinkage;
                        __instance.m_FoodItem.m_CaloriesRemaining = itemWeight * cookedBearCalories;
                        __instance.m_FoodItem.m_CaloriesTotal = cookedBearCalories;
                    }
                    else if (__instance.m_GearName == "GEAR_RawMeatDeer")
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = itemWeight * cookedDeerCalories * deerShrinkage;
                        __instance.m_FoodItem.m_CaloriesTotal = cookedDeerCalories * deerShrinkage;
                    }
                    else if (__instance.m_GearName == "GEAR_CookedMeatDeer")
                    {
                        if (itemWeight == 1) itemWeight *= deerShrinkage;
                        __instance.m_FoodItem.m_CaloriesRemaining = itemWeight * cookedDeerCalories;
                        __instance.m_FoodItem.m_CaloriesTotal = cookedDeerCalories;
                    }
                    else if (__instance.m_GearName == "GEAR_RawMeatMoose")
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = itemWeight * cookedMooseCalories * mooseShrinkage;
                        __instance.m_FoodItem.m_CaloriesTotal = cookedMooseCalories * mooseShrinkage;
                    }
                    else if (__instance.m_GearName == "GEAR_CookedMeatMoose")
                    {
                        if (itemWeight == 1) itemWeight *= mooseShrinkage;
                        __instance.m_FoodItem.m_CaloriesRemaining = itemWeight * cookedMooseCalories;
                        __instance.m_FoodItem.m_CaloriesTotal = cookedMooseCalories;
                    }
                    else if (__instance.m_GearName == "GEAR_RawMeatRabbit")
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = itemWeight * cookedRabbitCalories * rabbitShrinkage;
                        __instance.m_FoodItem.m_CaloriesTotal = cookedRabbitCalories * rabbitShrinkage;
                    }
                    else if (__instance.m_GearName == "GEAR_CookedMeatRabbit")
                    {
                        if (itemWeight == 1) itemWeight *= rabbitShrinkage;
                        __instance.m_FoodItem.m_CaloriesRemaining = itemWeight * cookedRabbitCalories;
                        __instance.m_FoodItem.m_CaloriesTotal = cookedRabbitCalories;
                    }
                    else if (__instance.m_GearName == "GEAR_RawMeatWolf")
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = itemWeight * cookedWolfCalories * wolfShrinkage;
                        __instance.m_FoodItem.m_CaloriesTotal = cookedWolfCalories * wolfShrinkage;
                    }
                    else if (__instance.m_GearName == "GEAR_CookedMeatWolf")
                    {
                        if (itemWeight == 1) itemWeight *= wolfShrinkage;
                        __instance.m_FoodItem.m_CaloriesRemaining = itemWeight * cookedWolfCalories;
                        __instance.m_FoodItem.m_CaloriesTotal = cookedWolfCalories;
                    }
                }

                // Fish
                else if (__instance.m_FoodItem.m_IsFish)
                {
                    if (Settings.settings.caloriesFish == Choice.Default && Settings.settings.fishShrinkage == Choice.Default) return;

                    // Shrinkage
                    float salmonShrinkage = 1 - Implementation.defaultFishShrinkage;
                    float whitefishShrinkage = 1 - Implementation.defaultFishShrinkage;
                    float troutShrinkage = 1 - Implementation.defaultFishShrinkage;
                    float bassShrinkage = 1 - Implementation.defaultFishShrinkage;

                    if (Settings.settings.fishShrinkage == Choice.Realistic)
                    {
                        salmonShrinkage = 1 - Implementation.realisticFishShrinkage;
                        whitefishShrinkage = 1 - Implementation.realisticFishShrinkage;
                        troutShrinkage = 1 - Implementation.realisticFishShrinkage;
                        bassShrinkage = 1 - Implementation.realisticFishShrinkage;
                    }
                    else if (Settings.settings.fishShrinkage == Choice.Custom)
                    {
                        salmonShrinkage = 1 - Settings.settings.salmonShrinks;
                        whitefishShrinkage = 1 - Settings.settings.whitefishShrinks;
                        troutShrinkage = 1 - Settings.settings.troutShrinks;
                        bassShrinkage = 1 - Settings.settings.bassShrinks;
                    }

                    // Calories
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

                    if (Settings.settings.caloriesFish == Choice.Default && Settings.settings.fishShrinkage != Choice.Default)
                    {
                        cookedSalmonCaloriesPerKg = Implementation.defaultCookedSalmonCaloriesPerKg / salmonShrinkage;
                        cookedWhitefishCaloriesPerKg = Implementation.defaultCookedWhitefishCaloriesPerKg / whitefishShrinkage;
                        cookedTroutCaloriesPerKg = Implementation.defaultCookedTroutCaloriesPerKg / troutShrinkage;
                        cookedBassCaloriesPerKg = Implementation.defaultCookedBassCaloriesPerKg / bassShrinkage;
                    }

                    if (__instance.m_GearName == "GEAR_RawCohoSalmon")
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * cookedSalmonCaloriesPerKg * salmonShrinkage;
                        __instance.m_FoodWeight.m_CaloriesPerKG = cookedSalmonCaloriesPerKg * salmonShrinkage;
                    }
                    else if (__instance.m_GearName == "GEAR_CookedCohoSalmon")
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * cookedSalmonCaloriesPerKg;
                        __instance.m_FoodWeight.m_CaloriesPerKG = cookedSalmonCaloriesPerKg;
                    }
                    else if (__instance.m_GearName.Contains("GEAR_RawLakeWhiteFish"))
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * cookedWhitefishCaloriesPerKg * whitefishShrinkage;
                        __instance.m_FoodWeight.m_CaloriesPerKG = cookedWhitefishCaloriesPerKg * whitefishShrinkage;
                    }
                    else if (__instance.m_GearName.Contains("GEAR_CookedLakeWhiteFish"))
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * cookedWhitefishCaloriesPerKg;
                        __instance.m_FoodWeight.m_CaloriesPerKG = cookedWhitefishCaloriesPerKg;
                    }
                    else if (__instance.m_GearName == "GEAR_RawRainbowTrout")
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * cookedTroutCaloriesPerKg * troutShrinkage;
                        __instance.m_FoodWeight.m_CaloriesPerKG = cookedTroutCaloriesPerKg * troutShrinkage;
                    }
                    else if (__instance.m_GearName == "GEAR_CookedRainbowTrout")
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * cookedTroutCaloriesPerKg;
                        __instance.m_FoodWeight.m_CaloriesPerKG = cookedTroutCaloriesPerKg;
                    }
                    else if (__instance.m_GearName == "GEAR_RawSmallMouthBass")
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * cookedBassCaloriesPerKg * bassShrinkage;
                        __instance.m_FoodWeight.m_CaloriesPerKG = cookedBassCaloriesPerKg * bassShrinkage;
                    }
                    else if (__instance.m_GearName == "GEAR_CookedSmallMouthBass")
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * cookedBassCaloriesPerKg;
                        __instance.m_FoodWeight.m_CaloriesPerKG = cookedBassCaloriesPerKg;
                    }
                    __instance.m_FoodItem.m_CaloriesTotal = __instance.m_FoodItem.m_CaloriesRemaining;
                }

                // Drinks
                else if (__instance.m_FoodItem.m_IsDrink)
                {
                    if (Settings.settings.caloriesDrinks != Choice.Default)
                    {
                        if (Settings.settings.caloriesDrinks == Choice.Realistic)
                        {
                            if (__instance.m_GearName == "GEAR_BirchbarkTea") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Implementation.realisticBirchBarkTeaCalories / Implementation.birchBarkTeaWeight);
                            else if (__instance.m_GearName == "GEAR_CoffeeCup") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Implementation.realisticCoffeeCalories / Implementation.coffeeWeight);
                            else if (__instance.m_GearName == "GEAR_GreenTeaCup") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Implementation.realisticHerbalTeaCalories / Implementation.herbalTeaWeight);
                            else if (__instance.m_GearName == "GEAR_SodaOrange") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Implementation.realisticOrangeSodaCalories / Implementation.orangeSodaWeight);
                            else if (__instance.m_GearName == "GEAR_SodaEnergy") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Implementation.realisticGoEnergyDrinkCalories / Implementation.goEnergyDrinkWeight);
                            else if (__instance.m_GearName == "GEAR_ReishiTea") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Implementation.realisticReishiTeaCalories / Implementation.reishiTeaWeight);
                            else if (__instance.m_GearName == "GEAR_RoseHipTea") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Implementation.realisticRoseHipTeaCalories / Implementation.roseHipTeaWeight);
                            else if (__instance.m_GearName == "GEAR_SodaGrape") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Implementation.realisticGrapeSodaCalories / Implementation.grapeSodaWeight);
                            else if (__instance.m_GearName == "GEAR_Soda") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Implementation.realisticSummitSodaCalories / Implementation.summitSodaWeight);
                        }
                        else if (Settings.settings.caloriesDrinks == Choice.Custom)
                        {
                            if (__instance.m_GearName == "GEAR_BirchbarkTea") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Settings.settings.birchBarkTea / Implementation.birchBarkTeaWeight);
                            else if (__instance.m_GearName == "GEAR_CoffeeCup") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Settings.settings.coffee / Implementation.coffeeWeight);
                            else if (__instance.m_GearName == "GEAR_GreenTeaCup") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Settings.settings.herbalTea / Implementation.herbalTeaWeight);
                            else if (__instance.m_GearName == "GEAR_SodaOrange") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Settings.settings.orangeSoda / Implementation.orangeSodaWeight);
                            else if (__instance.m_GearName == "GEAR_SodaEnergy") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Settings.settings.goEnergyDrink / Implementation.goEnergyDrinkWeight);
                            else if (__instance.m_GearName == "GEAR_ReishiTea") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Settings.settings.reishiTea / Implementation.reishiTeaWeight);
                            else if (__instance.m_GearName == "GEAR_RoseHipTea") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Settings.settings.roseHipTea / Implementation.roseHipTeaWeight);
                            else if (__instance.m_GearName == "GEAR_SodaGrape") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Settings.settings.grapeSoda / Implementation.grapeSodaWeight);
                            else if (__instance.m_GearName == "GEAR_Soda") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Settings.settings.summitSoda / Implementation.summitSodaWeight);
                        }
                        __instance.m_FoodItem.m_CaloriesTotal = __instance.m_FoodItem.m_CaloriesRemaining;
                    }
                }

                // Other Foods
                else if (Settings.settings.caloriesOtherFood != Choice.Default)
                { 
                    if (Settings.settings.caloriesOtherFood == Choice.Realistic)
                    {
                        if (__instance.m_GearName == "GEAR_AirlineFoodChick") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Implementation.realisticAirlineChickenCalories / Implementation.airlineChickenWeight);
                        else if (__instance.m_GearName == "GEAR_AirlineFoodVeg") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Implementation.realisticAirlineVegetableCalories / Implementation.airlineVegetableWeight);
                        else if (__instance.m_GearName == "GEAR_BeefJerky") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Implementation.realisticBeefJerkyCalories / Implementation.beefJerkyWeight);
                        else if (__instance.m_GearName == "GEAR_CandyBar") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Implementation.realisticChocolateBarCalories / Implementation.chocolateBarWeight);
                        else if (__instance.m_GearName == "GEAR_CattailStalk") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Implementation.realisticCattailStalkCalories / Implementation.cattailStalkWeight);
                        else if (__instance.m_GearName == "GEAR_CondensedMilk") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Implementation.realisticCondensedMilkCalories / Implementation.condensedMilkWeight);
                        else if (__instance.m_GearName == "GEAR_DogFood") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Implementation.realisticDogFoodCalories / Implementation.dogFoodWeight);
                        else if (__instance.m_GearName == "GEAR_EnergyBar") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Implementation.realisticEnergyBarCalories / Implementation.energyBarWeight);
                        else if (__instance.m_GearName == "GEAR_GranolaBar") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Implementation.realisticGranolaBarCalories / Implementation.granolaBarWeight);
                        else if (__instance.m_GearName == "GEAR_KetchupChips") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Implementation.realisticKetchupChipsCalories / Implementation.ketchupChipsWeight);
                        else if (__instance.m_GearName == "GEAR_MapleSyrup") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Implementation.realisticMapleSyrupCalories / Implementation.mapleSyrupWeight);
                        else if (__instance.m_GearName == "GEAR_MRE") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Implementation.realisticMreCalories / Implementation.mreWeight);
                        else if (__instance.m_GearName == "GEAR_PeanutButter") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Implementation.realisticPeanutButterCalories / Implementation.peanutButterWeight);
                        else if (__instance.m_GearName == "GEAR_PinnacleCanPeaches") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Implementation.realisticPinnaclePeachesCalories / Implementation.pinnaclePeachesWeight);
                        else if (__instance.m_GearName == "GEAR_CannedBeans") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Implementation.realisticPorkAndBeansCalories / Implementation.porkAndBeansWeight);
                        else if (__instance.m_GearName == "GEAR_Crackers") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Implementation.realisticSaltyCrackersCalories / Implementation.saltyCrackersWeight);
                        else if (__instance.m_GearName == "GEAR_CannedSardines") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Implementation.realisticSardinesCalories / Implementation.sardinesWeight);
                        else if (__instance.m_GearName == "Gear_TomatoSoupCan") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Implementation.realisticTomatoSoupCalories / Implementation.tomatoSoupWeight);
                    }
                    else if (Settings.settings.caloriesOtherFood == Choice.Custom)
                    {
                        if (__instance.m_GearName == "GEAR_AirlineFoodChick") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Settings.settings.airlineChicken / Implementation.airlineChickenWeight);
                        else if (__instance.m_GearName == "GEAR_AirlineFoodVeg") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Settings.settings.airlineVegetarian / Implementation.airlineVegetableWeight);
                        else if (__instance.m_GearName == "GEAR_BeefJerky") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Settings.settings.beefJerky / Implementation.beefJerkyWeight);
                        else if (__instance.m_GearName == "GEAR_CandyBar") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Settings.settings.chocolateBar / Implementation.chocolateBarWeight);
                        else if (__instance.m_GearName == "GEAR_CattailStalk") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Settings.settings.cattailStalk / Implementation.cattailStalkWeight);
                        else if (__instance.m_GearName == "GEAR_CondensedMilk") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Settings.settings.condensedMilk / Implementation.condensedMilkWeight);
                        else if (__instance.m_GearName == "GEAR_DogFood") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Settings.settings.dogFood / Implementation.dogFoodWeight);
                        else if (__instance.m_GearName == "GEAR_EnergyBar") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Settings.settings.energyBar / Implementation.energyBarWeight);
                        else if (__instance.m_GearName == "GEAR_GranolaBar") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Settings.settings.granolaBar / Implementation.granolaBarWeight);
                        else if (__instance.m_GearName == "GEAR_KetchupChips") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Settings.settings.ketchupChips / Implementation.ketchupChipsWeight);
                        else if (__instance.m_GearName == "GEAR_MapleSyrup") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Settings.settings.mapleSyrup / Implementation.mapleSyrupWeight);
                        else if (__instance.m_GearName == "GEAR_MRE") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Settings.settings.mre / Implementation.mreWeight);
                        else if (__instance.m_GearName == "GEAR_PeanutButter") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Settings.settings.peanutButter / Implementation.peanutButterWeight);
                        else if (__instance.m_GearName == "GEAR_PinnacleCanPeaches") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Settings.settings.pinnaclePeaches / Implementation.pinnaclePeachesWeight);
                        else if (__instance.m_GearName == "GEAR_CannedBeans") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Settings.settings.porkAndBeans / Implementation.porkAndBeansWeight);
                        else if (__instance.m_GearName == "GEAR_Crackers") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Settings.settings.saltyCrackers / Implementation.saltyCrackersWeight);
                        else if (__instance.m_GearName == "GEAR_CannedSardines") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Settings.settings.sardines / Implementation.sardinesWeight);
                        else if (__instance.m_GearName == "Gear_TomatoSoupCan") __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * (Settings.settings.tomatoSoup / Implementation.tomatoSoupWeight);
                    }
                    __instance.m_FoodItem.m_CaloriesTotal = __instance.m_FoodItem.m_CaloriesRemaining;
                }
            }
        }

        public static void ChangePrefabHydration(string name)
        {
            GearItem gearItem = GetGearItemPrefab(name);
            if (gearItem == null)
            {
                MelonLogger.Msg(name + " GearItem Prefab is NULL!");
                return;
            }
            FoodItem foodItem = gearItem.GetComponent<FoodItem>();
            if (foodItem == null)
            {
                MelonLogger.Msg(name + " FoodItem Prefab is NULL!");
                return;
            }
            foodItem.m_ReduceThirst = gearItem.m_WeightKG * Implementation.waterHydrationLevel;
        }

        public static GearItem GetGearItemPrefab(string name) => Resources.Load(name).Cast<GameObject>().GetComponent<GearItem>();
    }
}
