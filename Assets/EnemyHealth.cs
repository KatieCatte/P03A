using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyMaxHP = 40;
    public int enemyHP;
    // Start is called before the first frame update
    void Start()
    {
        enemyHP = enemyMaxHP;
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
            Perish();
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
}
