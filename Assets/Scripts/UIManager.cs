using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text highscoreText;

    public void QuitApplication()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit;
#endif
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    void Start()
    {
        string playerName = DataManager.Instance.GetHighscoreName();
        int highscore = DataManager.Instance.GetScore();

        Debug.Log("Name: "+playerName);
        Debug.Log("score: "+highscore);

        highscoreText.text = $"Best Score: {playerName} : {highscore}";
    }
}
