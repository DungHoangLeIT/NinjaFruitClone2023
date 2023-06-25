using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Collider spawnArea;

    [SerializeField] private GameObject[] fruitPrefabs;
    [SerializeField] private float minSpawnDelay = 0.25f;
    [SerializeField] private float maxSpawnDelay = 1.0f;
    [SerializeField] private float minAngle = -15f;
    [SerializeField] private float maxAngle = 15f;
    [SerializeField] private float minForce = 18f;
    [SerializeField] private float maxForce = 22f;
    [SerializeField] private float maxLifeTime = 5f;
 
    private void Awake()
    {
        spawnArea = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Spawn()
    {

        yield return new WaitForSeconds(2f);


        while(enabled)
        {
            int index = Random.Range(0, fruitPrefabs.Length);
            GameObject prefabs = fruitPrefabs[index];
            Vector3 position = new Vector3();
            position.x = Random.Range(spawnArea.bounds.min.x,spawnArea.bounds.max.x);
            position.y = Random.Range(spawnArea.bounds.min.y,spawnArea.bounds.max.y);
            position.z = Random.Range(spawnArea.bounds.min.z,spawnArea.bounds.max.z);
            Quaternion rotation = Quaternion.Euler(0f,0f,Random.Range(minAngle, maxAngle));
            int check = (int)Random.Range(0, 4);
            if(check == 1)
            {
                int cnt = 1;
                    for(int i = 0; i < fruitPrefabs.Length; i++)
                    {
                        position.x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
                        position.y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
                        position.z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);
                        /*position = new Vector3(position.x + Random.Range(-4f,4f), position.y, position.z);*/
                        rotation = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));
                        GameObject fruit = Instantiate(fruitPrefabs[i],position,rotation);
                        Destroy(fruit, maxLifeTime);
                        float force = Random.Range(minForce,maxForce);
                        fruit.GetComponent<Rigidbody>().AddForce(fruit.transform.up * force, ForceMode.Impulse);
                    }
     
                yield return new WaitForSeconds(4f);
            }
            else
            {
                GameObject fruit = Instantiate(prefabs,position,rotation);
                Destroy(fruit, maxLifeTime);
                float force = Random.Range(minForce, maxForce);
                fruit.GetComponent<Rigidbody>().AddForce(fruit.transform.up * force, ForceMode.Impulse);
            }
            Debug.Log(check);
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        }
    }
}
