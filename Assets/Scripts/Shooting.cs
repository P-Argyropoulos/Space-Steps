using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shooting : MonoBehaviour
{
   
    public GameObject bulletPrefab;
    //public ObjectPooling bulletOnPool;
    public Transform playerPosition;
    public AudioSource sound;
   
    void Start()
    {
        sound = GameObject.Find("Player").GetComponent<AudioSource>();
        playerPosition = GetComponent<Transform>();

        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            sound.Play();
           Instantiate(bulletPrefab, transform.position, transform.rotation);
           //bulletOnPool.GetObject(bulletPrefab);

        }

    }

    
}
