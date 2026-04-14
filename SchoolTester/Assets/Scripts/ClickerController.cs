using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class ClickerController : MonoBehaviour
{
    private int currentClickCount;

    //Network
    private string apiUrl = "http://127.0.0.1:8000/score";

    //[UI]
    public TextMeshProUGUI currentClickCountText;
    public GameManager gameManager;

    void Start()
    {
        //Debug.Log(gameManager.totalClicks);
        gameManager = GetComponent<GameManager>();
    }

    void Update()
    {
        //if (!gameManager.isPlaying)
            //return;

        currentClickCountText.text = currentClickCount.ToString();
    }

    public void Click()
    {
        currentClickCount++;
        StartCoroutine(CallApi());
    }

    IEnumerator CallApi()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(apiUrl))
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
