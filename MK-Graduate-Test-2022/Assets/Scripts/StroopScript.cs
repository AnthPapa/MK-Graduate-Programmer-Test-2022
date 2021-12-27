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

    public Button redButton, greenButton, blueButton, yellowButton;
    private bool pressed;

    // Start is called before the first frame update
    void Start()
    {
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
    void ButtonOnClick()
    {
        pressed = true;
    }

    IEnumerator display()
    {
        for (int i = 0; i < stroopAmount; i++)
        {
            stroop.text = coloursText[Random.Range(0, coloursText.Length)];
            stroop.color = colours[Random.Range(0, colours.Length)];
            //yield return new WaitForSeconds(2.0f);
            yield return new WaitUntil(() => pressed == true);
            pressed = false;
        }
    }
}
