using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjectInfo
{
    public GameObject goPrefab;
    public int count;
    public Transform tfPoolParent;
}

public class ObjectPool : MonoBehaviour
{
    [SerializeField] ObjectInfo[] objectInfo = null;

    public static ObjectPool instance;

    public Queue<GameObject> noteQueue = new Queue<GameObject>();

    private void Start()
    {
        instance = this;
        noteQueue = InserQueue(objectInfo[0]);
    }

    Queue<GameObject> InserQueue(ObjectInfo p_objectInfo)
    {
        Queue<GameObject> t_queue = new Queue<GameObject>();

        for (int i = 0; i < p_objectInfo.count; i++)
        {
            GameObject t_clone = Instantiate(p_objectInfo.goPrefab, transform.position, Quaternion.identity);
            t_clone.SetActive(false);
            if (p_objectInfo.tfPoolParent != null)
                t_clone.transform.SetParent(p_objectInfo.tfPoolParent);
            else
                t_clone.transform.SetParent(this.transform);

            t_queue.Enqueue(t_clone);
        }

        return t_queue;
    }

}
