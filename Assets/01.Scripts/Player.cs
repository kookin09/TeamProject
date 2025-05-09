using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // ������� ȿ����
    public AudioClip jumpSound;
    public AudioClip slideSound;
    public AudioSource sfxSource;


    // �̵� �ӵ��� ���� ����
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    // �ִ� ���� Ƚ�� (2�� ����)
    public int maxJump = 2;
    private int jumpCount = 0;

    // Rigidbody2D �����
    private Rigidbody2D rb;

    // �� üũ�� ����
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    // �����̵� ���� ����
    public Vector2 slideScale = new Vector2(1f, 0.5f); // �����̵� �� ĳ���� ũ��
    private bool isSliding = false;
    private Vector2 originalScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        Run();
        HandleJump();
        HandleSlide();
    }

    // �ڵ����� ������ �̵�
    void Run()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    // ���� ó��
    void HandleJump()
    {
        // ���� ������ ���� Ƚ�� �ʱ�ȭ
        if (IsGrounded())
        {
            jumpCount = 0;
        }

        // Space�� ������, ���� Ƚ���� ���Ҵٸ� ����
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0); // ���� ���ӵ� �ʱ�ȭ
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;

            sfxSource.PlayOneShot(jumpSound);
        }

    }

    // �����̵� �Է� ó��
    void HandleSlide()
    {
        // Shift ������ �����̵� ����
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartSlide();
        }
        // Shift ���� �����̵� ����
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            EndSlide();
        }
    }

    // �����̵� ����
    void StartSlide()
    {
        if (isSliding) return;
        isSliding = true;
        transform.localScale = slideScale; // �۾���
        sfxSource.PlayOneShot(slideSound);
    }

    // �����̵� ����      
    void EndSlide()
    {
        isSliding = false;
        transform.localScale = originalScale; // ���� ũ��� ����
    }

    // �� üũ (OverlapCircle ���)
    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}
