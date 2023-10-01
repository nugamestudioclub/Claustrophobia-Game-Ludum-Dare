using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class SpawnableObjectComponent : MonoBehaviour
{
    [SerializeField] private GameObject ne;
    [SerializeField] private GameObject nw;
    [SerializeField] private GameObject se;
    [SerializeField] private GameObject sw;
    [SerializeField] private GameObject spriteRender;
    private CardItem loadedItem;
    public CardItem correspondingCard { get { return loadedItem; } }

    private Vector3 startPos;
    [SerializeField]
    private float yIntroHeight = 50f;

    public void LoadDiagram(DiagramType diagram, CardItem item)
    {
        ne.gameObject.SetActive(diagram.NorthEast);
        nw.gameObject.SetActive(diagram.NorthWest);
        se.gameObject.SetActive(diagram.SouthEast);
        sw.gameObject.SetActive(diagram.SouthWest);
        loadedItem = item;
        EffectsStateManager.Instance.Report(this);
        Vector3 averagePosition = Vector3.zero;
        if (diagram.NorthEast) averagePosition += ne.transform.localPosition;
        if (diagram.NorthWest) averagePosition += nw.transform.localPosition;
        if (diagram.SouthEast) averagePosition += se.transform.localPosition;
        if (diagram.SouthWest) averagePosition += sw.transform.localPosition;
        int count = 0;
        count += (diagram.NorthEast ? 1 : 0) + (diagram.NorthWest ? 1 : 0) + (diagram.SouthEast ? 1 : 0) + (diagram.SouthWest?1:0);
        averagePosition = averagePosition / count;
        averagePosition = new Vector3(averagePosition.x,spriteRender.transform.localPosition.y,averagePosition.z);
        spriteRender.transform.localPosition = averagePosition;
        spriteRender.GetComponent<SpriteRenderer>().sprite = item.Sprite;
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        transform.position = new Vector3(transform.position.x,startPos.y+yIntroHeight,transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, startPos, Time.deltaTime*5f);
    }
}
