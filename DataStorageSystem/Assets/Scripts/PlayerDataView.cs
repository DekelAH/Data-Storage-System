#region Copy
// This file is © 2022 Rumyancev Pavel <paulrumyancev@gmail.com>
// Vector. School of Game development
#endregion
using Assets.Scripts.Infastructure;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace VectorSchool
{
    public class PlayerDataView : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Text _coinsBalance;

        [SerializeField]
        private Text _gemsBalance;
        
        #endregion
        
        #region Methods

        private void Start()
        {
            SubsribeToEvents();
            InitializeBalanceText();
        }

        private void OnDestroy()
        {
            UnSubsribeToEvents();
        }

        private void InitializeBalanceText()
        {
            _coinsBalance.text = PlayerModelProvider.Instance.Get.CoinsBalance.ToString();
            _gemsBalance.text = PlayerModelProvider.Instance.Get.GemsBalance.ToString();
        }

        private void SubsribeToEvents()
        {
            PlayerModelProvider.Instance.Get.CoinsBalanceChange += OnCoinBalanceChange;
            PlayerModelProvider.Instance.Get.GemsBalanceChange += OnGemsBalanceChange;
        }

        private void UnSubsribeToEvents()
        {
            PlayerModelProvider.Instance.Get.CoinsBalanceChange -= OnCoinBalanceChange;
            PlayerModelProvider.Instance.Get.GemsBalanceChange -= OnGemsBalanceChange;
        }

        private void OnCoinBalanceChange(int coinsBalance)
        {
            _coinsBalance.text = coinsBalance.ToString();
        }

        private void OnGemsBalanceChange(int gemsBalance)
        {
            _gemsBalance.text = gemsBalance.ToString();
        }

        #endregion
    }
}