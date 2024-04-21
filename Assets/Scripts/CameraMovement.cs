using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject angel;

    // Update is called once per frame
    void Update()
    {
        if (angel != null)
            transform.position = new Vector3(angel.transform.position.x, angel.transform.position.y, transform.position.z);
    }
}
