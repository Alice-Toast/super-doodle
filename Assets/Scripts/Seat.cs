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
            Player.position = new Vector3(this.transform.position.x, Player.position.y) + (Vector3)Offset;
            Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            CanSit = false;
            PlayerSat.Invoke();
            
        }
        else
        {
            Stand();
            Player.GetComponent<JuiceController>().EndSit();
        }

    }

    public void Stand()
    {
        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
