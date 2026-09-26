using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class Player : MonoBehaviour
{
    public static int score = 0;
    public float thrustForce = 5f;
    public float rotationSpeed = 18f;
    public GameObject gun, bulletPrefab;
    public float xBorderLimit = 20f;
    public float yBorderLimit = 8f;
    public PooledBullets _bulletPool;
    
    private Rigidbody _rigid;
    // Start is called before the first frame update
    void Start() 
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float thrust = Input.GetAxis("Thrust") * Time.deltaTime;
        float rotation = Input.GetAxis("Rotate") * Time.deltaTime;

        Vector3 thrustDirection = transform.right;
        transform.Rotate(Vector3.forward, rotation * rotationSpeed);

        _rigid.AddForce(thrustDirection * thrust * thrustForce);
        
    }

    void Update()
    {
        Vector3 newPos = transform.position;
        if (newPos.x > xBorderLimit) 
        {
            newPos.x = -xBorderLimit;
        }
        else if (newPos.x < -xBorderLimit)
        {
            newPos.x = xBorderLimit;
        }

        if (newPos.y > yBorderLimit)
        {
            newPos.y = -yBorderLimit;
        }
        else if (newPos.y < -yBorderLimit)
        {
            newPos.y = yBorderLimit;
        }
        transform.position = newPos;

        if (Input.GetKeyDown(KeyCode.Space))
        {

           GameObject bullet = _bulletPool.GetBullet(transform.right, gun.transform.position);
           // POOL vv
            _bulletPool.GetBullet(transform.right, gun.transform.position);
            Bullet bulletScript = bullet.GetComponent<Bullet>();

            bulletScript.targetVector = transform.right;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
            Time.timeScale = 0f;
        }    
    }

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            score = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


}
