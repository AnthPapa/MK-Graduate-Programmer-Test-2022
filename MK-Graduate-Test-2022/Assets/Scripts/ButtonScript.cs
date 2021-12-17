using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip btnHover;
    public AudioClip btnClick;

    public GameObject howToPlayUI;
    public GameObject mainMenuUI;

    void Start()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "MainMenuScene")
        {
            howToPlayUI.gameObject.SetActive(false);
            mainMenuUI.gameObject.SetActive(true);
        }
    }

    //----------------Audio----------------//
    public void OnHover()
    {
        audioSource.PlayOneShot(btnHover);
    }
    public void OnClick()
    {
        audioSource.PlayOneShot(btnClick);
    }

    //----------------ChangeUIPanels----------------//
    public void howToPlayClick()
    {
        StartCoroutine(IhowToPlayClick());
    }
    public void MenuClick()
    {
        StartCoroutine(IMenuClick());
    }
    IEnumerator IhowToPlayClick()
    {
        yield return new WaitForSeconds(0.3f);
        howToPlayUI.gameObject.SetActive(true);
        mainMenuUI.gameObject.SetActive(false);
    }
    IEnumerator IMenuClick()
    {
        yield return new WaitForSeconds(0.3f);
        howToPlayUI.gameObject.SetActive(false);
        mainMenuUI.gameObject.SetActive(true);
    }

    //----------------Change Scenes----------------//
    public void LoadMenu()
    {
        StartCoroutine(ILoadMenu());
    }
    public void LoadPlayGame()
    {
        StartCoroutine(ILoadPlayGame());
    }
    IEnumerator ILoadMenu()
    {
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene("MainMenuScene");
    }
    IEnumerator ILoadPlayGame()
    {
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene("PlayGameScene");
    }
}
