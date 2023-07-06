using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.IO;
using System.IO;

public class GeneralManager : MonoBehaviour
{
    public int m_Points;
    public int highscore;
    public string inputName;
    public string hsName;
    
    public static GeneralManager Instance;
    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighscore();
    }

    [System.Serializable]
    class SaveData
    {
        public int highscore;
        public string hsName;
        public string actualName;
    }

    public void SaveHighscore(int points)
    {
        SaveData data = new SaveData();
        if (points > highscore)
        {
            data.highscore = points;
            data.hsName = inputName;
        } else
        {
            data.highscore = highscore;
            data.hsName = hsName;
        }
        data.actualName = inputName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highscore = data.highscore;
            hsName = data.hsName;
            inputName = data.actualName;
        }
    }

}
