using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject player;
    void Start()
    {
        cam.orthographicSize = 1.0f;
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
    void Update()
    {
        if (cam.orthographicSize < 5.0f)
            cam.orthographicSize += 0.03f;
        else
            cam.orthographicSize = 5.0f;
        if (transform.position.x < 0)
            transform.position = new Vector3(transform.position.x + 0.003f, transform.position.y, -10);
        if (transform.position.y < 0)
            transform.position = new Vector3(transform.position.x, transform.position.y  + 0.005f, -10);
    }
}
