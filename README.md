# Food Tweaker
A mod for the Long Dark.

## Mod features:
  * Adjust calories of food items (meat, fish, drinks, packaged goods etc.)
  * Adjust cooking time for meat and fish
  * Adjust how much meat shrinks when cooked (**raw weight** vs **cooked weight**)
  * Adjust difference between weight of **whole, raw fish** vs **cleaned, cooked fish**
  * Enable MRE self-heating
  * All meat and fish will become "Hot" after cooking and will provide Warming Up buff when eaten hot
  * Includes Realistic presets, Custom sliders and ability to keep Game Default values

Realistic preset values are provided as an easy option for those who don't want to individually research and set custom values. 
These values will not please everyone and can't possibly be definitive. Use the Custom options if you don't like the presets!
  * Note that the Cooking skill will boost the calorie value of cooked foods by up tp 25% and reduce cooking time by up to 30%. This has been factored into the realistic presets.
  * Realistic meat calorie values have been largely taken from the [Alaska Department of Fish and Game](https://www.adfg.alaska.gov/index.cfm?adfg=hunting.eating) website.
  * Realistic fish calorie values were averaged from various nutrition data websites and based on wild-caught fish cooked with dry heat.
  * Realistic values for other foods and drinks were taken from various nutrition data websites, using the highest values found.
  * The data available on cattails suggests they have 10x less calories/kg than the Game Default value. [Source 1](https://nutritiondata.self.com/facts/ethnic-foods/10462/2), [Source 2](https://www.healthbenefitstimes.com/cattail/), [Source 3](https://www.lybrate.com/topic/benefits-of-cattail-and-its-side-effects).
  * Some foods, like wolf meat, have to be estimated as there isn't comprehensive nutritional data available for them.
  * Cooking times are based on the best online sources I could find and are averages / generalisations. There is limited information available on cooking these specific meats and fish over a fire and it is not possible to account for all of the factors that would affect cooking time in reality. 
  * If anyone has relevant real-world experience to share, you're very welcome to send me a message (see contact info at bottom).


The mod does not currently include calorie adjustment for foods added by mods, as these are already realistic and some come with their own settings to adjust calories. 

  ## Limitations:
  * If you change the mod settings while in-game, you will need to change scene to apply the changes (e.g. go outside/inside).
  * The mod can be used on an existing save, but food items that have already been spawned/harvested etc. in that save will not be updated to the new modded calorie values. Raw meat and fish will have updated values after you cook them.
  * Compatible with [Weight Tweaks](https://github.com/Xpazeman/tld-weight-tweaks) mod, **IF you leave Weight Tweaks food weight option at default values**. Otherwise there will probably be conflicts with the calories and shrinkage functions in Food Tweaker.


## Credit to [WarmFood](https://github.com/ttr/tld-WarmFood)
Originally by [Deus13](https://github.com/Deus13/WarmFood) and now updated and maintained by [ttr](https://github.com/ttr/tld-WarmFood).
  * **WarmFood** includes MRE self-heating, hot meat and fish as well as calorie adjustment for meat, fish and peanut butter. 
  * **Food Tweaker** uses the same methodology for MRE self-heating and hot fish/meat as **WarmFood**, as per WarmFood's [MIT License](https://github.com/ttr/tld-WarmFood/blob/master/LICENSE)
  * The calorie adjustment is different: **Food Tweaker** uses calories/kg and **Warm Food** uses a multiplier.
  * **Warm Food** is NOT recommended for use with **Food Tweaker**, certain settings will create conflicts.


## Requirements
[MelonLoader](https://github.com/HerpDerpinstine/MelonLoader/releases/latest/download/MelonLoader.Installer.exe)

[ModSettings](https://github.com/zeobviouslyfakeacc/ModSettings/releases)

## Installation:
1. Download ```FoodTweaker.dll``` from [releases](https://github.com/GruffCassquatch/FoodTweaker/releases)
2. Drop ```FoodTweaker.dll``` into your Mods folder
3. If you are updating from an older version, you may need to delete the ```FoodTweaker.json``` file from your Mods folder as old json's can cause errors if the mod's Settings have been changed.

## Uninstallation:
Delete ```FoodTweaker.dll``` and ```FoodTweaker.json``` from your Mods folder

## Using The Mod:
1. Open the ```Options``` menu
2. Open the ```Mod Settings``` menu
3. Scroll across to the ```Food Tweaker``` menu
4. Choose to Enable or Disable the mod
5. Mod Options:
	* Most sections include the following options: 
		* GAME DEFAULT: Values will remain unchanged.
		* REALISTIC: Based on real-world values.
		* CUSTOM: Set your own values. 
		* Choose CUSTOM and look at the description for each individual slider to see both the GAME DEFAULT value and the REALISTIC preset value.
	* Calories & Shrinkage:
		* All calorie values are *before* the Cooking Skill calorie bonus is applied. 
		* A cooked piece of meat or fish will always have at least as many calories as when it was raw.
			* The EXCEPTION to this is if you use the GAME DEFAULT setting for **meat**, as in the vanilla game raw venison and rabbit have *higher* calories than the cooked versions (Venison: 900 raw, 800 cooked; Rabbit: 500 raw, 450 cooked). If you choose GAME DEFAULT I assume you want this weirdness.
		* You will *gain* calories on cooked items if you have a high enough Cooking Skill, as you would in the vanilla game.
		* If you choose GAME DEFAULT for calories, but **not** GAME DEFAULT for shrinkage, the cooked meat or fish will have the same total calorie value as vanilla, regardless of shrinkage.
			* E.g. 1kg bear meat has 900 calories by default, the cooked bear meat will still have 900 calories regardless of shrinkage.
		* If you choose CUSTOM calories, but **not** GAME DEFAULT for shrinkage, the cooked meat or fish will have a *proportional amount* of calories to weight. Take this into account when setting Calories and Shrinkage.
			* If you want to use real-world calories/kg values, just set the Custom slider to the appropriate calories/kg value.
			* If you know how many calories you want 1kg meat to have after cooking & shrinkage, use this formula to get the calories/kg value: ```FinalCalories / (1 - shrinkage)```
			* E.g. you want cooked deer calories to match the Game Default raw deer calories, and also have 25% shrinkage: 
			 	* 900 / (1 - 0.25) = 900 / 0.75 = 1200
				* Then set ```Deer calories/kg (Cooked)``` to 1200 and ```Deer Shrinkage``` to 25%. Now 1kg of raw deer meat will cook to 0.75kg of cooked meat with 900 calories.
5. Click ```CONFIRM``` to apply your changes or ```BACK``` to exit without applying changes


## Feedback, Questions & Troubleshooting
* I am active on [The Long Dark Modding](https://discord.gg/QvFE7VV4WZ) Discord server
	* **General questions and feedback:** post in my channel #cass
	* **Troubleshooting:** 
		* Post in my channel #cass or in #troubleshooting 
		* Or create an issue here on GitHub if you're not on Discord

