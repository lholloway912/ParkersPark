using UnityEngine;

public class UnpoweredWireBehavior : MonoBehaviour
{
    UnpoweredWireStats unpoweredWireS;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        unpoweredWireS = gameObject.GetComponent<UnpoweredWireStats>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PoweredWireStats>())
        {
            PoweredWireStats poweredWireS = collision.GetComponent<PoweredWireStats>();
            if (poweredWireS.objectColor == unpoweredWireS.objectColor)
            {
                poweredWireS.connected = true;
                unpoweredWireS.connected = true;
                poweredWireS.connectedPosition = gameObject.transform.position;
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PoweredWireStats>())
        {
            PoweredWireStats poweredWireS = collision.GetComponent<PoweredWireStats>();
            poweredWireS.connected = false;
            unpoweredWireS.connected = false;
        }
    }
}
