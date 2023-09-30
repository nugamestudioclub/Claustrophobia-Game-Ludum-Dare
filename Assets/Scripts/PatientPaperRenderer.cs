using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// Renders and animates the Patient Info Paper. If no patient is assigned it hides by defualt.
/// If there is a patient then you can set it to visible and have it animated both the patient info
/// and the paper.
/// </summary>
public class PatientPaperRenderer : MonoBehaviour
{
    [SerializeField]
    private PatientInfo patient;
    [SerializeField]
    private Image patientImage;
    [SerializeField]
    private TMP_Text personName;
    [SerializeField]
    private TMP_Text personDescription;

    private Animator anim;
    [SerializeField]
    private Animator folderAnim;

    public bool isVisible;

    public void LoadPatient(PatientInfo patient)
    {
        this.patient = patient;
    }
    private void Awake()
    {
        anim= GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(patient != null)
        {
            patientImage.sprite = patient.PatientSane;
            personName.text = patient.PatientName;
            personDescription.text = patient.PatientDescription;
            
            this.anim.SetBool("IsVisible", isVisible);
            
        }
        else
        {
            this.anim.SetBool("IsVisible", false);
        }
        
    }
}
