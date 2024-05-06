using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidbody;
    public float speed = 2f;
    public Transform groundChekcerTransform;
    public LayerMask notPlayerMask;
    public float jumpForce = 3f;
    public Text completionText;
    public delegate void OnFinish();
    public static event OnFinish FinishReached;
    public Color flashColor = Color.red;
    public float flashDuration = 0.1f;
    private SpriteRenderer spriteRenderer ;
    private Color originalColor;
    private bool isFlashing = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 directionVector = new Vector3(h, 0, v);
        animator.SetFloat("Speed", Vector3.ClampMagnitude(directionVector, 1).magnitude);
        Vector3 moveDir = Vector3.ClampMagnitude(directionVector, 1) * speed;
        rigidbody.velocity = new Vector3(moveDir.x,rigidbody.velocity.y,moveDir.z);
        rigidbody.angularVelocity = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Physics.Raycast(groundChekcerTransform.position, Vector3.down, 0.2f, notPlayerMask))
        {
            animator.SetBool("isInAir",false);
        }
        else
        {
            animator.SetBool("isInAir",true);
        }
    }
    void Jump()
    {
        if (Physics.Raycast(groundChekcerTransform.position, Vector3.down, 0.2f, notPlayerMask))
        {
            animator.SetTrigger("Jump");
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Finish reached!");
            completionText.text = "Рівень завершено!";
            animator.SetBool("getFinish", true);
            gameObject.SetActive(true);
            if (FinishReached != null)
                FinishReached();
        }
        if (other.CompareTag("enemy"))
        {
            Debug.Log("Flash");
            isFlashing = true;
            StartCoroutine(FlashEnemy());
        }
    }
    IEnumerator FlashEnemy()
    {
        float elapsedTime = 0f;

        while (elapsedTime < flashDuration)
        {
            spriteRenderer.color = flashColor;
            yield return new WaitForSeconds(0.05f);
            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(0.05f);
            elapsedTime += 0.1f;
        }

        isFlashing = false;
    }
}
