using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    private float score;
    private float pScore;
    public int Score { get { return Mathf.RoundToInt(score); } }
    [SerializeField]
    private PlayerRenderer player;
    [SerializeField]
    private BarControl scoreBar;
    [SerializeField]
    private Volume sceneVolume;
    [SerializeField]
    private PatientPaperRenderer paper;

    private Color currentColor;
    private Color targetColor;
    private Color goodColor = Color.black;
    private Color badColor = Color.red;

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
        float maxScore = 6;
        float percentileScore = this.score / maxScore;
        scoreBar.SetPoints(percentileScore);
        if (score >= maxScore)
        {
            
            this.paper.ShowFinalScore("<color=red>Deceased</color>", score);
            print("YOU LOSE!");
        }
        if (score >= 4)
        {
            this.player.ChooseRandomCrazy();
        }
        else
        {
            float diff = this.score - pScore;
            if (diff > 0)
            {
                this.player.ChooseRandomBad();
            }
            else
            {
                this.player.ChooseRandomGood();
            }
        }
       

        pScore = score;
    }
    public void WinGame()
    {
        string insaneString = "<color=green>Insane!</color>";
        string saneString = "<color=yellow>Sane</color>";
        if (score > 4)
            this.paper.ShowFinalScore(insaneString, score);
        else
            this.paper.ShowFinalScore(saneString, score);
    }
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Rendering.Universal.Vignette vignette;

        if (!sceneVolume.sharedProfile.TryGet(out vignette)) throw new System.NullReferenceException(nameof(vignette));
        vignette.color.SetValue(new ColorParameter(Color.black));
        targetColor = goodColor;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (score > 4)
        {
            UnityEngine.Rendering.Universal.Vignette vignette;

            if (!sceneVolume.sharedProfile.TryGet(out vignette)) throw new System.NullReferenceException(nameof(vignette));
            vignette.color.SetValue(new ColorParameter(currentColor));
            currentColor = Color.Lerp(currentColor, targetColor,Time.deltaTime*10f);
            if (currentColor == goodColor)
            {
                targetColor = badColor;
            }else if(currentColor == badColor)
            {
                targetColor = goodColor;
            }
        }
        else
        {
            UnityEngine.Rendering.Universal.Vignette vignette;

            if (!sceneVolume.sharedProfile.TryGet(out vignette)) throw new System.NullReferenceException(nameof(vignette));
            vignette.color.SetValue(new ColorParameter(goodColor));
        }

    }

    
}
