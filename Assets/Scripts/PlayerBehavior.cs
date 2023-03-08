using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 10f; // WS speed
    public float rotateSpeed = 75f;// AD speed

    public float jumpVelocity = 5f;

    public float distanceToGround = 0.1f;

    public LayerMask groundLayer;

    public GameObject bullet;
    public float bulletSpeed = 100f;

    private float vInput; //vertical(WS) input
    private float hInput; //horizontal(AD) input

    private Rigidbody _rb;

    private CapsuleCollider _col;

    private GameBehavior _gameManager;

    public delegate void JumpingEvent();
    public event JumpingEvent playerJump;

    private void Start()
    {
        _rb = this.GetComponent<Rigidbody>();

        _col = this.GetComponent<CapsuleCollider>();

        _gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;

        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
    }
    
    private void FixedUpdate()
    {

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            playerJump();
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bullet, this.transform.position + new Vector3(1, 0, 0),
                this.transform.rotation) as  GameObject;

            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = this.transform.forward * bulletSpeed;
        }

        Vector3 rotation = Vector3.up * hInput;

        Quaternion angelRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);

        _rb.MoveRotation(_rb.rotation * angelRot);
    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);

        return grounded; 
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Enemy")
        {
            _gameManager.HP -= 3;
        }
    }
}