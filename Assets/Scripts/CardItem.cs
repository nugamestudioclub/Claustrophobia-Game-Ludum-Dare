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

    public Sprite Sprite { get { return sprite; }  }
    public string Title { get { return title; } }
    public string Description { get { return description; } }
}
