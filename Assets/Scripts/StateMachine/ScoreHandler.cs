using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    private float score;
    public int Score { get { return Mathf.RoundToInt(score); } }
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private BarControl scoreBar;

    float distWeight(float dist)
    {
        if (dist <= 2)
        {
            return 2;
        }else if (dist <= 3)
        {
            return 1;
        }
        else
        {
            return 0.5f;
        }
    }

    public void CalculateNewScore(List<SpawnableObjectComponent> reportedItems)
    {
        score = 0;
        Dictionary<MentalEffect,int> typeCount = new Dictionary<MentalEffect,int>();
        typeCount.Add(MentalEffect.Confusing, 0);
        typeCount.Add(MentalEffect.Personal, 0);
        typeCount.Add(MentalEffect.Historical, 0);
        foreach(SpawnableObjectComponent item in reportedItems)
        {
            
            //Get type of each card
            CardItem card = item.correspondingCard;
            MentalEffect type = card.EffectType;
            typeCount[type] += 1;

        }
        //multiply
        foreach(SpawnableObjectComponent item in reportedItems)
        {
            //Take in distance from player
            float dist = Vector3.Distance(item.transform.position, player.transform.position);
            dist = distWeight(dist);
            this.score += dist * typeCount[item.correspondingCard.EffectType];
        }
        float maxScore = 10;
        float percentileScore = this.score / maxScore;
        scoreBar.SetPoints(percentileScore);


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
