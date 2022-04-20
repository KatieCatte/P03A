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
    private Vector3 targetLocation;
    public bool moving = false;

    [SerializeField] AnimationManager anim;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"vpos: {vGridPosit}");
        Debug.Log($"Zpos: {transform.position.z}");
    }

    private void FixedUpdate()
    {
        if (moving == true)
        {
            float dist = Vector3.Distance(transform.position, targetLocation) / 2;
            if (dist > hDistance * 0.05) {
                transform.position = Vector3.MoveTowards(transform.position, targetLocation, dist);
            }
            else
            {
                transform.position = targetLocation;
                anim.SetPoseNeutral();
                moving = false;
                ctrlActive = true;
            }
        }
    }

    public IEnumerator MoveToGrid(float xMove, float yMove)
    {
        targetLocation = new Vector3(transform.position.x + xMove, transform.position.y + yMove, transform.position.z);
        anim.SetAnimationDirection(xMove, yMove);
        moving = true;
        ctrlActive = false;
        yield return new WaitForSeconds(moveInterval);
        
        //targetLocation = transform.position;
    }

    

    }
