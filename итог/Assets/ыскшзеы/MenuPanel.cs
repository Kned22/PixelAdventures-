using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;

    public void OpenShop(bool isOpenned)
    {
        shopPanel.SetActive(isOpenned);
    }
}
