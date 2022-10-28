using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class menuUI : MonoBehaviour
{
    public TMP_InputField veryCoolName;

    public void StartNew()
    {
        MainHandler.Instance.LoadScore();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        MainHandler.Instance.SaveScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit(); //original code to quit unity player
    }
    public void NameChange()
    {
        MainHandler.Instance.currentPlayerName = veryCoolName.text;
    }
}
