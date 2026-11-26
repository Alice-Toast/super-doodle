using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PassiveDialouge : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    public List<string> dialougeList = new List<string>();
    public int dialogeIndex = 0;
    public PassiveDialouge LinkedDialouge;
    public bool DialougeStarted = false;
    public float Delay = 4f;
    public bool PrimaryDialouge = true;
    private DialougeOutput OutputText;
    private NpcController NpcController;
    void Start()
    {
        OutputText = this.GetComponent<DialougeOutput>();
        if (this.tag != "Player")
        {
            NpcController = this.GetComponent<NpcController>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public void PlayDialouge()
    {
        if (LinkedDialouge != null)
        {
            NextDialouge();
            StartCoroutine(DelayDialouge(true));
        }
        else
        {
            NextDialouge();
            StartCoroutine(DelayDialouge(false));
        }
    }
    public void NextDialouge()
    {

        if (dialogeIndex < dialougeList.Count)
        {
            DisplayDialouge(dialougeList[dialogeIndex]);
            dialogeIndex++;
        }
        else
        {
            Debug.Log("index Error");
        }
    }

    public void DisplayDialouge(string curDialoge)
    {
        Debug.Log(curDialoge);
        if (this.tag != "Player")
        {
            NpcController.talk();
        }
        OutputText.Display(curDialoge);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!DialougeStarted && PrimaryDialouge)
        {
            if (collision.tag == "Player")
            {
                DialougeStarted = true;
                PlayDialouge();
            }
        }
    }

    IEnumerator DelayDialouge(bool startRemote)
    {
        //Wait for the specified delay time before continuing.
        //Debug.Log("delayStart");
        yield return new WaitForSeconds(Delay);
        if (startRemote)
        {
            LinkedDialouge.RemoteDialouge();
            yield return new WaitForSeconds(Delay);
        }
        
        if (dialogeIndex < dialougeList.Count)
        {
            PlayDialouge();
        }
        
        //Do the action after the delay time has finished.
    }

    public void RemoteDialouge()
    {
        DialougeStarted = true;
        NextDialouge();
    }

    
}

public class Dialoge
{
    public string Text;
}

