using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    bool canShoot = true;
    [SerializeField] DeckManager deck;
    [SerializeField] BulletManager shooter;
    [SerializeField] PlayerMovement mover;
    public float shuffleTime = 2f;

    private void Start()
    {
        StartCoroutine(CombatShuffleDeck(shuffleTime*0.1f));
    }

    // Update is called once per frame
    void Update()
    {
        //shooting code
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
        if(Input.GetKeyDown(KeyCode.LeftShift) & canShoot)
        {
            StartCoroutine(CombatShuffleDeck(shuffleTime));
        }

        //movement code
        if (mover.ctrlActive)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && mover.vGridPosit > 1)
            {
                StartCoroutine(mover.MoveToGrid(0f, mover.vDistance));
                mover.vGridPosit -= 1;
                Debug.Log($"vpos: {mover.vGridPosit}");
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && mover.vGridPosit < mover.vGridMax)
            {
                StartCoroutine(mover.MoveToGrid(0f, -mover.vDistance));
                mover.vGridPosit += 1;
                Debug.Log($"vpos: {mover.vGridPosit}");
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && mover.hGridPosit > 1)
            {
                StartCoroutine(mover.MoveToGrid(-mover.hDistance, 0f));
                mover.hGridPosit -= 1;
                Debug.Log($"hpos: {mover.hGridPosit}");
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && mover.hGridPosit < mover.hGridMax)
            {
                StartCoroutine(mover.MoveToGrid(mover.hDistance, 0f));
                mover.hGridPosit += 1;
                Debug.Log($"hpos: {mover.hGridPosit}");
            }
        }
    }

    private IEnumerator CombatShuffleDeck(float timer)
    {
        canShoot = false;
        deck.EmptyDisplay();
        yield return new WaitForSeconds(timer);
        deck.ShuffleDeck();
        canShoot = true;
    }
}
