using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameStateManagement;

public class ClickOnTile : MonoBehaviour
{
    [SerializeField]
    private GameObject objectPrefab;
    [SerializeField] 
    private float gridIncrement = 2;
    [SerializeField]
    private Vector3 gridOffset = Vector3.zero;
    [SerializeField]
    private int gridSize = 5;
    [SerializeField]
    private GameObject grid;
    [SerializeField]
    private GameObject sensor;


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
        if (GameStateMachine.Instance.CurrentState == GameState.Placement)
        {
            if (Input.GetMouseButtonDown(0)&&!sensor.GetComponent<SensorComponent>().triggered)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100) && (hit.collider.gameObject.tag == "TileMap"))
                {
                    Vector3 hitPoint = hit.point;
                    hitPoint /= gridIncrement;
                    Vector3 rounded = Vector3Int.RoundToInt(hitPoint);
                    rounded *= gridIncrement;
                    rounded += gridOffset;
                    Instantiate(objectPrefab, new Vector3(rounded.x, 1.002f, rounded.z), Quaternion.identity);
                }
            }
            else
            {
                sensor.gameObject.SetActive(true);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100) && (hit.collider.gameObject.tag == "TileMap"))
                {
                    Vector3 hitPoint = hit.point;
                    hitPoint /= gridIncrement;
                    Vector3 rounded = Vector3Int.RoundToInt(hitPoint);
                    rounded *= gridIncrement;
                    rounded += gridOffset;
                    sensor.transform.position = new Vector3(rounded.x, 1.002f, rounded.z);
                }
            }
        }
    }

}
