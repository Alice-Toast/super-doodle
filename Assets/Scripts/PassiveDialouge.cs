using UnityEngine;
using System.Collections.Generic;
using System.Threading;

public class PassiveDialouge : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    public List<string> dialougeList = new List<string>();
    public int dialogeIndex = 0;
    public PassiveDialouge LinkedDialouge;
    public bool DialougeStarted = false;
    public float Delay = 1.6f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextDialouge()
    {
        if (dialogeIndex < dialougeList.Count)
        {
            DisplayDialouge(dialougeList[dialogeIndex]);
            dialogeIndex++;
        }
    }

    public void DisplayDialouge(string curDialoge)
    {
        Debug.Log(curDialoge);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            DialougeStarted = true;
            if (LinkedDialouge != null)
            {
                NextDialouge();
                Sleep();
                LinkedDialouge.RemoteDialouge();
                Sleep();
            }
            else
            {
                while(dialogeIndex < dialougeList.Count)
                {
                    NextDialouge();
                    Sleep();
                }
            }
        }
    }
    private void Sleep()
    {
        Thread.Sleep((int)(Delay * 1000));
    }

    public void RemoteDialouge()
    {
        NextDialouge();
        Sleep();
    }
}

public class Dialoge
{
    public string Text;
}

