using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public GameObject player;
    private float pos;
    private float veloc = 0;
    public float smoothTime = 0.25f;
    void Update()
    {
        pos = Mathf.SmoothDamp(pos, player.transform.position.x, ref veloc, smoothTime);
        transform.position = new Vector3(pos, transform.position.y, transform.position.z);
    }
}