using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardRenderer : MonoBehaviour
{

    [SerializeField]
    private float yMag = 5f;
    private Vector3 initPosition;
    private Vector3 lowPosition;
    private Vector3 currentPosition;

    [SerializeField]
    private CardItem cardInfo;
    [SerializeField]
    private TMP_Text title;
    [SerializeField]
    private Image cardImage;
    public CardItem CardInfo { get { return cardInfo; } }

    private bool isSelected = false;
    public bool IsSelected { get { return isSelected; } }
    public void SetPrimary()
    {
        this.transform.SetAsLastSibling();
    }

    public void Hide()
    {
        currentPosition = lowPosition;
    }
    public void Show()
    {
        currentPosition = initPosition;
    }

    public void SetSelected()
    {
        this.isSelected = true;
        print("Selected");
    }
    public void SetUnselected()
    {
        this.isSelected = false;
        print("Unselected");
    }
   
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(SetPrimary);
        
        initPosition = transform.position;
        lowPosition = transform.position + (-transform.up*yMag);
        currentPosition = lowPosition;
        this.title.text = cardInfo.Title;
        this.cardImage.sprite = cardImage.sprite;
        
    }
    public void ToggleShow()
    {
        if (currentPosition != initPosition)
        {
            currentPosition = initPosition;
        }
        else
        {
            currentPosition = lowPosition;
        }
    }
  

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(transform.position, currentPosition, Time.deltaTime);
        
    }
}
