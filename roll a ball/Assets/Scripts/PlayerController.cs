using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 12;
    public TextMeshProUGUI countText;
    private Rigidbody rb;
    private int count;
    private float movementX, movementY;
    public GameObject winTextObject;
    public GameObject finalCoin;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        finalCoin.SetActive(false);
    }
    void Update()
    {
        if (rb.position.y <= -100)
        {
            Destroy(gameObject);
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "Void.";
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("SpecialPickUp"))
        {
            other.gameObject.SetActive(false);
            count += 10;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("SuperSpecialPickUp"))
        {
            other.gameObject.SetActive(false);
            count += 22;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("GoodCoin"))
        {
            other.gameObject.SetActive(false);
            count += 49;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("BadCoin"))
        {
            other.gameObject.SetActive(false);
            count -= 149;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Schizo")){
            other.gameObject.SetActive(false);
            count = 999;
            SetCountText();
            Destroy(gameObject);
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "touch grass now.\ntrue ending";
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "SCORE: " + count.ToString();
        if (count == 22)
        {
            rb.position = new Vector3(0, 100, 400);
        }
        else if (count == 50)
        {
            rb.position = new Vector3(-400, 105, 0);
        }
        else if(count == 99)
        {
            winTextObject.SetActive(true);
            finalCoin.SetActive(true);
        }
        else if (count == -99)
        {
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You \"win\" \n(normal ending)";
            finalCoin.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the current object
            Destroy(gameObject);
            // Update the winText to display "You Lose!"
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "Your freak was matched.";
        }
    }

}
