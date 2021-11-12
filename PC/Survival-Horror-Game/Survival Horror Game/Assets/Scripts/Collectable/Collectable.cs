using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {

        if(Input.GetKeyDown("q"))
        {
            StartCoroutine(Wait());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Cursor.visible = false;
    }

    IEnumerator Wait()
    {
        CollectedCount coll = FindObjectOfType<CollectedCount>();
        while (true)
        {
            yield return new WaitForSeconds((float)(double)0.1);
            coll.Collected += 1;
            Cursor.visible = false;

            GameObject.Destroy(gameObject);

            Cursor.visible = false;
        }
    }
}
