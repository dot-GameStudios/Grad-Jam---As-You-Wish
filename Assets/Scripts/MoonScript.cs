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
        GetComponent<SpriteRenderer>().enabled = false;
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
            GetComponent<SpriteRenderer>().enabled = true;
            RevealPlatform();
        }
    }

    public void RevealPlatform()
    {
        EndGoal.SetActive(true);
    }

    public void EndGame(string SceneName)
    {
        if (RB2DTrigger.CollTag == "Player")
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
