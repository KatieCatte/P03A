using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    bool canShoot = true;
    [SerializeField] DeckManager deck;
    [SerializeField] BulletManager shooter;
    [SerializeField] PlayerMovement mover;
    [SerializeField] AudioManager audioManager;
    [SerializeField] ShuffleIcon shuffleIcon;
    public float shuffleTime = 2f;
    public float shootTime = 0.1f;

    private void Start()
    {
        StartCoroutine(CombatShuffleDeck(shuffleTime*0.01f));
    }

    // Update is called once per frame
    void Update()
    {
        //shooting code
        if (Input.GetKeyDown(KeyCode.Z) && canShoot)
        {
            if (deck.IsSlotFilled(0)) {
                shooter.FireProjectile(deck.GetCardBulletID(0));
                deck.LoadSkill(0);
            }
            else if (deck.IsSlotFilled(1))
            {
                shooter.FireProjectile(deck.GetCardBulletID(1));
                deck.LoadSkill(1);
            }
            if(!deck.IsSlotFilled(0) && !deck.IsSlotFilled(1))
            {
                StartCoroutine(CombatShuffleDeck(shuffleTime));
            }
            else
            {
                StartCoroutine(ShotCooldown());
            }
            
        }
        if (Input.GetKeyDown(KeyCode.X) && canShoot)
        {
            if (deck.IsSlotFilled(1))
            {
                shooter.FireProjectile(deck.GetCardBulletID(1));
                deck.LoadSkill(1);
            }
            else if (deck.IsSlotFilled(0))
            {
                shooter.FireProjectile(deck.GetCardBulletID(0));
                deck.LoadSkill(0);
            }
            if (!deck.IsSlotFilled(0) && !deck.IsSlotFilled(1))
            {
                StartCoroutine(CombatShuffleDeck(shuffleTime));
            }
            else
            {
                StartCoroutine(ShotCooldown());
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
                audioManager.PlayMoveSFX();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && mover.vGridPosit < mover.vGridMax)
            {
                StartCoroutine(mover.MoveToGrid(0f, -mover.vDistance));
                mover.vGridPosit += 1;
                Debug.Log($"vpos: {mover.vGridPosit}");
                audioManager.PlayMoveSFX();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && mover.hGridPosit > 1)
            {
                StartCoroutine(mover.MoveToGrid(-mover.hDistance, 0f));
                mover.hGridPosit -= 1;
                Debug.Log($"hpos: {mover.hGridPosit}");
                audioManager.PlayMoveSFX();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && mover.hGridPosit < mover.hGridMax)
            {
                StartCoroutine(mover.MoveToGrid(mover.hDistance, 0f));
                mover.hGridPosit += 1;
                Debug.Log($"hpos: {mover.hGridPosit}");
                audioManager.PlayMoveSFX();
            }
        }

        //testing stuff
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (deck.IsSlotFilled(0))
            {
                shooter.FireProjectile(deck.GetCardBulletID(0));
                deck.LoadSkill(0);
            }
        }
    }

    private IEnumerator CombatShuffleDeck(float timer)
    {
        canShoot = false;
        deck.EmptyDisplay();
        audioManager.PlayShuffle1SFX();
        Debug.Log("Shuffle Started");
        shuffleIcon.StartSpinning();
        yield return new WaitForSeconds(timer);
        deck.ShuffleDeck();
        canShoot = true;
        audioManager.PlayShuffle2SFX();
        Debug.Log("Shuffle ended");
        shuffleIcon.StopSpinning();
    }
    private IEnumerator ShotCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootTime);
        canShoot = true;
    }
}
