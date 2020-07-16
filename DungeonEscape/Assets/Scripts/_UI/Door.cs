using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerScript player = collision.GetComponent<PlayerScript>();
        if(player && GameManager.Instance.HasKey)
        {
            Debug.Log("MoveToNextLevel");
        }
    }
}
