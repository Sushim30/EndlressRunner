using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgorithmicGeneration : MonoBehaviour
{
    public GameObject pathPrefab;
    public int GenerateDistance = 80;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            Instantiate(pathPrefab, new Vector3(0,0,transform.position.z +GenerateDistance), Quaternion.identity);
        }
        if (other.CompareTag("Destroy"))
        {
            Destroy(other.transform.parent.gameObject);
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
