using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 8.0f;
    [SerializeField] float rotationSpeed = 60.0f;

    [SerializeField] Animator playerAnimator;
    [SerializeField] PlayerAudio playerAudio;
    
    [SerializeField] float gravity = -20f;
    [SerializeField] float defaultJumpHeight = 2f;
    private float jumpHeight = 2f;

    private float coyoteTime = 0.25f;
    private float coyoteTimeCounter;

    [SerializeField] GameObject attackArea;
    private bool _isAttacking = false;
    private bool _canAttack = true;

    private CharacterController _playerController;
    private Vector3 _velocity;
    private float _speedY = 0f;
    private float _rotation;

    bool _isGrounded = true;
    
    private Vector3 _spawnPoint;
    void Start()
    {
        _playerController = gameObject.GetComponent<CharacterController>();
        _spawnPoint = gameObject.transform.position;
        jumpHeight = defaultJumpHeight;
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Attack") && _canAttack)
        {
            Attack();
        }

        if (_isGrounded && _velocity.y < 0)
        {
            _speedY = -2f;
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump") && (coyoteTimeCounter > 0f) && !_isAttacking)
        {
            SetJumpVelocity(jumpHeight);
            playerAudio.PlayJumpSound();
        }

        _rotation = rotationSpeed * horizontalInput;
        transform.Rotate(0, _rotation * Time.deltaTime, 0);

        _speedY += gravity * Time.deltaTime;
        _velocity = speed * transform.forward * verticalInput + _speedY * Vector3.up;
        _playerController.Move(_velocity * Time.deltaTime);

        UpdateAnimation(verticalInput);
        _isGrounded = _playerController.isGrounded;

        DieTEST();
    }

    private void UpdateAnimation(float verticalInput)
    {
        playerAnimator.SetBool("Attack", _isAttacking);
        playerAnimator.SetBool("IsGrounded", _isGrounded);
        playerAnimator.SetFloat("Speed", verticalInput);
        playerAnimator.SetFloat("RotationSpeed", _rotation);
    }

    public void SetJumpVelocity(float jumpHeight)
    {
        _speedY = Mathf.Sqrt(2 * jumpHeight * -gravity);
        _isGrounded = false;
    }
    public void SetJumpHeight(float jumpHeight, bool addDefultHeight = false)
    {
        this.jumpHeight = addDefultHeight ? jumpHeight + defaultJumpHeight : jumpHeight;
    }

    // Kick Attack Methods
    private void Attack()
    {
        _canAttack = false;
        _isAttacking = true;
        attackArea.SetActive(true);
        Invoke("EndAttack", 1f); // Attack duration: 1 second
        playerAudio.PlayKickSound();
    }
    private void EndAttack()
    {
        attackArea.SetActive(false);
        _isAttacking = false;
        Invoke("ResetAttack", 0.2f); // Cooldown after attack: 1 second
    }

    private void ResetAttack()
    {
        _canAttack = true;
    }

    // Spawn
    public void ChangeSpawnPoint(Vector3 spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }
    public void Spawn()
    {
        transform.position = _spawnPoint;
    }
    //REMOVE AFTER TESTS
    private void DieTEST()
    {
        if (transform.position.y < -50.0f) Spawn();
    }
}
