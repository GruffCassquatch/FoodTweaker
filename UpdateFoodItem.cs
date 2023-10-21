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
                    float cookedPtarmiganCalories = FoodTweaker.defaultCookedPtarmiganCalories;
                    float cookedRabbitCalories = FoodTweaker.defaultCookedRabbitCalories;
                    float cookedWolfCalories = FoodTweaker.defaultCookedWolfCalories;

                    if (Settings.settings.caloriesMeat == Choice.Realistic)
                    {
                        cookedBearCalories = FoodTweaker.realisticCookedBearCalories;
                        cookedDeerCalories = FoodTweaker.realisticCookedDeerCalories;
                        cookedMooseCalories = FoodTweaker.realisticCookedMooseCalories;
                        cookedPtarmiganCalories = FoodTweaker.realisticCookedPtarmiganCalories;
                        cookedRabbitCalories = FoodTweaker.realisticCookedRabbitCalories;
                        cookedWolfCalories = FoodTweaker.realisticCookedWolfCalories;
                    }
                    else if (Settings.settings.caloriesMeat == Choice.Custom)
                    {
                        cookedBearCalories = Settings.settings.bearCooked;
                        cookedDeerCalories = Settings.settings.deerCooked;
                        cookedMooseCalories = Settings.settings.mooseCooked;
                        cookedPtarmiganCalories = Settings.settings.ptarmiganCooked;
                        cookedRabbitCalories = Settings.settings.rabbitCooked;
                        cookedWolfCalories = Settings.settings.wolfCooked;
                    }

                    // Shrinkage
                    float bearShrinkage = 1 - FoodTweaker.defaultMeatShrinkage;
                    float deerShrinkage = 1 - FoodTweaker.defaultMeatShrinkage;
                    float mooseShrinkage = 1 - FoodTweaker.defaultMeatShrinkage;
                    float ptarmiganShrinkage = 1 - FoodTweaker.defaultMeatShrinkage;
                    float rabbitShrinkage = 1 - FoodTweaker.defaultMeatShrinkage;
                    float wolfShrinkage = 1 - FoodTweaker.defaultMeatShrinkage;

                    if (Settings.settings.meatShrinkage == Choice.Realistic)
                    {
                        bearShrinkage = 1 - FoodTweaker.realisticMeatShrinkage;
                        deerShrinkage = 1 - FoodTweaker.realisticMeatShrinkage;
                        mooseShrinkage = 1 - FoodTweaker.realisticMeatShrinkage;
                        ptarmiganShrinkage = 1 - FoodTweaker.realisticMeatShrinkage;
                        rabbitShrinkage = 1 - FoodTweaker.realisticMeatShrinkage;
                        wolfShrinkage = 1 - FoodTweaker.realisticMeatShrinkage;
                    }
                    else if (Settings.settings.meatShrinkage == Choice.Custom)
                    {
                        bearShrinkage = 1 - Settings.settings.bearShrinks;
                        deerShrinkage = 1 - Settings.settings.deerShrinks;
                        mooseShrinkage = 1 - Settings.settings.mooseShrinks;
                        ptarmiganShrinkage = 1 - Settings.settings.ptarmiganShrinks;
                        rabbitShrinkage = 1 - Settings.settings.rabbitShrinks;
                        wolfShrinkage = 1 - Settings.settings.wolfShrinks;
                    }

                    if (Settings.settings.caloriesMeat == Choice.Default && Settings.settings.meatShrinkage != Choice.Default)
                    {
                        cookedBearCalories = FoodTweaker.defaultCookedBearCalories / bearShrinkage;
                        cookedDeerCalories = FoodTweaker.defaultCookedDeerCalories / deerShrinkage;
                        cookedMooseCalories = FoodTweaker.defaultCookedMooseCalories / mooseShrinkage;
                        cookedPtarmiganCalories = FoodTweaker.defaultCookedPtarmiganCalories / ptarmiganShrinkage;
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
                    else if (__instance.name.Contains("GEAR_RawMeatPtarmigan"))
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = itemWeight * cookedPtarmiganCalories * ptarmiganShrinkage;
                        __instance.m_FoodItem.m_CaloriesTotal = cookedPtarmiganCalories * ptarmiganShrinkage;
                    }
                    else if (__instance.name.Contains("GEAR_CookedMeatPtarmigan"))
                    {
                        if (itemWeight == 1) itemWeight *= ptarmiganShrinkage;
                        __instance.m_FoodItem.m_CaloriesRemaining = itemWeight * cookedPtarmiganCalories;
                        __instance.m_FoodItem.m_CaloriesTotal = cookedPtarmiganCalories;
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
                    float burbotShrinkage = 1 - FoodTweaker.defaultFishShrinkage;
                    float goldeyeShrinkage = 1 - FoodTweaker.defaultFishShrinkage;
                    float redIrishLordShrinkage = 1 - FoodTweaker.defaultFishShrinkage;
                    float rockfishShrinkage = 1 - FoodTweaker.defaultFishShrinkage;

                    if (Settings.settings.fishShrinkage == Choice.Realistic)
                    {
                        salmonShrinkage = 1 - FoodTweaker.realisticFishShrinkage;
                        whitefishShrinkage = 1 - FoodTweaker.realisticFishShrinkage;
                        troutShrinkage = 1 - FoodTweaker.realisticFishShrinkage;
                        bassShrinkage = 1 - FoodTweaker.realisticFishShrinkage;
                        burbotShrinkage = 1 - FoodTweaker.realisticFishShrinkage;
                        goldeyeShrinkage = 1 - FoodTweaker.realisticFishShrinkage;
                        redIrishLordShrinkage = 1 - FoodTweaker.realisticFishShrinkage;
                        rockfishShrinkage = 1 - FoodTweaker.realisticFishShrinkage;
                    }
                    else if (Settings.settings.fishShrinkage == Choice.Custom)
                    {
                        salmonShrinkage = 1 - Settings.settings.salmonShrinks;
                        whitefishShrinkage = 1 - Settings.settings.whitefishShrinks;
                        troutShrinkage = 1 - Settings.settings.troutShrinks;
                        bassShrinkage = 1 - Settings.settings.bassShrinks;
                        burbotShrinkage = 1 - Settings.settings.burbotShrinks;
                        goldeyeShrinkage = 1 - Settings.settings.goldeyeShrinks;
                        redIrishLordShrinkage = 1 - Settings.settings.redIrishLordShrinks;
                        rockfishShrinkage = 1 - Settings.settings.rockfishShrinks;
                    }

                    // Calories
                    float cookedSalmonCaloriesPerKg = FoodTweaker.defaultCookedSalmonCaloriesPerKg;
                    float cookedWhitefishCaloriesPerKg = FoodTweaker.defaultCookedWhitefishCaloriesPerKg;
                    float cookedTroutCaloriesPerKg = FoodTweaker.defaultCookedTroutCaloriesPerKg;
                    float cookedBassCaloriesPerKg = FoodTweaker.defaultCookedBassCaloriesPerKg;
                    float cookedBurbotCaloriesPerKg = FoodTweaker.defaultCookedBurbotCaloriesPerKg;
                    float cookedGoldeyeCaloriesPerKg = FoodTweaker.defaultCookedGoldeyeCaloriesPerKg;
                    float cookedRedIrishLordCaloriesPerKg = FoodTweaker.defaultCookedRedIrishLordCaloriesPerKg;
                    float cookedRockfishCaloriesPerKg = FoodTweaker.defaultCookedRockfishCaloriesPerKg;

                    if (Settings.settings.caloriesFish == Choice.Realistic)
                    {
                        cookedSalmonCaloriesPerKg = FoodTweaker.realisticCookedSalmonCaloriesPerKg;
                        cookedWhitefishCaloriesPerKg = FoodTweaker.realisticCookedWhitefishCaloriesPerKg;
                        cookedTroutCaloriesPerKg = FoodTweaker.realisticCookedTroutCaloriesPerKg;
                        cookedBassCaloriesPerKg = FoodTweaker.realisticCookedBassCaloriesPerKg;
                        cookedBurbotCaloriesPerKg = FoodTweaker.realisticCookedBurbotCaloriesPerKg;
                        cookedGoldeyeCaloriesPerKg = FoodTweaker.realisticCookedGoldeyeCaloriesPerKg;
                        cookedRedIrishLordCaloriesPerKg = FoodTweaker.realisticCookedRedIrishLordCaloriesPerKg;
                        cookedRockfishCaloriesPerKg = FoodTweaker.realisticCookedRockfishCaloriesPerKg;
                    }
                    else if (Settings.settings.caloriesFish == Choice.Custom)
                    {
                        cookedSalmonCaloriesPerKg = Settings.settings.salmonCooked;
                        cookedWhitefishCaloriesPerKg = Settings.settings.whitefishCooked;
                        cookedTroutCaloriesPerKg = Settings.settings.troutCooked;
                        cookedBassCaloriesPerKg = Settings.settings.bassCooked;
                        cookedBurbotCaloriesPerKg = Settings.settings.burbotCooked;
                        cookedGoldeyeCaloriesPerKg = Settings.settings.goldeyeCooked;
                        cookedRedIrishLordCaloriesPerKg = Settings.settings.redIrishLordCooked;
                        cookedRockfishCaloriesPerKg = Settings.settings.rockfishCooked;
                    }

                    if (Settings.settings.caloriesFish == Choice.Default && Settings.settings.fishShrinkage != Choice.Default)
                    {
                        cookedSalmonCaloriesPerKg = FoodTweaker.defaultCookedSalmonCaloriesPerKg / salmonShrinkage;
                        cookedWhitefishCaloriesPerKg = FoodTweaker.defaultCookedWhitefishCaloriesPerKg / whitefishShrinkage;
                        cookedTroutCaloriesPerKg = FoodTweaker.defaultCookedTroutCaloriesPerKg / troutShrinkage;
                        cookedBassCaloriesPerKg = FoodTweaker.defaultCookedBassCaloriesPerKg / bassShrinkage;
                        cookedBurbotCaloriesPerKg = FoodTweaker.defaultCookedBurbotCaloriesPerKg / burbotShrinkage;
                        cookedGoldeyeCaloriesPerKg = FoodTweaker.defaultCookedGoldeyeCaloriesPerKg / goldeyeShrinkage;
                        cookedRedIrishLordCaloriesPerKg = FoodTweaker.defaultCookedRedIrishLordCaloriesPerKg / redIrishLordShrinkage;
                        cookedRockfishCaloriesPerKg = FoodTweaker.defaultCookedRockfishCaloriesPerKg / rockfishShrinkage;
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
                    else if (__instance.name.Contains("GEAR_RawBurbot"))
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * cookedBurbotCaloriesPerKg * burbotShrinkage;
                        __instance.m_FoodWeight.m_CaloriesPerKG = cookedBurbotCaloriesPerKg * burbotShrinkage;
                    }
                    else if (__instance.name.Contains("GEAR_CookedBurbot"))
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * cookedBurbotCaloriesPerKg;
                        __instance.m_FoodWeight.m_CaloriesPerKG = cookedBurbotCaloriesPerKg;
                    }
                    else if (__instance.name.Contains("GEAR_RawGoldeye"))
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * cookedGoldeyeCaloriesPerKg * goldeyeShrinkage;
                        __instance.m_FoodWeight.m_CaloriesPerKG = cookedGoldeyeCaloriesPerKg * goldeyeShrinkage;
                    }
                    else if (__instance.name.Contains("GEAR_CookedGoldeye"))
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * cookedGoldeyeCaloriesPerKg;
                        __instance.m_FoodWeight.m_CaloriesPerKG = cookedGoldeyeCaloriesPerKg;
                    }
                    else if (__instance.name.Contains("GEAR_RawRedIrishLord"))
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * cookedRedIrishLordCaloriesPerKg * redIrishLordShrinkage;
                        __instance.m_FoodWeight.m_CaloriesPerKG = cookedRedIrishLordCaloriesPerKg * redIrishLordShrinkage;
                    }
                    else if (__instance.name.Contains("GEAR_CookedRedIrishLord"))
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * cookedRedIrishLordCaloriesPerKg;
                        __instance.m_FoodWeight.m_CaloriesPerKG = cookedRedIrishLordCaloriesPerKg;
                    }
                    else if (__instance.name.Contains("GEAR_RawRockfish"))
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * cookedRockfishCaloriesPerKg * rockfishShrinkage;
                        __instance.m_FoodWeight.m_CaloriesPerKG = cookedRockfishCaloriesPerKg * rockfishShrinkage;
                    }
                    else if (__instance.name.Contains("GEAR_CookedRockfish"))
                    {
                        __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * cookedRockfishCaloriesPerKg;
                        __instance.m_FoodWeight.m_CaloriesPerKG = cookedRockfishCaloriesPerKg;
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
                            if (__instance.name.Contains("GEAR_AcornCoffeeCup")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticAcornCoffeeCalories / FoodTweaker.acornCoffeeWeight);
                            else if (__instance.name.Contains("GEAR_BirchbarkTea")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticBurdockTeaCalories / FoodTweaker.burdockTeaWeight);
                            else if (__instance.name.Contains("GEAR_BurdockTea")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticBirchBarkTeaCalories / FoodTweaker.birchBarkTeaWeight);
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
                            if (__instance.name.Contains("GEAR_AcornCoffeeCup")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.acornCoffee / FoodTweaker.acornCoffeeWeight);
                            else if (__instance.name.Contains("GEAR_BirchbarkTea")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.birchBarkTea / FoodTweaker.birchBarkTeaWeight);
                            else if (__instance.name.Contains("GEAR_BurdockTea")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.burdockTea / FoodTweaker.burdockTeaWeight);
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
                        if (__instance.name.Contains("GEAR_AcornCooked")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticAcornCalories / FoodTweaker.acornWeight);
                        else if (__instance.name.Contains("GEAR_AcornCookedBig")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticAcornBigCalories / FoodTweaker.acornBigWeight);
                        else if (__instance.name.Contains("GEAR_AirlineFoodChick")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticAirlineChickenCalories / FoodTweaker.airlineChickenWeight);
                        else if (__instance.name.Contains("GEAR_AirlineFoodVeg")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticAirlineVegetableCalories / FoodTweaker.airlineVegetableWeight);
                        else if (__instance.name.Contains("GEAR_BeefJerky")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticBeefJerkyCalories / FoodTweaker.beefJerkyWeight);
                        else if (__instance.name.Contains("GEAR_BurdockPrepared")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticBurdockPreparedCalories / FoodTweaker.burdockPreparedWeight);
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
                        else if (__instance.name.Contains("GEAR_TomatoSoupCan")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticTomatoSoupCalories / FoodTweaker.tomatoSoupWeight);
                        // TFTFT
                        else if (__instance.name.Contains("GEAR_CookedBannockAcorn")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticAcornBannockCalories / FoodTweaker.acornBannockWeight);
                        else if (__instance.name.Contains("GEAR_CookedPancakeAcorn")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticAcornPancakeCalories / FoodTweaker.acornPancakeWeight);
                        else if (__instance.name.Contains("GEAR_CookedBannock")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticBannockCalories / FoodTweaker.bannockWeight);
                        else if (__instance.name.Contains("GEAR_CookedPieMeat")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticMeatPieCalories / FoodTweaker.meatPieWeight);
                        else if (__instance.name.Contains("GEAR_Broth")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticBrothCalories / FoodTweaker.brothWeight);
                        else if (__instance.name.Contains("GEAR_CookedPorridgeFruit")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticFruitPorridgeCalories / FoodTweaker.fruitPorridgeWeight);
                        else if (__instance.name.Contains("GEAR_CannedCorn")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticCannedCornCalories / FoodTweaker.cannedCornWeight);
                        else if (__instance.name.Contains("GEAR_CannedHam")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticCannedHamCalories / FoodTweaker.cannedHamWeight);
                        else if (__instance.name.Contains("GEAR_Carrot")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticCarrotCalories / FoodTweaker.carrotWeight);
                        else if (__instance.name.Contains("GEAR_CookedFishcakes")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticFishcakesCalories / FoodTweaker.fishcakesWeight);
                        else if (__instance.name.Contains("GEAR_PotatoCooked")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticPotatoCookedCalories / FoodTweaker.potatoCookedWeight);
                        else if (__instance.name.Contains("GEAR_CookedPieFishermans")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticFishermansPieCalories / FoodTweaker.fishermansPieWeight);
                        else if (__instance.name.Contains("GEAR_CookedPancakePeach")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticPeachPancakeCalories / FoodTweaker.peachPancakeWeight);
                        else if (__instance.name.Contains("GEAR_CookedPancake")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticPancakeCalories / FoodTweaker.pancakeWeight);
                        else if (__instance.name.Contains("GEAR_CookedPiePeach")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticPeachFruitPieCalories / FoodTweaker.peachFruitPieWeight);
                        else if (__instance.name.Contains("GEAR_CookedPorridge")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticPorridgeCalories / FoodTweaker.porridgeWeight);
                        else if (__instance.name.Contains("GEAR_CookedPiePtarmigan")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticPtarmiganMeatPieCalories / FoodTweaker.ptarmiganMeatPieWeight);
                        else if (__instance.name.Contains("GEAR_CookedStewPtarmigan")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticPtarmiganMeatStewCalories / FoodTweaker.ptarmiganMeatStewWeight);
                        else if (__instance.name.Contains("GEAR_CookedPieForagers")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticCookedPieForagersCalories / FoodTweaker.cookedPieForagersWeight);
                        else if (__instance.name.Contains("GEAR_CookedPieRabbit")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticRabbitMeatPieCalories / FoodTweaker.rabbitMeatPieWeight);
                        else if (__instance.name.Contains("GEAR_CookedStewRabbit")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticRabbitMeatStewCalories / FoodTweaker.rabbitMeatStewWeight);
                        else if (__instance.name.Contains("GEAR_CookedStewMeat")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticMeatStewCalories / FoodTweaker.meatStewWeight);
                        else if (__instance.name.Contains("GEAR_CookedPieRoseHip")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticRoseHipFruitPieCalories / FoodTweaker.roseHipFruitPieWeight);
                        else if (__instance.name.Contains("GEAR_CookedPiePredator")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticPredatorPieCalories / FoodTweaker.predatorPieWeight);
                        else if (__instance.name.Contains("GEAR_CookedStewVegetables")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticVegetableStewCalories / FoodTweaker.vegetableStewWeight);
                        else if (__instance.name.Contains("GEAR_CookedStewTrout")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticTroutMeatStewCalories / FoodTweaker.troutMeatStewWeight);
                        else if (__instance.name.Contains("GEAR_CookedPieVenison")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticVenisonMeatPieCalories / FoodTweaker.venisonMeatPieWeight);
                        else if (__instance.name.Contains("GEAR_CookedStewVenison")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (FoodTweaker.realisticVenisonMeatStewCalories / FoodTweaker.venisonMeatStewWeight);

                    }
                    else if (Settings.settings.caloriesOtherFood == Choice.Custom)
                    {
                        if (__instance.name.Contains("GEAR_AcornCooked")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.acorn / FoodTweaker.acornWeight);
                        else if (__instance.name.Contains("GEAR_AcornCookedBig")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.acornBig / FoodTweaker.acornBigWeight);
                        else if (__instance.name.Contains("GEAR_AirlineFoodChick")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.airlineChicken / FoodTweaker.airlineChickenWeight);
                        else if (__instance.name.Contains("GEAR_AirlineFoodVeg")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.airlineVegetarian / FoodTweaker.airlineVegetableWeight);
                        else if (__instance.name.Contains("GEAR_BeefJerky")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.beefJerky / FoodTweaker.beefJerkyWeight);
                        else if (__instance.name.Contains("GEAR_BurdockPrepared")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.burdockPrepared / FoodTweaker.burdockPreparedWeight);
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
                        // TFTFT
                        else if (__instance.name.Contains("GEAR_CookedBannockAcorn")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.acornBannock / FoodTweaker.acornBannockWeight);
                        else if (__instance.name.Contains("GEAR_CookedPancakeAcorn")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.acornPancake / FoodTweaker.acornPancakeWeight);
                        else if (__instance.name.Contains("GEAR_CookedBannock")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.bannock / FoodTweaker.bannockWeight);
                        else if (__instance.name.Contains("GEAR_CookedPieMeat")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.meatPie / FoodTweaker.meatPieWeight);
                        else if (__instance.name.Contains("GEAR_Broth")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.broth / FoodTweaker.brothWeight);
                        else if (__instance.name.Contains("GEAR_CookedPorridgeFruit")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.fruitPorridge / FoodTweaker.fruitPorridgeWeight);
                        else if (__instance.name.Contains("GEAR_CannedCorn")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.cannedCorn / FoodTweaker.cannedCornWeight);
                        else if (__instance.name.Contains("GEAR_CannedHam")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.cannedHam / FoodTweaker.cannedHamWeight);
                        else if (__instance.name.Contains("GEAR_Carrot")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.carrot / FoodTweaker.carrotWeight);
                        else if (__instance.name.Contains("GEAR_CookedFishcakes")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.fishcakes / FoodTweaker.fishcakesWeight);
                        else if (__instance.name.Contains("GEAR_PotatoCooked")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.potatoCooked / FoodTweaker.potatoCookedWeight);
                        else if (__instance.name.Contains("GEAR_CookedPieFishermans")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.fishermansPie / FoodTweaker.fishermansPieWeight);
                        else if (__instance.name.Contains("GEAR_CookedPancakePeach")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.peachPancake / FoodTweaker.peachPancakeWeight);
                        else if (__instance.name.Contains("GEAR_CookedPancake")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.pancake / FoodTweaker.pancakeWeight);
                        else if (__instance.name.Contains("GEAR_CookedPiePeach")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.peachFruitPie / FoodTweaker.peachFruitPieWeight);
                        else if (__instance.name.Contains("GEAR_CookedPorridge")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.porridge / FoodTweaker.porridgeWeight);
                        else if (__instance.name.Contains("GEAR_CookedPiePtarmigan")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.ptarmiganMeatPie / FoodTweaker.ptarmiganMeatPieWeight);
                        else if (__instance.name.Contains("GEAR_CookedStewPtarmigan")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.ptarmiganMeatStew / FoodTweaker.ptarmiganMeatStewWeight);
                        else if (__instance.name.Contains("GEAR_CookedPieForagers")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.cookedPieForagers / FoodTweaker.cookedPieForagersWeight);
                        else if (__instance.name.Contains("GEAR_CookedPieRabbit")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.rabbitMeatPie / FoodTweaker.rabbitMeatPieWeight);
                        else if (__instance.name.Contains("GEAR_CookedStewRabbit")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.rabbitMeatStew / FoodTweaker.rabbitMeatStewWeight);
                        else if (__instance.name.Contains("GEAR_CookedStewMeat")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.meatStew / FoodTweaker.meatStewWeight);
                        else if (__instance.name.Contains("GEAR_CookedPieRoseHip")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.roseHipFruitPie / FoodTweaker.roseHipFruitPieWeight);
                        else if (__instance.name.Contains("GEAR_CookedPiePredator")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.predatorPie / FoodTweaker.predatorPieWeight);
                        else if (__instance.name.Contains("GEAR_CookedStewVegetables")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.vegetableStew / FoodTweaker.vegetableStewWeight);
                        else if (__instance.name.Contains("GEAR_CookedStewTrout")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.troutMeatStew / FoodTweaker.troutMeatStewWeight);
                        else if (__instance.name.Contains("GEAR_CookedPieVenison")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.venisonMeatPie / FoodTweaker.venisonMeatPieWeight);
                        else if (__instance.name.Contains("GEAR_CookedStewVenison")) __instance.m_FoodItem.m_CaloriesRemaining = __instance.WeightKG * (Settings.settings.venisonMeatStew / FoodTweaker.venisonMeatStewWeight);

                    }
                    __instance.m_FoodItem.m_CaloriesTotal = __instance.m_FoodItem.m_CaloriesRemaining;
                }
            }
        }
    }
}
