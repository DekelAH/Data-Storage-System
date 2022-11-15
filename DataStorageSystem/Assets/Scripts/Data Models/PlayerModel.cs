using System;
using UnityEngine;

namespace Assets.Scripts.Data_Models
{
    [CreateAssetMenu(menuName = "Data Models/Player Model", fileName = "Player Model")]
    public class PlayerModel : ScriptableObject
    {
        #region Events

        public event Action<int> CoinsBalanceChange;
        public event Action<int> GemsBalanceChange;
        public event Action DataBalanceChange;

        #endregion

        #region Editor

        [SerializeField]
        private int _coinsBalance;

        [SerializeField]
        private int _gemsBalance;

        [SerializeField]
        private bool _useLocalData;

        #endregion

        #region Fields

        private string _playerModelSaveTypeName;

        #endregion

        #region Methods

        public void SetPlayerModelName(string playerModelName)
        {
            _playerModelSaveTypeName = playerModelName;
        }

        public void InitializeData(int coins, int gems)
        {
            _coinsBalance = coins;
            _gemsBalance = gems;

            GemsBalanceChange?.Invoke(_gemsBalance);
            CoinsBalanceChange?.Invoke(_coinsBalance);
            DataBalanceChange?.Invoke();
        }

        public void AddCoins(int coinsToAdd)
        {
            _coinsBalance += coinsToAdd;
            CoinsBalanceChange?.Invoke(_coinsBalance);
            DataBalanceChange?.Invoke();
        }

        public void WithdrawCoins(int coinsToWithdraw)
        {
            _coinsBalance = Mathf.Max(0, _coinsBalance - coinsToWithdraw);
            CoinsBalanceChange?.Invoke(_coinsBalance);
            DataBalanceChange?.Invoke();
        }

        public void AddGems(int gemsToAdd)
        {
            _gemsBalance += gemsToAdd;
            GemsBalanceChange?.Invoke(_gemsBalance);
            DataBalanceChange?.Invoke();
        }

        public void WithdrawGems(int gemsToWithdraw)
        {
            _gemsBalance = Mathf.Max(0, _gemsBalance - gemsToWithdraw);
            GemsBalanceChange?.Invoke(_gemsBalance);
            DataBalanceChange?.Invoke();
        }

        #endregion

        #region Properties

        public int CoinsBalance => _coinsBalance;
        public int GemsBalance => _gemsBalance;
        public bool UseLocalData => _useLocalData;
        public string PlayerModelSaveTypeName => _playerModelSaveTypeName;

        #endregion
    }
}
