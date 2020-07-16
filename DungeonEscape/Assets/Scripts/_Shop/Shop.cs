using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private GameObject shopView;
    [SerializeField]
    private GameObject[] shopItemsButtons;
    [SerializeField]
    private GameObject[] shopItemsPrices;

    private int selectedItem = 0;
    private int itemCost = 200;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            UIManger.Instance.OpenShop(GameManager.Instance.Player.DiamondAmuont);
            shopView.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            shopView.SetActive(false);
        }
    }
    
    public void SelectItem(int tag)
    {
        this.selectedItem = tag;
        switch (tag)
        {
            case 0:
                UIManger.Instance.UpdateShopSelection(80);
                itemCost = 200;
                break;
            case 1:
                UIManger.Instance.UpdateShopSelection(-30);
                itemCost = 400;
                break;
            case 2:
                UIManger.Instance.UpdateShopSelection(-142);
                itemCost = 100;
                break;
        }
    }

    public void BuyItem()
    {
        int playerGems = GameManager.Instance.Player.DiamondAmuont;
        if (itemCost <= playerGems)
        {
            switch (selectedItem)
            {
                case 0:
                    GameManager.Instance.Player.IsFireSword(true);  
                    break;
                case 1:
                    GameManager.Instance.Player.AddBootsOfFlight();
                    break;
                case 2:
                    GameManager.Instance.HasKey = true;
                    break;
            }

            GameManager.Instance.Player.DiamondAmuont -= itemCost;

            shopItemsButtons[selectedItem].SetActive(false);
            shopItemsPrices[selectedItem].SetActive(false);
            SetNextSelected();
        }
        shopView.SetActive(false);
    }

    private void SetNextSelected()
    {
        for (int i = 0; i < shopItemsButtons.Length; i++)
        {
            if (!shopItemsButtons[i].active)
            {
                continue;
            }

            this.SelectItem(i);
            return;
        }
    }
}
