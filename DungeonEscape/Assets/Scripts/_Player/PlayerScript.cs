using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerScript : MonoBehaviour, IDamageable
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private int health;
    [SerializeField]
    private int power = 1;

    private int diamondAmuont = 0;

    private Rigidbody2D rig2D;
    private PlayerAnimation playerAnimation;
    private SpriteRenderer playerSpriteRenderer;
    private SpriteRenderer swordArcSpriteRenderer;
    private bool isDead = false;

    public int Health {
        get => this.health;
        set {
            health = value;
            UIManger.Instance.UpdatePlayerHealth(Health);
        }
    }

    public int Power
    {
        get => this.power;
        set => this.power = value;
    }

    public int DiamondAmuont
    {
        get => this.diamondAmuont;
        set
        {
            Debug.Log("DiamondAmuont : " + value);
            diamondAmuont = value;
            UIManger.Instance.UpdateGemCount(diamondAmuont);
        }
    }

    void Start()
    {
        rig2D = this.GetComponent<Rigidbody2D>();
        playerAnimation = this.GetComponent<PlayerAnimation>();
        playerSpriteRenderer = this.transform.Find("Sprite").GetComponent<SpriteRenderer>();
        swordArcSpriteRenderer = this.transform.Find("Sword Arc").GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        if (isDead)
            return;

        if (CrossPlatformInputManager.GetButtonDown("A_Button") /*Input.GetMouseButtonDown(0)*/)
        {
            playerAnimation.Attack();
        }
        Movement();
    }

    private void Movement()
    {
        float horizontalInput = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        float horizontalMovment = horizontalInput * speed;
        float verticalMovment = IsGrounded() && (Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("B_Button")) ? jumpForce : rig2D.velocity.y;

        rig2D.velocity = new Vector2(horizontalMovment, verticalMovment);

        Flip(horizontalMovment);
        this.playerAnimation.Jump(!IsGrounded());
        this.playerAnimation.Move(horizontalInput);

    }

    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position, Vector2.down * 0.6f, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, 1 << 8);
        return hit.collider;
    }

    private void Flip(float move)
    {
        if(move != 0)
        {
            bool shouldFlip = move < 0;
            playerSpriteRenderer.flipX = shouldFlip;
            swordArcSpriteRenderer.flipX = shouldFlip;
            swordArcSpriteRenderer.flipY = shouldFlip;

            Vector3 newPos = swordArcSpriteRenderer.transform.localPosition;
            newPos.x = shouldFlip ? -1.01f : 1.01f;
            swordArcSpriteRenderer.transform.localPosition = newPos;
        }
    }

    public void Damage(int damage)
    {
        if (isDead)
            return;
        Health -= damage;
        if (Health <= 0)
        {
            isDead = true;
            playerAnimation.Death();
        }
    }

    public void IsFireSword(bool isFireSword)
    {
        power = 3;
        playerAnimation.SeIsFireSword(isFireSword);
    }

    public void AddBootsOfFlight()
    {
        this.jumpForce = 11;
    }
}
