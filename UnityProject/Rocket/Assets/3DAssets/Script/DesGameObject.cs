using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesGameObject : MonoBehaviour
{
    public GameObject createGameObject;
    void OnTriggerEnter(Collider collider)
    {
        GameObject go = Instantiate(createGameObject);
        go.transform.position = gameObject.transform.position;
        // Destroy(gameObject);
    }
}
