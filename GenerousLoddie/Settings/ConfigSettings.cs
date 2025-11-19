using BepInEx.Configuration;
using TeamCherry.Localization;

namespace GenerousLoddie.Settings
{
    public static class ConfigSettings
    {
        /// <summary>
        /// Integrates with UI to set the multiplier of Loddie's prize
        /// </summary>
        public static ConfigEntry<float> loddieMultiplier;

        /// <summary>
        /// Initializes the settings
        /// </summary>
        /// <param name="config"></param>
        public static void Initialize(ConfigFile config)
        {
            // Bind set methods to Config
            LocalisedString name = new LocalisedString($"Mods.{GenerousLoddie.Id}", "NAME");
            LocalisedString description = new LocalisedString($"Mods.{GenerousLoddie.Id}", "DESC");
            float defaultValue = 2f;
            if (name.Exists &&
                description.Exists)
            {
                loddieMultiplier = config.Bind<float>("Modifier", name, defaultValue, description);
            }
            else
            {
                loddieMultiplier = config.Bind("Modifier", "Multiplier", defaultValue, "How much to multiply Loddie's reward by");
            }
        }
    }
}