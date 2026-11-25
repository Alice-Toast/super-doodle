using System;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    // Alice Bellefeuille
    private Transform target;

    private Transform secondaryTarget;

    private Rigidbody2D rb;

    public Vector3 offset;

    public Vector3 secondaryOffset;

    

    public float speed = 1;

    private bool firstrun = true; // have to do this because of script order stuff
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
        secondaryTarget = GameObject.FindGameObjectWithTag("PrimeCamPos").transform;
        if(secondaryTarget == null)
        {
            secondaryTarget = target;
        }
        rb = this.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (firstrun)
        { // this changes the position of the camera to the players. i should find a better way but the player gets moved on start by another script so it doesn't work in start. - alice
            if(rb.constraints != RigidbodyConstraints2D.FreezeAll)
            {
                Vector3 raycastTarget = ((target.position+offset) - transform.position);
                RaycastHit2D hit;
                LayerMask mask = LayerMask.GetMask("CameraColliders");

               

                float distance = (transform.position - (target.position + offset + (Vector3.back * 10))).magnitude;

                hit = Physics2D.Raycast(transform.position, raycastTarget.normalized, distance, mask);
                if (hit.point != Vector2.zero)
                {
                    transform.position = hit.point;
                }
                else
                {
                    transform.position = target.position + offset;
                }
                transform.position += (Vector3.back * 10);


                
                Debug.Log(hit.point);
            }
            firstrun = false;
            
        }
        Vector3 newoffset = offset;
        //offset.
        if (target.eulerAngles.z != 0f) // this adjusts the camera for the rotation.
        {
            newoffset = RotatePosition(offset, target.eulerAngles.z);
            
        }

        Vector3 targetpos = target.position + newoffset;

        rb.linearVelocity = ((targetpos - transform.position) * speed);

        
}

    Vector3 RotatePosition(Vector3 origin, float rotation)
    {
        Vector3 newPos = Vector3.zero;
        float radRotation = rotation* Mathf.PI / 180;
        newPos.x =origin.x *Mathf.Cos(radRotation) - origin.y *Mathf.Sin(radRotation);
        newPos.y =origin.y * Mathf.Cos(radRotation) + origin.x * Mathf.Sin(radRotation);
        return newPos;
        
    }

    public void SwapTarget()
    {
        Transform Temporary = target;
        target = secondaryTarget;
        secondaryTarget = Temporary;

        Vector3 Temporary2 = offset;
        offset = secondaryOffset;
        secondaryOffset = Temporary2;

    }


}

static class ExtensionMethods
{
    /// <summary>
    /// Rounds Vector3.
    /// </summary>
    /// <param name="vector3"></param>
    /// <param name="decimalPlaces"></param>
    /// <returns></returns>
    public static Vector3 Round(this Vector3 vector3, int decimalPlaces = 2)
    {
        float multiplier = 1;
        for (int i = 0; i < decimalPlaces; i++)
        {
            multiplier *= 10f;
        }
        return new Vector3(
            Mathf.Round(vector3.x * multiplier) / multiplier,
            Mathf.Round(vector3.y * multiplier) / multiplier,
            Mathf.Round(vector3.z * multiplier) / multiplier);
    }
}