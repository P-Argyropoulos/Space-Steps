using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> asteroidList;
    private GameObject asteroidPrefab, player, spawnerPoint;
    private Rigidbody asteroidRb;
    public float meteorLaunchSpeed = 100.0f;
    public GameObject[] spawners;


    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(MeteorSpawn());
    }

    void Update()
    {
       
    }

    IEnumerator MeteorSpawn()
    {
        while(true)
        {

            yield return new WaitForSeconds(1.0f);
            spawnerPoint = spawners[Random.Range(0,7)];
                
            asteroidPrefab = Instantiate(asteroidList[Random.Range(0,asteroidList.Count)], spawnerPoint.transform.position, Random.rotation);
            
            asteroidRb = asteroidPrefab.GetComponent<Rigidbody>();

            asteroidRb.AddForce((player.transform.position-spawnerPoint.transform.position) * meteorLaunchSpeed,ForceMode.Impulse);
            asteroidRb.AddTorque(Random.Range(-75f,75f),Random.Range(-75f,75f),Random.Range(-75f,75f), ForceMode.Acceleration);

        }
    }
}
