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
    private int gridSize = 5;
    [SerializeField]
    private GameObject grid;
    

    [SerializeField]
    GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        grid.GetComponent<MeshRenderer>().materials[0].SetVector("_Tiling", Vector2.one * gridSize);
        grid.transform.localScale = Vector3.one* gridSize*gridIncrement;
        gridOffset = new Vector3(grid.transform.position.x-1, 0, grid.transform.position.z + 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
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
