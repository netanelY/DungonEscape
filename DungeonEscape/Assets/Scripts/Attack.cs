using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool canAttack = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null && canAttack)
        {
            damageable.Damage(damageable.Power);
            canAttack = false;
            StartCoroutine(WaitForHit());
        }
    }

    private IEnumerator WaitForHit()
    {
        yield return new WaitForSeconds(0.5f);
        this.canAttack = true;
    }
}
