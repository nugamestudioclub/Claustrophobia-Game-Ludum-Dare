using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroManager : IStateManager
{
    
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
    void Hide()
    {

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
