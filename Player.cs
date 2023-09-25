using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float thrustForce = 100f;
    public float rotationSpeed = 100f;

    public GameObject gun, bulletPrefab;

    private Rigidbody _rigid; 

    public static int SCORE = 0;

    public float xBorderLimit = 10f;
    public float yBorderLimit = 4.5f;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float thrust = Input.GetAxis("Thrust") * Time.deltaTime;
        float rotation = Input.GetAxis("Rotate") * Time.deltaTime;

        Vector3 thrustDirection = transform.right;
        
        _rigid.AddForce(thrustForce*thrustDirection*thrust);

        transform.Rotate(Vector3.forward,-rotation*rotationSpeed);

        var newPos = transform.position;
        if(newPos.x > xBorderLimit)
            newPos.x = -xBorderLimit;
        else if(newPos.x < -xBorderLimit)
            newPos.x = xBorderLimit;
        else if(newPos.y > yBorderLimit)
            newPos.y = -yBorderLimit;
        else if(newPos.y < -yBorderLimit)
            newPos.y = yBorderLimit;
        transform.position = newPos;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab,gun.transform.position,Quaternion.identity);

            Bullet balaScript = bullet.GetComponent<Bullet>();
            balaScript.targetVector = transform.right;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy") // si colisionamos con un enemigo 
        {
            SCORE = 0;  
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // reiniciamos el juego
        }
        else
        {
            Debug.Log("He colisionado con otra cosa...");
        }
    }

}
