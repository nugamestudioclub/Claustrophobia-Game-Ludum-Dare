using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorTrigger : MonoBehaviour
{
    private bool isTriggered = false;
    public bool IsTriggered { get { return isTriggered; } }
  
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Blocker"))
        {
            this.isTriggered = true;
            this.gameObject.GetComponent<MeshRenderer>().materials[0].SetColor("_BaseColor", Color.red);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Blocker"))
        {
            this.isTriggered = false;
            this.gameObject.GetComponent<MeshRenderer>().materials[0].SetColor("_BaseColor", Color.blue);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
