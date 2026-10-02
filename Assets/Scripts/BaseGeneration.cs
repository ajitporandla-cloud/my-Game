using System;
using UnityEngine;

public class BaseGeneration : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.gameObject.SetActive(false);

            int randomIndex = UnityEngine.Random.Range(0, GameManager.instance.basePool.Count);
            GameObject currentbase = GameManager.instance.basePool[randomIndex];

            GameManager.instance.basePool.Remove(currentbase);
            currentbase.transform.position = GameManager.instance.nextBasePosition.position;
            GameManager.instance.nextBasePosition = currentbase.GetComponent<BaseManager>().nextBasePosition;
            currentbase.SetActive(true);

            currentbase.transform.parent = GameManager.instance.baseParent;
            GameManager.instance.baseList.Add(currentbase);
            currentbase.name = "Base " + (GameManager.instance.baseList.Count - 1);

            // GameObject gameObject=GameObject.Instantiate(basePrefab,
            // GameManager.instance.nextBasePosition.position,
            // Quaternion.identity, GameManager.instance.baseParent);

            // GameManager.instance.baseList.Add(gameObject);
            // GameManager.instance.nextBasePosition = gameObject.GetComponent<BaseManager>().nextBasePosition;
            // gameObject.name = "Path " + (GameManager.instance.baseList.Count - 1);

            if (GameManager.instance.baseList.Count >= 8)
            {

               GameObject baseToPool = GameManager.instance.baseList[GameManager.instance.baseToRemoveCount];
                GameManager.instance.baseList[GameManager.instance.baseToRemoveCount] = null;
                baseToPool.SetActive(false);

                if (baseToPool.GetComponent<BaseManager>().isPooled)
                {
                    baseToPool.transform.position = new Vector3(0, -1000, 0);
                    baseToPool.transform.parent = GameManager.instance.basePoolParent;
                    GameManager.instance.basePool.Add(baseToPool);
                }
               // Destroy(delBase);
               GameManager.instance.baseToRemoveCount += 1;
            }
        }


    }
}
