using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CardSelectionManager : IStateManager
{
    [SerializeField]
    private Card cardManager;

    
   
    // Start is called before the first frame update
    void Start()
    {
        this.stateMachine.RegisterEnterStateEvent(GameStateManagement.GameState.Card, Show);
        this.stateMachine.RegisterExitStateEvent(GameStateManagement.GameState.Card, Hide);
        this.cardManager.HideCards();
    }
    void Show()
    {
        this.cardManager.ShowCards();
    }
    void Hide()
    {
        this.cardManager.HideCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
