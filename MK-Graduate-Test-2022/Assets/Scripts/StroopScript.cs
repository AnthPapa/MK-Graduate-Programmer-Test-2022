using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StroopScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI stroop;
    [SerializeField]
    private float stroopAmount = 10;
    private string[] coloursText = new string[] { "Red", "Green", "Blue", "Yellow" };
    private Color32[] colours = { new Color32(244, 132, 116, 255), new Color32(92, 247, 155, 255), new Color32(133, 232, 255, 255), new Color32(252, 238, 141, 255) };
    private Color32 stroopColour;

    [SerializeField]
    private Button redButton, greenButton, blueButton, yellowButton; 
    private bool pressed;
    private bool redBtnPress = false;
    private bool blueBtnPress = false;
    private bool greenBtnPress = false;
    private bool yellowBtnPress = false;

    [SerializeField]
    private TextMeshProUGUI scoreText, timeText, bestScoreText, bestTimeText;

    [SerializeField]
    private float time;

    private int score;
    public float bestTime;
    public int bestScore = 0;
    private bool timerActive;

    [SerializeField]
    private GameObject playGameUI, resultsUI, bestTimeUI;
    [SerializeField]
    private GameObject particle;
    private Animator anim;

    public AudioSource audioSource;
    [SerializeField]
    private AudioClip audioBtnCorrect, audioBtnIncorrect, audioBestScore;

    void Start()
    {
        if (PlayerPrefs.HasKey("bestTimeKey"))
        {
            bestTime = PlayerPrefs.GetFloat("bestTimeKey"); 
        }       
        bestScore = PlayerPrefs.GetInt("bestScoreKey", 0);

        anim = stroop.gameObject.GetComponent<Animator>();
        
        resultsUI.gameObject.SetActive(false);
        bestTimeUI.gameObject.SetActive(false);
        playGameUI.gameObject.SetActive(true);
        particle.gameObject.SetActive(false);

        redButton.onClick.AddListener(ButtonOnClick);
        blueButton.onClick.AddListener(ButtonOnClick);
        greenButton.onClick.AddListener(ButtonOnClick);
        yellowButton.onClick.AddListener(ButtonOnClick);
        StartCoroutine(Stroop());
    }
    void Update()
    {
        if (timerActive)
        {
            time += Time.deltaTime;      
        }
    }
    public void Restartbtn()
    {
        resultsUI.gameObject.SetActive(false);
        playGameUI.gameObject.SetActive(true);
        score = 0;
        StartCoroutine(Stroop());
    }
    //----------------Button Press Checks----------------//
    public void RedOnClick()
    {
        redBtnPress = true;
    }
    public void BlueOnClick()
    {
        blueBtnPress = true;
    }
    public void GreenOnClick()
    {
        greenBtnPress = true;
    }
    public void YellowOnClick()
    {
        yellowBtnPress = true;
    }
    void ButtonOnClick()
    {
        pressed = true;
    }
    //----------------End----------------//
    IEnumerator Stroop()
    {
        Cursor.lockState = CursorLockMode.Locked;
        yield return new WaitForSeconds(2.0f);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        time = 0.00f;
        Color32 red = new Color32(244, 132, 116, 255);
        Color32 blue = new Color32(133, 232, 255, 255);
        Color32 green = new Color32(92, 247, 155, 255);
        Color32 yellow = new Color32(252, 238, 141, 255);

        for (int i = 0; i < stroopAmount; i++)
        {
            anim.SetTrigger("ChangeWordTrigger");
            stroop.text = coloursText[Random.Range(0, coloursText.Length)];
            stroopColour = colours[Random.Range(0, colours.Length)];
            stroop.color = stroopColour;
            timerActive = true;

            yield return new WaitUntil(() => pressed == true);

            //----------------Button Colour Checks----------------//
            if (stroopColour.Equals(red))
            {
                if (redBtnPress == true)
                {
                    audioSource.PlayOneShot(audioBtnCorrect);
                    Debug.Log("Pressed Red");
                    score++;                   
                }
                else
                {
                    audioSource.PlayOneShot(audioBtnIncorrect);
                    Debug.Log("Didin't press red");
                }
            }
            redBtnPress = false;
            if (stroopColour.Equals(blue))
            {
                if (blueBtnPress == true)
                {
                    audioSource.PlayOneShot(audioBtnCorrect);
                    Debug.Log("Pressed blue");
                    score++;                   
                }
                else
                {
                    audioSource.PlayOneShot(audioBtnIncorrect);
                    Debug.Log("Didin't press blue");
                }
            }
            blueBtnPress = false;
            if (stroopColour.Equals(green))
            {
                if (greenBtnPress == true)
                {
                    audioSource.PlayOneShot(audioBtnCorrect);
                    Debug.Log("Pressed green");
                    score++;   
                }
                else
                {
                    audioSource.PlayOneShot(audioBtnIncorrect);
                    Debug.Log("Didin't press green");
                }
            }
            greenBtnPress = false;
            if (stroopColour.Equals(yellow))
            {
                if (yellowBtnPress == true)
                {
                    audioSource.PlayOneShot(audioBtnCorrect);
                    Debug.Log("Pressed yellow");
                    score++;                 
                }
                else
                {
                    audioSource.PlayOneShot(audioBtnIncorrect);
                    Debug.Log("Didin't press yellow");
                }
            }
            yellowBtnPress = false;
            pressed = false;
    //----------------End----------------//

            if (i == stroopAmount - 1)
            {
                Debug.Log("max amount");
                Cursor.lockState = CursorLockMode.Locked;
                timerActive = false;
                yield return new WaitForSeconds(1f);
                playGameUI.gameObject.SetActive(false);
                scoreText.text = "Score: " + score.ToString() + " / " + stroopAmount;
                timeText.text = "Time: " + time.ToString("F2");           
                stroop.text = "Stroop";
                stroop.color = new Color32(249, 157, 199, 255);
                Cursor.lockState = CursorLockMode.None;
                Debug.Log("Time = " + time + " / " + bestTime);

                if (score > bestScore || score >= bestScore && time < bestTime)
                {
                    audioSource.PlayOneShot(audioBestScore);
                    bestScore = score;
                    bestTime = time;
                    particle.gameObject.SetActive(true);
                    bestTimeUI.gameObject.SetActive(true);
                    resultsUI.gameObject.SetActive(false);
                    bestScoreText.text = "Score: " + score.ToString() + " / " + stroopAmount;
                    bestTimeText.text = "Time: " + time.ToString("F2");

                    Debug.Log("Best Score = " + bestTime);
                    yield return new WaitForSeconds(4.5f);
                    resultsUI.gameObject.SetActive(true);
                    bestTimeUI.gameObject.SetActive(false);
                    particle.gameObject.SetActive(false);
                }
                else
                {
                    resultsUI.gameObject.SetActive(true);
                }
                break;
            }
        }
    }
    private void OnDisable()
    {
        PlayerPrefs.SetInt("bestScoreKey", bestScore);
        PlayerPrefs.SetFloat("bestTimeKey", bestTime);
        PlayerPrefs.Save();
    }
}

