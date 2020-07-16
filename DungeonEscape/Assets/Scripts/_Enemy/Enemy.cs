using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health, gems;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected Transform pointA, pointB;
    [SerializeField]
    protected Transform diamond;
    [SerializeField]
    protected int power = 1;

    protected Vector3 targetPosition;
    protected SpriteRenderer spriteRenderer;
    protected Animator animator;
    protected bool isHit = false;
    protected bool isFacingRight = true;
    protected bool isDead = false;

    protected PlayerScript player;

    protected virtual void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        spriteRenderer = this.transform.GetComponentInChildren<SpriteRenderer>();
        animator = transform.GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    public virtual void Update()
    {
        if ((!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") || InCombat) && !isDead)
        {
            isFacingRight = targetPosition == pointB.position;
            Flip();
            Patrol();
        }

    }

    protected virtual void Patrol()
    {
        Vector3 currentPositions = transform.position;

        if (isHit)
        {
            ChangeDirictionByPlayerLocation();
        }
        else
        {
            if (Vector3.Distance(currentPositions, pointA.position) < 0.001f)
            {
                PlayIdle();
                targetPosition = pointB.position;
            }
            else if (Vector3.Distance(currentPositions, pointB.position) < 0.001f)
            {
                PlayIdle();
                targetPosition = pointA.position;
            }
        }

        if (!isHit)
            transform.position = Vector3.MoveTowards(currentPositions, targetPosition, speed * Time.deltaTime);

        float disFromPlayer = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        if(disFromPlayer > 3)
        {
            this.isHit = false;
            this.InCombat = false;
        }
    }


    protected virtual void Flip()
    {
        spriteRenderer.flipX = targetPosition == pointA.position;
    }

    protected void ChangeDirictionByPlayerLocation()
    {
        Vector3 playerDirction = player.transform.localPosition - transform.localPosition;
        if (playerDirction.x > 0)
        {
            targetPosition = pointB.position;
        }
        else if (playerDirction.x < 0)
        {
            targetPosition = pointA.position;
        }
    }

    protected virtual void PlayIdle()
    {
        this.animator.SetTrigger("Idle");

    }

    protected bool InCombat
    {
        get { return animator.GetBool("InCombat"); }
        set { this.animator.SetBool("InCombat", value); }
    }

    protected void TakeDamage(int damage)
    {
        if (isDead)
            return;
        this.animator.SetTrigger("Hit");
        this.health -= damage;
        this.isHit = true;

        InCombat = true;
        if (this.health < 1 && !isDead)
        {
            isDead = true;
            animator.SetTrigger("Death");
            Diamond d = Instantiate(diamond, transform.position, Quaternion.identity).GetComponent<Diamond>();
            if (d != null)
            {
                d.gems = this.gems;
            }
        }
    }
}
