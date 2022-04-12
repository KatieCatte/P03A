using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Grid Information")]
    public float vDistance = 1.2f;
    public float hDistance = 1.7f;
    public int vGridPosit = 1;
    public int hGridPosit = 1;
    public int vGridMax = 4;
    public int hGridMax = 4;
    public float moveInterval = 0.2f;
    private float hSpeed = 0f;
    private float vSpeed = 0f;

    private bool ctrlActive = true;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"vpos: {vGridPosit}");
        Debug.Log($"Zpos: {transform.position.z}");
    }

    // Update is called once per frame
    void Update()
    {
        if (ctrlActive)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && vGridPosit > 1)
            {
                transform.Translate(0f, vDistance, -0f);
                vGridPosit -= 1;
                Debug.Log($"vpos: {vGridPosit}");
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && vGridPosit < vGridMax)
            {
                transform.Translate(0f, -vDistance, 0f);
                vGridPosit += 1;
                Debug.Log($"vpos: {vGridPosit}");
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && hGridPosit > 1)
            {
                transform.Translate(-hDistance, 0f, 0f);
                hGridPosit -= 1;
                Debug.Log($"hpos: {hGridPosit}");
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && hGridPosit < hGridMax)
            {
                transform.Translate(hDistance, 0f, 0f);
                hGridPosit += 1;
                Debug.Log($"hpos: {hGridPosit}");
            }
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(hSpeed * Time.deltaTime, vSpeed, 0f) ;
    }

    private IEnumerator MoveHorizontal(float dist)
    {
        ctrlActive = false;
        hSpeed = dist * hDistance / moveInterval;
        yield return new WaitForSeconds(moveInterval);
        hSpeed = 0f;
        ctrlActive = true;
    }
}
