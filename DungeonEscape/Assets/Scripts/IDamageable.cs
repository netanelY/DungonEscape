using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    int Health { get; set; }
    int Power { get; set; }
    void Damage(int damage);
}
