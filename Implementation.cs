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
            foodItem.m_ReduceThirst = gearItem.WeightKG * FoodTweaker.waterHydrationLevel;
        }

        public override void OnInitializeMelon()
        {
            Debug.Log($"[{Info.Name}] Version {Info.Version} loaded!");
            Settings.OnLoad();
        }

        // Game Default Values
        public const float defaultCookedBearCalories = 900;
        public const float defaultCookedDeerCalories = 800;
        public const float defaultCookedMooseCalories = 900;
        public const float defaultCookedRabbitCalories = 450;
        public const float defaultCookedWolfCalories = 700;

        public const float defaultCookedSalmonCaloriesPerKg = 454.5f;
        public const float defaultCookedWhitefishCaloriesPerKg = 383.5f;
        public const float defaultCookedTroutCaloriesPerKg = 383.5f;
        public const float defaultCookedBassCaloriesPerKg = 454.5f;

        public const float defaultMeatShrinkage = 0;
        public const float defaultFishShrinkage = 0.33f;

        public const float birchBarkTeaWeight = 0.1f;
        public const float coffeeWeight = 0.1f;
        public const float goEnergyDrinkWeight = 0.25f;
        public const float herbalTeaWeight = 0.1f;
        public const float orangeSodaWeight = 0.25f;
        public const float reishiTeaWeight = 0.1f;
        public const float roseHipTeaWeight = 0.1f;
        public const float grapeSodaWeight = 0.25f;
        public const float summitSodaWeight = 0.25f;

        public const float  airlineChickenWeight = 0.25f;
        public const float  airlineVegetableWeight = 0.25f;
        public const float  beefJerkyWeight = 0.1f;
        public const float  cattailStalkWeight = 0.05f;
        public const float  chocolateBarWeight = 0.1f;
        public const float  condensedMilkWeight = 0.25f;
        public const float  dogFoodWeight = 0.3f;
        public const float  energyBarWeight = 0.1f;
        public const float  granolaBarWeight = 0.1f;
        public const float  ketchupChipsWeight = 0.1f;
        public const float  mapleSyrupWeight = 0.3f;
        public const float  mreWeight = 0.5f;
        public const float  peanutButterWeight = 0.5f;
        public const float  pinnaclePeachesWeight = 0.5f;
        public const float  porkAndBeansWeight = 0.25f;
        public const float  saltyCrackersWeight = 0.1f;
        public const float  sardinesWeight = 0.1f;
        public const float  tomatoSoupWeight = 0.25f;

        public const float waterHydrationLevel = 150;

        // Realistic Values
        public const float realisticCookedBearCalories = 1305;
        public const float realisticCookedDeerCalories = 1172;
        public const float realisticCookedMooseCalories = 1040;
        public const float realisticCookedRabbitCalories = 932;
        public const float realisticCookedWolfCalories = 875;

        public const float realisticCookedSalmonCaloriesPerKg = 1120;
        public const float realisticCookedWhitefishCaloriesPerKg = 1065;
        public const float realisticCookedTroutCaloriesPerKg = 1200;
        public const float realisticCookedBassCaloriesPerKg = 1170;

        public const float realisticMeatShrinkage = 0.25f;
        public const float realisticFishShrinkage = 0.5f;

        public const float bearCookingTime = 35;
        public const float deerCookingTime = 20;
        public const float mooseCookingTime = 25;
        public const float rabbitCookingTime = 28;
        public const float wolfCookingTime = 35;

        public const float fishCookingTime = 15;

        public const float realisticBirchBarkTeaCalories = 5;
        public const float realisticCoffeeCalories = 5;
        public const float realisticGoEnergyDrinkCalories = 115;
        public const float realisticHerbalTeaCalories = 2;
        public const float realisticOrangeSodaCalories = 160;
        public const float realisticReishiTeaCalories = 1;
        public const float realisticRoseHipTeaCalories = 3;
        public const float realisticGrapeSodaCalories = 170;
        public const float realisticSummitSodaCalories = 120;

        public const float realisticAirlineChickenCalories = 620;
        public const float realisticAirlineVegetableCalories = 560;
        public const float realisticBeefJerkyCalories = 410;
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
    }
}
