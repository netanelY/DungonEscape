using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    private Spider spider;

    private void Start()
    {
        spider = gameObject.GetComponentInParent<Spider>();
    }

    public void Fire()
    {
        spider.Attack();
    }
}
