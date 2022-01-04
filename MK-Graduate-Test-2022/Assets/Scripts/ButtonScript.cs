using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField]
    public AudioClip btnHoverMenu, btnHoverGame, btnClick;

    [SerializeField]
    private GameObject howToPlayUI, mainMenuUI, settingsUI;

    void Start()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "MainMenuScene")
        {
            howToPlayUI.gameObject.SetActive(false);
            settingsUI.gameObject.SetActive(false);
            mainMenuUI.gameObject.SetActive(true);
        }
    }

    //----------------Audio----------------//
    public void OnHover()
    {
        audioSource.PlayOneShot(btnHoverMenu);
    }
    public void OnHover2()
    {
        audioSource.PlayOneShot(btnHoverGame);
    }
    public void OnClick()
    {
        audioSource.PlayOneShot(btnClick);
    }

    //----------------ChangeUIPanels----------------//
    public void settingsClick()
    {
        StartCoroutine(IsettingsClick());
    }
    public void howToPlayClick()
    {
        StartCoroutine(IhowToPlayClick());
    }
    public void MenuClick()
    {
        StartCoroutine(IMenuClick());
    }
    IEnumerator IsettingsClick()
    {
        yield return new WaitForSeconds(0.3f);
        settingsUI.gameObject.SetActive(true);
        mainMenuUI.gameObject.SetActive(false);
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
        settingsUI.gameObject.SetActive(false);
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
