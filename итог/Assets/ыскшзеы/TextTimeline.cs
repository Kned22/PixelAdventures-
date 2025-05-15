using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTimeline : MonoBehaviour
{
    public TMP_Text text;
    public string[] frazi = new string[] { "я отобрал у теб€ твою подвеску! „то бы мен€ поймать тебе надо забрать 10 вишенок,удачи!!" };
    public float zaderzhka = 2f;
    void Start()
    {
        StartCoroutine(ShowPhrases());
    }
    IEnumerator ShowPhrases()
    {
        while (true)
        {
            foreach(string fraza in frazi)
            {
                text.text = fraza;
                yield return new WaitForSeconds(zaderzhka);
            }
            text.enabled = false;
            break;
        }

    }
}
