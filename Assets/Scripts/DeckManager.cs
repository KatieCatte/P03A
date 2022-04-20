using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [SerializeField] DeckUI deckUI;
    [SerializeField] BulletManager bulletManager;

    [Header("Card 01")]
    private Card card01;
    [SerializeField] string card01name;
    [SerializeField] int card01bullet;
    [SerializeField] int card01cost;
    [Header("Card 02")]
    private Card card02;
    [SerializeField] string card02name;
    [SerializeField] int card02bullet;
    [SerializeField] int card02cost;
    [Header("Card 03")]
    private Card card03;
    [SerializeField] string card03name;
    [SerializeField] int card03bullet;
    [SerializeField] int card03cost;
    [Header("Card 04")]
    private Card card04;
    [SerializeField] string card04name;
    [SerializeField] int card04bullet;
    [SerializeField] int card04cost;

    //public Card[] mainDeck2 = new Card[4];
    //just make this a public array if you want a version that can have more things

    private Card[] mainDeck;
    private Card[] ActiveDeck;
    private int[] iconIndex;
    //use lists for the deck if you want to add cards
    //god I'd have to redo the whole icon system though

    private void Awake()
    {
        //card01 = new Card(card01name, card01bullet);
        //card02 = new Card(card02name, card02bullet);
        //card03 = new Card(card03name, card03bullet);
        //card04 = new Card(card04name, card04bullet);
        mainDeck = new Card[4];
        mainDeck[0] = new Card(card01name, card01bullet, card01cost);
        mainDeck[1] = new Card(card02name, card02bullet, card02cost);
        mainDeck[2] = new Card(card03name, card03bullet, card03cost);
        mainDeck[3] = new Card(card04name, card04bullet, card04cost);
        

        

        ActiveDeck = new Card[mainDeck.Length];

        /*iconIndex:
         * array that will connect each card in the deck to an icon
         * starting values - 0, 1, 2, 3
         * call the icon at [i]
         * starts out saying, icon 0 is at 0, but then after that, [0] will be 2
        */
        iconIndex = new int[4];
        for (int i = 0; i < iconIndex.Length; i++)
        {
            iconIndex[i] = i;
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        //ShuffleDeck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShuffleDeck()
    {
        EmptyDeck();
        UpdateDisplay();
        for(int i = 0; i < mainDeck.Length; i++)
        {
            int rnd = Random.Range(0, ActiveDeck.Length); //pick a random active deck slot
            if (ActiveDeck[rnd] == null) //if it isn't already full...
            {
                ActiveDeck[rnd] = mainDeck[i]; //assign card to active deck slot 
            }
            else
            {
                i--; //if the slot isn't empty, rewind, reroll for a slot that IS empty
            }

            //reset order of icon index values, too. set order of icons back to 0, 1, 2, 3
            for (int j = 0; j < iconIndex.Length; j++)
            {
                iconIndex[j] = j;
            }

        }
        deckUI.Refresh();
        UpdateDisplay();
    }

    public void InitializeDeck()
    {
        for (int i = 0; i < mainDeck.Length; i++)
        {
            int rnd = Random.Range(0, ActiveDeck.Length); //pick a random active deck slot
            if (ActiveDeck[rnd] == null) //if it isn't already full...
            {
                ActiveDeck[rnd] = mainDeck[i]; //assign card to active deck slot 
            }
            else
            {
                i--;
            }
        }
        UpdateDisplay();
    }
    private void EmptyDeck()
    {
        for(int i = 0; i < ActiveDeck.Length; i++)
        {
            ActiveDeck[i] = null;
        }
        Debug.Log("Active deck emptied");
    }

    private void UpdateDisplay()
    {
        for(int b = 0; b < ActiveDeck.Length; b++)
        {
            if (ActiveDeck[b] != null)
            {
                deckUI.SetSlot(b, ActiveDeck[b].GetName(), ActiveDeck[b].GetCost());
            }
            else
            {
                deckUI.SetSlot(b, "Null",0);
            }
        }

    }
    public void EmptyDisplay()
    {
        /*deckUI.SetSlot(0, "Null");
        deckUI.SetSlot(1, "Null");
        deckUI.SetSlot(2, "Null");
        deckUI.SetSlot(3, "Null");
        older version, do not use*/
        for(int a = 0; a < iconIndex.Length; a++)
        {
            deckUI.EmptySlot(a);
        }
        deckUI.EmptyMiniSlots();
    }

    //for testing
    public void LoadSkill(int slot) //only use 0 or 1 for this
    {
        deckUI.EmptySlot(iconIndex[slot]); //empty whatever icon is in slot 0 (using 0 as example)
        ActiveDeck[slot] = ActiveDeck[2]; //active card in slot 0 takes on value of slot 2 (it has to be slot 2, only valid slot for loading into 0 or 1
        if (ActiveDeck[2] != null) //if there was a card in slot 2-
        {
            deckUI.MoveSlot(iconIndex[2], slot); //move icon in index 2 to the slot that just got used
            iconIndex[slot] = iconIndex[2]; //icon index 0 gets the value of icon index 2; skill 2's icon is now icon 0, old icon 0 is just gone
        }
        ActiveDeck[2] = ActiveDeck[3]; //move card 3 to spot 2
        if (ActiveDeck[3] != null) //if there was a card in slot 3
        {
            deckUI.MoveSlot(iconIndex[3], 2); //move icon in index 2 to the slot that just got used
            iconIndex[2] = iconIndex[3]; //icon index 2 gets the value of icon index 3
            ActiveDeck[3] = null;
            iconIndex[3] = 0;
        } //if the deck's size is greater than 4 or unknown, this could probably be done as a for loop. Don't need it just yet for this small test deck though

        //this part is just for changing out the mini icons
        if (ActiveDeck[slot] != null) { 
            deckUI.SetMiniSlot(slot, ActiveDeck[slot].GetName()); 
        } else { deckUI.SetMiniSlot(slot, "Empty"); }
    }

    public void SwapXSkill()
    {
        ActiveDeck[1] = ActiveDeck[2];
        ActiveDeck[2] = ActiveDeck[3];
        ActiveDeck[3] = null;
        UpdateDisplay();
    }
    public int GetCardBulletID(int id)
    {
        return ActiveDeck[id].bulletID;
    }
    public bool IsSlotFilled(int id)
    {
        if(ActiveDeck[id] == null) {
            return false;
        }
        else { return true; }
    }

    public int CostOfSlot(int slot)
    {
        if (ActiveDeck[slot] != null)
        {
            return ActiveDeck[slot].GetCost();
        }
        else { return 0; }
    }
}

public class Card
{
    public string name;
    public int bulletID;
    public int cost;

    public Card(string cardname, int bullet, int MPcost)
    {
        name = cardname;
        bulletID = bullet;
        cost = MPcost;
    }

    public string GetName()
    {
        return name;
    }
    public int GetCost()
    {
        return cost;
    }
}