using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icon : MonoBehaviour
{

    Vector2 targetLocation;
    private int state;
    //state 0 for neutral
    //state 1 for moving to a position
    //state 2 for being popped out
    public float hSpeed = 0.5f;
    public float vSpeed = 1f;
    private float currentVSpeed;
    public float gravity = 0.01f;
    public float fallingTime = 3f;
    private Image image;
    public float swapSpeed;
    public float rotationSpeed;
    private float currentSpin;
    // Start is called before the first frame update
    void Awake()
    {
        image = this.gameObject.GetComponent<Image>();
        Stop();
        Debug.Log($"Starting at {transform.position.x}, {transform.position.y}, {transform.position.z}");
        //Debug.Log($"Moving to {targetLocation.x}, {targetLocation.y}, {transform.position.z}");
        state = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (state == 1) {
            transform.position = Vector2.MoveTowards(transform.position, targetLocation, swapSpeed);
        }
        else if(state==2) { 
            transform.Translate(hSpeed, currentVSpeed, 0f,Space.World);
            currentVSpeed -= gravity;
            transform.Rotate(0f, 0f, currentSpin, Space.Self);
        }
        
    }

    public void MoveTo(Vector2 target)
    {
        targetLocation = target;
        state = 1;
        Debug.Log($"Starting at {transform.position.x}, {transform.position.y}, {transform.position.z}");
        Debug.Log($"Moving to {targetLocation.x}, {targetLocation.y}, {transform.position.z}");
    }

    public void SetPosition(Vector2 target)
    {
        transform.position = target;
        state = 0;
    }

    public void SetRotation(float angle)
    {
        transform.rotation = Quaternion.Euler(0f,0f,angle);
    }

    public void PopIconOut()
    {
        if (state != 2) {
            StopAllCoroutines();
            StartCoroutine(Iconfall());
        }
    }

    public void Stop()
    {
        targetLocation = transform.position;
        state = 0;
    }

    private IEnumerator Iconfall()
    {
        state = 2;
        currentVSpeed = vSpeed;
        float rnd = Random.Range(-rotationSpeed/2, rotationSpeed/2);
        currentSpin = rotationSpeed + rnd;
        yield return new WaitForSeconds(fallingTime);
        Stop();
    }

    public void setSprite(Sprite icon)
    {
        image.sprite = icon;
    }
}
