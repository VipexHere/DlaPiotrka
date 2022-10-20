using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.TimeZoneInfo;

public class LoadSceneManager : MonoBehaviour
{
    [SerializeField] private Button sceneReadyButton;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI loadingText;
    [SerializeField] private TextMeshProUGUI progressText;

    public Animator transition;

    public float transitionTime = 1f;

    public static LoadSceneManager instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        AsyncOperation loading = SceneManager.LoadSceneAsync(sceneName);
        loadingScreen.SetActive(true);
        while (!loading.isDone)
        {
            float progress = Mathf.Clamp01(loading.progress / .9f);

            slider.value = loading.progress;
            progressText.text = progress * 100f + "%";

            if (loading.progress >= 0.9f)
            {
                break;
            }
            sceneReadyButton.gameObject.SetActive(true);
            sceneReadyButton.onClick.AddListener(() =>
            {
                loading.allowSceneActivation = true;
                loadingScreen.SetActive(false);
            });
            yield return null;
        }
    }
}
