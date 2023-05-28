namespace FoodTweaker
{
    [HarmonyPatch(typeof(CookingPotItem), nameof(CookingPotItem.ModifiedCookTimeMinutes))]
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
                        return (FoodTweaker.bearCookingTime * itemWeight) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                    }
                    else if (__instance.m_GearItemBeingCooked.name == "GEAR_RawMeatDeer")
                    {
                        if (Settings.settings.meatCookingTime == Choice.Custom) return (Settings.settings.deerCookingTime * itemWeight) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        return (FoodTweaker.deerCookingTime * itemWeight) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                    }
                    else if (__instance.m_GearItemBeingCooked.name == "GEAR_RawMeatMoose")
                    {
                        if (Settings.settings.meatCookingTime == Choice.Custom) return (Settings.settings.mooseCookingTime * itemWeight) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        return (FoodTweaker.mooseCookingTime * itemWeight) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                    }
                    else if (__instance.m_GearItemBeingCooked.name == "GEAR_RawMeatRabbit")
                    {
                        if (Settings.settings.meatCookingTime == Choice.Custom) return (Settings.settings.rabbitCookingTime * itemWeight) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        return (FoodTweaker.rabbitCookingTime * itemWeight) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                    }
                    else if (__instance.m_GearItemBeingCooked.name == "GEAR_RawMeatWolf")
                    {
                        if (Settings.settings.meatCookingTime == Choice.Custom) return (Settings.settings.wolfCookingTime * itemWeight) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        return (FoodTweaker.wolfCookingTime * itemWeight) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                    }
                }
                if (Settings.settings.fishCookingTime != Choice.Default)
                {
                    if (__instance.m_GearItemBeingCooked.name == "GEAR_RawCohoSalmon")
                    {
                        if (Settings.settings.fishCookingTime == Choice.Custom) return (Settings.settings.salmonCookingTime * __instance.m_GearItemBeingCooked.WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        return (FoodTweaker.fishCookingTime * __instance.m_GearItemBeingCooked.WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                    }
                    else if (__instance.m_GearItemBeingCooked.name == "GEAR_RawLakeWhiteFish")
                    {
                        if (Settings.settings.fishCookingTime == Choice.Custom) return (Settings.settings.whitefishCookingTime * __instance.m_GearItemBeingCooked.WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        return (FoodTweaker.fishCookingTime * __instance.m_GearItemBeingCooked.WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                    }
                    else if (__instance.m_GearItemBeingCooked.name == "GEAR_RawRainbowTrout")
                    {
                        if (Settings.settings.fishCookingTime == Choice.Custom) return (Settings.settings.troutCookingTime * __instance.m_GearItemBeingCooked.WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        return (FoodTweaker.fishCookingTime * __instance.m_GearItemBeingCooked.WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                    }
                    else if (__instance.m_GearItemBeingCooked.name == "GEAR_RawSmallMouthBass")
                    {
                        if (Settings.settings.fishCookingTime == Choice.Custom) return (Settings.settings.bassCookingTime * __instance.m_GearItemBeingCooked.WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        return (FoodTweaker.fishCookingTime * __instance.m_GearItemBeingCooked.WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                    }
                }
            }
            return __result;
        }
    }


    [HarmonyPatch(typeof(CookingPotItem), nameof(CookingPotItem.SetCookedGearProperties))]
    internal class AdjustCookedMeatAndFish
    {
        private static void Postfix(GearItem rawItem, GearItem cookedItem)
        {
            if (Settings.settings.modFunction && rawItem.name.StartsWith("GEAR_Raw"))
            {
                if (rawItem.m_FoodItem.m_IsFish)
                {
                    cookedItem.m_FoodItem.m_CaloriesRemaining = rawItem.m_FoodItem.m_CaloriesRemaining * GameManager.GetSkillCooking().GetCalorieScale();
                    cookedItem.m_FoodItem.m_CaloriesTotal = rawItem.m_FoodItem.m_CaloriesTotal * GameManager.GetSkillCooking().GetCalorieScale();

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
                    if (cookedItem.name.StartsWith("GEAR_CookedCohoSalmon")) cookedItem.m_FoodWeight.m_CaloriesPerKG = cookedSalmonCaloriesPerKg * GameManager.GetSkillCooking().GetCalorieScale();
                    else if (cookedItem.name.StartsWith("GEAR_CookedLakeWhiteFish")) cookedItem.m_FoodWeight.m_CaloriesPerKG = cookedWhitefishCaloriesPerKg * GameManager.GetSkillCooking().GetCalorieScale();
                    else if (cookedItem.name.StartsWith("GEAR_CookedRainbowTrout")) cookedItem.m_FoodWeight.m_CaloriesPerKG = cookedTroutCaloriesPerKg * GameManager.GetSkillCooking().GetCalorieScale();
                    else if (cookedItem.name.StartsWith("GEAR_CookedSmallMouthBass")) cookedItem.m_FoodWeight.m_CaloriesPerKG = cookedBassCaloriesPerKg * GameManager.GetSkillCooking().GetCalorieScale();

                    // Shrinkage
                    float fishShrinkage = 1 - FoodTweaker.defaultFishShrinkage;

                    if (Settings.settings.fishShrinkage == Choice.Realistic) fishShrinkage = 1 - FoodTweaker.realisticFishShrinkage;
                    else if (Settings.settings.fishShrinkage == Choice.Custom)
                    {
                        if (cookedItem.name.StartsWith("GEAR_CookedCohoSalmon")) fishShrinkage = 1 - Settings.settings.salmonShrinks;
                        else if (cookedItem.name.StartsWith("GEAR_CookedLakeWhiteFish")) fishShrinkage = 1 - Settings.settings.whitefishShrinks;
                        else if (cookedItem.name.StartsWith("GEAR_CookedRainbowTrout")) fishShrinkage = 1 - Settings.settings.troutShrinks;
                        else if (cookedItem.name.StartsWith("GEAR_CookedSmallMouthBass")) fishShrinkage = 1 - Settings.settings.bassShrinks;
                    }
                    cookedItem.WeightKG = rawItem.WeightKG * fishShrinkage;
                }
                else if (rawItem.m_FoodItem.m_IsMeat)
                {
                    float rawItemWeight = rawItem.m_FoodItem.m_CaloriesRemaining / rawItem.m_FoodItem.m_CaloriesTotal;
                    float cookedItemWeight = rawItemWeight;

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

                    if (cookedItem.name.Contains("GEAR_CookedMeatBear"))
                    {
                        cookedItemWeight *= bearShrinkage;
                        cookedItem.m_FoodItem.m_CaloriesRemaining = cookedItemWeight * cookedBearCalories * GameManager.GetSkillCooking().GetCalorieScale();
                    }
                    else if (cookedItem.name.Contains("GEAR_CookedMeatDeer"))
                    {
                        cookedItemWeight *= deerShrinkage;
                        cookedItem.m_FoodItem.m_CaloriesRemaining = cookedItemWeight * cookedDeerCalories * GameManager.GetSkillCooking().GetCalorieScale();
                    }
                    else if (cookedItem.name.Contains("GEAR_CookedMeatMoose"))
                    {
                        cookedItemWeight *= mooseShrinkage;
                        cookedItem.m_FoodItem.m_CaloriesRemaining = cookedItemWeight * cookedMooseCalories * GameManager.GetSkillCooking().GetCalorieScale();
                    }
                    else if (cookedItem.name.Contains("GEAR_CookedMeatRabbit"))
                    {
                        cookedItemWeight *= rabbitShrinkage;
                        cookedItem.m_FoodItem.m_CaloriesRemaining = cookedItemWeight * cookedRabbitCalories * GameManager.GetSkillCooking().GetCalorieScale();
                    }
                    else if (cookedItem.name.Contains("GEAR_CookedMeatWolf"))
                    {
                        cookedItemWeight *= wolfShrinkage;
                        cookedItem.m_FoodItem.m_CaloriesRemaining = cookedItemWeight * cookedWolfCalories * GameManager.GetSkillCooking().GetCalorieScale();
                    }
                    cookedItem.m_FoodItem.m_CaloriesTotal = cookedItem.m_FoodItem.m_CaloriesRemaining / cookedItemWeight;
                }
            }
        }
    }

    [HarmonyPatch(typeof(GearItem), nameof(GearItem.ApplyBuffs))]
    internal static class ApplyBuffs
    {
        private static void Prefix(GearItem __instance, float normalizedValue)
        {
            if (Settings.settings.modFunction && __instance.m_FoodItem)
            {
                if (__instance.name.Contains("GEAR_MRE") && Settings.settings.mreHeating)
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

    [HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
    internal static class AdjustCalories
    {
        private static void Postfix(GearItem __instance)
        {
            if (Settings.settings.modFunction)
            {
                if (__instance.m_FoodItem)
                {
                   UpdateFood.UpdateFoodItem(__instance);
                }
            }
        }
    }


    [HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
    internal static class AdjustFoodItemsOnLoad
    {
        private static void Postfix()
        {
            if (Settings.settings.modFunction)
            {
                Settings.settings.ChangePrefabs();
            }
        }
    }
}
