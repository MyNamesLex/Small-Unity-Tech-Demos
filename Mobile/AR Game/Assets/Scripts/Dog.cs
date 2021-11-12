using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dog : MonoBehaviour
{
    public int TreatCount;

    public void Awake()
    {
         FindObjectOfType<ARCursor>().TreatText.text = "Treats Given: ";
    }

    public void Update()
    { 

    }
    public void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<ARCursor>().DebugText.text = "Detected Object";
        if (other.gameObject.tag == "DogTreat")
        {
            FindObjectOfType<ARCursor>().DebugText.text = "Given Treat";
            TreatCount++;
            FindObjectOfType<ARCursor>().TreatText.text = "Treats Given: " + TreatCount;
            Destroy(other.gameObject);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        FindObjectOfType<ARCursor>().DebugText.text = "Detected Object Trigger Stay";
        if (other.gameObject.tag == "DogTreat")
        {
            FindObjectOfType<ARCursor>().DebugText.text = "Given Treat Trigger Stay";
            TreatCount++;
            FindObjectOfType<ARCursor>().TreatText.text = "Treats Given: " + TreatCount;
            Destroy(other.gameObject);
        }
    }
}
