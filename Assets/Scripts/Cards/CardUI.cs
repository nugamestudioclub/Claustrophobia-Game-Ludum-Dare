using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    GameObject cardPrefab;
    [SerializeField]
    private float xOffset;
    [SerializeField]
    private float yOffset;
    [SerializeField]
    private PlacementManager placement;

    List<int> cardPosX = new List<int> { -200, -100, 0, 100, 200 };
    List<int> cardPosY = new List<int> { 170, 200, 210, 200, 170 };
    List<int> cardRotZ = new List<int> { 20, 10, 0, -10, -20 };

    private List<Button> cards = new List<Button>();
    private List<bool> shownStatus = new List<bool>();
    public List<bool> ShownStatus { get { return shownStatus; } }

    // Start is called before the first frame update
    void Start()
    {
        
        

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    // Renders the card in the UI
    public void CardRenderer(List<CardItem> chosenCards)
    {
        if (canvas == null)
        {
            canvas = GameObject.FindObjectOfType<Canvas>();
        }
        for (var i = 0; i < 5; i++)
        {
            GameObject card = Instantiate(cardPrefab, canvas.transform);
            card.transform.localPosition = new Vector3(cardPosX[i]+xOffset, cardPosY[i]+yOffset, 0);
            
            card.transform.Rotate(0, 0, cardRotZ[i], Space.Self);
            cards.Add(card.GetComponent<Button>());
            card.GetComponent<Button>().onClick.AddListener(Clicked);
            shownStatus.Add(false);
            card.GetComponent<CardRenderer>().LoadCard(chosenCards[i]);
        }

    }
    public void Clicked()
    {
        int sel = 0;
        for(int i = 0; i < cards.Count; i++)
        {
            if (cards[i].GetComponent<CardRenderer>().IsSelected)
            {
                sel = i;
            }
        }
        HideAllButOneCard(sel);
    }
    public void RandomizeDiagrams(List<DiagramType> diagrams)
    {
        
        foreach(Button b in cards)
        {
            DiagramType type = diagrams[Random.Range(0, diagrams.Count)];
            b.GetComponent<CardRenderer>().diagramType= type;
            b.GetComponent<CardRenderer>().CardInfo.Diagram = type;
        }
    }

    public void ShowCards()
    {
        gameObject.GetComponent<CardSound>().CardsOpen();
        int counter = 0;
        foreach(Button b in cards)
        {
            b.GetComponent<CardRenderer>().Show();
            b.interactable = true;
            shownStatus[counter] = true;
            counter++;   
        }
    }
    public void HideCards()
    {
        foreach (Button b in cards)
        {
            b.GetComponent<CardRenderer>().Hide();
            b.interactable = false;
            shownStatus[cards.IndexOf(b)] = false;
        }
    }
    public void HideCard(int i)
    {
        if (i < 0 || i >= cards.Count)
        {
            return;
        }
        shownStatus[i] = false;
        this.cards[i].GetComponent<CardRenderer>().Hide();
        this.cards[i].GetComponent<CardRenderer>().PlayFadeAnimation();
        
    }
    public void HideAllButOneCard(int exception)
    {
        gameObject.GetComponent<CardSound>().CardPick();
        for (int i = 0; i < cards.Count; i++)
        {
            if (i != exception)
            {
                
                cards[i].GetComponent<CardRenderer>().Hide();
                cards[i].GetComponent<Button>().interactable = false;
                shownStatus[i] = false;
            }
            else
            {
                shownStatus[i] = true;
            }
        }
    }


    public CardRenderer GetCard(int i)
    {
        return cards[i].GetComponent<CardRenderer>();
    }
}
