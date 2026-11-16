using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class JuiceController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rb;
    public float speed = 1f;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    public void HandleMovement(InputAction.CallbackContext context)
    {
        //print(context.ReadValue<Vector2>());
        rb.linearVelocity = context.ReadValue<Vector2>() * speed;
    }

    public void Interact(InputAction.CallbackContext context)
    {
        //foreach(Collider2D in rb.Overlap)
        List<Collider2D> overlapColliders = new List<Collider2D>();
        rb.Overlap(overlapColliders);
        foreach(Collider2D col in overlapColliders)
        {
            col.tag = "interact";
            col.GetComponent<InteractionController>().interact(context.ReadValueAsButton());
        }

    }
    // Update is called once per frame
    void Update()
    {
        //if(inputac
    }
}
