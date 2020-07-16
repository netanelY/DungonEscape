using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get => this.health; set => this.health = value; }

    public int Power { get => this.power; set => this.power = value; }

    public override void Update()
    {
        base.Update();
        //CombatMode();
    }

    public void Damage(int damage)
    {
        TakeDamage(damage);
    }

    //private void CombatMode()
    //{
    //    Debug.DrawRay(transform.position, (this.isFacingRight ? Vector2.right : Vector2.left) * 2f, Color.green);
    //    RaycastHit2D hit = Physics2D.Raycast(transform.position, this.isFacingRight ? Vector2.right : Vector2.left, 2f, 1 << 10);
    //    bool didHit = hit.collider;
    //    this.isHit = didHit;
    //    this.animator.SetBool("InCombat", didHit);
    //}
}
