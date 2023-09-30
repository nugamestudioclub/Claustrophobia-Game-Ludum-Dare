using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnTile : MonoBehaviour
{
    [SerializeField] 
    private float gridIncrement = 2;
    [SerializeField]
    private Vector3 gridOffset = Vector3.zero;
    [SerializeField]
    private Material gridMaterial;

    [SerializeField]
    GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        gridMaterial.SetVector("_Tiling", Vector2.one * gridIncrement / 2);
        gridMaterial.SetVector("_Offset", gridOffset / 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100) && (hit.collider.gameObject.tag == "TileMap")) {
                Vector3 hitPoint = hit.point;
                hitPoint /= gridIncrement;
                Vector3 rounded = Vector3Int.RoundToInt(hitPoint);
                rounded *= gridIncrement;
                rounded += gridOffset;
                print(rounded);
                cube.transform.position = new Vector3(rounded.x, 1.002f, rounded.z);
            }
        }
    }
}
