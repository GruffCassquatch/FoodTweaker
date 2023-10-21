using UnityEngine.Analytics;

namespace FoodTweaker
{
    public class FoodTweaker : MelonMod
    {
        public static GearItem GetGearItemPrefab(string name) => GearItem.LoadGearItemPrefab(name).GetComponent<GearItem>();

        public static void ChangePrefabHydration(string name)
        {
            GearItem gearItem = FoodTweaker.GetGearItemPrefab(name);
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
            foodItem.m_ReduceThirst = gearItem.GetItemWeightKG() * FoodTweaker.waterHydrationLevel;
        }

        public override void OnInitializeMelon()
        {
            Debug.Log($"[{Info.Name}] Version {Info.Version} loaded!");
            Settings.OnLoad();
        }

        // Game default values
        public const float defaultCookedBearCalories = 900;
        public const float defaultCookedDeerCalories = 800;
        public const float defaultCookedMooseCalories = 900;
        public const float defaultCookedPtarmiganCalories = 450;
        public const float defaultCookedRabbitCalories = 450;
        public const float defaultCookedWolfCalories = 700;

        public const float defaultCookedSalmonCaloriesPerKg = 454.5f;
        public const float defaultCookedWhitefishCaloriesPerKg = 383.5f;
        public const float defaultCookedTroutCaloriesPerKg = 383.5f;
        public const float defaultCookedBassCaloriesPerKg = 454.5f;
        public const float defaultCookedBurbotCaloriesPerKg = 488f;
        public const float defaultCookedGoldeyeCaloriesPerKg = 450f;
        public const float defaultCookedRedIrishLordCaloriesPerKg = 450f;
        public const float defaultCookedRockfishCaloriesPerKg = 450f;

        public const float defaultMeatShrinkage = 0;
        public const float defaultFishShrinkage = 0.33f;

        public const float birchBarkTeaWeight = 0.1f;
        public const float coffeeWeight = 0.1f;
        public const float acornCoffeeWeight = 0.1f;
        public const float burdockTeaWeight = 0.1f;
        public const float goEnergyDrinkWeight = 0.25f;
        public const float herbalTeaWeight = 0.1f;
        public const float orangeSodaWeight = 0.25f;
        public const float reishiTeaWeight = 0.1f;
        public const float roseHipTeaWeight = 0.1f;
        public const float grapeSodaWeight = 0.25f;
        public const float summitSodaWeight = 0.25f;

        public const float acornWeight = 0.03f;
        public const float acornBigWeight = 0.12f;
        public const float airlineChickenWeight = 0.25f;
        public const float airlineVegetableWeight = 0.25f;
        public const float beefJerkyWeight = 0.1f;
        public const float burdockPreparedWeight = 0.15f;
        public const float cattailStalkWeight = 0.05f;
        public const float chocolateBarWeight = 0.1f;
        public const float condensedMilkWeight = 0.25f;
        public const float dogFoodWeight = 0.3f;
        public const float energyBarWeight = 0.1f;
        public const float granolaBarWeight = 0.1f;
        public const float ketchupChipsWeight = 0.1f;
        public const float mapleSyrupWeight = 0.3f;
        public const float mreWeight = 0.5f;
        public const float peanutButterWeight = 0.5f;
        public const float pinnaclePeachesWeight = 0.5f;
        public const float porkAndBeansWeight = 0.25f;
        public const float saltyCrackersWeight = 0.1f;
        public const float sardinesWeight = 0.1f;
        public const float tomatoSoupWeight = 0.25f;

        public const float waterHydrationLevel = 150;

        public const float acornBannockWeight = 0.05f;
        public const float acornPancakeWeight = 0.15f;
        public const float bannockWeight = 0.05f;
        public const float meatPieWeight = 0.20f;
        public const float brothWeight = 0.80f;
        public const float fruitPorridgeWeight = 0.30f;
        public const float cannedCornWeight = 0.30f;
        public const float cannedHamWeight = 0.40f;
        public const float carrotWeight = 0.10f;
        public const float fishcakesWeight = 0.05f;
        public const float potatoCookedWeight = 0.15f;
        public const float fishermansPieWeight = 0.30f;
        public const float peachPancakeWeight = 0.20f;
        public const float pancakeWeight = 0.15f;
        public const float peachFruitPieWeight = 0.10f;
        public const float porridgeWeight = 0.20f;
        public const float ptarmiganMeatPieWeight = 0.10f;
        public const float ptarmiganMeatStewWeight = 0.35f;
        public const float cookedPieForagersWeight = 0.20f;
        public const float rabbitMeatPieWeight = 0.10f;
        public const float rabbitMeatStewWeight = 0.35f;
        public const float meatStewWeight = 0.40f;
        public const float roseHipFruitPieWeight = 0.10f;
        public const float predatorPieWeight = 0.20f;
        public const float vegetableStewWeight = 0.35f;
        public const float troutMeatStewWeight = 0.35f;
        public const float venisonMeatPieWeight = 0.10f;
        public const float venisonMeatStewWeight = 0.35f;


