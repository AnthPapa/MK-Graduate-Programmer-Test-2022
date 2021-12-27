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
    private bool pressed;

    private int score;

    private bool redBtnPress = false;
    private bool blueBtnPress = false;
    private bool greenBtnPress = false;
    private bool yellowBtnPress = false;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI timeText;
    public float time;


    public Button restart;
    private bool restartPressed;

    public GameObject playGameUI;
    public GameObject ResultsUI;
    // Start is called before the first frame update

    void Start()
    {
        ResultsUI.gameObject.SetActive(false);
        playGameUI.gameObject.SetActive(true);

        redButton.onClick.AddListener(ButtonOnClick);
        blueButton.onClick.AddListener(ButtonOnClick);
        greenButton.onClick.AddListener(ButtonOnClick);
        yellowButton.onClick.AddListener(ButtonOnClick);
        StartCoroutine(display());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Restartbtn()
    {
        ResultsUI.gameObject.SetActive(false);
        playGameUI.gameObject.SetActive(true);
        score = 0;
    }
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
    IEnumerator display()
    {
        yield return new WaitForSeconds(2.0f);

        Color32 red = new Color32(244, 132, 116, 255);
        Color32 blue = new Color32(133, 232, 255, 255);
        Color32 green = new Color32(92, 247, 155, 255);
        Color32 yellow = new Color32(252, 238, 141, 255);

        for (int i = 0; i < stroopAmount; i++)
        {
            stroop.text = coloursText[Random.Range(0, coloursText.Length)];

            stroopColour = colours[Random.Range(0, colours.Length)];

            stroop.color = stroopColour;

            //Debug.Log(stroopColour);

            //yield return new WaitForSeconds(2.0f);
            yield return new WaitUntil(() => pressed == true);

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
            if (i == stroopAmount - 1)
            {
                Debug.Log("max amount");
                yield return new WaitForSeconds(1f);
                ResultsUI.gameObject.SetActive(true);
                playGameUI.gameObject.SetActive(false);
                scoreText.text = "Score: " + score.ToString();
                i = 0;
            }
        }
    }
}

