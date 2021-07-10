using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;
 public class LoadData : MonoBehaviour
{
    int ammo;
    int health;
    int ammoClip;
    public void LoadGameForContinue()
    {
        if (File.Exists(Application.persistentDataPath
    + "/SaveData/MySavedData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fileStream = File.Open(Application.persistentDataPath
    + "/SaveData/MySavedData.dat", FileMode.Open);

            CreaeteandSaveData progress = (CreaeteandSaveData)bf.Deserialize(fileStream);
            fileStream.Close();
            ammo = progress.ammoSaved;
            health = progress.healthSaved;
            ammoClip = progress.ammoClipSaved;
            Debug.Log("Game data loaded " +
                "ammo= "+ammo+" health = "+health+" ammoClip= "+ammoClip);
        }
        else { Debug.Log("This saved game is not found"); }
    }
}
