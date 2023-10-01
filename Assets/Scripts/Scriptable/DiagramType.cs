using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sample Diagram", menuName = "Cards/Create New Diagram", order = 3)]
public class DiagramType : ScriptableObject
{
    [SerializeField]
    private bool northWest;
    [SerializeField]
    private bool northEast;
    [SerializeField]
    private bool southWest;
    [SerializeField]
    private bool southEast;
    [SerializeField]
    private Sprite image;
    public Sprite Image { get { return image; } }
    public bool NorthWest { get { return northWest; } }
    public bool NorthEast { get { return northEast; } }
    public bool SouthWest { get { return southWest; } }
    public bool SouthEast { get { return southEast; } }

    
}
