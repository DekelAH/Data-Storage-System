#region Copy
// This file is © 2022 Rumyancev Pavel <paulrumyancev@gmail.com>
// Vector. School of Game development
#endregion
using Assets.Scripts.Infastructure;
using UnityEngine;
using UnityEngine.UI;

namespace VectorSchool
{
    public class GameScreen : MonoBehaviour
    {
        #region Fields

        [SerializeField]
        private int _coinsToAdd = 30;
        
        [SerializeField]
        private int _coinsToTake = 30;

        [SerializeField]
        private int _gemsToAdd = 1;

        [SerializeField]
        private int _gemsToTake = 1;

        #endregion

        #region Methods

        public void OnAddCoinsButtonClick()
        {
            PlayerModelProvider.Instance.Get.AddCoins(_coinsToAdd);
        }

        public void OnTakeCoinsButtonClick()
        {
            PlayerModelProvider.Instance.Get.WithdrawCoins(_coinsToTake);
        }

        public void OnAddGemsButtonClick()
        {
            PlayerModelProvider.Instance.Get.AddGems(_gemsToAdd);
        }

        public void OnTakeGemsButtonClick()
        {
            PlayerModelProvider.Instance.Get.WithdrawGems(_gemsToTake);
        }

        #endregion
    }
}