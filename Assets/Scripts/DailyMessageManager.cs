using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class DailyMessageManager : MonoBehaviour
{
    private JsonDataImport jsonDataImport;
    public TMP_Text dateText;
    public TMP_Text messageText;
    private string[] messages;
    private string[] motivation;
    private string[] love;
    public int messageIndex;
    public int loveIndex;
    public int motivationIndex;
    private int changeType;

    void Awake()
    {
        jsonDataImport = FindObjectOfType<JsonDataImport>();
        if (jsonDataImport == null)
        {
            Debug.LogWarning("JsonDataImport script is NOT available.");
        }
        else Debug.Log("Json is available...");
    }

    void Start()
    {
        //load json content
        messages = jsonDataImport.messages_jsonn;
        motivation = jsonDataImport.motivation_jsonn;
        love = jsonDataImport.love_jsonn;

        // Display today's date
        dateText.text = DateTime.Now.ToString("MMMM dd, yyyy");

        // Calculate the message index based on the day of the year
        int dayOfYear = DateTime.Now.DayOfYear;
        messageIndex = dayOfYear % messages.Length;
        motivationIndex = dayOfYear % motivation.Length;
        loveIndex = dayOfYear % love.Length;

        // Display the message
        MessageAnimation(messageIndex, changeType);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChangeLoveButton()
    {
        MessageAnimation(loveIndex, 2);
    }
    public void ChangeMessageButton()
    {
        MessageAnimation(messageIndex, 0);
    }
    public void ChangeMotivationButton()
    {
        MessageAnimation(motivationIndex, 1);
    }

    public void MessageAnimation(int ind, int chT)
    {
        switch (chT)
        {
            case 0:
                messageText.text = messages[ind];
                messageText.color = new Color(0.2858668f, 0.9182389f, 0.4453874f); // RGB values
                break;
            case 1:
                messageText.text = motivation[ind];
                messageText.color = new Color(0.9176471f, 0.7431028f, 0.2862745f);
                break;
            case 2:
                messageText.text = love[ind];
                messageText.color = new Color(0.9685534f, 0.5695581f, 0.8073645f);
                break;
            default:
                // Optional: Handle unexpected cases if necessary
                messageText.text = messages[ind];
                break;
        }
    }
}
