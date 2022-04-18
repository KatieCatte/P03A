using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiProjectileBehavior : MonoBehaviour
{
    [SerializeField] ProjectileBehavior subBullet01;
    [SerializeField] ProjectileBehavior subBullet02; //this could probably be done in an array lol
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        FireProjectile(subBullet01);
        FireProjectile(subBullet02);
    }

    private void FireProjectile(ProjectileBehavior bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.SetBulletActive(transform.position);
    }
}
