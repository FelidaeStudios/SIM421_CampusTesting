using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //public bool isPlaying;
    //public GameObject playButton;
    public static int totalScore;
    public static int currentScore;

    public static int doubleMultAmount = 1;
    public static int automateAmount = 0;

    //[UI]
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI totalScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalScore = 0;
        currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        currentScoreText.text = currentScore.ToString();
        totalScoreText.text = totalScore.ToString();
    }

    /*public void BeginGame()
    {
        isPlaying = true;
        totalClicks = 0;
        playButton.SetActive(false);
    }*/

    /*public void EndGame()
    {
        isPlaying = false;
        playButton.SetActive(true);
        //append to leaderboard
    }*/
}
