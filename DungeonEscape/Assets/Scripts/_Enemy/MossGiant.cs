using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get => this.health; set => this.health = value; }

    public int Power { get => this.power; set => this.power = value; }

    public void Damage(int damage)
    {
        TakeDamage(damage);
    }
}
