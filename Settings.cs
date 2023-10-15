using Il2Cpp;
using ModSettings;

namespace FoodTweaker
{
    public enum Choice
    {
        Default, Realistic, Custom
    }
    public enum ChoiceYN
    {
        Default, Custom
    }
    class FoodTweakerSettings : JsonModSettings
    {
        [Section("Enable Mod")]
        [Name("Enable Mod")]
        [Description("Enable/Disable Mod")]
        public bool modFunction = false;

        [Section("Meat")]
        [Name("Calories (Before Cooking Skill Bonus)")]
        [Description("GAME DEFAULT: Calorie values will remain unchanged.\nREALISTIC: Based on real-world values.\nCUSTOM: Set your own values.")]
        [Choice("Game Default", "Realistic", "Custom")]
        public Choice caloriesMeat = Choice.Default;

        [Name("Bear calories/kg (Cooked)")]
        [Description("Set the calorie value of 1kg of COOKED Bear.\nDefault Game Value: 900\nRealistic Value: 1305 (1630 at Cooking lvl 5)")]
        [Slider(250, 2000, 351, NumberFormat = "{0:0.#} /kg")]
        public float bearCooked = 900;

        [Name("Deer calories/kg (Cooked)")]
        [Description("Set the calorie value of 1kg of COOKED Deer.\nDefault Game Value: 800\nRealistic Value: 1172 (1465 at Cooking lvl 5)")]
        [Slider(250, 2000, 351, NumberFormat = "{0:0.#} /kg")]
        public float deerCooked = 800;

        [Name("Moose calories/kg (Cooked)")]
        [Description("Set the calorie value of 1kg of COOKED Moose.\nDefault Game Value: 900\nRealistic Value: 1040 (1300 at Cooking lvl 5)")]
        [Slider(250, 2000, 351, NumberFormat = "{0:0.#} /kg")]
        public float mooseCooked = 900;

        [Name("Ptarmigan calories/kg (Cooked)")]
        [Description("Set the calorie value of 1kg of COOKED Ptarmigan.\nDefault Game Value: 450\nRealistic Value: 980 (1225 at Cooking lvl 5)")]
        [Slider(250, 2000, 351, NumberFormat = "{0:0.#} /kg")]
        public float ptarmiganCooked = 450;

        [Name("Rabbit calories/kg (Cooked)")]
        [Description("Set the calorie value of 1kg of COOKED Rabbit.\nDefault Game Value: 450\nRealistic Value: 932 (1140 at Cooking lvl 5)")]
        [Slider(250, 2000, 351, NumberFormat = "{0:0.#} /kg")]
        public float rabbitCooked = 450;

        [Name("Wolf calories/kg (Cooked)")]
        [Description("Set the calorie value of 1kg of COOKED Wolf.\nDefault Game Value: 700\nRealistic Value: 875 (1165 at Cooking lvl 5)")]
        [Slider(250, 2000, 351, NumberFormat = "{0:0.#} /kg")]
        public float wolfCooked = 700;


        [Name("Shrinkage")]
        [Description("How much meat shrinks when cooking.\nGAME DEFAULT: 0%. REALISTIC: 25%.\nCUSTOM: Set your own values.")]
        [Choice("Game Default", "Realistic", "Custom")]
        public Choice meatShrinkage = Choice.Default;

        [Name("Bear Meat")]
        [Description("Weight difference between RAW and COOKED piece of meat.\nGAME DEFAULT: 0%.\nREALISTIC: 25%")]
        [Slider(0, 0.5f, 51, NumberFormat = "{0:P0}")]
        public float bearShrinks = 0.25f;

        [Name("Deer Meat")]
        [Description("Weight difference between RAW and COOKED piece of meat.\nGAME DEFAULT: 0%.\nREALISTIC: 25%")]
        [Slider(0, 0.5f, 51, NumberFormat = "{0:P0}")]
        public float deerShrinks = 0.25f;

        [Name("Moose Meat")]
        [Description("Weight difference between RAW and COOKED piece of meat.\nGAME DEFAULT: 0%.\nREALISTIC: 25%")]
        [Slider(0, 0.5f, 51, NumberFormat = "{0:P0}")]
        public float mooseShrinks = 0.25f;

        [Name("Ptarmigan Meat")]
        [Description("Weight difference between RAW and COOKED piece of meat.\nGAME DEFAULT: 0%.\nREALISTIC: 25%")]
        [Slider(0, 0.5f, 51, NumberFormat = "{0:P0}")]
        public float ptarmiganShrinks = 0.25f;

        [Name("Rabbit Meat")]
        [Description("Weight difference between RAW and COOKED piece of meat.\nGAME DEFAULT: 0%.\nREALISTIC: 25%")]
        [Slider(0, 0.5f, 51, NumberFormat = "{0:P0}")]
        public float rabbitShrinks = 0.25f;

        [Name("Wolf Meat")]
        [Description("Weight difference between RAW and COOKED piece of meat.\nGAME DEFAULT: 0%.\nREALISTIC: 25%")]
        [Slider(0, 0.5f, 51, NumberFormat = "{0:P0}")]
        public float wolfShrinks = 0.25f;

        [Name("Cooking Time (Before Cooking Skill Bonus)")]
        [Description("GAME DEFAULT: Values will remain unchanged.\nREALISTIC: Based on realistic values + some assumptions.\nCUSTOM: Set your own values.")]
        [Choice("Game Default", "Realistic", "Custom")]
        public Choice meatCookingTime = Choice.Default;

