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

    public bool ctrlActive = true;
    private Vector2 targetLocation;
    public bool moving = false;

    [SerializeField] AnimationManager anim;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"vpos: {vGridPosit}");
        Debug.Log($"Zpos: {transform.position.z}");
    }

    // Update is called once per frame
    void Update()
    {
        /**if (ctrlActive)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && vGridPosit > 1)
            {
                StartCoroutine(MoveToGrid(0f, vDistance));
                vGridPosit -= 1;
                Debug.Log($"vpos: {vGridPosit}");
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && vGridPosit < vGridMax)
            {
                StartCoroutine(MoveToGrid(0f, -vDistance));
                vGridPosit += 1;
                Debug.Log($"vpos: {vGridPosit}");
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && hGridPosit > 1)
            {
                StartCoroutine(MoveToGrid(-hDistance, 0f));
                hGridPosit -= 1;
                Debug.Log($"hpos: {hGridPosit}");
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && hGridPosit < hGridMax)
            {
                StartCoroutine(MoveToGrid(hDistance, 0f));
                hGridPosit += 1;
                Debug.Log($"hpos: {hGridPosit}");
            }
        }*/
    }

    private void FixedUpdate()
    {
        if (moving == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetLocation, hDistance / 2);
        }
    }

    public IEnumerator MoveToGrid(float xMove, float yMove)
    {
        targetLocation = new Vector2(transform.position.x + xMove, transform.position.y + yMove);
        anim.SetAnimationDirection(xMove, yMove);
        moving = true;
        ctrlActive = false;
        yield return new WaitForSeconds(moveInterval);
        anim.SetPoseNeutral();
        moving = false;
        ctrlActive = true;
        targetLocation = transform.position;
    }

    

    }
