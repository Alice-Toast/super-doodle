using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class Seat : MonoBehaviour
{
    public bool CanSit;
    private Transform Player;
    public Vector2 Offset;
    public UnityEvent PlayerSat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sit()
    {
        if (CanSit)
        {
            Player.position = this.transform.position + (Vector3)Offset;
            Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            CanSit = false;
            PlayerSat.Invoke();
            
        }
        else
        {
            Stand();
        }

    }

    public void Stand()
    {
        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
