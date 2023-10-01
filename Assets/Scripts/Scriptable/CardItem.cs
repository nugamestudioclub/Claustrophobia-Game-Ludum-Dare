using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewCard", menuName = "Cards/Create New Card", order = 1)]
public class CardItem : ScriptableObject
{
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private string title;
    [SerializeField]
    private string description;

    [SerializeField]
    private MentalEffect effect;
    [SerializeField]
    [Tooltip("The value when not magnified")]
    private float defaultMagnitude;

    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    public DiagramType Diagram;

    public Sprite Sprite { get { return sprite; }  }
    public string Title { get { return title; } }
    public string Description { get { return description; } }
    public GameObject Prefab { get { return prefab; } }
    public MentalEffect EffectType { get { return effect; } }
    
}
public enum MentalEffect {Personal, Historical, Confusing };

