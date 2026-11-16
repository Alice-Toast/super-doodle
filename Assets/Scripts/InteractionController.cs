using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class InteractionController : MonoBehaviour
{
    public Type interacType;
    void Start()
    {
        
    }
    //int selected = 0;

    // Update is called once per frame
    void Update()
    {
        
    }
    public void interact(bool isOn)
    {
        switch (interacType)
        {
            case Type.Door:
                if (isOn)
                {
                    
                    Debug.Log("Door");
                    this.GetComponent<door>().OpenDoor();
                }
                
                break;
            case Type.Button:
                Debug.Log("Button");
                break;
            case Type.Seat:
                Debug.Log("Seat");
                break;
            default:
                Debug.Log("No Type Found");
                break;
        }
            
    }
}
public enum Type
{
    Door,
    Seat,
    Button,
}
