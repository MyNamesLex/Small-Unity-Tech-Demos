using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatThrow : MonoBehaviour
{
    public GameObject Dog;

    public void Awake()
    {
        Dog = FindObjectOfType<ARCursor>().dog;
        Vector3.MoveTowards(transform.position, Dog.transform.position, 5);
    }
    public void Update()
    {
        Dog = FindObjectOfType<ARCursor>().dog;
    }
}
