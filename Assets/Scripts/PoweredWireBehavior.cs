using UnityEngine;

public class PoweredWireBehavior : MonoBehaviour
{
    bool mouseDown = false;
    public PoweredWireStats powerWireS;
    LineRenderer line;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        powerWireS = gameObject.GetComponent<PoweredWireStats>();
        line = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveWire();
        line.SetPosition(3, new Vector3(gameObject.transform.position.x - .1f, gameObject.transform.position.y - .1f, gameObject.transform.position.z));
        line.SetPosition(2, new Vector3(gameObject.transform.position.x - .4f, gameObject.transform.position.y - .1f, gameObject.transform.position.z));
    }
    void OnMouseDown()
    {
        mouseDown = true;
    }
    void OnMouseOver()
    {
        powerWireS.movable = true;
    }
    void OnMouseExit()
    {
        if (!powerWireS.moving)
            powerWireS.movable = false;
    }
    void OnMouseUp()
    {
        mouseDown = false;
        if(!powerWireS.connected)
        gameObject.transform.position = powerWireS.startPosition;
        if (powerWireS.connected)
            gameObject.transform.position = powerWireS.connectedPosition;
    }
    void MoveWire()
    {
        // if mouse is down and movable then i can move my wire and if not then its not moving
        if (mouseDown && powerWireS.movable)
        {
            powerWireS.moving = true;
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;

            gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 1));
           // skipped parent transform position thats in video here because it moved the wire behind the background, may cause problems later

        }
        else
            powerWireS.moving = false;
    }
}
