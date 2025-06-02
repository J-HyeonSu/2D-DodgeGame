using System.Collections.Generic;
using UnityEngine;

public class RainManager : MonoBehaviour
{
    public GameObject[] prefabs;
    private List<GameObject>[] pools;
    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        //prefabs 갯수에 따라
        //리스트 생성
        for (int i = 0; i < prefabs.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }
    
    public GameObject Get(int index)
    {
        GameObject select = null;
        
        // 선택한 풀[index] 의 놀고있는 게임오브젝트 접근
        foreach (var item in pools[index])
        {
            // 발견하면 select 변수에 할당
            if (!item.activeSelf)
            {
                Debug.Log("재사용");
                select = item;
                select.SetActive(true);
                break;
            }
            
        }
        
        // 모두 사용중이면 새로 생성
        if (!select)
        {
            Debug.Log("생성");
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }
        
        return select;
    }
}
