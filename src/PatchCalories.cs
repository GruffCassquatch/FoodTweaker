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
    class PatchCalories
    {
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
                    if (__instance.m_FoodItem.m_IsMeat || __instance.m_FoodItem.m_IsFish)
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
                    if (__instance.m_FoodItem)
                    {
                        // Hot Food + Warming Up Buff
                        if (__instance.m_GearName.Contains("Cooked") && (__instance.m_FoodItem.m_IsMeat || __instance.m_FoodItem.m_IsFish))
                        {
                            __instance.m_FoodItem.m_HeatedWhenCooked = true;
                            __instance.m_FoodItem.m_PercentHeatLossPerMinuteIndoors = 1f;
                            __instance.m_FoodItem.m_PercentHeatLossPerMinuteOutdoors = 2f;
                            __instance.m_FoodItem.m_HeatPercent = 100;

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
                            float bearShrinkage = Implementation.defaultMeatShrinkage;
                            float deerShrinkage = Implementation.defaultMeatShrinkage;
                            float mooseShrinkage = Implementation.defaultMeatShrinkage;
                            float rabbitShrinkage = Implementation.defaultMeatShrinkage;
                            float wolfShrinkage = Implementation.defaultMeatShrinkage;

                            if (Settings.settings.meatShrinkage == Choice.Realistic)
                            {
                                bearShrinkage = Implementation.realisticMeatShrinkage;
                                deerShrinkage = Implementation.realisticMeatShrinkage;
                                mooseShrinkage = Implementation.realisticMeatShrinkage;
                                rabbitShrinkage = Implementation.realisticMeatShrinkage;
                                wolfShrinkage = Implementation.realisticMeatShrinkage;
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
                                __instance.m_FoodItem.m_CaloriesRemaining = itemWeight * cookedWolfCalories;
                                __instance.m_FoodItem.m_CaloriesTotal = cookedWolfCalories;
                            }
                        }

                        // Fish
                        else if (__instance.m_FoodItem.m_IsFish)
                        {
                            if (Settings.settings.caloriesFish == Choice.Default && Settings.settings.fishShrinkage == Choice.Default) return;

                            // Shrinkage
                            float salmonShrinkage = Implementation.defaultFishShrinkage;
                            float whitefishShrinkage = Implementation.defaultFishShrinkage;
                            float troutShrinkage = Implementation.defaultFishShrinkage;
                            float bassShrinkage = Implementation.defaultFishShrinkage;

                            if (Settings.settings.fishShrinkage == Choice.Realistic)
                            {
                                salmonShrinkage = Implementation.realisticFishShrinkage;
                                whitefishShrinkage = Implementation.realisticFishShrinkage;
                                troutShrinkage = Implementation.realisticFishShrinkage;
                                bassShrinkage = Implementation.realisticFishShrinkage;
                            }
                            else if (Settings.settings.fishShrinkage == Choice.Custom)
                            {
                                salmonShrinkage = 1- Settings.settings.salmonShrinks;
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
                        else if (__instance.m_FoodItem.m_IsDrink && Settings.settings.caloriesDrinks != Choice.Default)
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
                            if (__instance.m_GearName == "GEAR_CoffeeCup")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * coffee;
                            }
                            if (__instance.m_GearName == "GEAR_GreenTeaCup")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * herbalTea;
                            }
                            if (__instance.m_GearName == "GEAR_SodaOrange")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * orangeSoda;
                            }
                            if (__instance.m_GearName == "GEAR_SodaEnergy")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * goEnergyDrink;
                            }
                            if (__instance.m_GearName == "GEAR_ReishiTea")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * reishiTea;
                            }
                            if (__instance.m_GearName == "GEAR_RoseHipTea")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * roseHipTea;
                            }
                            if (__instance.m_GearName == "GEAR_SodaGrape")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * grapeSoda;
                            }
                            if (__instance.m_GearName == "GEAR_Soda")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * summitSoda;
                            }
                            __instance.m_FoodItem.m_CaloriesTotal = __instance.m_FoodItem.m_CaloriesRemaining;
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
                            if (__instance.m_GearName == "GEAR_AirlineFoodVeg")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * airlineVegetable;
                            }
                            if (__instance.m_GearName == "GEAR_BeefJerky") 
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * beefJerky;
                            }
                            if (__instance.m_GearName == "GEAR_CandyBar")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * chocolateBar;
                            }
                            if (__instance.m_GearName == "GEAR_CattailStalk")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * cattailStalk;
                            }
                            if (__instance.m_GearName == "GEAR_CondensedMilk")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * condensedMilk;
                            }
                            if (__instance.m_GearName == "GEAR_DogFood")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * dogFood;
                            }
                            if (__instance.m_GearName == "GEAR_EnergyBar")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * energyBar;
                            }
                            if (__instance.m_GearName == "GEAR_GranolaBar")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * granolaBar;
                            }
                            if (__instance.m_GearName == "GEAR_KetchupChips")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * ketchupChips;
                            }
                            if (__instance.m_GearName == "GEAR_MapleSyrup")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * mapleSyrup;
                            }
                            if (__instance.m_GearName == "GEAR_MRE")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * mre;
                            }
                            if (__instance.m_GearName == "GEAR_PeanutButter")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * peanutButter;
                            }
                            if (__instance.m_GearName == "GEAR_PinnacleCanPeaches")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * pinnaclePeaches;
                            }
                            if (__instance.m_GearName == "GEAR_CannedBeans")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * porkAndBeans;
                            }
                            if (__instance.m_GearName == "GEAR_Crackers")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * saltyCrackers;
                            }
                            if (__instance.m_GearName == "GEAR_CannedSardines")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * sardines;
                            }
                            if (__instance.m_GearName == "Gear_TomatoSoupCan")
                            {
                                __instance.m_FoodItem.m_CaloriesRemaining = __instance.m_WeightKG * tomatoSoup;
                            }
                            __instance.m_FoodItem.m_CaloriesTotal = __instance.m_FoodItem.m_CaloriesRemaining;
                        }
                    }
                }
            }
        }
    }
}
