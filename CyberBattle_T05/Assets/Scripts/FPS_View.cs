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

    void Start ()
    {
        o_rot = transform.localRotation;
    }
	
	void Update ()
    {
        float h = Input.GetAxis("Horizontal") * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * Time.deltaTime;

        transform.Translate(h * speed, 0.0f, v * speed);

        if(h != 0.0f || v != 0.0f)
        {
            //CameraShake(1.0f);
        }

        Sprint();

        MouseLook();

        Jump(300.0f);
    
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
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

    private void CameraShake(float shakeTimer)
    {
        Vector2 _pos = new Vector2(camera_player.transform.position.x, camera_player.transform.position.y);
        Vector2 shake = _pos + (Random.insideUnitCircle * amount);

        float x = Mathf.SmoothDamp(_pos.x, shake.x, ref velocity, shakeDuration);
        float y = Mathf.SmoothDamp(_pos.y, shake.y, ref velocity, shakeDuration);

        camera_player.transform.position = new Vector3(x, y, 
            camera_player.transform.position.z);
    }

    private void Sprint()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))      
            speed *= 2;      
    }


}