        // Realistic values
        public const float realisticCookedBearCalories = 1305;
        public const float realisticCookedDeerCalories = 1172;
        public const float realisticCookedMooseCalories = 1040;
        public const float realisticCookedPtarmiganCalories = 980;
        public const float realisticCookedRabbitCalories = 932;
        public const float realisticCookedWolfCalories = 875;
            
        public const float realisticCookedSalmonCaloriesPerKg = 1120;
        public const float realisticCookedWhitefishCaloriesPerKg = 1065;
        public const float realisticCookedTroutCaloriesPerKg = 1200;
        public const float realisticCookedBassCaloriesPerKg = 1170;
        public const float realisticCookedBurbotCaloriesPerKg = 1150;
        public const float realisticCookedGoldeyeCaloriesPerKg = 2500;
        public const float realisticCookedRedIrishLordCaloriesPerKg = 1150;
        public const float realisticCookedRockfishCaloriesPerKg = 1090;

        public const float realisticMeatShrinkage = 0.25f;
        public const float realisticFishShrinkage = 0.5f;

        public const float bearCookingTime = 35;
        public const float deerCookingTime = 20;
        public const float mooseCookingTime = 25;
        public const float ptarmiganCookingTime = 28;
        public const float rabbitCookingTime = 28;
        public const float wolfCookingTime = 35;

        public const float fishCookingTime = 15;

        public const float realisticAcornCoffeeCalories = 5;
        public const float realisticBirchBarkTeaCalories = 5;
        public const float realisticBurdockTeaCalories = 5;
        public const float realisticCoffeeCalories = 5;
        public const float realisticGoEnergyDrinkCalories = 115;
        public const float realisticHerbalTeaCalories = 5; // you put 2 before but I thought it was a little too much precision :°)
        public const float realisticOrangeSodaCalories = 160;
        public const float realisticReishiTeaCalories = 5; // you put 1 before ...
        public const float realisticRoseHipTeaCalories = 5; // you put 3 before ...
        public const float realisticGrapeSodaCalories = 170;
        public const float realisticSummitSodaCalories = 120;

        public const float realisticAcornCalories = 150;
        public const float realisticAcornBigCalories = 600;
        public const float realisticAirlineChickenCalories = 620;
        public const float realisticAirlineVegetableCalories = 560;
        public const float realisticBeefJerkyCalories = 410;
        public const float realisticBurdockPreparedCalories = 108;
        public const float realisticCattailStalkCalories = 15;
        public const float realisticChocolateBarCalories = 585;
        public const float realisticCondensedMilkCalories = 815;
        public const float realisticDogFoodCalories = 425;
        public const float realisticEnergyBarCalories = 500;
        public const float realisticGranolaBarCalories = 300;
        public const float realisticKetchupChipsCalories = 540;
        public const float realisticMapleSyrupCalories = 920;
        public const float realisticMreCalories = 1200;
        public const float realisticPeanutButterCalories = 3060;
        public const float realisticPinnaclePeachesCalories = 245;
        public const float realisticPorkAndBeansCalories = 265;
        public const float realisticSaltyCrackersCalories = 515;
        public const float realisticSardinesCalories = 230;
        public const float realisticTomatoSoupCalories = 150;

        public const float realisticAcornBannockCalories = 327;
        public const float realisticAcornPancakeCalories = 808;
        public const float realisticBannockCalories = 427;
        public const float realisticMeatPieCalories = 2397;
        public const float realisticBrothCalories = 48;
        public const float realisticFruitPorridgeCalories = 560;
        public const float realisticCannedCornCalories = 273;
        public const float realisticCannedHamCalories = 480;
        public const float realisticCarrotCalories = 41;
        public const float realisticFishcakesCalories = 230;
        public const float realisticPotatoCookedCalories = 131;
        public const float realisticFishermansPieCalories = 1420;
        public const float realisticPeachPancakeCalories = 1053;
        public const float realisticPancakeCalories = 708;
        public const float realisticPeachFruitPieCalories = 367;
        public const float realisticPorridgeCalories = 96;
        public const float realisticPtarmiganMeatPieCalories = 448;
        public const float realisticPtarmiganMeatStewCalories = 738;
        public const float realisticCookedPieForagersCalories = 1205;
        public const float realisticRabbitMeatPieCalories = 440;
        public const float realisticRabbitMeatStewCalories = 714;
        public const float realisticMeatStewCalories = 1561;
        public const float realisticRoseHipFruitPieCalories = 328;
        public const float realisticPredatorPieCalories = 1745;
        public const float realisticVegetableStewCalories = 994;
        public const float realisticTroutMeatStewCalories = 848;
        public const float realisticVenisonMeatPieCalories = 480;
        public const float realisticVenisonMeatStewCalories = 834;


    }
}
