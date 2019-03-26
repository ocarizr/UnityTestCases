using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Assets.Scripts.UiTest
{
    public abstract class SaveSystem<TData> : MonoBehaviour
    {
        public abstract void SaveData();

        public virtual void BinarySaveFile(TData data)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "UserData.dat", FileMode.Open);
            bf.Serialize(file, data);
            file.Close();
        }
    }
}
