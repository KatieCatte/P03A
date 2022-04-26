using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    bool canShoot = true;
    [SerializeField] DeckManager deck;
    [SerializeField] BulletManager shooter;
    [SerializeField] PlayerMovement mover;
    [SerializeField] AudioManager audioManager;
    [SerializeField] ShuffleIcon shuffleIcon;
    [SerializeField] ManaSystem mana;
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
                FireSlot(0);
            }
            else if (deck.IsSlotFilled(1))
            {
                FireSlot(1);
            }
            if(!deck.IsSlotFilled(0) && !deck.IsSlotFilled(1))
            {
                StartCoroutine(CombatShuffleDeck(shuffleTime));
            }
            else
            {
                StartCoroutine(ShotCooldown(shootTime));
            }
            
        }
        if (Input.GetKeyDown(KeyCode.X) && canShoot)
        {
            if (deck.IsSlotFilled(1))
            {
                FireSlot(1);
            }
            else if (deck.IsSlotFilled(0))
            {
                FireSlot(0);
            }
            if (!deck.IsSlotFilled(0) && !deck.IsSlotFilled(1))
            {
                StartCoroutine(CombatShuffleDeck(shuffleTime));
            }
            else
            {
                StartCoroutine(ShotCooldown(shootTime));
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(0);
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
    private IEnumerator ShotCooldown(float time)
    {
        canShoot = false;
        yield return new WaitForSeconds(time);
        canShoot = true;
    }

    private void FireSlot(int slot)
    {
        if (mana.currentMP >= deck.CostOfSlot(slot))
        {
            shooter.FireProjectile(deck.GetCardBulletID(slot));
            mana.changeMP(-deck.CostOfSlot(slot));
            deck.LoadSkill(slot);
            
        }
        else
        {
            audioManager.PlayShuffle2SFX();
        }
    }
}
