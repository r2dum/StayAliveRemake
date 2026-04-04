using System;
using System.Collections.Generic;

namespace CodeBase.Runtime.Core.Data
{
    [Serializable]
    public class BiomeData
    {
        public string SelectedBiome = "MountainBiome";
        public List<string> UnlockedBiomes = new();
    }
}