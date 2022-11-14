using Assets.Scripts.Data_Models;
using UnityEngine;

namespace Assets.Scripts.Infastructure
{
    public class PlayerModelProvider
    {
        #region Consts

        private const string PLAYER_MODEL_RESOURCE_NAME = "Player Model";

        #endregion

        #region Fields

        private static PlayerModelProvider _instance;
        private static PlayerModel _playerModel;

        #endregion

        #region Constructors

        private PlayerModelProvider(string playerModelResourceName)
        {
            _playerModel = Resources.Load<PlayerModel>(playerModelResourceName);
        }

        #endregion

        #region Properties

        public static PlayerModelProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PlayerModelProvider(PLAYER_MODEL_RESOURCE_NAME);              
                }

                return _instance;
            }
        }

        public PlayerModel Get => _playerModel;

        #endregion


    }
}
