using UnityEngine;

public class ParalaxEffect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float Amount = 1f;
    public Vector3 MidPoint = new Vector3(50f, 0);
    public Transform Player;
    public Vector3 Offset;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Player = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //this.GetComponent<SpriteRenderer>().
        Vector3 NewPosition = MidPoint + -(MidPoint - Player.position) * Amount + Offset;
        NewPosition = new Vector3(NewPosition.x, NewPosition.y, 0);
        transform.position = NewPosition;
    }
}
