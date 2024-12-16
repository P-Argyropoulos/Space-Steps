
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletScript : MonoBehaviour
{
    public GameObject bulletImpactPrefab;
    private Transform playersPosition;
    [SerializeField] private float bulletSpeed = 1000.0f;
    
    
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
        playersPosition = GameObject.Find("Player").transform;
    }

    
    void Update()
    {
        if (Vector3.Distance(playersPosition.position, transform.position) > 1500.0f)
        {
            Destroy(gameObject);
        }
    }

     void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Instantiate(bulletImpactPrefab, transform.position, transform.rotation);
    } 
}
