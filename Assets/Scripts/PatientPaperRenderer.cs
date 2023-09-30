using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

    public void LoadPatient(PatientInfo patient)
    {
        this.patient = patient;
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
        }
    }
}
