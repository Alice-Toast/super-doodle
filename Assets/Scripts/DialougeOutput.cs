using TMPro;
using UnityEngine;


public class DialougeOutput : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Prefab;
    private Camera cam;
    private Canvas canvas;
    public Vector2 offsetPer;
    public Vector2 currentOffset = new Vector2(0, 2);
    public float LifeTimer = 6f;
    void Start()
    {
        cam = Camera.main;
        canvas = FindAnyObjectByType<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Display(string newText)
    {
        GameObject Text = Instantiate(Prefab, cam.WorldToScreenPoint(transform.position+(Vector3)currentOffset), Quaternion.identity, canvas.transform);
        Text.GetComponent<TextController>().Setup(newText, LifeTimer, currentOffset, transform);
    }

    
}
