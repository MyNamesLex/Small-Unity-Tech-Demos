using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewPlayerMovement : MonoBehaviour
{
    public GameObject[] pauseObjects;

    //CharacterController Controller;
    public Rigidbody rb;

    public float Speed;

    public Transform Cam;

    // Start is called before the first frame update
    void Start()
    {
       //Controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        float Horizontal = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float Vertical = Input.GetAxis("Vertical") * Speed * Time.deltaTime;

        Vector3 Movement = Cam.transform.right * Horizontal + Cam.transform.forward * Vertical;
        Movement.y = 0f;

        transform.Translate(Horizontal, 0, Vertical);

        if (Movement.magnitude != 0f)
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Cam.GetComponent<NewCameraController>().sensivity * Time.deltaTime);

            Quaternion CamRotation = Cam.rotation;
            CamRotation.x = 0f;
            CamRotation.z = 0f;

            transform.rotation = Quaternion.Lerp(transform.rotation, CamRotation, 0.1f);
        }


        //CONTROLS


        CollectedCount collectable = FindObjectOfType<CollectedCount>();

        if (collectable.Collected == collectable.Amount)
        {
            SceneManager.LoadScene(3);
        }

        if (Input.GetKeyDown("p"))
        {
            if (Time.timeScale == 1)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Cursor.visible = false;

                Time.timeScale = 1;
                hidePaused();
            }
        }
    }
    private void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    private void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }
}

