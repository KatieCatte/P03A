using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyMaxHP = 40;
    private int enemyHP;

    //these sprites should go in a separate animation manager in a real game
    private SpriteRenderer enemySprite;
    [SerializeField] Sprite normalSprite;
    [SerializeField] Sprite damagedSprite;
    [SerializeField] float flinchTime;
    private BoxCollider2D coll;
    [SerializeField] HitsparkManager hitspark;
    [SerializeField] HitsparkManager diespark;
    [SerializeField] AudioSource hurtsfx;
    [SerializeField] AudioSource diesfx;

    // Start is called before the first frame update
    void Start()
    {
        enemyHP = enemyMaxHP;
        enemySprite = this.GetComponentInChildren<SpriteRenderer>();
        coll = this.GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeHP(int hpchange)
    {
        enemyHP += hpchange;
        if(enemyHP <= 0)
        {
            enemyHP = 0;
        }
        if (hpchange < 0)
        {
            StopCoroutine(damageAnim());
            StartCoroutine(damageAnim());
            
        }
        if(enemyHP > enemyMaxHP)
        {
            enemyHP = enemyMaxHP;
        }
    }

    public void Perish()
    {
        this.gameObject.SetActive(false);
    }
    private IEnumerator damageAnim()
    {
        enemySprite.sprite = damagedSprite;
        if (enemyHP <= 0)
        {
            diesfx.Play();
            coll.enabled = false;
            diespark.gameObject.SetActive(true);
            enemySprite.sprite = null;
        }
        else {
            hurtsfx.Play();
            hitspark.gameObject.SetActive(true); 
        }
        yield return new WaitForSeconds(flinchTime);
        if(enemyHP == 0)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            enemySprite.sprite = normalSprite;
        }
    }
}
