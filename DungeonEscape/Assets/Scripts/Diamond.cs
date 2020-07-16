using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public int gems = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerScript playerScript = collision.GetComponent<PlayerScript>();
        if(playerScript != null)
        {
            playerScript.DiamondAmuont += gems;
            Destroy(gameObject);
        }
    }
}
