using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StroopScript : MonoBehaviour
{

    public TextMeshProUGUI stroop;
    public float stroopAmount = 10;
    private string[] coloursText = new string[] { "Red", "Green", "Blue", "Yellow" };
    private Color32[] colours = { new Color32(244, 132, 116, 255), new Color32(92, 247, 155, 255), new Color32(133, 232, 255, 255), new Color32(252, 238, 141, 255) };
    private Color32 stroopColour;

    public Button redButton, greenButton, blueButton, yellowButton;
    public Button restart;
    private bool pressed;
    private bool redBtnPress = false;
    private bool blueBtnPress = false;
    private bool greenBtnPress = false;
    private bool yellowBtnPress = false;

    private int score;
    public TextMeshProUGUI timeText;
    public float time;
    private bool timerActive;


    public TextMeshProUGUI scoreText;

    

    public GameObject playGameUI;
    public GameObject ResultsUI;



    void Start()
    {
        ResultsUI.gameObject.SetActive(false);
        playGameUI.gameObject.SetActive(true);

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
        ResultsUI.gameObject.SetActive(false);
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
        yield return new WaitForSeconds(2.0f);
        time = 0.00f;
        Color32 red = new Color32(244, 132, 116, 255);
        Color32 blue = new Color32(133, 232, 255, 255);
        Color32 green = new Color32(92, 247, 155, 255);
        Color32 yellow = new Color32(252, 238, 141, 255);

        for (int i = 0; i < stroopAmount; i++)
        {
            stroop.text = coloursText[Random.Range(0, coloursText.Length)];
            stroopColour = colours[Random.Range(0, colours.Length)];
            stroop.color = stroopColour;
            timerActive = true;
            //Debug.Log(stroopColour);

            yield return new WaitUntil(() => pressed == true);

    //----------------Button Colour Checks----------------//
            if (stroopColour.CompareRGB(red))
            {
                if (redBtnPress == true)
                {
                    Debug.Log("Pressed Red");
                    score++;
                }
                else
                {
                    Debug.Log("Didin't press red");
                }
            }
            redBtnPress = false;
            if (stroopColour.CompareRGB(blue))
            {
                if (blueBtnPress == true)
                {
                    Debug.Log("Pressed blue");
                    score++;
                }
                else
                {
                    Debug.Log("Didin't press blue");
                }
            }
            blueBtnPress = false;
            if (stroopColour.CompareRGB(green))
            {
                if (greenBtnPress == true)
                {
                    Debug.Log("Pressed green");
                    score++;
                }
                else
                {
                    Debug.Log("Didin't press green");
                }
            }
            greenBtnPress = false;
            if (stroopColour.CompareRGB(yellow))
            {
                if (yellowBtnPress == true)
                {
                    Debug.Log("Pressed yellow");
                    score++;
                }
                else
                {
                    Debug.Log("Didin't press yellow");
                }
            }
            yellowBtnPress = false;
            pressed = false;
    //----------------End----------------//

            if (i == stroopAmount - 1)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Debug.Log("max amount");
                timerActive = false;
                yield return new WaitForSeconds(1f);
                ResultsUI.gameObject.SetActive(true);
                playGameUI.gameObject.SetActive(false);
                scoreText.text = "Score: " + score.ToString() + " / " + stroopAmount;
                timeText.text = "Time: " + time.ToString("F2");

                stroop.text = "Stroop";
                stroop.color = new Color32(249, 157, 199, 255);
                Cursor.lockState = CursorLockMode.None;
                break;
            }
        }
    }
}

