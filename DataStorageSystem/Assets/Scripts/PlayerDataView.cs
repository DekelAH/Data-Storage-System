#region Copy
// This file is © 2022 Rumyancev Pavel <paulrumyancev@gmail.com>
// Vector. School of Game development
#endregion
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
        }
        
        #endregion
    }
}