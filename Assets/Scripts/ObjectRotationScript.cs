using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotationScript : MonoBehaviour
{
    private float _maxSpeed = 15;
    private float _minSpeed = 7;
    private float _maxTorque = 10;
    private GameManager gameManager;

    public int pointValue;

    [SerializeField] ParticleSystem particleSystem;
    



    // Start is called before the first frame update
    void Start()
    {
       

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(RandomForceValue(), ForceMode.Impulse);
        rigidbody.AddTorque(RandomTourqueValue(), RandomTourqueValue(), RandomTourqueValue(), ForceMode.Impulse);
        transform.position = RandomObject();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    Vector3 RandomForceValue()
    {
        return Vector3.up * Random.Range(_minSpeed, _maxSpeed);
    }

    float RandomTourqueValue()
    {
        return Random.Range(-_maxTorque, _maxTorque);
    }

    private Vector3 RandomObject()
    {
        return new Vector3(Random.Range(-4.3f, 4.3f), -1, 0);
    }

    public void DestroyTarget()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(particleSystem, transform.position,
            particleSystem.transform.rotation);
            gameManager.UpdateScore(pointValue);
            Debug.Log("slice");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sensor"))
        {
            Destroy(gameObject);
            if (!gameObject.CompareTag("Enemy"))
            {
                gameManager.UpdateLives(-1);
                if (gameManager.Lives == 0)
                {
                    gameManager.GameOver();
                }
            }
        }        
    }
}
