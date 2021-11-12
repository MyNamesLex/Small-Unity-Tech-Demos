using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject text = GameObject.Find("Canvas");
        text.transform.GetChild(0).gameObject.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject text = GameObject.Find("Canvas");
        text.transform.GetChild(0).gameObject.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(0);
        }
    }
}
