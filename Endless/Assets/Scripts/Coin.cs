using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            gameObject.SetActive(false);
            return;
        }
        
        if (other.gameObject.name != "Player") { return; }

        GameManager.instance.IncreaseScore();

        gameObject.SetActive(false);
    }
    void Start()
    {
        rotationSpeed = 90f;
    }

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
