using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Weapon;

    public float movementSpeed = 20f;
    public float jumpForce = 400f;
    public float horizontalMove;
    private bool jump = false;
    Rigidbody2D rb;

    string PlayerClass = "player";
    int PlayerHealth;
    int PlayerStrength;
    int PlayerIntelligence;
    int PlayerAgility;
    int PlayerDamage;
    bool PlayerShoot;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        WarriorClass();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * movementSpeed;

        if (horizontalMove < 0f) transform.localEulerAngles = new Vector3(0, 180, 0);
        if (horizontalMove > 0f) transform.localEulerAngles = new Vector3(0, 0, 0);

        if (Input.GetButtonDown("Jump")) jump = true;
    }

    private void FixedUpdate()
    {
        Moving(horizontalMove, jump);
    }

    void Moving(float movement, bool canJump)
    {
        rb.velocity = new Vector2(movement * movementSpeed * Time.fixedDeltaTime, rb.velocity.y);

        if (canJump && GetComponent<CircleCollider2D>().IsTouchingLayers())
        {
            rb.AddForce(new Vector2(0, jumpForce));
            jump = !canJump;
        }
    }

    void WarriorClass()
    {
        if (!GetComponent<BaseWarrior>())
        {
            var Class = gameObject.AddComponent<BaseWarrior>();
            PlayerClass = Class.ClassName;
            PlayerHealth = Class.Health;
            PlayerStrength = Class.Strength;
            PlayerIntelligence = Class.Intelligence;
            PlayerAgility = Class.Agility;
            PlayerDamage = Class.Damage;
        }

        var weapon = Instantiate(Weapon, gameObject.transform);
        weapon.transform.position += new Vector3(0.6f, 0.3f, 0);
    }

}
