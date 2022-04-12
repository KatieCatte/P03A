using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float hSpeed = 1f;
    public float vSpeed = 0f;
    public float hOffset = 0f;
    public float vOffset = 0f;
    public float hTileLength = 1.7f;
    public float vTileHeight = 1.2f;
    public bool VanishOnHit = true;
    public float TimeToDespawn = 1f;
    public int damage;

    [Header("Sub Bullets")] //this could be done in arrays but I'm lazy
    [SerializeField] ProjectileBehavior subBullet1;
    [SerializeField] ProjectileBehavior subBullet2;

    private IEnumerator despawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        despawnTimer = StartDespawnTimer();
        //SetBulletActive(transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(hSpeed, vSpeed, 0f);
    }
    private void OnEnable()
    {
        if(despawnTimer == null)
        {
            despawnTimer = StartDespawnTimer();
        }
        StartCoroutine(StartDespawnTimer());
    }

    public void SetBulletActive(Vector3 startPosition)
    {
        transform.position = startPosition;
        transform.Translate(hOffset * hTileLength, vOffset * vTileHeight, 0f);
        FireSubBullet(subBullet1, startPosition);
        FireSubBullet(subBullet2, startPosition);
    }
    private IEnumerator StartDespawnTimer()
    {
        Debug.Log("Despawn Timer Started.");
        yield return new WaitForSeconds(TimeToDespawn);
        Despawn();
    }

    private void Despawn()
    {
        Debug.Log("Despawn Timer Finished.");
        StopAllCoroutines();
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Bullet has hit something.");
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if(enemy != null)
        {
            //add code for reducing health here
            if (VanishOnHit == true)
            {
                Debug.Log("Projectile disappears.");
                this.Despawn();
                this.gameObject.SetActive(false);
            }
        }
    }
    private void FireSubBullet(ProjectileBehavior bullet, Vector3 startPosition) //pass bullet to fire and start position
    {
        if (bullet != null)
        {
            bullet.gameObject.SetActive(true);
            bullet.SetBulletActive(startPosition);
        }
    }
}
