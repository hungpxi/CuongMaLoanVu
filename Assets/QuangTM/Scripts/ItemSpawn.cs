using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs; // Array of prefabs for different items
    [SerializeField] int period = 5;
    [SerializeField] int MaximumCount = 10;
    [SerializeField] Vector3 startPosition;
    [SerializeField] Vector3 endPosition;
    [SerializeField] bool enableExtend;

    private float time = 0;
    private List<GameObject> itemPool;

    void Start()
    {
        itemPool = new List<GameObject>();
        for (int i = 0; i < MaximumCount; i++)
        {
            GameObject newItem = Instantiate(prefabs[Random.Range(0, 3)]);
            newItem.SetActive(false);
            itemPool.Add(newItem);
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= period && itemPool.Count > 0)
        {
            SpawnItem();
            time = 0;
        }
    }

    void SpawnItem()
    {
        foreach (GameObject item in itemPool)
        {
            if (!item.activeInHierarchy)
            {
                // Only randomize the x position
                Vector3 randomPosition = new Vector3(
                    Random.Range(startPosition.x, endPosition.x),
                    startPosition.y,  // Keep y position constant
                    startPosition.z   // Keep z position constant
                );

                item.transform.position = randomPosition;
                item.SetActive(true);
                break;
            }
        }
    }

}
