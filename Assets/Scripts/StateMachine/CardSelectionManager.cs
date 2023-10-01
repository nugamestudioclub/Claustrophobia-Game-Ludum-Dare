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
    [SerializeField]
    private List<DiagramType> diagramTypes;
    [SerializeField]
    private List<CardItem> cards;
    

    private List<CardItem> shuffle(List<CardItem> cards,int size)
    {
        List<CardItem> newList = new List<CardItem>();
        for(int i = 0; i < size; i++)
        {
            int index = Random.Range(0,cards.Count - 1);
            newList.Add(cards[index]);
            cards.Remove(cards[index]);
        }
        return newList;
    }

    // Start is called before the first frame update
    void Start()
    {
        List<CardItem> randItems = shuffle(cards, 5);
        this.cardManager.CardRenderer(randItems);
        this.stateMachine.RegisterEnterStateEvent(GameStateManagement.GameState.Card, Show);
        this.stateMachine.RegisterExitStateEvent(GameStateManagement.GameState.Card, Hide);
        this.cardManager.HideCards();
        
    }
    void Show()
    {
        print("showing!");
        this.cardManager.RandomizeDiagrams(diagramTypes);
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
