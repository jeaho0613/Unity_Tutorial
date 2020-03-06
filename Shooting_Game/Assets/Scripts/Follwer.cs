using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follwer : MonoBehaviour
{
    public float maxShotDelay;
    public float curShotDelay;
    public ObjectManager objecetManager;

    public Vector3 followPos;
    public int followDelay;
    public Transform parent;
    public Queue<Vector3> parentPos;

    private void Awake()
    {
        parentPos = new Queue<Vector3>();
    }
    void Update()
    {
        Watch();
        Follow();
        Fire();
        Reload();
    }

    private void Watch()
    {
        // #. 부모의 위치값을 넣어줌
        if (!parentPos.Contains(parent.position))
            parentPos.Enqueue(parent.position);

        // #. 큐의 값을 빼줌
        if (parentPos.Count > followDelay)
            followPos = parentPos.Dequeue();
        else if (parentPos.Count < followDelay)
            followPos = parent.position;
    }

    private void Follow()
    {
        transform.position = followPos;
    }

    void Fire()
    {
        if (curShotDelay < maxShotDelay)
        {
            return;
        }
        GameObject bullet = objecetManager.MakeObj("BulletFollower");
        bullet.transform.position = transform.position;
        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

        curShotDelay = 0;
    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }
}
