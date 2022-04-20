using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaSystem : MonoBehaviour
{

    public float maxMP;
    public float currentMP;
    public float gainMPrate;
    private int intMP;
    [SerializeField] Slider manaSlider;
    [SerializeField] Text manaText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentMP >= maxMP)
        {
            currentMP = maxMP;
        }
        else
        {
            currentMP += gainMPrate*Time.deltaTime;
        }
        manaSlider.value = currentMP;
        intMP = (int)currentMP;
        manaText.text = $"{intMP}/{maxMP}";
    }

    public void changeMP(int change)
    {
        currentMP += change;
        if (currentMP <= 0) { currentMP = 0; }
        if(currentMP >= maxMP) { currentMP = maxMP; }
    }
}
