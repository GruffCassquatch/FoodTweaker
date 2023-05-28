namespace FoodTweaker
{
    internal class UpdateFood
    {
        internal static void UpdateFoodItem(GearItem __instance)
        {
            if (__instance.m_FoodItem)
            {
                // Hot Food + Warming Up Buff
                if (__instance.name.Contains("Cooked") && (__instance.m_FoodItem.m_IsMeat || __instance.m_FoodItem.m_IsFish))
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
                    float cookedBearCalories = FoodTweaker.defaultCookedBearCalories;
                    float cookedDeerCalories = FoodTweaker.defaultCookedDeerCalories;
                    float cookedMooseCalories = FoodTweaker.defaultCookedMooseCalories;
                    float cookedRabbitCalories = FoodTweaker.defaultCookedRabbitCalories;
                    float cookedWolfCalories = FoodTweaker.defaultCookedWolfCalories;

                    if (Settings.settings.caloriesMeat == Choice.Realistic)
                    {
                        cookedBearCalories = FoodTweaker.realisticCookedBearCalories;
                        cookedDeerCalories = FoodTweaker.realisticCookedDeerCalories;
                        cookedMooseCalories = FoodTweaker.realisticCookedMooseCalories;
                        cookedRabbitCalories = FoodTweaker.realisticCookedRabbitCalories;
                        cookedWolfCalories = FoodTweaker.realisticCookedWolfCalories;
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
                    float bearShrinkage = 1 - FoodTweaker.defaultMeatShrinkage;
                    float deerShrinkage = 1 - FoodTweaker.defaultMeatShrinkage;
                    float mooseShrinkage = 1 - FoodTweaker.defaultMeatShrinkage;
                    float rabbitShrinkage = 1 - FoodTweaker.defaultMeatShrinkage;
                    float wolfShrinkage = 1 - FoodTweaker.defaultMeatShrinkage;

                    if (Settings.settings.meatShrinkage == Choice.Realistic)
                    {
                        bearShrinkage = 1 - FoodTweaker.realisticMeatShrinkage;
                        deerShrinkage = 1 - FoodTweaker.realisticMeatShrinkage;
                        mooseShrinkage = 1 - FoodTweaker.realisticMeatShrinkage;
                        rabbitShrinkage = 1 - FoodTweaker.realisticMeatShrinkage;
                        wolfShrinkage = 1 - FoodTweaker.realisticMeatShrinkage;
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
                        cookedBearCalories = FoodTweaker.defaultCookedBearCalories / bearShrinkage;
                        cookedDeerCalories = FoodTweaker.defaultCookedDeerCalories / deerShrinkage;
                        cookedMooseCalories = FoodTweaker.defaultCookedMooseCalories / mooseShrinkage;
                        cookedRabbitCalories = FoodTweaker.defaultCookedRabbitCalories / rabbitShrinkage;
                        cookedWolfCalories = FoodTweaker.defaultCookedWolfCalories / wolfShrinkage;
                    }

                    if (__instance.name.Contains("GEAR_RawMeatBear"))
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = itemWeight * cookedBearCalories * bearShrinkage;
                        __instance.m_FoodItem.m_CaloriesTotal = __instance.m_FoodItem.m_CaloriesRemaining / itemWeight;
                    }

                    else if (__instance.name.Contains("GEAR_CookedMeatBear"))
                    {
                        if (itemWeight == 1) itemWeight *= bearShrinkage;
                        __instance.m_FoodItem.m_CaloriesRemaining = itemWeight * cookedBearCalories;
                        __instance.m_FoodItem.m_CaloriesTotal = cookedBearCalories;
                    }
                    else if (__instance.name.Contains("GEAR_RawMeatDeer"))
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = itemWeight * cookedDeerCalories * deerShrinkage;
                        __instance.m_FoodItem.m_CaloriesTotal = cookedDeerCalories * deerShrinkage;
                    }
                    else if (__instance.name.Contains("GEAR_CookedMeatDeer"))
                    {
                        if (itemWeight == 1) itemWeight *= deerShrinkage;
                        __instance.m_FoodItem.m_CaloriesRemaining = itemWeight * cookedDeerCalories;
                        __instance.m_FoodItem.m_CaloriesTotal = cookedDeerCalories;
                    }
                    else if (__instance.name.Contains("GEAR_RawMeatMoose"))
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = itemWeight * cookedMooseCalories * mooseShrinkage;
                        __instance.m_FoodItem.m_CaloriesTotal = cookedMooseCalories * mooseShrinkage;
                    }
                    else if (__instance.name.Contains("GEAR_CookedMeatMoose"))
                    {
                        if (itemWeight == 1) itemWeight *= mooseShrinkage;
                        __instance.m_FoodItem.m_CaloriesRemaining = itemWeight * cookedMooseCalories;
                        __instance.m_FoodItem.m_CaloriesTotal = cookedMooseCalories;
                    }
                    else if (__instance.name.Contains("GEAR_RawMeatRabbit"))
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = itemWeight * cookedRabbitCalories * rabbitShrinkage;
                        __instance.m_FoodItem.m_CaloriesTotal = cookedRabbitCalories * rabbitShrinkage;
                    }
                    else if (__instance.name.Contains("GEAR_CookedMeatRabbit"))
                    {
                        if (itemWeight == 1) itemWeight *= rabbitShrinkage;
                        __instance.m_FoodItem.m_CaloriesRemaining = itemWeight * cookedRabbitCalories;
                        __instance.m_FoodItem.m_CaloriesTotal = cookedRabbitCalories;
                    }
                    else if (__instance.name.Contains("GEAR_RawMeatWolf"))
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = itemWeight * cookedWolfCalories * wolfShrinkage;
                        __instance.m_FoodItem.m_CaloriesTotal = cookedWolfCalories * wolfShrinkage;
                    }
                    else if (__instance.name.Contains("GEAR_CookedMeatWolf"))
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
                    float salmonShrinkage = 1 - FoodTweaker.defaultFishShrinkage;
                    float whitefishShrinkage = 1 - FoodTweaker.defaultFishShrinkage;
                    float troutShrinkage = 1 - FoodTweaker.defaultFishShrinkage;
                    float bassShrinkage = 1 - FoodTweaker.defaultFishShrinkage;

                    if (Settings.settings.fishShrinkage == Choice.Realistic)
                    {
                        salmonShrinkage = 1 - FoodTweaker.realisticFishShrinkage;
                        whitefishShrinkage = 1 - FoodTweaker.realisticFishShrinkage;
                        troutShrinkage = 1 - FoodTweaker.realisticFishShrinkage;
                        bassShrinkage = 1 - FoodTweaker.realisticFishShrinkage;
                    }
                    else if (Settings.settings.fishShrinkage == Choice.Custom)
                    {
                        salmonShrinkage = 1 - Settings.settings.salmonShrinks;
                        whitefishShrinkage = 1 - Settings.settings.whitefishShrinks;
                        troutShrinkage = 1 - Settings.settings.troutShrinks;
                        bassShrinkage = 1 - Settings.settings.bassShrinks;
                    }

                    // Calories
                    float cookedSalmonCaloriesPerKg = FoodTweaker.defaultCookedSalmonCaloriesPerKg;
                    float cookedWhitefishCaloriesPerKg = FoodTweaker.defaultCookedWhitefishCaloriesPerKg;
                    float cookedTroutCaloriesPerKg = FoodTweaker.defaultCookedTroutCaloriesPerKg;
                    float cookedBassCaloriesPerKg = FoodTweaker.defaultCookedBassCaloriesPerKg;

                    if (Settings.settings.caloriesFish == Choice.Realistic)
                    {
                        cookedSalmonCaloriesPerKg = FoodTweaker.realisticCookedSalmonCaloriesPerKg;
                        cookedWhitefishCaloriesPerKg = FoodTweaker.realisticCookedWhitefishCaloriesPerKg;
                        cookedTroutCaloriesPerKg = FoodTweaker.realisticCookedTroutCaloriesPerKg;
                        cookedBassCaloriesPerKg = FoodTweaker.realisticCookedBassCaloriesPerKg;
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
                        cookedSalmonCaloriesPerKg = FoodTweaker.defaultCookedSalmonCaloriesPerKg / salmonShrinkage;
                        cookedWhitefishCaloriesPerKg = FoodTweaker.defaultCookedWhitefishCaloriesPerKg / whitefishShrinkage;
                        cookedTroutCaloriesPerKg = FoodTweaker.defaultCookedTroutCaloriesPerKg / troutShrinkage;
                        cookedBassCaloriesPerKg = FoodTweaker.defaultCookedBassCaloriesPerKg / bassShrinkage;
                    }

                    if (__instance.name.Contains("GEAR_RawCohoSalmon"))
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * cookedSalmonCaloriesPerKg * salmonShrinkage;
                        __instance.m_FoodWeight.m_CaloriesPerKG = cookedSalmonCaloriesPerKg * salmonShrinkage;
                    }
                    else if (__instance.name.Contains("GEAR_CookedCohoSalmon"))
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * cookedSalmonCaloriesPerKg;
                        __instance.m_FoodWeight.m_CaloriesPerKG = cookedSalmonCaloriesPerKg;
                    }
                    else if (__instance.name.Contains("GEAR_RawLakeWhiteFish"))
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * cookedWhitefishCaloriesPerKg * whitefishShrinkage;
                        __instance.m_FoodWeight.m_CaloriesPerKG = cookedWhitefishCaloriesPerKg * whitefishShrinkage;
                    }
                    else if (__instance.name.Contains("GEAR_CookedLakeWhiteFish"))
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * cookedWhitefishCaloriesPerKg;
                        __instance.m_FoodWeight.m_CaloriesPerKG = cookedWhitefishCaloriesPerKg;
                    }
                    else if (__instance.name.Contains("GEAR_RawRainbowTrout"))
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * cookedTroutCaloriesPerKg * troutShrinkage;
                        __instance.m_FoodWeight.m_CaloriesPerKG = cookedTroutCaloriesPerKg * troutShrinkage;
                    }
                    else if (__instance.name.Contains("GEAR_CookedRainbowTrout"))
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * cookedTroutCaloriesPerKg;
                        __instance.m_FoodWeight.m_CaloriesPerKG = cookedTroutCaloriesPerKg;
                    }
                    else if (__instance.name.Contains("GEAR_RawSmallMouthBass"))
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * cookedBassCaloriesPerKg * bassShrinkage;
                        __instance.m_FoodWeight.m_CaloriesPerKG = cookedBassCaloriesPerKg * bassShrinkage;
                    }
                    else if (__instance.name.Contains("GEAR_CookedSmallMouthBass"))
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * cookedBassCaloriesPerKg;
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
                            if (__instance.name.Contains("GEAR_BirchbarkTea")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticBirchBarkTeaCalories / FoodTweaker.birchBarkTeaWeight);
                            else if (__instance.name.Contains("GEAR_CoffeeCup")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticCoffeeCalories / FoodTweaker.coffeeWeight);
                            else if (__instance.name.Contains("GEAR_GreenTeaCup")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticHerbalTeaCalories / FoodTweaker.herbalTeaWeight);
                            else if (__instance.name.Contains("GEAR_SodaOrange")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticOrangeSodaCalories / FoodTweaker.orangeSodaWeight);
                            else if (__instance.name.Contains("GEAR_SodaEnergy")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticGoEnergyDrinkCalories / FoodTweaker.goEnergyDrinkWeight);
                            else if (__instance.name.Contains("GEAR_ReishiTea")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticReishiTeaCalories / FoodTweaker.reishiTeaWeight);
                            else if (__instance.name.Contains("GEAR_RoseHipTea")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticRoseHipTeaCalories / FoodTweaker.roseHipTeaWeight);
                            else if (__instance.name.Contains("GEAR_SodaGrape")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticGrapeSodaCalories / FoodTweaker.grapeSodaWeight);
                            else if (__instance.name.Contains("GEAR_Soda")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticSummitSodaCalories / FoodTweaker.summitSodaWeight);
                        }
                        else if (Settings.settings.caloriesDrinks == Choice.Custom)
                        {
                            if (__instance.name.Contains("GEAR_BirchbarkTea")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.birchBarkTea / FoodTweaker.birchBarkTeaWeight);
                            else if (__instance.name.Contains("GEAR_CoffeeCup")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.coffee / FoodTweaker.coffeeWeight);
                            else if (__instance.name.Contains("GEAR_GreenTeaCup")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.herbalTea / FoodTweaker.herbalTeaWeight);
                            else if (__instance.name.Contains("GEAR_SodaOrange")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.orangeSoda / FoodTweaker.orangeSodaWeight);
                            else if (__instance.name.Contains("GEAR_SodaEnergy")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.goEnergyDrink / FoodTweaker.goEnergyDrinkWeight);
                            else if (__instance.name.Contains("GEAR_ReishiTea")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.reishiTea / FoodTweaker.reishiTeaWeight);
                            else if (__instance.name.Contains("GEAR_RoseHipTea")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.roseHipTea / FoodTweaker.roseHipTeaWeight);
                            else if (__instance.name.Contains("GEAR_SodaGrape")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.grapeSoda / FoodTweaker.grapeSodaWeight);
                            else if (__instance.name.Contains("GEAR_Soda")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.summitSoda / FoodTweaker.summitSodaWeight);
                        }
                        __instance.m_FoodItem.m_CaloriesTotal = __instance.m_FoodItem.m_CaloriesRemaining;
                    }
                }

                // Other Foods
                else if (Settings.settings.caloriesOtherFood != Choice.Default)
                {
                    if (Settings.settings.caloriesOtherFood == Choice.Realistic)
                    {
                        if (__instance.name.Contains("GEAR_AirlineFoodChick")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticAirlineChickenCalories / FoodTweaker.airlineChickenWeight);
                        else if (__instance.name.Contains("GEAR_AirlineFoodVeg")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticAirlineVegetableCalories / FoodTweaker.airlineVegetableWeight);
                        else if (__instance.name.Contains("GEAR_BeefJerky")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticBeefJerkyCalories / FoodTweaker.beefJerkyWeight);
                        else if (__instance.name.Contains("GEAR_CandyBar")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticChocolateBarCalories / FoodTweaker.chocolateBarWeight);
                        else if (__instance.name.Contains("GEAR_CattailStalk")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticCattailStalkCalories / FoodTweaker.cattailStalkWeight);
                        else if (__instance.name.Contains("GEAR_CondensedMilk")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticCondensedMilkCalories / FoodTweaker.condensedMilkWeight);
                        else if (__instance.name.Contains("GEAR_DogFood")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticDogFoodCalories / FoodTweaker.dogFoodWeight);
                        else if (__instance.name.Contains("GEAR_EnergyBar")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticEnergyBarCalories / FoodTweaker.energyBarWeight);
                        else if (__instance.name.Contains("GEAR_GranolaBar")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticGranolaBarCalories / FoodTweaker.granolaBarWeight);
                        else if (__instance.name.Contains("GEAR_KetchupChips")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticKetchupChipsCalories / FoodTweaker.ketchupChipsWeight);
                        else if (__instance.name.Contains("GEAR_MapleSyrup")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticMapleSyrupCalories / FoodTweaker.mapleSyrupWeight);
                        else if (__instance.name.Contains("GEAR_MRE")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticMreCalories / FoodTweaker.mreWeight);
                        else if (__instance.name.Contains("GEAR_PeanutButter")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticPeanutButterCalories / FoodTweaker.peanutButterWeight);
                        else if (__instance.name.Contains("GEAR_PinnacleCanPeaches")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticPinnaclePeachesCalories / FoodTweaker.pinnaclePeachesWeight);
                        else if (__instance.name.Contains("GEAR_CannedBeans")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticPorkAndBeansCalories / FoodTweaker.porkAndBeansWeight);
                        else if (__instance.name.Contains("GEAR_Crackers")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticSaltyCrackersCalories / FoodTweaker.saltyCrackersWeight);
                        else if (__instance.name.Contains("GEAR_CannedSardines")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticSardinesCalories / FoodTweaker.sardinesWeight);
                        else if (__instance.name.Contains("Gear_TomatoSoupCan")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticTomatoSoupCalories / FoodTweaker.tomatoSoupWeight);
                    }
                    else if (Settings.settings.caloriesOtherFood == Choice.Custom)
                    {
                        if (__instance.name.Contains("GEAR_AirlineFoodChick")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.airlineChicken / FoodTweaker.airlineChickenWeight);
                        else if (__instance.name.Contains("GEAR_AirlineFoodVeg")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.airlineVegetarian / FoodTweaker.airlineVegetableWeight);
                        else if (__instance.name.Contains("GEAR_BeefJerky")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.beefJerky / FoodTweaker.beefJerkyWeight);
                        else if (__instance.name.Contains("GEAR_CandyBar")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.chocolateBar / FoodTweaker.chocolateBarWeight);
                        else if (__instance.name.Contains("GEAR_CattailStalk")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.cattailStalk / FoodTweaker.cattailStalkWeight);
                        else if (__instance.name.Contains("GEAR_CondensedMilk")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.condensedMilk / FoodTweaker.condensedMilkWeight);
                        else if (__instance.name.Contains("GEAR_DogFood")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.dogFood / FoodTweaker.dogFoodWeight);
                        else if (__instance.name.Contains("GEAR_EnergyBar")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.energyBar / FoodTweaker.energyBarWeight);
                        else if (__instance.name.Contains("GEAR_GranolaBar")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.granolaBar / FoodTweaker.granolaBarWeight);
                        else if (__instance.name.Contains("GEAR_KetchupChips")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.ketchupChips / FoodTweaker.ketchupChipsWeight);
                        else if (__instance.name.Contains("GEAR_MapleSyrup")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.mapleSyrup / FoodTweaker.mapleSyrupWeight);
                        else if (__instance.name.Contains("GEAR_MRE")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.mre / FoodTweaker.mreWeight);
                        else if (__instance.name.Contains("GEAR_PeanutButter")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.peanutButter / FoodTweaker.peanutButterWeight);
                        else if (__instance.name.Contains("GEAR_PinnacleCanPeaches")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.pinnaclePeaches / FoodTweaker.pinnaclePeachesWeight);
                        else if (__instance.name.Contains("GEAR_CannedBeans")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.porkAndBeans / FoodTweaker.porkAndBeansWeight);
                        else if (__instance.name.Contains("GEAR_Crackers")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.saltyCrackers / FoodTweaker.saltyCrackersWeight);
                        else if (__instance.name.Contains("GEAR_CannedSardines")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.sardines / FoodTweaker.sardinesWeight);
                        else if (__instance.name.Contains("GEAR_TomatoSoupCan")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.tomatoSoup / FoodTweaker.tomatoSoupWeight);
                    }
                    __instance.m_FoodItem.m_CaloriesTotal = __instance.m_FoodItem.m_CaloriesRemaining;
                }
            }
        }
    }
}
