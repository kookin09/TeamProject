using UnityEngine;

/// <summary>
///  ▣ 자동 달리기 캐릭터 컨트롤러
///   - 달리기 / 2단 점프 / 슬라이드 / 벽 끼임 탈출
/// </summary>
[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D), typeof(Animator))]
public class Player : MonoBehaviour
{
    [Header("── 이동 / 점프 ──")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 11f;
    [SerializeField, Range(1, 2)] int maxJump = 2;

    [Header("── 땅 판정 ──")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundRadius = 0.2f;
    [SerializeField] LayerMask groundMask;

    [Header("── 슬라이드 ──")]
    [SerializeField] AudioSource slideSource;
    [SerializeField] AudioClip slideClip;

    [Header("── 벽 끼임 해소 ──")]
    [SerializeField] float stuckSpeedThreshold = 0.05f;
    [SerializeField] float stuckCheckDuration = 0.25f;
    [SerializeField] LayerMask wallMask;

    Rigidbody2D rb;
    Animator anim;
    BoxCollider2D boxCol;

    Vector3 origScale;
    Vector2 origSize, origOffset;

    int jumpCount = 0;
    bool isSliding = false;
    bool wasGrounded = false;
    float stuckTimer = 0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCol = GetComponent<BoxCollider2D>();

        origScale = transform.localScale;
        origSize = boxCol.size;
        origOffset = boxCol.offset;

        slideSource.loop = true;
        slideSource.clip = slideClip;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJump)
        {
            if (isSliding) EndSlide();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
            anim.SetBool("IsJump", true);
            SoundManager.Instance?.PlaySFX(SFXType.Jump);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isSliding)
            StartSlide();
        else if (Input.GetKeyUp(KeyCode.LeftShift) && isSliding)
            EndSlide();
    }

    void FixedUpdate()
    {
        bool grounded = IsGrounded();

        if (!wasGrounded && grounded)
        {
            jumpCount = 0;
            anim.SetBool("IsJump", false);
        }
        wasGrounded = grounded;

        // 지면 슬로프 대응
        if (!grounded)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(
                groundCheck.position, Vector2.down, groundRadius + 0.1f, groundMask);
            if (hit && Mathf.Abs(hit.normal.x) > 0.1f)
            {
                Vector2 slopeDir = new Vector2(hit.normal.y, -hit.normal.x).normalized;
                rb.velocity = slopeDir * moveSpeed;
            }
            else
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }
        }

        // 벽 끼임 검사
        if (IsWallAhead() && Mathf.Abs(rb.velocity.x) < stuckSpeedThreshold)
        {
            stuckTimer += Time.fixedDeltaTime;
            if (stuckTimer > stuckCheckDuration)
            {
                rb.velocity += Vector2.down * 0.5f;
                stuckTimer = 0f;
            }
        }
        else
        {
            stuckTimer = 0f;
        }
    }

    void StartSlide()
    {
        isSliding = true;
        transform.localScale = new Vector3(origScale.x, origScale.y * 0.5f, 1f);
        boxCol.size = new Vector2(origSize.x, origSize.y * 0.5f);
        boxCol.offset = new Vector2(origOffset.x, origOffset.y - 0.25f);
        slideSource.Play();
        SoundManager.Instance?.PlaySFX(SFXType.Slide);
    }

    void EndSlide()
    {
        isSliding = false;
        transform.localScale = origScale;
        boxCol.size = origSize;
        boxCol.offset = origOffset;
        slideSource.Stop();
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundMask);
    }

    bool IsWallAhead()
    {
        Vector2 origin = (Vector2)transform.position + Vector2.right * (boxCol.size.x / 2 + 0.01f);
        origin.y += boxCol.offset.y;
        return Physics2D.BoxCast(origin, boxCol.size, 0f, Vector2.right, 0.01f, wallMask);
    }

    void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
    }

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        if (groundCheck)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
        }
    }
#endif
}
