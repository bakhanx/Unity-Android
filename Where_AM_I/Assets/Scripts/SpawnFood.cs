using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class SpawnFood : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] foods;
    public Transform[] spawnLocs;

    public List<GameObject> getFoods;
    public int[] idx = new int[5];

    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        GetFood();
    }

    public void Spawn()
    {
        //스폰할 랜덤 위치 5곳
        for (int i = 0; i < idx.Length; i++)
        {
            idx[i] = Random.Range(0, spawnLocs.Length);
            for (int j = 0; j < i; j++)
            {
                if (idx[i] == idx[j])
                {
                    i--;
                    break;
                }
            }
        }

        for (int i = 0; i < idx.Length; i++)
            Instantiate(foods[Random.Range(0, foods.Length)], spawnLocs[idx[i]]);
    }

    public void GetFood()
    {
        if(StarterController.hit.transform != null)
        {
            if (StarterController.hit.transform.tag == "Item")
            {
                if (StarterAssetsInputs.interactive == true)
                {
                    getFoods.Add(StarterController.hit.transform.gameObject);
                    StarterController.hit.transform.gameObject.SetActive(false);
                }
            }
        }
    }
  
}
