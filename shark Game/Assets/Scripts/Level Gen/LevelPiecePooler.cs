using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;
using UnityEngine.Subsystems;

public class LevelPiecePooler : MonoBehaviour
{

    //dictionary to contain the game Objects and Strings
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    [System.Serializable]
    //class called Pool containing tag, prefab and an int.
    public class Pool
    {
        public string name;
        public GameObject levelPiece;
        public int size;

    }
    //despawn level pieces after 15 seconds
   /* IEnumerator Example(GameObject objecttospawn)
    {
        yield return new WaitForSeconds(12);

        objecttospawn.SetActive(false);
    }*/

    #region Singleton

    public static LevelPiecePooler Instance;

    private void Awake()
    {
        Instance = this;
    }


    #endregion


    public List<Pool> pools;
    // Start is called before the first frame update
    void Start()
    {   //creates a new pool contianing the Tag , and the prefabs.
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        // loops through the list of pools.
        foreach (Pool pool in pools)
        {   //queues the game objects into the dictionary
            Queue<GameObject> objectPool = new Queue<GameObject>();
            //loops through the dictionary instantiating the new pool of objects
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.levelPiece);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.name, objectPool);
        }

    }
    //used for spawning each object from the pool
    public GameObject SpawnFromPool(string name, Vector3 position)
    {   //checks if the desired tag is in the Dictionary
        if (!poolDictionary.ContainsKey(name))
        {
            Debug.LogWarning("pool with tag " + name + " doesn't exist.");
            return null;
        }

        //removes the spawn object from queue
        GameObject objectToSpawn = poolDictionary[name].Dequeue();
        objectToSpawn.SetActive(false);
        //sets spawn object to active and sets transforms.
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;

        //adds tagged object back to queue.
        poolDictionary[name].Enqueue(objectToSpawn);
        //StartCoroutine(Example(objectToSpawn));



        return null;

    }
}
