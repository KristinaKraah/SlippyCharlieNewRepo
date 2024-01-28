using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    public GameObject ice;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
<<<<<<< Updated upstream
=======
            ice.GetComponent<Rigidbody>().isKinematic = false;
>>>>>>> Stashed changes
        }
    }
}
