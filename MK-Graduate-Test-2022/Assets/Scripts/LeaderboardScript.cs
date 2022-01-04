using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI bestScoreText, bestTimeText;
    public float bestTime;
    public int bestScore;

    void OnEnable()
    {
        GameObject stroopObject = GameObject.Find("StroopScript");
        StroopScript stroopScript = stroopObject.GetComponent<StroopScript>();
        bestScoreText.text = "Score: " + stroopScript.bestScore;

        bestTime = PlayerPrefs.GetFloat("bestTimeKey");
        bestTimeText.text = "Time: " + stroopScript.bestTime.ToString("F2");
    }
}
