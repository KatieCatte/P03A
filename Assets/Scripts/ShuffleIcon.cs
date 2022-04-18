using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleIcon : MonoBehaviour
{

    [SerializeField] float spinSpeed;
    private float activeSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        activeSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, activeSpeed);
    }

    public void StartSpinning()
    {
        activeSpeed = spinSpeed;
        Debug.Log("Wheel spinning");
    }
    public void StopSpinning()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        activeSpeed = 0f;
        Debug.Log("Wheel stopped");
    }
}