        [Name("Bear (minutes/kg)")]
        [Description("Adjust cooking time, in minutes, for 1kg Bear meat.\nGAME DEFAULT: 1 hour 22 mins.\nREALISTIC: 35 mins (24.5 with Cooking lvl 5)")]
        [Slider(1, 60, 60, NumberFormat = "{0:0.#} mins")]
        public float bearCookingTime = 35;

        [Name("Deer (minutes/kg)")]
        [Description("Adjust cooking time, in minutes, for 1kg Deer meat.\nGAME DEFAULT: 57 mins.\nREALISTIC: 20 mins (14 with Cooking lvl 5)")]
        [Slider(1, 60, 60, NumberFormat = "{0:0.#} mins")]
        public float deerCookingTime = 20;

        [Name("Moose (minutes/kg)")]
        [Description("Adjust cooking time, in minutes, for 1kg Moose meat.\nGAME DEFAULT: 1 hour 22 mins.\nREALISTIC: 25 mins (17.5 with Cooking lvl 5)")]
        [Slider(1, 60, 60, NumberFormat = "{0:0.#} mins")]
        public float mooseCookingTime = 25;

        [Name("Ptarmigan (minutes/kg)")]
        [Description("Adjust cooking time, in minutes, for 1kg Moose meat.\nGAME DEFAULT: 38 mins.\nREALISTIC: 28 mins (19.6 with Cooking lvl 5)")]
        [Slider(1, 60, 60, NumberFormat = "{0:0.#} mins")]
        public float ptarmiganCookingTime = 25;

        [Name("Rabbit (minutes/kg)")]
        [Description("Adjust cooking time, in minutes, for 1kg Rabbit meat\nGAME DEFAULT: 38 mins.\nREALISTIC: 28 mins (19.6 with Cooking lvl 5)")]
        [Slider(1, 60, 60, NumberFormat = "{0:0.#} mins")]
        public float rabbitCookingTime = 20;

        [Name("Wolf (minutes/kg)")]
        [Description("Adjust cooking time, in minutes, for 1kg Wolf meat.\nGAME DEFAULT: 1 hour 9 mins.\nREALISTIC: 35 mins (24.5 with Cooking lvl 5)")]
        [Slider(1, 60, 60, NumberFormat = "{0:0.#} mins")]
        public float wolfCookingTime = 30;


        [Section("Fish")]
        [Name("Calories (Before Cooking Skill Bonus)")]
        [Description("GAME DEFAULT: Calorie values will remain unchanged.\nREALISTIC: Based on real-world values + some assumptions.\nCUSTOM: Set your own values.")]
        [Choice("Game Default", "Realistic", "Custom")]
        public Choice caloriesFish = Choice.Default;

        [Name("Coho Salmon calories/kg (Cooked)")]
        [Description("Set the calorie value of 1kg of COOKED Coho Salmon.\nDefault Game Value: 454.5\nRealistic Value: 1120 (1400 at Cooking lvl 5)")]
        [Slider(250, 2000, 351, NumberFormat = "{0:0.#} /kg")]
        public float salmonCooked = 454.5f;

        [Name("Lake Whitefish calories/kg (Cooked)")]
        [Description("Set the calorie value of 1kg of COOKED Lake Whitefish.\nDefault Game Value: 383.5\nRealistic Value: 1065 (1330 at Cooking lvl 5)")]
        [Slider(250, 2000, 351, NumberFormat = "{0:0.#} /kg")]
        public float whitefishCooked = 383.5f;

        [Name("Rainbow Trout calories/kg (Cooked)")]
        [Description("Set the calorie value of 1kg of COOKED Rainbow Trout.\nDefault Game Value: 383.5\nRealistic Value: 1200 (1500 at Cooking lvl 5)")]
        [Slider(250, 2000, 351, NumberFormat = "{0:0.#} /kg")]
        public float troutCooked = 383.5f;

        [Name("Smallmouth Bass calories/kg (Cooked)")]
        [Description("Set the calorie value of 1kg of COOKED Smallmouth Bass.\nDefault Game Value: 454.5\nRealistic Value: 1168 (1460 at Cooking lvl 5)")]
        [Slider(250, 2000, 351, NumberFormat = "{0:0.#} /kg")]
        public float bassCooked = 454.5f;

        [Name("Burbot calories/kg (Cooked)")]
        [Description("Set the calorie value of 1kg of COOKED Burbot.\nDefault Game Value: 488\nRealistic Value: 1150 (1437 at Cooking lvl 5)")]
        [Slider(250, 2000, 351, NumberFormat = "{0:0.#} /kg")]
        public float burbotCooked = 488f;

        [Name("Goldeye calories/kg (Cooked)")]
        [Description("Set the calorie value of 1kg of COOKED Goldeye Fish.\nDefault Game Value: 450\nRealistic Value: 2500 (3125 at Cooking lvl 5)")]
        [Slider(250, 3000, 551, NumberFormat = "{0:0.#} /kg")]
        public float goldeyeCooked = 450f;

        [Name("Red Irish Lord calories/kg (Cooked)")]
        [Description("Set the calorie value of 1kg of COOKED Red Irish Lord.\nDefault Game Value: 450\nRealistic Value: 1150 (1437 at Cooking lvl 5)")]
        [Slider(250, 2000, 351, NumberFormat = "{0:0.#} /kg")]
        public float redIrishLordCooked = 450f;

