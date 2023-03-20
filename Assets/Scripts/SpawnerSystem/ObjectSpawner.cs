using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class PoolObject : MonoBehaviour
{
    public ObjectPool<GameObject> myPool;

    public void DestoryPoolObject()
    {
        myPool.Release(gameObject);
    }
}
public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPoolPrefap;
    ObjectPool<GameObject> objectPool;

    public GameObject objectToSpawn;

    public GameObject gridToSpawn;
    public Vector2Int gird;
    public float y = 0;

    public Vector3 firstPosition;
    public float gap = 2;
    public GameObject ObjectToCreate;

    private Vector3 minPosition;
    private Vector3 maxPosition;

    private Vector3 origin = Vector3.zero;
    public float radius = 10f;


    void Awake()
    {
       // objectPool = new ObjectPool<GameObject>(OnObjectCreate, OnTake, OnRelease, OnObjectDestroy);
    }
    // Start is called before the first frame update
    void Start()
    {
        // SpawnObject();
        // RandomSpawn();
        // SpawnInARow();
        // SpawnGrid(gird);
    }

   void SpawnObject()
    {
        //GameObject newObject = Instantiate(objectToSpawn, transform.position, transform.rotation); // reference to the postion and rotation of the object attach to
        //GameObject newObject = Instantiate(objectToSpawn,objectToSpawn.transform.position, objectToSpawn.transform.rotation); // using original rotation of the prefap or position
        //GameObject newObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity); // has no rotation by using identity property of the quaternion class( quaterino is used to represent rotation)
        //Instantiate(objectToSpawn, transform);
        //Instantiate(objectToSpawn, transform, true); // uses original postion and rotation of the prefap
        //Instantiate(objectToSpawn, transform.position, transform.rotation, transform); // created a child but uses custom position and rotation values;
        //GameObject newObject = (GameObject)Instantiate(Resources.Load("Square"));
    }// end of Spawn Object

    void RandomSpawn()
    {
        
        Vector3 randomPosition = origin + Random.insideUnitSphere * radius;
        GameObject newObject = Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
        
        /*
        Vector2 randomPosition =  Random.insideUnitCircle * radius;
        GameObject newObject = Instantiate(objectToSpawn, randomPosition, transform.rotation);
        */
    }// end of Random Spawn

    void SpawnInARow()
    {
        Vector3 position = firstPosition;
        for(int i = 0; i < 5; i++)
        {
            Instantiate(ObjectToCreate, position, Quaternion.identity);
            position.x += gap;
            
        }// end of for loop
    }

    void SpawnGrid(Vector2Int gridSize)
    {

        for(int x = 0; x < gridSize.y; x++)
        {
            for(int z =0; z < gridSize.x; z++)
            {
                Instantiate(gridToSpawn, new Vector3(x, y, 0), Quaternion.identity);
                
            }
        }// end of nested for loop
    }// end of spawn grid 

     GameObject OnObjectCreate()
    {
        GameObject newObject = Instantiate(objectPoolPrefap);
        newObject.AddComponent<PoolObject>().myPool = objectPool; // not working need to figure it out
        return newObject;
    }
    void OnTake(GameObject objectPool)
    {
        objectPool.SetActive(true);
    }
    void OnRelease(GameObject objectPool)
    {
        objectPool.SetActive(false);
    }
     void OnObjectDestroy(GameObject objectPool)
    {
        Destroy(objectPool);
    }

    


}// end of spawn in a row
