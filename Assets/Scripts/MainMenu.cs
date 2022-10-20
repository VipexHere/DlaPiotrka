using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private string gameSceneName;

    private void Awake()
    {
        startGameButton.onClick.AddListener(PlayGame);
    }

    private void PlayGame ()
    {
        LoadSceneManager.instance.LoadScene(gameSceneName); 
    }

    public void QuitGame ()
    {
        Debug.Log("Exit!");
        Application.Quit();
    }
}
