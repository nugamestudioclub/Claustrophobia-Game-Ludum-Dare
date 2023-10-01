using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography;
using UnityEngine.SceneManagement;

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
    private Image outsidePatientImage;
    [SerializeField]
    private TMP_Text personName;
    [SerializeField]
    private TMP_Text personDescription;
    [SerializeField]
    private Button folderButton;
    [SerializeField]
    private Button returnButton;
    [SerializeField]
    private Button exitButton;

    [SerializeField]
    private TMP_Text patientStatus;
    [SerializeField]
    private TMP_Text patientScore;

    private Animator[] anims;



    public bool isVisible;

    public void LoadPatient(PatientInfo patient)
    {
        this.patient = patient;
    }
    private void Awake()
    {
        anims = this.transform.GetComponentsInChildren<Animator>();
       
    }

    // Start is called before the first frame update
    void Start()
    {
        folderButton.onClick.AddListener(OpenFolder);
        returnButton.onClick.AddListener(CloseFolder);
        exitButton.onClick.AddListener(ExitGame);
    }
    private void OpenFolder()
    {
        this.isVisible = true;
    }
    private void CloseFolder()
    {
        this.isVisible = false;
    }
    private void ExitGame()
    {
        Application.Quit();
    }

    public void ShowFinalScore(string status,float score)
    {
        
        this.OpenFolder();
        patientStatus.text = "\"Patient\" Status:"+status;
        patientScore.transform.parent.gameObject.SetActive(true);
        patientScore.text = "\"Patient\" Insanity:"+score.ToString();
        personDescription.gameObject.SetActive(false);
        returnButton.GetComponentInChildren<TMP_Text>().text = "Main Menu";
        returnButton.onClick.AddListener(GoHome);
    }
    void GoHome()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(patient != null)
        {
            patientImage.sprite = patient.PatientSane;
            outsidePatientImage.sprite = patient.PatientSane;
            personName.text = patient.PatientName;
            personDescription.text = patient.PatientDescription;
            foreach(Animator anim in anims)
            {
                anim.SetBool("IsVisible", isVisible);
            }
           
            
        }
        else
        {
            foreach (Animator anim in anims)
            {
                anim.SetBool("IsVisible", false);
            }
        }
        
        
    }
}
