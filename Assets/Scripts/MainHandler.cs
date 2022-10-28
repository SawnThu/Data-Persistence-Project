using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainHandler : MonoBehaviour
{
    public string currentPlayerName;

    public static MainHandler Instance;
    [System.Serializable]
    class SaveData
    {
        public int maxScore;
        public string playerName;
    }

    public int maxScore; //new variable declared
    public string playerName; //ur mom

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.maxScore = maxScore;
        data.playerName = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            maxScore = data.maxScore;
            playerName = data.playerName;
        }
    }

    private void Awake()
    {
        //new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        //end of code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }
}
