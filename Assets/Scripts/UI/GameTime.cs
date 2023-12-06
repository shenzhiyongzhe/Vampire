using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    TMP_Text tmp_text;

    float gameTime;
    // Start is called before the first frame update
    void Start()
    {
        tmp_text = GetComponent<TMP_Text>();
        gameTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        string formattedTime = FormatTime(gameTime);
        UpdateUIText(formattedTime);
    }

    string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60f);
        string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        return formattedTime;
    }

    void UpdateUIText(string timeText)
    {
        tmp_text.text = timeText;
    }
}
