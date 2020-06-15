using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform thePlayer = null;
    [SerializeField] float followSpeed = 15;

    Vector3 playerDistance = new Vector3();

    float hitDistance = 0f;
    [SerializeField] float zoomDistance = 0.1f;

    void Start()
    {
        playerDistance = transform.position - thePlayer.position;
    }


    void Update()
    {
        Vector3 t_destPos = thePlayer.position + playerDistance + (transform.position * hitDistance);
        transform.position = Vector3.Lerp(transform.position, t_destPos, followSpeed * Time.deltaTime);
    }

    public IEnumerator ZomCam()
    {
        hitDistance = zoomDistance;

        yield return new WaitForSeconds(0.15f);

        hitDistance = 0;
    }
}
