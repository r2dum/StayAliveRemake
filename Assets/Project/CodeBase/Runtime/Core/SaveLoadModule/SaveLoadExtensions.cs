using UnityEngine;

namespace CodeBase.Runtime.Core.SaveLoadModule
{
    public static class SaveLoadExtensions
    {
        public static T FromJson<T>(this string json) =>
            JsonUtility.FromJson<T>(json);

        public static string ToJson(this object obj) =>
            JsonUtility.ToJson(obj);
    }
}