using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManger : MonoBehaviour
{
    private static UIManger _instance;
    public Text playerGemCountText;
    public Text gemCountText;
    public Image selectionImage;
    public Image[] playerHealthArray;
    public GameObject menu;

    public static UIManger Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("Instance is null");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = gemCount + "G";
    }

    public void UpdateShopSelection(int yPos)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x,yPos);
    }

    public void UpdateGemCount(int count)
    {
        gemCountText.text = count + "G";
        this.OpenShop(count);
    }

    public void UpdatePlayerHealth(int health)
    {
        playerHealthArray[3].gameObject.SetActive(health >= 4);

        for (int i = 0; i < 4; i++){
            playerHealthArray[i].enabled = health >= i+1;
        }
    }

    public void openMenu()
    {
        menu.SetActive(true);
    }
}
