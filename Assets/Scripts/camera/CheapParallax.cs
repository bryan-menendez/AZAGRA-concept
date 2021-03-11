using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheapParallax : MonoBehaviour
{
    public GameObject cameraToFollow;
    private Vector3 basePos;
    public float slowness = 4; //25% scrolling speed

    // Start is called before the first frame update
    void Start()
    {
        basePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = basePos - cameraToFollow.transform.position;
        
        transform.position = basePos - distance - new Vector3(0,0,cameraToFollow.transform.position.z);
    }
}