        [Name("Rockfish calories/kg (Cooked)")]
        [Description("Set the calorie value of 1kg of COOKED Rockfish.\nDefault Game Value: 450\nRealistic Value: 1090 (1362 at Cooking lvl 5)")]
        [Slider(250, 2000, 351, NumberFormat = "{0:0.#} /kg")]
        public float rockfishCooked = 450f;

        [Name("Fish Shrinkage & Cleaning Loss")]
        [Description("Weight difference between WHOLE, RAW FISH and CLEANED, COOKED FISH.\nGAME DEFAULT: 33%. REALISTIC: 50%\nCUSTOM: Set your own values.")]
        [Choice("Game Default", "Realistic", "Custom")]
        public Choice fishShrinkage = Choice.Default;

        [Name("Coho Salmon")]
        [Description("Weight difference between WHOLE, RAW FISH and CLEANED, COOKED FISH.\nGAME DEFAULT: 33%. REALISTIC: 50%")]
        [Slider(0.25f, 0.75f, 51, NumberFormat = "{0:P0}")]
        public float salmonShrinks = 0.33f;

        [Name("Lake Whitefish")]
        [Description("Weight difference between WHOLE, RAW FISH and CLEANED, COOKED FISH.\nGAME DEFAULT: 33%. REALISTIC: 50%")]
        [Slider(0.25f, 0.75f, 51, NumberFormat = "{0:P0}")]
        public float whitefishShrinks = 0.33f;

        [Name("Rainbow Trout")]
        [Description("Weight difference between WHOLE, RAW FISH and CLEANED, COOKED FISH.\nGAME DEFAULT: 33%. REALISTIC: 50%")]
        [Slider(0.25f, 0.75f, 51, NumberFormat = "{0:P0}")]
        public float troutShrinks = 0.33f;

        [Name("Smallmouth Bass")]
        [Description("Weight difference between WHOLE, RAW FISH and CLEANED, COOKED FISH.\nGAME DEFAULT: 33%. REALISTIC: 50%")]
        [Slider(0.25f, 0.75f, 51, NumberFormat = "{0:P0}")]
        public float bassShrinks = 0.33f;

        [Name("Burbot")]
        [Description("Weight difference between WHOLE, RAW FISH and CLEANED, COOKED FISH.\nGAME DEFAULT: 33%. REALISTIC: 50%")]
        [Slider(0.25f, 0.75f, 51, NumberFormat = "{0:P0}")]
        public float burbotShrinks = 0.33f;

        [Name("Goldeye")]
        [Description("Weight difference between WHOLE, RAW FISH and CLEANED, COOKED FISH.\nGAME DEFAULT: 33%. REALISTIC: 50%")]
        [Slider(0.25f, 0.75f, 51, NumberFormat = "{0:P0}")]
        public float goldeyeShrinks = 0.33f;

        [Name("Red Irish Lord")]
        [Description("Weight difference between WHOLE, RAW FISH and CLEANED, COOKED FISH.\nGAME DEFAULT: 33%. REALISTIC: 50%")]
        [Slider(0.25f, 0.75f, 51, NumberFormat = "{0:P0}")]
        public float redIrishLordShrinks = 0.33f;

        [Name("Rockfish")]
        [Description("Weight difference between WHOLE, RAW FISH and CLEANED, COOKED FISH.\nGAME DEFAULT: 33%. REALISTIC: 50%")]
        [Slider(0.25f, 0.75f, 51, NumberFormat = "{0:P0}")]
        public float rockfishShrinks = 0.33f;

        [Name("Cooking Time (Before Cooking Skill Bonus)")]
        [Description("GAME DEFAULT: Values will remain unchanged.\nREALISTIC: Based on realistic values + some assumptions.\nCUSTOM: Set your own values.")]
        [Choice("Game Default", "Realistic", "Custom")]
        public Choice fishCookingTime = Choice.Default;

        [Name("Coho Salmon (minutes/kg)")]
        [Description("Adjust cooking time, in minutes, for 1kg Coho Salmon.\nGAME DEFAULT: 12 mins.\nREALISTIC: 15 mins")]
        [Slider(1, 60, 60, NumberFormat = "{0:0.#} mins")]
        public float salmonCookingTime = 15;

        [Name("Lake Whitefish (minutes/kg)")]
        [Description("Adjust cooking time, in minutes, for 1kg Lake Whitefish.\nGAME DEFAULT: 21 mins.\nREALISTIC: 15 mins")]
        [Slider(1, 60, 60, NumberFormat = "{0:0.#} mins")]
        public float whitefishCookingTime = 15;

        [Name("Rainbow Trout (minutes/kg)")]
        [Description("Adjust cooking time, in minutes, for 1kg Rainbow Trout.\nGAME DEFAULT: 19 mins.\nREALISTIC: 15 mins")]
        [Slider(1, 60, 60, NumberFormat = "{0:0.#} mins")]
        public float troutCookingTime = 15;

        [Name("Smallmouth Bass (minutes/kg)")]
        [Description("Adjust cooking time, in minutes, for 1kg Smallmouth Bass.\nGAME DEFAULT: 15 mins.\nREALISTIC: 15 mins")]
        [Slider(1, 60, 60, NumberFormat = "{0:0.#} mins")]
        public float bassCookingTime = 15;

        [Name("Burbot (minutes/kg)")]
        [Description("Adjust cooking time, in minutes, for 1kg Burbot.\nGAME DEFAULT: ? .\nREALISTIC: 15 mins")]
        [Slider(1, 60, 60, NumberFormat = "{0:0.#} mins")]
        public float burbotCookingTime = 15;

