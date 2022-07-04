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
  
  ## Limitations:
  * If you change the mod settings while in-game, you will need to change scene to apply the changes (e.g. go outside/inside).
  * The mod can be used on an existing save, but food items that have already been spawned/harvested etc. in that save will not be updated to the new modded calorie values. Other settings will be applied, such as cooking time and heating.


## Credit to [WarmFood](https://github.com/ttr/tld-WarmFood)
Originally by [Deus13](https://github.com/Deus13/WarmFood) and now updated and maintained by [ttr](https://github.com/ttr/tld-WarmFood).
  * **WarmFood** includes MRE self-heating, hot meat and fish as well as calorie adjustment for meat, fish and peanut butter. 
  * **Food Tweaker** uses the same methodology for MRE self-heating and hot fish/meat as **WarmFood**, as per WarmFood's [MIT License](https://github.com/ttr/tld-WarmFood/blob/master/LICENSE)
  * The calorie adjustment is different: **Food Tweaker** uses calories/kg and **Warm Food** uses a multiplier.
  * Unfortunately, **Warm Food** is NOT compatible with **Food Tweaker**.


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
        * GAME DEFAULT: Calorie values will remain unchanged.
        * REALISTIC: Based on real-world values.
        * CUSTOM: Set your own values. 
        * Choose CUSTOM and look at the description for each individual slider to see both the GAME DEFAULT value and the REALISTIC preset value.
    * Calories & Shrinkage:
    * * If you choose GAME DEFAULT for calories, but **not** GAME DEFAULT for shrinkage, the cooked meat or fish will have the same total calorie value as vanilla, regardless of shrinkage.
    * *	* E.g. 1kg bear meat has 900 calories by default, the cooked bear meat will still have 900 calories regardless of shrinkage.
    * * If you choose CUSTOM calories, but **not** GAME DEFAULT for shrinkage, the cooked meat or fish will have a *proportional amount* of calories to weight.
    * * * E.g. if you set 1kg of COOKED bear meat to have 1000 calories, and also set bear meat shrinkage to 25%: 1kg of raw bear meat will have 750 calories, and it will yeild 0.75kg of cooked bear meat that also has 750 calories.
    * * The raw meat or fish will always have the appropriate amount of calories to match the cooked meat or fish. You will not lose calories by cooking, you can only lose weight.    
5. Click ```CONFIRM``` to apply your changes or ```BACK``` to exit without applying changes


## Feedback, Questions & Troubleshooting
* I am active on [The Long Dark Modding](https://discord.gg/QvFE7VV4WZ) Discord server
	* **General questions and feedback:** post in my channel #cass
	* **Troubleshooting:** 
		* Post in my channel #cass or in #troubleshooting 
		* Or create an issue here on GitHub if you're not on Discord

