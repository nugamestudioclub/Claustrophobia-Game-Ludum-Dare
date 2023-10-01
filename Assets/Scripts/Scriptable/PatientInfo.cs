using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Cards/Create a new Patient", order = 1)]
public class PatientInfo : ScriptableObject
{
    [SerializeField]
    private string patientName;
    [SerializeField]
    private string patientDescription;
    [SerializeField]
    private Sprite patientSane;
    [SerializeField]
    private Sprite patientSemiSane;
    [SerializeField]
    private Sprite patientInsane;
    [SerializeField]
    private List<string> goodDialogs = new List<string>();
    [SerializeField]
    private List<string> badDialogs = new List<string>();
    [SerializeField]
    private List<string> crazyDialogs = new List<string>();
    
    public string PatientName { get { return patientName; } }
    public string PatientDescription { get { return patientDescription; } }
    public Sprite PatientSane { get { return patientSane; } }
    public Sprite PatientSemiSane { get { return patientSemiSane; } }
    public Sprite PatientInsane { get { return patientInsane; } }

    public List<string> BadDialogs { get { return badDialogs;} }
    public List<string> CrazyDialogs { get { return crazyDialogs;} }
    public List<string> GoodDialogs { get { return goodDialogs;} }
    
}
