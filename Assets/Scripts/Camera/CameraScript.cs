using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    private BoxCollider2D cameraBox;
    [SerializeField]
    private BoxCollider2D currBoundary;
    private Transform player;

    // Use this for initialization
    void Start () {
        cameraBox = GetComponent<BoxCollider2D>();
        cameraBox.size = new Vector2 ( 2 * Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize * 2);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        FollowPlayer();
        //AspectRatioBoxChange();
	}

    void AspectRatioBoxChange()
    {
        if(Camera.main.aspect >= 1.3f && Camera.main.aspect < 1.4f)
        {
            cameraBox.size = new Vector2(2.8f, 2.1f);
        }
    }

    public void setBoundary(BoxCollider2D newBoundary) {
        currBoundary = newBoundary;
        //transform.position = Vector3.Lerp(transform.position, player.transform.position, 1);
    }

    void FollowPlayer()
    {
        if (currBoundary != null)
        {
            transform.position = new Vector3(Mathf.Clamp(player.position.x, currBoundary.bounds.min.x + cameraBox.size.x / 2, currBoundary.bounds.max.x - cameraBox.size.x / 2),
                                            Mathf.Clamp(player.position.y, currBoundary.bounds.min.y + cameraBox.size.y / 2, currBoundary.bounds.max.y - cameraBox.size.y / 2),
                                            transform.position.z);
        }
    }

    
}
