using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator playerAnimator;
    private Animator swordArcAnimator;

    private void Start()
    {
        playerAnimator = transform.Find("Sprite").GetComponent<Animator>();
        swordArcAnimator = transform.Find("Sword Arc").GetComponent<Animator>();
    }

    public void Move(float move)
    {
        playerAnimator.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool isJumping)
    {
        playerAnimator.SetBool("Jumping", isJumping);
    }

    public void Attack()
    {
        playerAnimator.SetTrigger("Attack");
        swordArcAnimator.SetTrigger("Sword Animation");
    }

    public void Death()
    {
        playerAnimator.SetTrigger("Death");
    }

    public void SeIsFireSword(bool isFireSword)
    {
        playerAnimator.SetBool("IsFireSword", isFireSword);
    }
}
