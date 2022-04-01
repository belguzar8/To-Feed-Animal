using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float yemSpeed = 10.0f;
    public float xRange = 7;
    public int skor;
    public VariableJoystick js;
    public Text skorText;
    public GameObject straw; 
    public GameObject weed; 
    public GameObject wheat;
    public GameObject GameOverMenu;
    public Transform SpawnPoint;

    public void saman_buton() 
    {

       GameObject prefab1 =Instantiate(straw);
        prefab1.transform.position = SpawnPoint.position;
        prefab1.GetComponent<Rigidbody>().velocity = Vector3.forward * yemSpeed;

    }
    public void ot_buton()
    {
        GameObject prefab2 =Instantiate(weed);
        prefab2.transform.position = SpawnPoint.position;
        prefab2.GetComponent<Rigidbody>().velocity = Vector3.forward * yemSpeed;
    }
    public void yem_buton() 
    {

        GameObject prefab3 = Instantiate(wheat);
        prefab3.transform.position = SpawnPoint.position;
        prefab3.GetComponent<Rigidbody>().velocity = Vector3.forward * yemSpeed;

    }


    // Start is called before the first frame update
    void Start()
    {

    }

  
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        horizontalInput = js.Horizontal + Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (skor == -1)
        {
            GameOverMenu.SetActive(true);
        }
        if (skor.ToString() != skorText.text)
            skorText.text = skor.ToString();
    }
    public void RePlay()
    {
        GameOverMenu.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
