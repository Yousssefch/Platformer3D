using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouvement : MonoBehaviour
{
    public float xsense;
    public float ysense;
    public Transform player;

    float xrotation;
    float yrotation;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xsense;
        float mousey = Input.GetAxisRaw("Mouse Y") * Time.deltaTime*ysense;

        yrotation += mouseX;
        xrotation -= mousey;
        xrotation = Mathf.Clamp(xrotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xrotation, yrotation, 0f);
        player.rotation = Quaternion.Euler(0f, yrotation, 0f);
    }
}
