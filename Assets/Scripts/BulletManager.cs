using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] ProjectileBehavior bullet01;
    [SerializeField] ProjectileBehavior bullet02;
    [SerializeField] ProjectileBehavior bullet03;
    [SerializeField] ProjectileBehavior bullet04;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !bullet01.gameObject.activeSelf)
        {
            FireProjectile(bullet01);
        }
        if (Input.GetKeyDown(KeyCode.X) && !bullet02.gameObject.activeSelf)
        {
            FireProjectile(bullet02);
        }
    }

    private void FireProjectile(ProjectileBehavior bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.SetBulletActive(transform.position);
    }
}
