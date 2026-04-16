using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class ClickerController : MonoBehaviour
{
    private int currentScore;

    //Network
    private string apiUrl = "http://127.0.0.1:8000/score";

    //[UI]
    public TextMeshProUGUI currentScoreText;
    public GameManager gameManager;

    void Start()
    {
        //Debug.Log(gameManager.totalClicks);
        gameManager = GetComponent<GameManager>();
    }

    void Update()
    {
        currentScoreText.text = currentScore.ToString();

    }

    public void Click()
    {
        currentScore++;
        StartCoroutine(CallApi(1));
    
    }

    public void ClickWithMultiplier(int value)
    {
        //alue += 
        currentScore++;
        StartCoroutine(CallApi(value));

    }

    IEnumerator CallApi(int value)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(apiUrl+"?score="+value))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError ||
                request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("API Error: " + request.error);
            }
            else
            {
                string jsonResponse = request.downloadHandler.text;
                Debug.Log("API Response: " + jsonResponse);
            }
        }
    }
}
