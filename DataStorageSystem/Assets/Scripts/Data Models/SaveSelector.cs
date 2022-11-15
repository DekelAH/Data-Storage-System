using UnityEngine;

namespace Assets.Scripts.Data_Models
{
    [CreateAssetMenu(menuName = "Data Models/Save Selector", fileName = "Save Selector")]
    public class SaveSelector : ScriptableObject
    {
        #region Consts

        private const string LOCAL_FILE = "Local File";
        private const string PLAYER_PREFS = "Player Prefs";

        #endregion

        #region Editor

        [SerializeField]
        private PlayerModel _playerModel;

        [SerializeField]
        private SaveType _saveType;

        #endregion

        #region Methods

        private PlayerModel SaveTypeSelector()
        {
            switch (_saveType)
            {
                case SaveType.LocalFile:
                    _playerModel.SetPlayerModelName(LOCAL_FILE);
                    return _playerModel;
                case SaveType.PlayerPrefs:
                    _playerModel.SetPlayerModelName(PLAYER_PREFS);
                    return _playerModel;
                default:
                    return null;
            }
        }

        #endregion

        #region Properties

        public PlayerModel GetSaveType => SaveTypeSelector();

        #endregion
    }
}
