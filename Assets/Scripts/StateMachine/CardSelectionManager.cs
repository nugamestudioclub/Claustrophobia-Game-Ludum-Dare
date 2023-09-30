using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class CardSelectionManager : IStateManager
{
    [SerializeField]
    private Card cardManager;
    [SerializeField]
    private PlacementManager placement;
    
   
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
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(this.stateMachine.CurrentState!= GameStateManagement.GameState.Card)
        {
            return;
        }
        int count = 0;
        foreach(bool b in this.cardManager.ShownStatus)
        {
            count += b ? 1 : 0;
        }
        
        if(count == 1)
        {
            this.stateMachine.Next();
        }
    }
}
