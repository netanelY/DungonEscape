using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    [SerializeField]
    private Transform acidShot;

    public int Power { get => this.power; set => this.power = value; }

    public int Health { get => this.health; set => this.health = value; }

    public void Damage(int damage)
    {
        TakeDamage(damage);
    }

    public override void Update()
    {

    }

    public void Attack()
    {
        Instantiate(acidShot, transform.position, Quaternion.identity);
    }
}
