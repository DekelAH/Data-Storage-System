using Assets.Scripts.Infastructure;
using System;
using UnityEngine;

namespace Assets.Scripts.StorageSystem
{
    public sealed class PlayerPrefsStorageSystem : StorageSystem
    {
        protected override void LoadInternal()
        {
            PlayerModelProvider.Instance.Get.InitializeData(PlayerPrefs.GetInt("Coins"), PlayerPrefs.GetInt("Gems"));

            Debug.Log("<--- Loaded From PlayerPrefs --->");
        }

        protected override void SaveInternal()
        {
            PlayerPrefs.SetInt("Coins", PlayerModelProvider.Instance.Get.CoinsBalance);
            PlayerPrefs.SetInt("Gems", PlayerModelProvider.Instance.Get.GemsBalance);
            PlayerPrefs.Save();

            Debug.Log("<--- Saved In PlayerPrefs --->");
        }
    }
}
