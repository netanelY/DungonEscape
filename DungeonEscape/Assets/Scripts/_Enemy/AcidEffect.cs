using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    private Rigidbody2D rigi2D;
    private bool playerOnTheLeft;
    private int power = 1;

    private void Start()
    {
        rigi2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
        Vector3 playerDirction = GameManager.Instance.Player.transform.localPosition - transform.localPosition;
        playerOnTheLeft = playerDirction.x > 0;
    }

    void Update()
    {
        rigi2D.velocity = (playerOnTheLeft ? Vector2.right : Vector2.left) * 3;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerScript player = collision.GetComponent<PlayerScript>();
        if(player != null)
        {
            player.Damage(power);
            Destroy(gameObject);
        }
    }
}
