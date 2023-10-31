using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public GameObject nicknameInputField, mainMenu, hallOfFameObject;
    public TextMeshProUGUI BestScoreText;

    public void Start()
    {
        SetBestScore();
    }

    public void SetNickname()
    {
        string nickname = nicknameInputField.GetComponent<TMP_InputField>().text;
        GameManager.Instance.SaveCurrentUserData(nickname, 0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SetBestScore()
    {
        GameManager.HallOfFame data = GameManager.Instance.LoadHallOfFameData();
        if (data != null)
            BestScoreText.text = $"Best Score: {data.nickname1}: {data.bestScore1}";
    }

    public void ShowHallOfFame()
    {
        mainMenu.SetActive(false);
        hallOfFameObject.SetActive(true);
        GameManager.HallOfFame data = GameManager.Instance.LoadHallOfFameData();
        if (data != null)
        {
            GameObject name;
            TextMeshProUGUI text;

            if (data.bestScore1 > 0)
            {
                name = GameObject.Find("Name1");
                name.SetActive(true);
                text = name.GetComponent<TextMeshProUGUI>();
                text.text = $"{data.nickname1}: {data.bestScore1}";
            }
            if (data.bestScore2 > 0)
            {
                name = GameObject.Find("Name2");
                name.SetActive(true);
                text = name.GetComponent<TextMeshProUGUI>();
                text.text = $"{data.nickname2}: {data.bestScore2}";
            }
            if (data.bestScore3 > 0)
            {
                name = GameObject.Find("Name3");
                name.SetActive(true);
                text = name.GetComponent<TextMeshProUGUI>();
                text.text = $"{data.nickname3}: {data.bestScore3}";
            }
            if (data.bestScore4 > 0)
            {
                name = GameObject.Find("Name4");
                name.SetActive(true);
                text = name.GetComponent<TextMeshProUGUI>();
                text.text = $"{data.nickname4}: {data.bestScore4}";
            }
            if (data.bestScore5 > 0)
            {
                name = GameObject.Find("Name5");
                name.SetActive(true);
                text = name.GetComponent<TextMeshProUGUI>();
                text.text = $"{data.nickname5}: {data.bestScore5}";
            }
        }
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        hallOfFameObject.SetActive(false);
    }
}
