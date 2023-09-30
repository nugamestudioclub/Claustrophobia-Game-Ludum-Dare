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

    public string PatientName { get { return patientName; } }
    public string PatientDescription { get { return patientDescription; } }
    public Sprite PatientSane { get { return patientSane; } }
    public Sprite PatientSemiSane { get { return patientSemiSane; } }
    public Sprite PatientInsane { get { return patientInsane; } }
}
