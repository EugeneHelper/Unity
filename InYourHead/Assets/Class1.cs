using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;
namespace Assets
{

    public static class DataHolder
    {
        static public  int ammoHolder=50;
        static public int healthHolder=100; 
        static public int ammoClipHolder=10;
        
        static public void LoadGameForContinue()
        {
            if (File.Exists(Application.persistentDataPath
        + "/SaveData/MySavedData.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fileStream = File.Open(Application.persistentDataPath
        + "/SaveData/MySavedData.dat", FileMode.Open);

                CreaeteandSaveData progress = (CreaeteandSaveData)bf.Deserialize(fileStream);
                fileStream.Close();
                ammoHolder = progress.ammoSaved;
                healthHolder =  progress.healthSaved;
                ammoClipHolder = 
                    progress.ammoClipSaved;
                Debug.Log("Game data loaded " +
                    "ammo= " + ammoHolder + " health = " + healthHolder + " ammoClip= " + ammoClipHolder);
            }
            else { Debug.Log("This saved game is not found"); }
        }
        static public void LoadGameForPlay()
        {
            ammoHolder = 50;
            healthHolder = 100;
            ammoClipHolder = 10;
        }
    }
}
