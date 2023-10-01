using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroManager : IStateManager
{
    [SerializeField]
    private GameObject fade;

    // Start is called before the first frame update
    void Start()
    {
        GameStateManagement.GameState state = this.stateMachine.CurrentState;
        this.stateMachine.RegisterEnterStateEvent(GameStateManagement.GameState.Intro,Show);
        this.stateMachine.RegisterExitStateEvent(GameStateManagement.GameState.Intro, Hide);
    }

    void Show()
    {

    }
    public void Hide()
    {
        fade.GetComponent<FadeOut>().ChangeFade();
        
    }


    // Update is called once per frame
    void Update()
    {

    }
}
