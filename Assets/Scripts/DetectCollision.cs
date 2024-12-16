using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class DetectCollision : MonoBehaviour
{
    public GameObject asteroidExplosion;
    private Transform playersPosition;
    
    void Start()
    {
        playersPosition = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((playersPosition.position - transform.position).magnitude > 3000)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Asteroids"))
        { 
            //StartCoroutine(AsteroidBoom());
            Instantiate(asteroidExplosion, transform.position, transform.rotation);
            Destroy(gameObject,0.13f);
            
        }

    }

    /*IEnumerator AsteroidBoom()
    {
        yield return new WaitForSeconds(0.07f);
        Instantiate(asteroidExplosion, transform.position, transform.rotation); 
    }
    */
}
