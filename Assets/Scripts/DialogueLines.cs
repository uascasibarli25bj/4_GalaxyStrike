using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueLines : MonoBehaviour
{
    [SerializeField] string[] timelineTextLines;
    [SerializeField] TMP_Text dialogueText;
    int currentLineIndex = 0;

    public void DisplayNextLine()
    {
        currentLineIndex++;
        dialogueText.text = timelineTextLines[currentLineIndex];
    }
}