        [Name("Goldeye (minutes/kg)")]
        [Description("Adjust cooking time, in minutes, for 1kg Goldeye.\nGAME DEFAULT: ? .\nREALISTIC: 15 mins")]
        [Slider(1, 60, 60, NumberFormat = "{0:0.#} mins")]
        public float goldeyeCookingTime = 15;

        [Name("Red Irish Lord (minutes/kg)")]
        [Description("Adjust cooking time, in minutes, for 1kg Red Irish Lord.\nGAME DEFAULT: ? .\nREALISTIC: 15 mins")]
        [Slider(1, 60, 60, NumberFormat = "{0:0.#} mins")]
        public float redIrishLordCookingTime = 15;

        [Name("Rockfish (minutes/kg)")]
        [Description("Adjust cooking time, in minutes, for 1kg rockfish.\nGAME DEFAULT: ? .\nREALISTIC: 15 mins")]
        [Slider(1, 60, 60, NumberFormat = "{0:0.#} mins")]
        public float rockfishCookingTime = 15;


        [Section("Meat & Fish Warming Up Buff")]
        [Name("Buff Duration")]
        [Description("How long the Warming Up buff lasts.\nGame Defaults: Pinnacle Peaches = 0.75,\nPork & Beans = 1.0, Tomato Soup = 1.0")]
        [Slider(0.25f, 6, 24, NumberFormat = "{0:0.##} hours")]
        public float meatFishWarmingUpDuration = 2;

        [Name("Buff Initial Warmth increase")]
        [Description("Immediate % increase to Warmth meter.\nGame Defaults: Pinnacle Peaches = 8%,\nPork & Beans = 10%, Tomato Soup = 20%")]
        [Slider(0, 100, 101, NumberFormat = "{0:0.#}%")]
        public float meatFishInitialWarmthBonus = 15;


        [Section("Drinks")]
        [Name("Calories")]
        [Description("GAME DEFAULT: Calorie values will remain unchanged.\nREALISTIC: Based on real-world values.\nCUSTOM: Set your own values.")]
        [Choice("Game Default", "Realistic", "Custom")]
        public Choice caloriesDrinks = Choice.Default;

        [Name("Acorn Coffee")]
        [Description("Default Game Value: 100\nRealistic Value: 5 (estimated)")]
        [Slider(1, 100, 100, NumberFormat = "{0:0.#}")]
        public float acornCoffee = 100;

        [Name("Birch Bark Tea")]
        [Description("Default Game Value: 100\nRealistic Value: 5 (estimated)")]
        [Slider(1, 100, 100, NumberFormat = "{0:0.#}")]
        public float birchBarkTea = 100;

        [Name("Burdock Tea")]
        [Description("Default Game Value: 100\nRealistic Value: 5 (estimated)")]
        [Slider(1, 100, 100, NumberFormat = "{0:0.#}")]
        public float burdockTea = 100;

        [Name("Coffee")]
        [Description("Default Game Value: 100\nRealistic Value: 5")]
        [Slider(1, 100, 100, NumberFormat = "{0:0.#}")]
        public float coffee = 100;

        [Name("Go! Energy Drink")]
        [Description("Default Game Value: 100\nRealistic Value: 115")]
        [Slider(5, 500, 100, NumberFormat = "{0:0.#}")]
        public float goEnergyDrink = 100;

        [Name("Herbal Tea")]
        [Description("Default Game Value: 100\nRealistic Value: 2")]
        [Slider(1, 100, 100, NumberFormat = "{0:0.#}")]
        public float herbalTea = 100;

