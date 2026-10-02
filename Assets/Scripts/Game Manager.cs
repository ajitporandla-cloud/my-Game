using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<GameObject> baseList = new List<GameObject>();

    public List<GameObject> basePrefabList = new List<GameObject>();
    public Transform nextBasePosition;
    public GameObject basePrefab;
    public Transform baseParent;
    public int baseToRemoveCount = 0;
    public Transform basePoolParent;
    public bool isPaused = true;
    public List<GameObject> basePool = new List<GameObject>();

    private void Start()
    {
        if (instance == true)
        {
            DestroyImmediate(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        LoadBasePool();
    }
    private void LoadBasePool()
    {
        if(basePrefabList.Count == 0)
        {
            Debug.LogError("No base Error");
            return;
        }
        foreach (GameObject baseprefab in basePrefabList)
        {
            for(int i = 0; i < 5; i++)
            {
                GameObject newbase = Instantiate(baseprefab, new Vector3(0, -1000, 0), Quaternion.identity, basePoolParent);
                newbase.gameObject.SetActive(false);
                newbase.GetComponent<BaseManager>().isPooled = true;
                basePool.Add(newbase);
            }
        }
        isPaused = false;
    }
}
