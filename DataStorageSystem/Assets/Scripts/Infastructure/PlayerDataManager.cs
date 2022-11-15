using Assets.Scripts.StorageSystem;
using System;
using UnityEngine;

namespace Assets.Scripts.Infastructure
{
    public class PlayerDataManager
    {
        #region Fields

        private static PlayerDataManager _instance;

        private readonly static LocalFileStorageSystem _localFileStorageSystem = new LocalFileStorageSystem();
        private readonly static PlayerPrefsStorageSystem _playerPrefsStorageSystem = new PlayerPrefsStorageSystem();

        #endregion

        #region Methods

        public void LoadPlayerPrefsData()
        {
            LoadPlayerData();
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void CreateInstance()
        {
            _instance = new PlayerDataManager();
            Debug.Log("<----- PlayerDataManager Created ----->");

            PlayerDataManagerActions();
        }

        private static void PlayerDataManagerActions()
        {
            if (!PlayerModelProvider.Instance.Get.UseLocalData)
            {
                SubsribeToEvents();
                LoadPlayerData();
            }
            else
            {
                return;
            }
        }

        private static void OnDataBalanceChange()
        {
            if (!PlayerModelProvider.Instance.Get.UseLocalData)
            {
                switch (PlayerModelProvider.Instance.Get.PlayerModelSaveTypeName)
                {
                    case "Local File":
                        _localFileStorageSystem.Save();
                        break;
                    case "Player Prefs":
                        _playerPrefsStorageSystem.Save();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                return;
            }
        }

        private static void LoadPlayerData()
        {
            switch (PlayerModelProvider.Instance.Get.PlayerModelSaveTypeName)
            { 
                case "Local File":
                    _localFileStorageSystem.Load();
                    break;
                case "Player Prefs":
                    _playerPrefsStorageSystem.Load();
                    break;
                default:
                    break;
            }
        }

        private static void SubsribeToEvents()
        {
            PlayerModelProvider.Instance.Get.DataBalanceChange += OnDataBalanceChange;
        }

        #endregion

        #region Properties

        public static PlayerDataManager Instance => _instance;

        #endregion
    }
}
