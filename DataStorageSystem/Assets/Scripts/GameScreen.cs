#region Copy
// This file is © 2022 Rumyancev Pavel <paulrumyancev@gmail.com>
// Vector. School of Game development
#endregion
using UnityEngine;

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
        }

        public void OnTakeCoinsButtonClick()
        {
        }

        public void OnAddGemsButtonClick()
        {
        }

        public void OnTakeGemsButtonClick()
        {
        }

        #endregion
    }
}