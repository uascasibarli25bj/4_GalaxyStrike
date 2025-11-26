using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public struct MezuEstruktura
{
    public string autorea;
    public string mezua;
}

public class froga : MonoBehaviour
{
    public MezuEstruktura[] mezuak;
    public int mezuIdx;
    public TMP_Text UIText;

    void Start()
    {
        mezuIdx = -1;
    }
    
    void Update()
    {
        
    }

    IEnumerator NextMessage()
    {
        mezuIdx++;
        UIText.text=""+mezuak[mezuIdx].autorea+": ";

        for (int i = 0; i < mezuak[mezuIdx].mezua.Length; i++)
        {
            UIText.text += mezuak[mezuIdx].mezua[i];
            yield return new WaitForSeconds(0.05f);
        }
    }
}
