using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource shuffle1;
    [SerializeField] AudioSource shuffle2;

    [SerializeField] AudioSource move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Play(AudioSource audio)
    {
        if (audio != null)
        {
            audio.Play();
        }
    }
    public void PlayShuffle1SFX()
    {
        Play(shuffle1);
    }
    public void PlayShuffle2SFX()
    {
        Play(shuffle2);
    }
    public void PlayMoveSFX()
    {
        Play(move);
    }
}
