using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_View : MonoBehaviour {

    public float speed;
    private float rotationX, rotationY;
    public float s_X, s_Y;
    private bool lockCursor = true;
    private Quaternion o_rot;
    public Camera camera_player;
    private float velocity;
    public float shakeDuration;
    public float amount;
    private bool isZoomed = false;
    private Vector3 original_cam_pos;
    private float original_speed;
    public float jump_force;

    void Start ()
    {
        o_rot = transform.localRotation;
        original_cam_pos = camera_player.transform.position;
        original_speed = speed;
    }
	
	void Update ()
    {
        float h = Input.GetAxis("Horizontal") * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * Time.deltaTime;

        transform.Translate(h * speed, 0.0f, v * speed);

        Sprint();
        MouseLook();
        Jump(jump_force);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (Input.GetKeyDown(KeyCode.Q)) isZoomed = !isZoomed;
        
        if(isZoomed)
        {
            ZoomON();
        }
        else
        {
            ZoomOFF();
        }

        Physics.gravity = new Vector3(0.0f, -9.81f * 3, 0.0f);

    }

    private void MouseLook()
    {
        // Multiply this by the minimum angle
        rotationX += Input.GetAxis("Mouse X") *  s_X * Time.deltaTime; // Get value between -1 or 1
        rotationY += Input.GetAxis("Mouse Y") *  s_Y * Time.deltaTime; // Get value between -1 or 1

        //Constrains on the rotations axis
        rotationX = ClampAngle(rotationX, -360.0f, 360.0f);
        rotationY = ClampAngle(rotationY, -60.0f, 60.0f);
        
        Quaternion quaternionX = Quaternion.AngleAxis(rotationX, Vector3.up);
        Quaternion quaternionY = Quaternion.AngleAxis(rotationY, -Vector3.right);

        transform.rotation = o_rot * quaternionX; // Rotate player only in Y axis
        camera_player.transform.rotation = o_rot * quaternionX * quaternionY; // Rotate camera in XY
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }

    private void Jump(float jump_force)
    {
        if(Input.GetKeyDown(KeyCode.Space))
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, jump_force, 0.0f));
    }

    private void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            HeadBobbing.bobbingSpeedX = 0.15f;
            HeadBobbing.bobbingSpeedY = 0.10f;
            speed = original_speed * 1.5f;
        }
        else {
            HeadBobbing.bobbingSpeedX = 0.08f;
            HeadBobbing.bobbingSpeedY = 0.05f;
            speed = original_speed;
        }
    }

    private void ZoomON()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0.0f)
        {
            camera_player.fieldOfView -= 2.0f;
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0.0f)
        {
            camera_player.fieldOfView += 2.0f;
        }
    }

    private void ZoomOFF()
    {
        camera_player.fieldOfView = 60.0f;
    }


}
