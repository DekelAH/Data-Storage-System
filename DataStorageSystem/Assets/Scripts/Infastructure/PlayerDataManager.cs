using UnityEngine;

namespace Assets.Scripts.Infastructure
{
    public class PlayerDataManager
    {
        #region Fields

        private static PlayerDataManager _instance;

        #endregion

        #region Methods

        public void LoadPlayerPrefsData()
        {
            LoadPlayerModel();
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
                LoadPlayerModel();
            }
            else
            {
                return;
            }
        }

        private static void OnCoinsBalanceChange(int coins)
        {
            PlayerPrefs.SetInt("Coins", coins);
            PlayerPrefs.Save();
        }

        private static void OnGemsBalanceChange(int gems)
        {
            PlayerPrefs.SetInt("Gems", gems);
            PlayerPrefs.Save();
        }

        private static void LoadPlayerModel()
        {
            PlayerModelProvider.Instance.Get.InitializeData(PlayerPrefs.GetInt("Coins"), PlayerPrefs.GetInt("Gems"));
            Debug.Log("<-- Load Complete -->");
        }

        private static void SubsribeToEvents()
        {
            PlayerModelProvider.Instance.Get.CoinsBalanceChange += OnCoinsBalanceChange;
            PlayerModelProvider.Instance.Get.GemsBalanceChange += OnGemsBalanceChange;
        }

        #endregion

        #region Properties

        public static PlayerDataManager Instance => _instance;

        #endregion
    }
}
