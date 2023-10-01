using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class SensorComponent : MonoBehaviour
{
    private SensorTrigger[] triggers;
    public bool triggered = false;
    [SerializeField]
    private Color goodColor = Color.blue;
    [SerializeField]
    private Color badColor = Color.red;
    [SerializeField]
    private CardItem loadedCard;
    // Start is called before the first frame update
    void Start()
    {
        triggers = this.GetComponentsInChildren<SensorTrigger>();
        foreach(SensorTrigger trigger in triggers)
        {
            trigger.goodColor = goodColor;
            trigger.badColor = badColor;
        }
        this.gameObject.SetActive(false);
    }

    public void LoadCard(CardItem card)
    {
        this.loadedCard= card;
        DiagramType diagram = this.loadedCard.Diagram;
        this.triggers[0].gameObject.SetActive(diagram.NorthWest);
        this.triggers[1].gameObject.SetActive(diagram.NorthEast);
        this.triggers[2].gameObject.SetActive(diagram.SouthWest);
        this.triggers[3].gameObject.SetActive(diagram.SouthEast);
    }

    // Update is called once per frame
    void Update()
    {
        if (loadedCard != null)
        {
            triggered = false;
            foreach (SensorTrigger trigger in triggers)
            {
                triggered = triggered || trigger.IsTriggered;
            }
        }
        
        
    }
}
