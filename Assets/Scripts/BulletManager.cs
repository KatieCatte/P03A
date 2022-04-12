using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] ProjectileBehavior bullet01;
    [SerializeField] ProjectileBehavior bullet02;
    [SerializeField] ProjectileBehavior bullet03;
    [SerializeField] ProjectileBehavior bullet04;
    //stick these bullets in an array and you can just use the deck's index to call bullets
    private ProjectileBehavior[] bullets;

    // Start is called before the first frame update
    void Start()
    {
        bullets = new ProjectileBehavior[4];
        bullets[0] = bullet01;
        bullets[1] = bullet02;
        bullets[2] = bullet03;
        bullets[3] = bullet04;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FireProjectile(int bulletID)
    {
        if (!bullets[bulletID].gameObject.activeSelf)
        {
            bullets[bulletID].gameObject.SetActive(true);
            bullets[bulletID].SetBulletActive(transform.position);
        }
    }
}
