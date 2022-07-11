using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;
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
        public class AdjustCalories
        {
            private static void Postfix(GearItem __instance)
            {
                if (Settings.settings.modFunction)
                {
                    Settings.settings.ChangePrefabs();
                    
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
                            MelonLogger.Msg(__instance.m_GearName.ToString() + " Item Weight " + itemWeight);
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
                                cookedSalmonCaloriesPerKg = Implementation.realisticCookedSalmonCaloriesPerKg / salmonShrinkage;
                                cookedWhitefishCaloriesPerKg = Implementation.realisticCookedWhitefishCaloriesPerKg / whitefishShrinkage;
                                cookedTroutCaloriesPerKg = Implementation.realisticCookedTroutCaloriesPerKg / troutShrinkage;
                                cookedBassCaloriesPerKg = Implementation.realisticCookedBassCaloriesPerKg / bassShrinkage;
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
                                float birchBarkTea = Implementation.defaultBirchBarkTeaCalories / Implementation.birchBarkTeaWeight;
                                float coffee = Implementation.defaultCoffeeCalories / Implementation.coffeeWeight;
                                float goEnergyDrink = Implementation.defaultGoEnergyDrinkCalories / Implementation.goEnergyDrinkWeight;
                                float herbalTea = Implementation.defaultHerbalTeaCalories / Implementation.herbalTeaWeight;
                                float orangeSoda = Implementation.defaultOrangeSodaCalories / Implementation.orangeSodaWeight;
                                float reishiTea = Implementation.defaultReishiTeaCalories / Implementation.reishiTeaWeight;
                                float roseHipTea = Implementation.defaultRoseHipTeaCalories / Implementation.roseHipTeaWeight;
                                float grapeSoda = Implementation.defaultGrapeSodaCalories / Implementation.grapeSodaWeight;
                                float summitSoda = Implementation.defaultSummitSodaCalories / Implementation.summitSodaWeight;

                                if (Settings.settings.caloriesDrinks == Choice.Realistic)
                                {
                                    birchBarkTea = Implementation.realisticBirchBarkTeaCalories / Implementation.birchBarkTeaWeight;
                                    coffee = Implementation.realisticCoffeeCalories / Implementation.coffeeWeight;
                                    goEnergyDrink = Implementation.realisticGoEnergyDrinkCalories / Implementation.goEnergyDrinkWeight;
                                    herbalTea = Implementation.realisticHerbalTeaCalories / Implementation.herbalTeaWeight;
                                    orangeSoda = Implementation.realisticOrangeSodaCalories / Implementation.orangeSodaWeight;
                                    reishiTea = Implementation.realisticReishiTeaCalories / Implementation.reishiTeaWeight;
                                    roseHipTea = Implementation.realisticRoseHipTeaCalories / Implementation.roseHipTeaWeight;
                                    grapeSoda = Implementation.realisticGrapeSodaCalories / Implementation.grapeSodaWeight;
                                    summitSoda = Implementation.realisticSummitSodaCalories / Implementation.summitSodaWeight;
                                }
                                else if (Settings.settings.caloriesDrinks == Choice.Custom)
                                {
                                    birchBarkTea = Settings.settings.birchBarkTea / Implementation.birchBarkTeaWeight;
                                    coffee = Settings.settings.coffee / Implementation.coffeeWeight;
                                    herbalTea = Settings.settings.herbalTea / Implementation.herbalTeaWeight;
                                    orangeSoda = Settings.settings.orangeSoda / Implementation.orangeSodaWeight;
                                    goEnergyDrink = Settings.settings.goEnergyDrink / Implementation.goEnergyDrinkWeight;
                                    reishiTea = Settings.settings.reishiTea / Implementation.reishiTeaWeight;
                                    roseHipTea = Settings.settings.roseHipTea / Implementation.roseHipTeaWeight;
                                    grapeSoda = Settings.settings.grapeSoda / Implementation.grapeSodaWeight;
                                    summitSoda = Settings.settings.summitSoda / Implementation.summitSodaWeight;
                                }

                                if (__instance.m_GearName == "GEAR_BirchbarkTea")
                                {
                                    __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * birchBarkTea;
                                }
                                else if (__instance.m_GearName == "GEAR_CoffeeCup")
                                {
                                    __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * coffee;
                                }
                                else if (__instance.m_GearName == "GEAR_GreenTeaCup")
                                {
                                    __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * herbalTea;
                                }
                                else if (__instance.m_GearName == "GEAR_SodaOrange")
                                {
                                    __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * orangeSoda;
                                }
                                else if (__instance.m_GearName == "GEAR_SodaEnergy")
                                {
                                    __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * goEnergyDrink;
                                }
                                else if (__instance.m_GearName == "GEAR_ReishiTea")
                                {
                                    __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * reishiTea;
                                }
                                else if (__instance.m_GearName == "GEAR_RoseHipTea")
                                {
                                    __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * roseHipTea;
                                }
                                else if (__instance.m_GearName == "GEAR_SodaGrape")
                                {
                                    __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * grapeSoda;
                                }
                                else if (__instance.m_GearName == "GEAR_Soda")
                                {
                                    __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * summitSoda;
                                }
                                __instance.m_FoodItem.m_CaloriesTotal = __instance.m_FoodItem.m_CaloriesRemaining;
                            }
                        }

                        // Other Foods
                        else if (Settings.settings.caloriesOtherFood != Choice.Default)
                        {
                            float airlineChicken = Implementation.defaultAirlineChickenCalories / Implementation.airlineChickenWeight;
                            float airlineVegetable = Implementation.defaultAirlineVegetableCalories / Implementation.airlineVegetableWeight;
                            float beefJerky = Implementation.defaultBeefJerkyCalories / Implementation.beefJerkyWeight;
                            float cattailStalk = Implementation.defaultCattailStalkCalories / Implementation.cattailStalkWeight;
                            float chocolateBar = Implementation.defaultChocolateBarCalories / Implementation.chocolateBarWeight;
                            float condensedMilk = Implementation.defaultCondensedMilkCalories / Implementation.condensedMilkWeight;
                            float dogFood = Implementation.defaultDogFoodCalories / Implementation.dogFoodWeight;
                            float energyBar = Implementation.defaultEnergyBarCalories / Implementation.energyBarWeight;
                            float granolaBar = Implementation.defaultGranolaBarCalories / Implementation.granolaBarWeight;
                            float ketchupChips = Implementation.defaultKetchupChipsCalories / Implementation.ketchupChipsWeight;
                            float mapleSyrup = Implementation.defaultMapleSyrupCalories / Implementation.mapleSyrupWeight;
                            float mre = Implementation.defaultMreCalories / Implementation.mreWeight;
                            float peanutButter = Implementation.defaultPeanutButterCalories / Implementation.peanutButterWeight;
                            float pinnaclePeaches = Implementation.defaultPinnaclePeachesCalories / Implementation.pinnaclePeachesWeight;
                            float porkAndBeans = Implementation.defaultPorkAndBeansCalories / Implementation.porkAndBeansWeight;
                            float saltyCrackers = Implementation.defaultSaltyCrackersCalories / Implementation.saltyCrackersWeight;
                            float sardines = Implementation.defaultSardinesCalories / Implementation.sardinesWeight;
                            float tomatoSoup = Implementation.defaultTomatoSoupCalories / Implementation.tomatoSoupWeight;

                            if (Settings.settings.caloriesOtherFood == Choice.Realistic)
                            {
                                airlineChicken = Implementation.realisticAirlineChickenCalories / Implementation.airlineChickenWeight;
                                airlineVegetable = Implementation.realisticAirlineVegetableCalories / Implementation.airlineVegetableWeight;
                                beefJerky = Implementation.realisticBeefJerkyCalories / Implementation.beefJerkyWeight;
                                cattailStalk = Implementation.realisticCattailStalkCalories / Implementation.cattailStalkWeight;
                                chocolateBar = Implementation.realisticChocolateBarCalories / Implementation.chocolateBarWeight;
                                condensedMilk = Implementation.realisticCondensedMilkCalories / Implementation.condensedMilkWeight;
                                dogFood = Implementation.realisticDogFoodCalories / Implementation.dogFoodWeight;
                                energyBar = Implementation.realisticEnergyBarCalories / Implementation.energyBarWeight;
                                granolaBar = Implementation.realisticGranolaBarCalories / Implementation.granolaBarWeight;
                                ketchupChips = Implementation.realisticKetchupChipsCalories / Implementation.ketchupChipsWeight;
                                mapleSyrup = Implementation.realisticMapleSyrupCalories / Implementation.mapleSyrupWeight;
                                mre = Implementation.realisticMreCalories / Implementation.mreWeight;
                                peanutButter = Implementation.realisticPeanutButterCalories / Implementation.peanutButterWeight;
                                pinnaclePeaches = Implementation.realisticPinnaclePeachesCalories / Implementation.pinnaclePeachesWeight;
                                porkAndBeans = Implementation.realisticPorkAndBeansCalories / Implementation.porkAndBeansWeight;
                                saltyCrackers = Implementation.realisticSaltyCrackersCalories / Implementation.saltyCrackersWeight;
                                sardines = Implementation.realisticSardinesCalories / Implementation.sardinesWeight;
                                tomatoSoup = Implementation.realisticTomatoSoupCalories / Implementation.tomatoSoupWeight;
                            }
                            else if (Settings.settings.caloriesOtherFood == Choice.Custom)
                            {
                                airlineChicken = Settings.settings.airlineChicken / Implementation.airlineChickenWeight;
                                airlineVegetable = Settings.settings.airlineVegetarian / Implementation.airlineVegetableWeight;
                                beefJerky = Settings.settings.beefJerky / Implementation.beefJerkyWeight;
                                cattailStalk = Settings.settings.cattailStalk / Implementation.cattailStalkWeight;
                                chocolateBar = Settings.settings.chocolateBar / Implementation.chocolateBarWeight;
                                condensedMilk = Settings.settings.condensedMilk / Implementation.condensedMilkWeight;
                                dogFood = Settings.settings.dogFood / Implementation.dogFoodWeight;
                                energyBar = Settings.settings.energyBar / Implementation.energyBarWeight;
                                granolaBar = Settings.settings.granolaBar / Implementation.granolaBarWeight;
                                ketchupChips = Settings.settings.ketchupChips / Implementation.ketchupChipsWeight;
                                mapleSyrup = Settings.settings.mapleSyrup / Implementation.mapleSyrupWeight;
                                mre = Settings.settings.mre / Implementation.mreWeight;
                                peanutButter = Settings.settings.peanutButter / Implementation.peanutButterWeight;
                                pinnaclePeaches = Settings.settings.pinnaclePeaches / Implementation.pinnaclePeachesWeight;
                                porkAndBeans = Settings.settings.porkAndBeans / Implementation.porkAndBeansWeight;
                                saltyCrackers = Settings.settings.saltyCrackers / Implementation.saltyCrackersWeight;
                                sardines = Settings.settings.sardines / Implementation.sardinesWeight;
                                tomatoSoup = Settings.settings.tomatoSoup / Implementation.tomatoSoupWeight;
                            }

                            if (__instance.m_GearName == "GEAR_AirlineFoodChick")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * airlineChicken;
                            }
                            else if (__instance.m_GearName == "GEAR_AirlineFoodVeg")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * airlineVegetable;
                            }
                            else if (__instance.m_GearName == "GEAR_BeefJerky")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * beefJerky;
                            }
                            else if (__instance.m_GearName == "GEAR_CandyBar")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * chocolateBar;
                            }
                            else if (__instance.m_GearName == "GEAR_CattailStalk")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * cattailStalk;
                            }
                            else if (__instance.m_GearName == "GEAR_CondensedMilk")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * condensedMilk;
                            }
                            else if (__instance.m_GearName == "GEAR_DogFood")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * dogFood;
                            }
                            else if (__instance.m_GearName == "GEAR_EnergyBar")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * energyBar;
                            }
                            else if (__instance.m_GearName == "GEAR_GranolaBar")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * granolaBar;
                            }
                            else if (__instance.m_GearName == "GEAR_KetchupChips")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * ketchupChips;
                            }
                            else if (__instance.m_GearName == "GEAR_MapleSyrup")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * mapleSyrup;
                            }
                            else if (__instance.m_GearName == "GEAR_MRE")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * mre;
                            }
                            else if (__instance.m_GearName == "GEAR_PeanutButter")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * peanutButter;
                            }
                            else if (__instance.m_GearName == "GEAR_PinnacleCanPeaches")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * pinnaclePeaches;
                            }
                            else if (__instance.m_GearName == "GEAR_CannedBeans")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * porkAndBeans;
                            }
                            else if (__instance.m_GearName == "GEAR_Crackers")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * saltyCrackers;
                            }
                            else if (__instance.m_GearName == "GEAR_CannedSardines")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * sardines;
                            }
                            else if (__instance.m_GearName == "Gear_TomatoSoupCan")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * tomatoSoup;
                            }
                            __instance.m_FoodItem.m_CaloriesTotal = __instance.m_FoodItem.m_CaloriesRemaining;
                        }
                    }
                }
            }
        }
        public static void ChangePrefabParameters(string name)
        {
            GearItem item = GetGearItemPrefab(name);
            if (item == null) return;
            if (!item.m_FoodItem) return;
            item.m_FoodItem.m_ReduceThirst = item.m_WeightKG * Implementation.waterHydrationLevel;

        }
        private static GearItem GetGearItemPrefab(string name) => Resources.Load(name).Cast<GameObject>().GetComponent<GearItem>();
    }
}
