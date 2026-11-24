using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class JuiceController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rb;
    public float speed = 1f;
    public bool verticalMovement = false;
    private Vector2 playerVelocity= Vector2.down;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    public void HandleMovement(InputAction.CallbackContext context)
    {
        //print(context.ReadValue<Vector2>());
        if (verticalMovement)
        {
            playerVelocity = context.ReadValue<Vector2>() * speed;
        }
        else
        {
            playerVelocity = context.ReadValue<Vector2>() * speed * Vector2.right+Vector2.down*2; // this will remove vertical movement.
        }
        if(playerVelocity.x < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if(playerVelocity.x > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        //foreach(Collider2D in rb.Overlap)
        List<Collider2D> overlapColliders = new List<Collider2D>();
        rb.Overlap(overlapColliders);
        foreach(Collider2D col in overlapColliders)
        {
            if (col.tag == "interact")
            {
                col.GetComponent<InteractionController>().interact(context.ReadValueAsButton());
            }
            
        }

    }
    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = playerVelocity;
    }
}
