using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour {

    public bool lockcursor;
    public float mousesensitivity = 10f;
    public Transform target;
    public float targetdist;
    public Vector2 pitchminmax = new Vector2(-40, 85);
    public float rotationsmoothtime = 8f;
    Vector3 rotationsmoothvelocity;
    Vector3 curentrotation;
    float yaw;
    float pitch;
    [Header("cliping fix varables")]

     public bool changetranparacy= true;
     public MeshRenderer targetrenderer;
     public float movespeed  = 5f;
     public float returnspeed = 9f;
     public float wallpush = 0.7f;
     public float closestdistancetoplayer = 2;
     public float evencloserdistancetoplayeer = 1;
     public LayerMask colisionmask;
     private bool pitchlock;
    
    void Start () {
        if (lockcursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }	
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Collisiondetect( target.position - transform.forward * targetdist);

        if (!pitchlock)
        {
            yaw += Input.GetAxis("Mouse X") * mousesensitivity;
            pitch -= Input.GetAxis("Mouse Y") * mousesensitivity;
            pitch = Mathf.Clamp(pitch, pitchminmax.x, pitchminmax.y);
            curentrotation = Vector3.Lerp(curentrotation, new Vector3(pitch, yaw), rotationsmoothtime * Time.deltaTime);
        }
        else
        {
            yaw += Input.GetAxis("Mouse X") * mousesensitivity;
            pitch = pitchminmax.y;

            curentrotation = Vector3.Lerp(curentrotation, new Vector3(pitch, yaw), rotationsmoothtime * Time.deltaTime);
        }
       

        //curentrotation = Vector3.SmoothDamp(curentrotation, new Vector3(pitch, yaw), ref rotationsmoothvelocity, );
        transform.eulerAngles = curentrotation;

        
    }

    private void Collisiondetect(Vector3 retpoint)
    {
        RaycastHit hit;
        if (Physics.Linecast(target.position,retpoint,out hit,colisionmask))
        {
            Vector3 norm = hit.normal * wallpush;
            Vector3 p = hit.point  + norm;
            Tranceparancycheck();
            if (Vector3.Distance(Vector3.Lerp(transform.position, p, movespeed * Time.deltaTime), target.position) <= evencloserdistancetoplayeer)
            {

            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, p, movespeed * Time.deltaTime);
            }
            return;
        }
        Fulltranceparancy();
        transform.position = Vector3.Lerp(transform.position, retpoint, returnspeed * Time.deltaTime);
        pitchlock = false;
    }

    private void Tranceparancycheck()
    {
        if (changetranparacy)
        {
            if (Vector3.Distance(transform.position,target.position) <= closestdistancetoplayer)
            {

            }
            else
            {

            }
        }
    }
    private void Fulltranceparancy()
    {

    }
    private void Wallcheck()
    {
        Ray ray = new Ray(target.position, -target.forward);
        RaycastHit hit;
        if (Physics.SphereCast (ray , 0.5f , out hit,0.7f,colisionmask))
        {
            pitchlock = true;

        }
    }
}
