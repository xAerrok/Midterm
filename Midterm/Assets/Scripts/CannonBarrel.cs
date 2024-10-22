using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBarrel : MonoBehaviour
{
    float angle = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        
        //Vector3 direction = mousePos2D - transform.position;

        angle = Mathf.Atan2(mousePos3D.y, mousePos3D.x) * Mathf.Rad2Deg;

        if (Mathf.Abs(angle-90) <= 85)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
    }
}
