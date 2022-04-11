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
        this.gameObject.SetActive(false);
    }
}
