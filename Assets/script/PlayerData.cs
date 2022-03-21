using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class PlayerData : MonoBehaviour
{
   public SaveData activeSave; 

    void Update(){
        if(Input.GetKeyDown(KeyCode.K)){
            Save();
        }
        else if(Input.GetKeyUp(KeyCode.L)){
            Load();
        }
    }

   public void Save(){
       string dataPath = Application.persistentDataPath;
       var seralizer = new XmlSerializer(typeof(SaveData));
       var stream = new FileStream(dataPath + "/" + activeSave.saveName + ".save", FileMode.Create);
       seralizer.Serialize(stream, activeSave);
       stream.Close();

       Debug.Log("Saved");
   }

   public void Load(){
       string dataPath = Application.persistentDataPath;
       if(System.IO.File.Exists(dataPath + "/" + activeSave.saveName + ".save")){
            var seralizer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(dataPath + "/" + activeSave.saveName + ".save", FileMode.Open);
            activeSave = seralizer.Deserialize(stream) as SaveData;
            stream.Close();
            Debug.Log("Loaded");
       }

   }
}
[System.Serializable]
public class SaveData {
    public string saveName;
    public Vector3 position;
    public int itemsCollected;
}