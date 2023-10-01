using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ScoreHandler : MonoBehaviour
{
    private float score;
    public int Score { get { return Mathf.RoundToInt(score); } }
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private BarControl scoreBar;
    [SerializeField]
    private Volume sceneVolume;

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
            this.score += dist * typeCount[item.correspondingCard.EffectType]*item.correspondingCard.DefaultMagnitude;
        }
        float maxScore = 10;
        float percentileScore = this.score / maxScore;
        scoreBar.SetPoints(percentileScore);
        if (score >= maxScore)
        {

        }

    }
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Rendering.Universal.Vignette vignette;

        if (!sceneVolume.sharedProfile.TryGet(out vignette)) throw new System.NullReferenceException(nameof(vignette));
        vignette.color.SetValue(new ColorParameter(Color.black));
    }

    // Update is called once per frame
    void Update()
    {
        
        if (score > 6)
        {
            UnityEngine.Rendering.Universal.Vignette vignette;

            if (!sceneVolume.sharedProfile.TryGet(out vignette)) throw new System.NullReferenceException(nameof(vignette));
            vignette.color.SetValue(new ColorParameter(Color.red));
        }

    }

    
}
