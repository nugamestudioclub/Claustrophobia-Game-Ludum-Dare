using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSound : MonoBehaviour
{
    [SerializeField]
    AudioClip[] clips;


    AudioSource source;

    void Start()
    {
        source = GameObject.Find("CardsAudioSource").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CardFlip()
    {
        source.PlayOneShot(clips[0], 0.9f);
    }


    public void CardPick()
    {
        source.PlayOneShot(clips[1], 0.7f);
    }

    public void CardsOpen()
    {
        source.PlayOneShot(clips[2], 0.7f);
    }

    public void CardsClose()
    {
        source.PlayOneShot(clips[3], 0.7f);
    }


}
