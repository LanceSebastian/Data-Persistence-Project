using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    [SerializeField] int highscore;

    [SerializeField] string highscoreName;

    [SerializeField] string playerName = "NoName";

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    public string GetName()
    {
        return playerName;
    }

    public string GetHighscoreName()
    {
        return highscoreName;
    }

    public int GetScore()
    {
        return highscore;
    }

    [System.Serializable]
    class SaveData
    {
        public int score;
        public string playerName;
    }

    public void SetName(string input)
    {
        //Get input from Name Input and set it to playerName
        playerName = input;
    }

    public void SaveScore(int m_Points)
    {
        // Save score if greater than highscore
        if (highscore < m_Points)
        {
            SaveData data = new SaveData();
            data.score = m_Points;
            data.playerName = playerName;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highscore = data.score;
            highscoreName = data.playerName;
        }
    }
}
