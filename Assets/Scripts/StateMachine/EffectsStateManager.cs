using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsStateManager : IStateManager
{
    private List<SpawnableObjectComponent> reportedItems = new List<SpawnableObjectComponent>();

    public static EffectsStateManager Instance;

    [SerializeField]
    private ScoreHandler score;

    private void Awake()
    {
        Instance = this;
    }

    public void Report(SpawnableObjectComponent item)
    {
        this.reportedItems.Add(item);
        
    }

    public void Show()
    {
        score.CalculateNewScore(reportedItems);
        StartCoroutine(WaitForEffect());
    }
    private IEnumerator WaitForEffect()
    {
        if (reportedItems.Count >= 5)
        {
            score.WinGame();
        }
        yield return new WaitForSeconds(10);
        this.stateMachine.Next();
    }
    public void Hide()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        this.stateMachine.RegisterEnterStateEvent(GameStateManagement.GameState.Effect,Show);
        this.stateMachine.RegisterExitStateEvent(GameStateManagement.GameState.Effect, Hide);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
