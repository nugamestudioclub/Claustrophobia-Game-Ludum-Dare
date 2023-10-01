using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    private int score;
    public int Score { get { return score; } }
    [SerializeField]
    private GameObject player;

    public void CalculateNewScore(List<SpawnableObjectComponent> reportedItems)
    {
        Dictionary<MentalEffect,int> typeCount = new Dictionary<MentalEffect,int>();
        typeCount.Add(MentalEffect.Confusing, 0);
        typeCount.Add(MentalEffect.Personal, 0);
        typeCount.Add(MentalEffect.Historical, 0);
        foreach(SpawnableObjectComponent item in reportedItems)
        {
            //Take in distance from player
            float dist = Vector3.Distance(item.transform.position, player.transform.position);
            print("Dist:"+dist);
            //Get type of each card
            CardItem card = item.correspondingCard;
            MentalEffect type = card.EffectType;
            typeCount[type] += 1;

        }
        //multiply

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
