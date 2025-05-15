using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public GameObject player;

    public void Save()
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
    }

    public void Load()
    {
        float tempX = PlayerPrefs.GetFloat("PlayerX");
        float tempY = PlayerPrefs.GetFloat("PlayerY");
        player.transform.position = new Vector2(tempX, tempY);
    }
}

