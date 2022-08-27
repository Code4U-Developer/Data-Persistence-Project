using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class PersistentDataManager : MonoBehaviour
{
    
    public static PersistentDataManager Instance;

    public string Name;
    public int Score = 0;
    public string BestName;
    public int BestScore = 0;

    // Start is called before the first frame update
    private void Awake()
    {
    LoadBestName();
    if (Instance != null)
    {
        Destroy(gameObject);
        return;
    }
    // end of new code

    Instance = this;
    DontDestroyOnLoad(gameObject);
    }
   
    [System.Serializable]
    class SaveData
    {
    public string BestName;
    public int BestScore = 0;
    }

    public void SaveBestName()
    {
    SaveData data = new SaveData();
    if(data.BestName != null){
        if(data.BestScore < Score){
            data.BestName = Name;
            data.BestScore = Score;
        }
    }else{
        data.BestName = Name;
        data.BestScore = Score;
    }

    string json = JsonUtility.ToJson(data);
  
    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestName()
    {
    string path = Application.persistentDataPath + "/savefile.json";
    if (File.Exists(path))
    {
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        BestName = data.BestName;
        BestScore = data.BestScore;
    }
    }
    
}
