using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerRenderer : MonoBehaviour
{
    [SerializeField]
    private TMP_Text dialogText;
    [SerializeField]
    private GameObject dialogBox;
    [SerializeField]
    private PatientInfo selected;

    public void ChooseRandomGood()
    {
        this.dialogBox.gameObject.SetActive(true);
        int sel = Random.Range(0, selected.GoodDialogs.Count);
        this.dialogText.text = selected.GoodDialogs[sel];
    }
    public void ChooseRandomBad()
    {
        this.dialogBox.gameObject.SetActive(true);
        int sel = Random.Range(0, selected.BadDialogs.Count);
        this.dialogText.text = selected.BadDialogs[sel];
    }
    public void ChooseRandomCrazy()
    {
        this.dialogBox.gameObject.SetActive(true);
        int sel = Random.Range(0, selected.CrazyDialogs.Count);
        this.dialogText.text = selected.CrazyDialogs[sel];
    }
    // Start is called before the first frame update
    void Start()
    {
        this.dialogBox.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

