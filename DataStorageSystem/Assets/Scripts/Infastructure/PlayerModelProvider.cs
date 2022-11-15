using Assets.Scripts.Data_Models;
using UnityEngine;

namespace Assets.Scripts.Infastructure
{
    public class PlayerModelProvider
    {
        #region Consts

        private const string SAVE_SELECTOR_RESOURCE_NAME = "Save Selector";

        #endregion

        #region Fields

        private static PlayerModelProvider _instance;
        private static SaveSelector _saveSelector;

        #endregion

        #region Constructors

        private PlayerModelProvider(string saveSelectorResourceName)
        {
            _saveSelector = Resources.Load<SaveSelector>(saveSelectorResourceName);
        }

        #endregion

        #region Properties

        public static PlayerModelProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PlayerModelProvider(SAVE_SELECTOR_RESOURCE_NAME);              
                }

                return _instance;
            }
        }

        public PlayerModel Get => _saveSelector.GetSaveType;

        #endregion


    }
}
