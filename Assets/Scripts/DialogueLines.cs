using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public struct Messagestructure
{
    public string author;
    public string message;
    public Color authorColor;
}

public class DialogueLines : MonoBehaviour
{
    public Messagestructure[] messageList;
    [SerializeField] TMP_Text dialogueText;
    int currentLineIndex = -1;

    public void Start()
    {
        currentLineIndex = -1;
    }

    public void DisplayNextLine()
    {
        StartCoroutine(NextMessage());
    }

    IEnumerator NextMessage()
    {
        currentLineIndex++;

        Color c = messageList[currentLineIndex].authorColor;
        string hex = ColorUtility.ToHtmlStringRGB(c);

        dialogueText.text = $"<color=#{hex}>{messageList[currentLineIndex].author}</color>: ";

        for (int i = 0; i < messageList[currentLineIndex].message.Length; i++)
        {
            dialogueText.text += messageList[currentLineIndex].message[i];
            yield return new WaitForSeconds(0.02f);
        }
    }
}

