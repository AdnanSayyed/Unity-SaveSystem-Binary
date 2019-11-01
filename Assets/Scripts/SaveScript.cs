using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;

public class SaveScript : MonoBehaviour
{

    private GameData gameData;
    private string savePath;

    // Start is called before the first frame update
    void Start()
    {
        gameData = GetComponent<GameData>();
        savePath = Application.persistentDataPath + "/gamesave.save";
    }
    public void SaveData()
    {
        var save = new Save()
        {
            savedInteger = gameData.GameInteger,
            savedString = gameData.GameString
        };

        var binaryFormatter = new BinaryFormatter();
        using(var fileStream = File.Create(savePath))
        {
            binaryFormatter.Serialize(fileStream, save);
        }

        print("Data Saved");
    }


    public void LoadData()
    {
        if (File.Exists(savePath))
        {
            Save save;
            var binaryFormatter = new BinaryFormatter();
            using(var fileStream = File.Open(savePath, FileMode.Open))
            {
                save = (Save)binaryFormatter.Deserialize(fileStream);

            }

            gameData.GameInteger = save.savedInteger;
            gameData.GameString = save.savedString;
            gameData.ShowData();

            print("Data Loaded");
        }
    }
   
}
