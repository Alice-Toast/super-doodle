using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //public SceneAsset
    public string NextScene;
    public bool isLocked;
    public Scene scene;
    void Start()
    {
        //Debug.Log(sceneHandle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenDoor()
    {
        if (isLocked)
        {
            Debug.Log("I shouln't leave yet");
        }
        else
        {
            SceneManager.LoadScene(NextScene);
            //SceneManager.SetActiveScene(scene);
        }
            
    }
    public void UnlockDoor()
    {
        isLocked = false;
    }
}
