using UnityEngine;
using System.Collections;
public class ObjectKiller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void KillObject(float TimeAlive)
    {
        Debug.Log(TimeAlive);
        StartCoroutine(KillIn(TimeAlive));
    }
    IEnumerator KillIn(float DeathTime)
    {
        //Wait for the specified delay time before continuing.
        //Debug.Log("delayStart");
        yield return new WaitForSeconds(DeathTime);

        Destroy(this.gameObject);
        //Do the action after the delay time has finished.
    }
}
