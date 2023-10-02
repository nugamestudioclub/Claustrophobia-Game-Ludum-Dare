using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManagerScuffed : MonoBehaviour
{

    [SerializeField]
    private AudioClip[] musicTracks;

    /*
    [SerializeField]
    private AudioClip mainTheme;
    */

    /*
    [SerializeField]
    private GameStateManagement.GameStateMachine gameStateMachine;
    */

    [SerializeField]
    private AudioSource musicSource;

    [SerializeField]
    private Scrollbar score;

    private bool isIntro;
    private int trackNum;
    private bool loop;

    private bool dead;

    // Start is called before the first frame update
    void Start()
    {
        loop = true;
        dead = false;
        trackNum = 0;
        musicSource.clip = musicTracks[trackNum];
        StartCoroutine(PlayMusic());
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            musicSource.Stop();
        }
        else if (score.size >= 0.6 && trackNum < 5)
        {
            loop = false;
            trackNum = 5;    
        }
        else if (score.size >= 0.4 && trackNum < 3)
        {
            loop = false;
            trackNum = 3;
        }
        else if (score.size >= 0.25 && trackNum < 1)
        {
            loop = false;
            trackNum = 1;
        }
        /*
        if (gameStateMachine.CurrentState.Equals(GameStateManagement.GameState.Intro)) {
            isIntro = true;

        } else
        {
            isIntro = false;
        }
        //musicSource.loop = true;
        musicSource.PlayOneShot(mainTheme, 0.7f);
        */
    }

    IEnumerator PlayMusic()
    {
        musicSource.clip = musicTracks[trackNum];
        musicSource.Play();
        yield return new WaitForSeconds(musicSource.clip.length - (1.5f * Time.deltaTime));
        if (loop == true)
        {
            StartCoroutine(PlayMusic());
        } 
        else
        {
            musicSource.clip = musicTracks[trackNum];
            if (trackNum % 2 == 0)
            {
                loop = true;
                trackNum++;
            }
            StartCoroutine(PlayMusic());
        }
    }

    public void SetDead()
    {
        dead = true;
    }

    void transitionLevelTwo()
    {

    }

    void transitionLevelThree()
    {

    }
}
