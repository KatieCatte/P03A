using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    bool canShoot = true;
    [SerializeField] DeckManager deck;
    [SerializeField] BulletManager shooter;
    public float shuffleTime = 2f;

    private void Start()
    {
        StartCoroutine(CombatShuffleDeck(shuffleTime*0.1f));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && canShoot)
        {
            if (deck.IsSlotFilled(0)) {
                shooter.FireProjectile(deck.GetCardBulletID(0));
                deck.SwapZSkill();
            }
            else if (deck.IsSlotFilled(1))
            {
                shooter.FireProjectile(deck.GetCardBulletID(1));
                deck.SwapXSkill();
            }
            if(!deck.IsSlotFilled(0) && !deck.IsSlotFilled(1))
            {
                StartCoroutine(CombatShuffleDeck(shuffleTime));
            }
            
        }
        if (Input.GetKeyDown(KeyCode.X) && canShoot)
        {
            if (deck.IsSlotFilled(1))
            {
                shooter.FireProjectile(deck.GetCardBulletID(1));
                deck.SwapXSkill();
            }
            else if (deck.IsSlotFilled(0))
            {
                shooter.FireProjectile(deck.GetCardBulletID(0));
                deck.SwapZSkill();
            }
            if (!deck.IsSlotFilled(0) && !deck.IsSlotFilled(1))
            {
                StartCoroutine(CombatShuffleDeck(shuffleTime));
            }

        }
        if(Input.GetKeyDown(KeyCode.C) & canShoot)
        {
            StartCoroutine(CombatShuffleDeck(shuffleTime));
        }
    }

    private IEnumerator CombatShuffleDeck(float timer)
    {
        canShoot = false;
        yield return new WaitForSeconds(timer);
        deck.ShuffleDeck();
        canShoot = true;
    }
}