        [Name("Orange Soda")]
        [Description("Default Game Value: 250\nRealistic Value: 160")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float orangeSoda = 250;

        [Name("Reishi Tea")]
        [Description("Default Game Value: 100\nRealistic Value: 1")]
        [Slider(1, 100, 100, NumberFormat = "{0:0.#}")]
        public float reishiTea = 100;

        [Name("Rose Hip Tea")]
        [Description("Default Game Value: 100\nRealistic Value: 3")]
        [Slider(1, 100, 100, NumberFormat = "{0:0.#}")]
        public float roseHipTea = 100;

        [Name("Stacey's Grape Soda")]
        [Description("Default Game Value: 250\nRealistic Value: 170")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float grapeSoda = 250;

        [Name("Summit Soda")]
        [Description("Default Game Value: 250\nRealistic Value: 120")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float summitSoda = 250;


        [Section("Other Food")]
        [Name("Calories (Before Cooking Skill Bonus)")]
        [Description("GAME DEFAULT: Calorie values will remain unchanged.\nREALISTIC: Based on real-world values.\nCUSTOM: Set your own values.")]
        [Choice("Game Default", "Realistic", "Custom")]
        public Choice caloriesOtherFood = Choice.Default;

        [Name("         Acorn")]
        [Description("Default Game Value: 100\nRealistic Value: 150")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float acorn = 100;

        [Name("         Acorn : Large portion")]
        [Description("Default Game Value: 400\nRealistic Value: 600")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float acornBig = 400;

        [Name("         Airline Food: Chicken")]
        [Description("Default Game Value: 620\nRealistic Value: 620")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float airlineChicken = 620;

        [Name("         Airline Food: Vegetarian")]
        [Description("Default Game Value: 560\nRealistic Value: 560")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float airlineVegetarian = 560;

        [Name("         Beef Jerky")]
        [Description("Default Game Value: 350\nRealistic Value: 410")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float beefJerky = 350;

        [Name("         Burdock prepared")]
        [Description("Default Game Value: 275\nRealistic Value: 108")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float burdockPrepared = 275;

        [Name("         Cattail Stalk")]
        [Description("Default Game Value: 150\nRealistic Value: 15 (estimated)")]
        [Slider(5, 500, 100, NumberFormat = "{0:0.#}")]
        public float cattailStalk = 150;

        [Name("         Chocolate Bar")]
        [Description("Default Game Value: 250\nRealistic Value: 585")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float chocolateBar = 250;

        [Name("         Condensed Milk")]
        [Description("Default Game Value: 750\nRealistic Value: 815")]
        [Slider(250, 1000, 751, NumberFormat = "{0:0.#}")]
        public float condensedMilk = 750;

        [Name("         Dog Food")]
        [Description("Default Game Value: 500\nRealistic Value: 425")]
        [Slider(250, 1000, 751, NumberFormat = "{0:0.#}")]
        public float dogFood = 500;

        [Name("         Energy Bar")]
        [Description("Default Game Value: 500\nRealistic Value: 500")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float energyBar = 500;

        [Name("         Granola Bar")]
        [Description("Default Game Value: 300\nRealistic Value: 300")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float granolaBar = 300;

        [Name("         Ketchup Chips")]
        [Description("Default Game Value: 300\nRealistic Value: 540")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float ketchupChips = 300;

        [Name("         Maple Syrup")]
        [Description("Default Game Value: 850\nRealistic Value: 920")]
        [Slider(500, 1500, 201, NumberFormat = "{0:0.#}")]
        public float mapleSyrup = 850;

        [Name("         Military-Grade MRE")]
        [Description("Default Game Value: 1750\nRealistic Value: 1200")]
        [Slider(1000, 2500, 301, NumberFormat = "{0:0.#}")]
        public float mre = 1750;

        [Name("         Peanut Butter")]
        [Description("Default Game Value: 900\nRealistic Value: 3060")]
        [Slider(500, 3500, 601, NumberFormat = "{0:0.#}")]
        public float peanutButter = 900;

        [Name("         Pinnacle Peaches")]
        [Description("Default Game Value: 450\nRealistic Value: 245")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float pinnaclePeaches = 450;

        [Name("         Pork and Beans")]
        [Description("Default Game Value: 600\nRealistic Value: 265")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float porkAndBeans = 600;

        [Name("         Salty Crackers")]
        [Description("Default Game Value: 600\nRealistic Value: 515")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float saltyCrackers = 600;

        [Name("         Tin of Sardines")]
        [Description("Default Game Value: 300\nRealistic Value: 230")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float sardines = 300;

        [Name("         Tomato Soup")]
        [Description("Default Game Value: 300\nRealistic Value: 150")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float tomatoSoup = 300;

        // TFTFT FoodItems

        [Name("         Acorn Bannock")]
        [Description("Default Game Value: 250\nRealistic Value: 327")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float acornBannock = 250;

        [Name("         Acorn Pancakes")]
        [Description("Default Game Value: 750\nRealistic Value: 808")]
        [Slider(250, 2000, 351, NumberFormat = "{0:0.#}")]
        public float acornPancake = 750;

        [Name("         Bannock")]
        [Description("Default Game Value: 200\nRealistic Value: 427")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float bannock = 200;

        [Name("         Breyerhouse Pie")]
        [Description("Default Game Value: 2125\nRealistic Value: 2397")]
        [Slider(500, 3500, 601, NumberFormat = "{0:0.#}")]
        public float meatPie = 2125;

        [Name("         Broth")]
        [Description("Default Game Value: 170\nRealistic Value: 48")]
        [Slider(5, 500, 100, NumberFormat = "{0:0.#}")]
        public float broth = 170;

        [Name("         Camber Flight Porridge")]
        [Description("Default Game Value: 1250\nRealistic Value: 559")]
        [Slider(250, 2000, 351, NumberFormat = "{0:0.#}")]
        public float fruitPorridge = 1250;

        [Name("         Canned Corn")]
        [Description("Default Game Value: 295\nRealistic Value: 273")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float cannedCorn = 295;

        [Name("         Canned Ham")]
        [Description("Default Game Value: 550\nRealistic Value: 480")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float cannedHam = 550;

        [Name("         Carrot")]
        [Description("Default Game Value: 175\nRealistic Value: 41")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float carrot = 175;

        [Name("         Coastal Fishcakes")]
        [Description("Default Game Value: 312\nRealistic Value: 229")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float fishcakes = 312;

        [Name("         Cooked Potato")]
        [Description("Default Game Value: 250\nRealistic Value: 131")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float potatoCooked = 250;

        [Name("         Dockworker's Pie")]
        [Description("Default Game Value: 1500\nRealistic Value: 1421")]
        [Slider(500, 3500, 601, NumberFormat = "{0:0.#}")]
        public float fishermansPie = 1500;

        [Name("         Lily's Pancakes")]
        [Description("Default Game Value: 1000\nRealistic Value: 1053")]
        [Slider(250, 2000, 351, NumberFormat = "{0:0.#}")]
        public float peachPancake = 1000;

        [Name("         Pancakes")]
        [Description("Default Game Value: 500\nRealistic Value: 708")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float pancake = 500;

        [Name("         Peach Pie")]
        [Description("Default Game Value: 250\nRealistic Value: 367")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float peachFruitPie = 250;

        [Name("         Porridge")]
        [Description("Default Game Value: 350\nRealistic Value: 96")]
        [Slider(5, 1000, 200, NumberFormat = "{0:0.#}")]
        public float porridge = 350;

        [Name("         Ptarmigan Pie")]
        [Description("Default Game Value: 250\nRealistic Value: 448")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float ptarmiganMeatPie = 250;

        [Name("         Ptarmigan Stew")]
        [Description("Default Game Value: 900\nRealistic Value: 1205")]
        [Slider(250, 2000, 351, NumberFormat = "{0:0.#}")]
        public float ptarmiganMeatStew = 900;

        [Name("         Prepper's Pie")]
        [Description("Default Game Value: 350\nRealistic Value: 96")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float cookedPieForagers = 350;

        [Name("         Rabbit Pie")]
        [Description("Default Game Value: 250\nRealistic Value: 440")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float rabbitMeatPie = 250;

        [Name("         Rabbit Stew")]
        [Description("Default Game Value: 750\nRealistic Value: 714")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float rabbitMeatStew = 750;

        [Name("         Ranger Stew")]
        [Description("Default Game Value: 1600\nRealistic Value: 1561")]
        [Slider(500, 3500, 601, NumberFormat = "{0:0.#}")]
        public float meatStew = 1600;

        [Name("         Rose Hip Pie")]
        [Description("Default Game Value: 225\nRealistic Value: 328")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float roseHipFruitPie = 225;

        [Name("         Stalker's Pie")]
        [Description("Default Game Value: 1600\nRealistic Value: 1745")]
        [Slider(500, 3500, 601, NumberFormat = "{0:0.#}")]
        public float predatorPie = 1600;

        [Name("         Thomson Family Stew")]
        [Description("Default Game Value: 900\nRealistic Value: 994")]
        [Slider(250, 2000, 351, NumberFormat = "{0:0.#}")]
        public float vegetableStew = 900;

        [Name("         Trout Stew")]
        [Description("Default Game Value: 750\nRealistic Value: 848")]
        [Slider(250, 2000, 351, NumberFormat = "{0:0.#}")]
        public float troutMeatStew = 750;

        [Name("         Venison Pie")]
        [Description("Default Game Value: 325\nRealistic Value: 480")]
        [Slider(100, 1000, 181, NumberFormat = "{0:0.#}")]
        public float venisonMeatPie = 325;

        [Name("         Venison Stew")]
        [Description("Default Game Value: 900\nRealistic Value: 834")]
        [Slider(250, 2000, 351, NumberFormat = "{0:0.#}")]
        public float venisonMeatStew = 900;



        [Section("MRE Self-Heating")]
        [Name("Does MRE self-heat when opened")]
        [Description("GAME DEFAULT: No.\nREALITY: Canadian MREs (IMPs) do NOT have self-heating.\nUSA MREs DO have self-heating")]
        public bool mreHeating = false;

        [Name("     Buff Duration")]
        [Description("How long the Warming Up buff lasts.\nGame Defaults: Pinnacle Peaches = 0.75,\nPork & Beans = 1.0, Tomato Soup = 1.0")]
        [Slider(0.25f, 6, 24, NumberFormat = "{0:0.##} hours")]
        public float mreWarmingUpDuration = 2;

        [Name("     Buff Initial Warmth increase")]
        [Description("Immediate % increase to Warmth meter.\nGame Defaults: Pinnacle Peaches = 8%,\nPork & Beans = 10%, Tomato Soup = 20%")]
        [Slider(0, 100, 101, NumberFormat = "{0:0.#}%")]
        public float mreInitialWarmthBonus = 15;


        [Section("Fix Tea & Coffee Hydration Amount")]
        [Name("Fix mismatched hydration levels")]
        [Description("NO: Nothing will be changed.\nYES: Fix tea & coffee being 2x more hydrating than water.\nChange will apply when you next change scene.")]
        public bool updateHydration = false;

        protected override void OnChange(FieldInfo field, object? oldValue, object? newValue)
        {
            if (field.Name == nameof(modFunction) ||
                field.Name == nameof(caloriesMeat) ||
                field.Name == nameof(caloriesFish) ||
                field.Name == nameof(caloriesOtherFood) ||
                field.Name == nameof(caloriesDrinks) ||
                field.Name == nameof(meatShrinkage) ||
                field.Name == nameof(fishShrinkage) ||
                field.Name == nameof(meatCookingTime) ||
                field.Name == nameof(fishCookingTime) ||
                field.Name == nameof(mreHeating))
            {
                RefreshFields();
            }
        }

        internal void RefreshFields()
        {
            SetFieldVisible(nameof(caloriesMeat), Settings.settings.modFunction == true);
            SetFieldVisible(nameof(bearCooked), Settings.settings.modFunction == true && Settings.settings.caloriesMeat == Choice.Custom);
            SetFieldVisible(nameof(deerCooked), Settings.settings.modFunction == true && Settings.settings.caloriesMeat == Choice.Custom);
            SetFieldVisible(nameof(mooseCooked), Settings.settings.modFunction == true && Settings.settings.caloriesMeat == Choice.Custom);
            SetFieldVisible(nameof(ptarmiganCooked), Settings.settings.modFunction == true && Settings.settings.caloriesMeat == Choice.Custom);
            SetFieldVisible(nameof(rabbitCooked), Settings.settings.modFunction == true && Settings.settings.caloriesMeat == Choice.Custom);
            SetFieldVisible(nameof(wolfCooked), Settings.settings.modFunction == true && Settings.settings.caloriesMeat == Choice.Custom);
            SetFieldVisible(nameof(caloriesFish), Settings.settings.modFunction == true);
            SetFieldVisible(nameof(salmonCooked), Settings.settings.modFunction == true && Settings.settings.caloriesFish == Choice.Custom);
            SetFieldVisible(nameof(whitefishCooked), Settings.settings.modFunction == true && Settings.settings.caloriesFish == Choice.Custom);
            SetFieldVisible(nameof(troutCooked), Settings.settings.modFunction == true && Settings.settings.caloriesFish == Choice.Custom);
            SetFieldVisible(nameof(bassCooked), Settings.settings.modFunction == true && Settings.settings.caloriesFish == Choice.Custom);
            SetFieldVisible(nameof(burbotCooked), Settings.settings.modFunction == true && Settings.settings.caloriesFish == Choice.Custom);
            SetFieldVisible(nameof(goldeyeCooked), Settings.settings.modFunction == true && Settings.settings.caloriesFish == Choice.Custom);
            SetFieldVisible(nameof(redIrishLordCooked), Settings.settings.modFunction == true && Settings.settings.caloriesFish == Choice.Custom);
            SetFieldVisible(nameof(rockfishCooked), Settings.settings.modFunction == true && Settings.settings.caloriesFish == Choice.Custom);
            SetFieldVisible(nameof(caloriesOtherFood), Settings.settings.modFunction == true);
            SetFieldVisible(nameof(acorn), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(acornBig), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(airlineChicken), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(airlineVegetarian), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(beefJerky), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(burdockPrepared), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(cattailStalk), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(chocolateBar), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(condensedMilk), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(dogFood), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(energyBar), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(granolaBar), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(ketchupChips), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(mapleSyrup), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(mre), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(peanutButter), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(pinnaclePeaches), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(porkAndBeans), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(saltyCrackers), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(sardines), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(tomatoSoup), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(acornBannock), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(acornPancake), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(bannock), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(meatPie), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(broth), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(fruitPorridge), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(cannedCorn), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(cannedHam), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(carrot), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(fishcakes), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(potatoCooked), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(fishermansPie), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(peachPancake), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(pancake), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(peachFruitPie), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(porridge), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(ptarmiganMeatPie), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(ptarmiganMeatStew), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(cookedPieForagers), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(rabbitMeatPie), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(rabbitMeatStew), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(meatStew), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(roseHipFruitPie), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(predatorPie), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(vegetableStew), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(troutMeatStew), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(venisonMeatPie), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(venisonMeatStew), Settings.settings.modFunction == true && Settings.settings.caloriesOtherFood == Choice.Custom);
            SetFieldVisible(nameof(caloriesDrinks), Settings.settings.modFunction == true);
            SetFieldVisible(nameof(acornCoffee), Settings.settings.modFunction == true && Settings.settings.caloriesDrinks == Choice.Custom);
            SetFieldVisible(nameof(birchBarkTea), Settings.settings.modFunction == true && Settings.settings.caloriesDrinks == Choice.Custom);
            SetFieldVisible(nameof(burdockTea), Settings.settings.modFunction == true && Settings.settings.caloriesDrinks == Choice.Custom);
            SetFieldVisible(nameof(coffee), Settings.settings.modFunction == true && Settings.settings.caloriesDrinks == Choice.Custom);
            SetFieldVisible(nameof(herbalTea), Settings.settings.modFunction == true && Settings.settings.caloriesDrinks == Choice.Custom);
            SetFieldVisible(nameof(orangeSoda), Settings.settings.modFunction == true && Settings.settings.caloriesDrinks == Choice.Custom);
            SetFieldVisible(nameof(goEnergyDrink), Settings.settings.modFunction == true && Settings.settings.caloriesDrinks == Choice.Custom);
            SetFieldVisible(nameof(reishiTea), Settings.settings.modFunction == true && Settings.settings.caloriesDrinks == Choice.Custom);
            SetFieldVisible(nameof(roseHipTea), Settings.settings.modFunction == true && Settings.settings.caloriesDrinks == Choice.Custom);
            SetFieldVisible(nameof(grapeSoda), Settings.settings.modFunction == true && Settings.settings.caloriesDrinks == Choice.Custom);
            SetFieldVisible(nameof(summitSoda), Settings.settings.modFunction == true && Settings.settings.caloriesDrinks == Choice.Custom);
            SetFieldVisible(nameof(meatShrinkage), Settings.settings.modFunction == true);
            SetFieldVisible(nameof(bearShrinks), Settings.settings.modFunction == true && Settings.settings.meatShrinkage == Choice.Custom);
            SetFieldVisible(nameof(deerShrinks), Settings.settings.modFunction == true && Settings.settings.meatShrinkage == Choice.Custom);
            SetFieldVisible(nameof(mooseShrinks), Settings.settings.modFunction == true && Settings.settings.meatShrinkage == Choice.Custom);
            SetFieldVisible(nameof(ptarmiganShrinks), Settings.settings.modFunction == true && Settings.settings.meatShrinkage == Choice.Custom);
            SetFieldVisible(nameof(rabbitShrinks), Settings.settings.modFunction == true && Settings.settings.meatShrinkage == Choice.Custom);
            SetFieldVisible(nameof(wolfShrinks), Settings.settings.modFunction == true && Settings.settings.meatShrinkage == Choice.Custom);
            SetFieldVisible(nameof(fishShrinkage), Settings.settings.modFunction == true);
            SetFieldVisible(nameof(salmonShrinks), Settings.settings.modFunction == true && Settings.settings.fishShrinkage == Choice.Custom);
            SetFieldVisible(nameof(whitefishShrinks), Settings.settings.modFunction == true && Settings.settings.fishShrinkage == Choice.Custom);
            SetFieldVisible(nameof(troutShrinks), Settings.settings.modFunction == true && Settings.settings.fishShrinkage == Choice.Custom);
            SetFieldVisible(nameof(bassShrinks), Settings.settings.modFunction == true && Settings.settings.fishShrinkage == Choice.Custom);
            SetFieldVisible(nameof(burbotShrinks), Settings.settings.modFunction == true && Settings.settings.fishShrinkage == Choice.Custom);
            SetFieldVisible(nameof(goldeyeShrinks), Settings.settings.modFunction == true && Settings.settings.fishShrinkage == Choice.Custom);
            SetFieldVisible(nameof(redIrishLordShrinks), Settings.settings.modFunction == true && Settings.settings.fishShrinkage == Choice.Custom);
            SetFieldVisible(nameof(rockfishShrinks), Settings.settings.modFunction == true && Settings.settings.fishShrinkage == Choice.Custom);
            SetFieldVisible(nameof(meatCookingTime), Settings.settings.modFunction == true);
            SetFieldVisible(nameof(bearCookingTime), Settings.settings.modFunction == true && Settings.settings.meatCookingTime == Choice.Custom);
            SetFieldVisible(nameof(deerCookingTime), Settings.settings.modFunction == true && Settings.settings.meatCookingTime == Choice.Custom);
            SetFieldVisible(nameof(mooseCookingTime), Settings.settings.modFunction == true && Settings.settings.meatCookingTime == Choice.Custom);
            SetFieldVisible(nameof(ptarmiganCookingTime), Settings.settings.modFunction == true && Settings.settings.meatCookingTime == Choice.Custom);
            SetFieldVisible(nameof(rabbitCookingTime), Settings.settings.modFunction == true && Settings.settings.meatCookingTime == Choice.Custom);
            SetFieldVisible(nameof(wolfCookingTime), Settings.settings.modFunction == true && Settings.settings.meatCookingTime == Choice.Custom);
            SetFieldVisible(nameof(fishCookingTime), Settings.settings.modFunction == true);
            SetFieldVisible(nameof(salmonCookingTime), Settings.settings.modFunction == true && Settings.settings.fishCookingTime == Choice.Custom);
            SetFieldVisible(nameof(whitefishCookingTime), Settings.settings.modFunction == true && Settings.settings.fishCookingTime == Choice.Custom);
            SetFieldVisible(nameof(troutCookingTime), Settings.settings.modFunction == true && Settings.settings.fishCookingTime == Choice.Custom);
            SetFieldVisible(nameof(bassCookingTime), Settings.settings.modFunction == true && Settings.settings.fishCookingTime == Choice.Custom);
            SetFieldVisible(nameof(burbotCookingTime), Settings.settings.modFunction == true && Settings.settings.fishCookingTime == Choice.Custom);
            SetFieldVisible(nameof(goldeyeCookingTime), Settings.settings.modFunction == true && Settings.settings.fishCookingTime == Choice.Custom);
            SetFieldVisible(nameof(redIrishLordCookingTime), Settings.settings.modFunction == true && Settings.settings.fishCookingTime == Choice.Custom);
            SetFieldVisible(nameof(rockfishCookingTime), Settings.settings.modFunction == true && Settings.settings.fishCookingTime == Choice.Custom);
            SetFieldVisible(nameof(updateHydration), Settings.settings.modFunction == true);
            SetFieldVisible(nameof(mreHeating), Settings.settings.modFunction == true);
            SetFieldVisible(nameof(mreWarmingUpDuration), Settings.settings.modFunction == true && Settings.settings.mreHeating);
            SetFieldVisible(nameof(mreInitialWarmthBonus), Settings.settings.modFunction == true && Settings.settings.mreHeating);
            SetFieldVisible(nameof(meatFishWarmingUpDuration), Settings.settings.modFunction == true);
            SetFieldVisible(nameof(meatFishInitialWarmthBonus), Settings.settings.modFunction == true);
        }
        protected override void OnConfirm()
        {
            base.OnConfirm();
            ChangePrefabs();
        }
        internal void ChangePrefabs()
        {
            if (Settings.settings.modFunction)
            {
                if (Settings.settings.updateHydration)
                {
                    FoodTweaker.ChangePrefabHydration("GEAR_CoffeeCup");
                    FoodTweaker.ChangePrefabHydration("GEAR_GreenTeaCup");
                    FoodTweaker.ChangePrefabHydration("GEAR_ReishiTea");
                    FoodTweaker.ChangePrefabHydration("GEAR_RoseHipTea");
                    FoodTweaker.ChangePrefabHydration("GEAR_BurdockTea");
                    FoodTweaker.ChangePrefabHydration("GEAR_AcornCoffeeCup");
                }
            }
        }
    }

    internal static class Settings
    {
        public static FoodTweakerSettings settings = new();

        public static void OnLoad()
        {
            settings.AddToModSettings("Food Tweaker Settings");
            settings.RefreshFields();
        }
    }
}
