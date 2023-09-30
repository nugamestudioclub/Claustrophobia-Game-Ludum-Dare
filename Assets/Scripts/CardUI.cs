using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private Canvas canvas;

    [SerializeField]
    GameObject cardPrefab;

    List<int> cardPosX = new List<int> { -200, -100, 0, 100, 200 };
    List<int> cardPosY = new List<int> { 170, 200, 210, 200, 170 };
    List<int> cardRotZ = new List<int> { 20, 10, 0, -10, -20 };

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindObjectOfType<Canvas>();
        CardRenderer();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Renders the card in the UI
    void CardRenderer()
    {
        for (var i = 0; i < 5; i++)
        {
            GameObject card = Instantiate(cardPrefab, canvas.transform);
            card.transform.localPosition = new Vector3(cardPosX[i], cardPosY[i], 0);
            card.transform.Rotate(0, 0, cardRotZ[i], Space.Self);
        }

    }
}
