using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;

public class MoveObject : MonoBehaviour
{

    public float Speed = 10f;
    public float SpeedHorizontal = 5f;
    public Vector3 Direction;
    public float xDirection;
    public Rigidbody rb;
    public float jumpForce = 400f;
    public delegate void OnFinish();
    public static event OnFinish FinishReached;
    private bool isGrounded = true;
    public float accelerationTime = 3f;
    private float currentAccelerationTime = 0f;
    private int collisionCount = 0;
    public Text collisionText;
    public Text completionText;
    // Start is called before the first frame update
    void Start()
    {
        Direction = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Direction * Speed * Time.deltaTime);
        xDirection = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(xDirection, 0.0f, 0.0f);
        transform.position = transform.position + moveDirection;

        if (currentAccelerationTime > 0)
        {
            Speed += Time.deltaTime * 5f;
            currentAccelerationTime -= Time.deltaTime;
            if (currentAccelerationTime <= 0)
            {

                Speed = 10f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            currentAccelerationTime = accelerationTime;
        }


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Finish reached!");
            completionText.text = "Рівень завершено!";
            gameObject.SetActive(true);
            if (FinishReached != null)
                FinishReached();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Touch"))
        {
            collisionCount++;
            collisionText.text = "Зіткнення: " + collisionCount.ToString();
        }
    }
}
