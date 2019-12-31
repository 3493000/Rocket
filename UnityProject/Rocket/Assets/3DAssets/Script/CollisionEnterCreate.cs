using System.Collections;
using UnityEngine;

public class CollisionEnterCreate : MonoBehaviour
{

    public GameObject createGameObject;

    public int collisionMaxNum;

    public float desTime;

    private int collisionNum = 0;

    void Start()
    {
        createGameObject.gameObject.SetActive(false);
    }

    //碰撞检测
    void OnTriggerEnter(Collider collider)
   {
    	collisionNum++;
        if (collisionNum >= collisionMaxNum)
        {
    //	print(1);
            GameObject go = Instantiate(createGameObject);
            go.transform.parent = createGameObject.transform.parent;
            go.transform.position = createGameObject.transform.position;
            go.transform.eulerAngles = createGameObject.transform.eulerAngles;
            go.transform.localScale = createGameObject.transform.localScale;
            go.gameObject.SetActive(true);

            collisionNum -= collisionMaxNum;

            StartCoroutine(IEDes(go));
        }
    }
    IEnumerator IEDes(GameObject go)
    {
        yield return new WaitForSeconds(desTime);
        Destroy(go);
    }
}
