using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : IStateManager
{
    [SerializeField]
    public Card cardui;
    [SerializeField]
    private SensorComponent sensor;
    [SerializeField]
    private ClickOnTile clicker;
    private int selectedCard = -1;

    public void Show()
    {
        
        
        selectedCard = cardui.ShownStatus.IndexOf(true);
        
        CardRenderer card = cardui.GetCard(selectedCard);
        
        sensor.LoadCard(card.CardInfo);
        clicker.SetCard(card.CardInfo);
       
    }
    public void Hide()
    {
        selectedCard = cardui.ShownStatus.IndexOf(true);
        cardui.HideCard(selectedCard);
        sensor.gameObject.SetActive(false);
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
