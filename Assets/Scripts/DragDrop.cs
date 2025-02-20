using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragDrop : MonoBehaviour
{
    public GameObject gearToDrag;
    public GameObject ObjectDragToPos;

    public float Dropdistance;

    public bool Islocked;

    Vector2 objectInitPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectInitPos = gearToDrag.transform.position;
    }

    public void DragObject()
    {
        if(Islocked == false)
        {
            gearToDrag.transform.position = Input.mousePosition;

        }

    }
    public void DropObject()
    {
        float Distance = Vector3.Distance(gearToDrag.transform.position, ObjectDragToPos.transform.position);
        if(Distance < Dropdistance)
        {
            Islocked = true;
            gearToDrag.transform.position = ObjectDragToPos.transform.position;
        }
        else
        {
            gearToDrag.transform.position = objectInitPos;
        }
    }
    
    public void Win()
    {
        // needs another condition for it to trigger for all of the gears
        // also needs to trigger the gear turn animation (but idk how to add that in)

        // if (Islocked = true)
        // {
        //     SceneManager.LoadScene("Map");
        // }

    }

}
