using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckUI : MonoBehaviour
{
    [Header("Icon Slots")]
    [SerializeField] Image card_slot_X;
    [SerializeField] Image card_slot_Z;
    [SerializeField] Image card_slot_reserve_1;
    [SerializeField] Image card_slot_reserve_2; //oh there is definitely a better way to do this

    [Header("Icons")]
    [SerializeField] Sprite Icon_Empty;
    [SerializeField] Sprite Icon_Fire;
    [SerializeField] Sprite Icon_Ice;
    [SerializeField] Sprite Icon_Highbeam;
    [SerializeField] Sprite Icon_Beam;

    Dictionary<string, Sprite> icons = new Dictionary<string, Sprite>(); //there has GOT to be a better way to do this lmao
    // Start is called before the first frame update
    void Awake()
    {
        icons.Add("Fire", Icon_Fire);
        icons.Add("Ice", Icon_Ice);
        icons.Add("Highbeam", Icon_Highbeam);
        icons.Add("Beam", Icon_Beam);
        icons.Add("Empty", Icon_Empty);
        //card_slot_Z.sprite = Icon_Fire;
        /*SetSlotZ("Fire"); //these are just for testing. remove these for final version
        SetSlotX("Beam");
        SetSlotRes1("Highbeam");
        SetSlotRes2("Ice");*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSlotZ(string icon)
    {
        if (icons.ContainsKey(icon)) { 
            card_slot_Z.sprite = icons[icon];
        }
        else
        {
            card_slot_Z.sprite = icons["Empty"];
            Debug.Log("No data for Z skill icon");
        }
        
    }
    public void SetSlotX(string icon)
    {
        if (icons.ContainsKey(icon))
        {
            card_slot_X.sprite = icons[icon];
        }
        else
        {
            card_slot_X.sprite = icons["Empty"];
            Debug.Log("No data for X skill icon");
        }
    }
    public void SetSlotRes1(string icon)
    {
        if (icons.ContainsKey(icon))
        {
            card_slot_reserve_1.sprite = icons[icon];
        }
        else
        {
            card_slot_reserve_1.sprite = icons["Empty"];
            Debug.Log("No data for reserve icon 1");
        }
    }
    public void SetSlotRes2(string icon)
    {
        if (icons.ContainsKey(icon))
        {
            card_slot_reserve_2.sprite = icons[icon];
        }
        else
        {
            card_slot_reserve_2.sprite = icons["Empty"];
            Debug.Log("No data for reserve icon 2");
        }
    }
}
