using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Numerics;
using UnityEngine;

public class Generation : MonoBehaviour
{   //string of prefab names.
    public string[] prefabNames;
    //temp string to find level pieces.
    string levelName;
    //x & Ylocation of the spawned object.
    public float locationX;
    public float locationY;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   //selects a random prefab from the array based on it's length.
            levelName = prefabNames[Random.Range(0, prefabNames.Length)];
            //creates a new instance of a pooled object and sets position of new pooled object instances
            LevelPiecePooler.Instance.SpawnFromPool(levelName, transform.position = new UnityEngine.Vector3(locationX, locationY, 0)) ;
            //sets the resoawn position of the level marker
            transform.position = new UnityEngine.Vector3(locationX, 0, 0);
        }
    }
}
