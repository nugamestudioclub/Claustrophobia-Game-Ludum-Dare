using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacingSounds : MonoBehaviour
{
    AudioSource source;

    [SerializeField]
    AudioClip[] clips;

    // Start is called before the first frame update
    void Start()
    {
        source = GameObject.Find("MovingObjectAudioSource").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ObjectMove()
    {
        source.PlayOneShot(clips[0], 0.7f);
    }
}
