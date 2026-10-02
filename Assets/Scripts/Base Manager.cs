using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    public Transform nextBasePosition;
    public bool isPooled = false;
    public GameObject trigger;
    //public Transform obstacleParent;

    private void OnEnable()
    {        
        if (trigger != null)
        {
            trigger.SetActive(true);
        }

        //for (int i = 0; i < obstacleParent.childCount; i++)
            //obstacleParent.GetChild(i).gameObject.SetActive(true);
    }

}
