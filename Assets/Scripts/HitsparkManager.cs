using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitsparkManager : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 randomPosition;
    public float animInterval = 0.1f;
    [SerializeField] Sprite frame1;
    [SerializeField] Sprite frame2;
    [SerializeField] Sprite frame3;
    private SpriteRenderer ren;
    // Start is called before the first frame update
    void Awake()
    {
        startPosition = transform.position;
        ren = gameObject.GetComponent<SpriteRenderer>();
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(PlayAnimation());
    }

    private IEnumerator PlayAnimation()
    {
        ren.sprite = frame1;
        yield return new WaitForSeconds(animInterval);
        ren.sprite = frame2;
        yield return new WaitForSeconds(animInterval);
        ren.sprite = frame3;
        yield return new WaitForSeconds(animInterval);
        this.gameObject.SetActive(false);
    }

    //private Vector3 RandomizePosition()
    //{
        //
    //}
}
