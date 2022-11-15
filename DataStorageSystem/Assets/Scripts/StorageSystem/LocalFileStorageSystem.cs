using Assets.Scripts.Infastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.StorageSystem
{
    public class LocalFileStorageSystem : StorageSystem
    {
        protected override void LoadInternal()
        {
            if (File.Exists(Application.dataPath + "/save.txt"))
            {
                string json = File.ReadAllText(Application.dataPath + "/save.txt");
                JsonUtility.FromJsonOverwrite(json, PlayerModelProvider.Instance.Get);
                PlayerModelProvider.Instance.Get.InitializeData(PlayerModelProvider.Instance.Get.CoinsBalance, PlayerModelProvider.Instance.Get.GemsBalance);

                Debug.Log("<--- Loaded From Local JSON File --->");
            }
            else
            {
                Debug.LogError("<--- Didn't Load From Local JSON File --->");
            }
        }

        protected override void SaveInternal()
        {
            string json = JsonUtility.ToJson(PlayerModelProvider.Instance.Get);
            File.WriteAllText(Application.dataPath + "/save.txt", json);

            Debug.Log("<--- Saved In Local JSON File --->");
        }
    }
}
