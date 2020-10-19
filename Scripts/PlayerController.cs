using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    public Camera camera;

    public GameObject LavaGate;
    public GameObject UnlockTorus;

    public GameObject player;

    public Camera DummyCamera;

    private Rigidbody rb;
    public int count = 0;
    private float movementX;
    private float movementY;

    #region materials
    public Material blue;
    public Material green;
    public Material black;
    public Material yellow;
    #endregion
    public int colorCount = -1;

    public int winCount = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        

    }

   

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        

        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    void SetCountText()
    {
        if (count <= winCount)
        {
            winTextObject.SetActive(false);
        }
        
        countText.text = "Count: " + count.ToString();
        if(count >= winCount)
        {
            winTextObject.SetActive(true);
        }
    }

     void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0f, movementY);
        rb.AddForce(movement * speed);

       /* if (Input.GetKeyDown("space"))
        {
            Vector3 up = new Vector3(0f, 50.0f, 0f);
            rb.AddForce(up);
        } */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            colorCount++;
            
            switch (colorCount)
            {   case 0:
                    meshRenderer.material = blue;
                    break;
                case 1:
                    meshRenderer.material = yellow;
                    break;
                case 2:
                    meshRenderer.material = black;
                    break;
                case 3:
                    meshRenderer.material = green;
                    colorCount = -1;
                    break;
            }


        }

        

        if (other.gameObject.CompareTag("Reset"))
        {
            SceneManager.LoadScene("PipeJumpin");    //reset the scene if the player collides with the lava
        }
        
        if (other.gameObject.CompareTag("Unlock Ending"))   //unlock the ending
        {
            LavaGate.SetActive(false);
        }

    }
        
        
}
