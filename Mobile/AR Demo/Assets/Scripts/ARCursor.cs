using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ARCursor : MonoBehaviour
{
    [Header("Objects")]
    public GameObject dog;
    public GameObject treat;
    [Header("Cursor")]
    public GameObject cursorChildObject;
    public bool useCursor = true;
    public ARRaycastManager raycastmanager;

    [Header("Equipped")]
    public TextMeshProUGUI CurrentEquipped;
    public int EquipCount;

    [Header("Swipes")]
    private Vector2 fp;
    private Vector2 lp;

    [Header("Dog")]
    public bool DogPlaced = false;
    public TextMeshProUGUI TreatText;

    [Header("Debug")]
    public TextMeshProUGUI DebugText;
    // Start is called before the first frame update
    void Start()
    {
        cursorChildObject.SetActive(useCursor);
    }

    // Update is called once per frame
    void Update()
    {
        if (useCursor)
        {
            UpdateCursor();
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !DogPlaced)
        {
            if(!useCursor)
            {
                List<ARRaycastHit> hits = new List<ARRaycastHit>();
                raycastmanager.Raycast(Input.GetTouch(0).position, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
                if(hits.Count > 0)
                {
                    DogPlaced = true;
                    DebugText.text = "Placed Dog";
                    GameObject.Instantiate(dog, hits[0].pose.position, hits[0].pose.rotation);
                }
            }
        }
        if (Input.GetTouch(0).phase == TouchPhase.Began && DogPlaced)
        {
            fp = Input.GetTouch(0).position;
            lp = Input.GetTouch(0).position;
        }
        if (Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            lp = Input.GetTouch(0).position;
        }
        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            if ((fp.x - lp.x) > 80) // left swipe
            {
                CurrentEquipped.text = ("left swipe here...");
            }
            else if ((fp.x - lp.x) < -80) // right swipe
            {
                CurrentEquipped.text = ("right swipe here...");
            }
            else if ((fp.y - lp.y) < -80) // up swipe
            {
                CurrentEquipped.text = ("up swipe here...");
                if (DogPlaced == true)
                {
                    DogPlaced = true;
                    List<ARRaycastHit> hits = new List<ARRaycastHit>();
                    raycastmanager.Raycast(Input.GetTouch(0).position, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
                    if (hits.Count > 0)
                    {
                        GameObject.Instantiate(treat, hits[0].pose.position, hits[0].pose.rotation);
                    }
                }
            }
            else if ((fp.y - lp.y) > 80) // down swipe
            {
                CurrentEquipped.text = ("down swipe here...");
            }
        }
    }

    public void UpdateCursor()
    {
        Vector3 screenPosition = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raycastmanager.Raycast(screenPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
        }
    }
}
