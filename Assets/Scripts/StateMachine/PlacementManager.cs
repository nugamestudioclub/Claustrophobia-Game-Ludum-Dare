using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : IStateManager
{
    [SerializeField]
    public Card cardui;
    private int selectedCard = -1;

    public void Show()
    {
        //print(cardui.ShownStatus);
        selectedCard = cardui.ShownStatus.IndexOf(true);
        
        CardRenderer card = cardui.GetCard(selectedCard);
        print("selected:" + card.CardInfo.Title);
       
    }
    public void Hide()
    {
        selectedCard = cardui.ShownStatus.IndexOf(true);
        //cardui.HideCard(selectedCard);
    }

    // Start is called before the first frame update
    void Start()
    {
        this.stateMachine.RegisterEnterStateEvent(GameStateManagement.GameState.Placement, Show);
        this.stateMachine.RegisterExitStateEvent(GameStateManagement.GameState.Placement, Hide);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
