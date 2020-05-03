using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoonScript : MonoBehaviour
{
    public int KeyCount;
    public GameObject EndGoal;
    private Rigidbody2DTrigger RB2DTrigger;

    // Start is called before the first frame update
    void Start()
    {
        RB2DTrigger = GetComponent<Rigidbody2DTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseKeyCount()
    {
        KeyCount++;
        if(KeyCount == 4)
        {
            RevealPlatform();
        }
    }

    public void RevealPlatform()
    {
        EndGoal.SetActive(true);
    }

    public void EndGame(string SceneName)
    {
        if (RB2DTrigger.Tag == "Player")
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
