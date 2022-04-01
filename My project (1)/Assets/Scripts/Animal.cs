using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public Transform Player;
    public AnimalType animaltype;
    bool isHungry = true;
    public float animalSpeed = 5;
    public float maxDistance = 50;
    
    private void Start()
    {
        Player = GameObject.Find("Player").transform;     
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().skor = -1;
            return;
        }

       
        if (animaltype == AnimalType.chicken)
        {
            if (collision.gameObject.CompareTag("wheat"))
            {
                Destroy(collision.gameObject);
                Player.GetComponent<PlayerController>().skor += 5;
                isHungry = false;

            }
            else if(collision.gameObject.CompareTag("straw")|| collision.gameObject.CompareTag("weed"))
            {
                Destroy(collision.gameObject);
                Player.GetComponent<PlayerController>().skor -= 5;
            }
        }
        else if (animaltype == AnimalType.cow)
        {
            if (collision.gameObject.CompareTag("straw"))
            {
                Destroy(collision.gameObject);
                Player.GetComponent<PlayerController>().skor += 5;
                isHungry = false;

            }
            else if (collision.gameObject.CompareTag("wheat") || collision.gameObject.CompareTag("weed"))
            {
                Destroy(collision.gameObject);
                Player.GetComponent<PlayerController>().skor -= 5;
            }
        }
        else if (animaltype == AnimalType.sheep)
        {
            if (collision.gameObject.CompareTag("weed"))
            {
                Destroy(collision.gameObject);
                Player.GetComponent<PlayerController>().skor += 5;
                isHungry = false;

            }
            else if (collision.gameObject.CompareTag("straw") || collision.gameObject.CompareTag("wheat"))
            {
                Destroy(collision.gameObject);
                Player.GetComponent<PlayerController>().skor -= 5;
            }
        }

    }
   
    public enum AnimalType
    {
        chicken,cow,sheep 
    }
    private void Update()
    {
        if (isHungry)
        {
            transform.LookAt(Player.position);
            GetComponent<Rigidbody>().velocity = transform.forward.normalized * animalSpeed;
        }
        else
        {
            transform.LookAt(Vector3.forward*1000);
            GetComponent<Rigidbody>().velocity = transform.forward.normalized * animalSpeed;
            if (transform.position.z > maxDistance)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
