using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [SerializeField] DeckUI deckUI;
    [SerializeField] BulletManager bulletManager;
    //insert list for main deck
    //insert list for active deck
    [Header("Card 01")]
    private Card card01;
    [SerializeField] string card01name;
    [SerializeField] int card01bullet;
    [Header("Card 02")]
    private Card card02;
    [SerializeField] string card02name;
    [SerializeField] int card02bullet;
    [Header("Card 03")]
    private Card card03;
    [SerializeField] string card03name;
    [SerializeField] int card03bullet;
    [Header("Card 04")]
    private Card card04;
    [SerializeField] string card04name;
    [SerializeField] int card04bullet;

    private Card[] mainDeck;
    private Card[] ActiveDeck;
    private void Awake()
    {
        //card01 = new Card(card01name, card01bullet);
        //card02 = new Card(card02name, card02bullet);
        //card03 = new Card(card03name, card03bullet);
        //card04 = new Card(card04name, card04bullet);
        mainDeck = new Card[4];
        mainDeck[0] = new Card(card01name, card01bullet);
        mainDeck[1] = new Card(card02name, card02bullet);
        mainDeck[2] = new Card(card03name, card03bullet);
        mainDeck[3] = new Card(card04name, card04bullet);
        ActiveDeck = new Card[mainDeck.Length];
        
    }
    // Start is called before the first frame update
    void Start()
    {
        //ShuffleDeck();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ShuffleDeck();
        }
    }

    public void ShuffleDeck()
    {
        EmptyDeck();
        UpdateDisplay();
        for(int i = 0; i < mainDeck.Length; i++)
        {
            int rnd = Random.Range(0, ActiveDeck.Length);
            if (ActiveDeck[rnd] == null)
            {
                ActiveDeck[rnd] = mainDeck[i];
            }
            else
            {
                i--;
            }
        }
        UpdateDisplay();
    }

    public void InitializeDeck()
    {
        for (int i = 0; i < mainDeck.Length; i++)
        {
            int rnd = Random.Range(0, ActiveDeck.Length);
            if (ActiveDeck[rnd] == null)
            {
                ActiveDeck[rnd] = mainDeck[i];
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
        if(ActiveDeck[0] != null) { 
            deckUI.SetSlotZ(ActiveDeck[0].GetName());
        }
        else
        {
            deckUI.SetSlotZ("Empty");
        }
        if (ActiveDeck[1] != null)
        {
            deckUI.SetSlotX(ActiveDeck[1].GetName());
        }
        else
        {
            deckUI.SetSlotX("Empty");
        }
        if (ActiveDeck[2] != null)
        {
            deckUI.SetSlotRes1(ActiveDeck[2].GetName());
        }
        else
        {
            deckUI.SetSlotRes1("Empty");
        }
        if (ActiveDeck[3] != null)
        {
            deckUI.SetSlotRes2(ActiveDeck[3].GetName());
        }
        else
        {
            deckUI.SetSlotRes2("Empty");
        }
    }

    public void SwapZSkill()
    {
        ActiveDeck[0] = ActiveDeck[2];
        ActiveDeck[2] = ActiveDeck[3];
        ActiveDeck[3] = null;
        UpdateDisplay();
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
}

public class Card
{
    public string name;
    public int bulletID;

    public Card(string cardname, int bullet)
    {
        name = cardname;
        bulletID = bullet;
    }

    public string GetName()
    {
        return name;
    }
}