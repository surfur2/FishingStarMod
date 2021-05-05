using FishingStarMod.UIElements;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Menus;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace FishingStarMod.Options
{
    class ModConfig : IDisposable
    {
        private readonly List<IDisposable> _elementsToDispose;
        private readonly IDictionary<string, String> _options;
        private readonly IModHelper _helper;

        private readonly TileTracker _showFishInfo;

        public ModConfig(IModHelper helper, IDictionary<String, String> options)
        {
            _options = options;
            _helper = helper;

            _showFishInfo = new TileTracker(helper);

            _elementsToDispose = new List<IDisposable>()
            {
                _showFishInfo
            };

            _showFishInfo.ManageEventRegistration(true);

            // Version thisVersion = Assembly.GetAssembly(this.GetType()).GetName().Version;
        }


        public void Dispose()
        {
            foreach (var item in _elementsToDispose)
                item.Dispose();
        }
    }
}