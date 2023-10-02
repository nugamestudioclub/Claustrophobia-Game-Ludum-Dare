using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerScuffed : MonoBehaviour
{

    [SerializeField]
    AudioClip[] musicTracks;

    [SerializeField]
    AudioClip mainTheme;

    [SerializeField]
    GameStateManagement.GameStateMachine gameStateMachine;

    [SerializeField]
    AudioSource musicSource;

    private bool isIntro;

    // Start is called before the first frame update
    void Start()
    {
        musicSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStateMachine.CurrentState.Equals(GameStateManagement.GameState.Intro)) {
            isIntro = true;

        } else
        {
            isIntro = false;
        }
        //musicSource.loop = true;
        musicSource.PlayOneShot(mainTheme, 0.7f);
    }
}
