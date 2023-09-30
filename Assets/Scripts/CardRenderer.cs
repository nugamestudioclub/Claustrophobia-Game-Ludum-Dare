using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardRenderer : MonoBehaviour
{

    [SerializeField]
    private float yMag = 5f;
    private Vector3 initPosition;
    private Vector3 lowPosition;
    private Vector3 currentPosition;
    
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
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(SetPrimary);
        
        initPosition = transform.position;
        currentPosition = initPosition;
        lowPosition = transform.position + (-transform.up*yMag);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(transform.position, currentPosition, Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(currentPosition!= initPosition)
            {
                currentPosition = initPosition;
            }
            else
            {
                currentPosition = lowPosition;
            }
        }
    }
}
