using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableObjectComponent : MonoBehaviour
{
    [SerializeField] private GameObject ne;
    [SerializeField] private GameObject nw;
    [SerializeField] private GameObject se;
    [SerializeField] private GameObject sw;
    private CardItem loadedItem;
    public CardItem correspondingCard { get { return loadedItem; } }

    public void LoadDiagram(DiagramType diagram, CardItem item)
    {
        ne.gameObject.SetActive(diagram.NorthEast);
        nw.gameObject.SetActive(diagram.NorthWest);
        se.gameObject.SetActive(diagram.SouthEast);
        sw.gameObject.SetActive(diagram.SouthWest);
        loadedItem = item;
        EffectsStateManager.Instance.Report(this);
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
