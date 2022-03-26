using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 8.0f;
    [SerializeField] float rotationSpeed = 60.0f;

    [SerializeField] Animator playerAnimator;
    
    [SerializeField] float gravity = -20f;
    [SerializeField] float jumpHeight = 2f;

    [SerializeField] GameObject attackArea;
    private bool _isAttacking = false;
    private bool _canAttack = true;

    private CharacterController _playerController;
    private Vector3 _velocity;
    private float _speedY = 0f;
    private float _rotation;

    void Start()
    {
        _playerController = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Attack") && _canAttack)
        {
            Attack();
        }

        if (_playerController.isGrounded && _velocity.y < 0)
        {
            _speedY = -2f;
        }
        if (Input.GetButtonDown("Jump") && _playerController.isGrounded && !_isAttacking)
        {
            _speedY = Mathf.Sqrt(2 * jumpHeight * -gravity);
        }

        _rotation = rotationSpeed * horizontalInput;
        transform.Rotate(0, _rotation * Time.deltaTime, 0);

        _speedY += gravity * Time.deltaTime;
        _velocity = speed * transform.forward * verticalInput + _speedY * Vector3.up;
        _playerController.Move(_velocity * Time.deltaTime);

        UpdateAnimation(verticalInput);
    }

    private void UpdateAnimation(float verticalInput)
    {
        playerAnimator.SetBool("Attack", _isAttacking);
        playerAnimator.SetBool("IsGrounded", _playerController.isGrounded);
        playerAnimator.SetFloat("Speed", verticalInput);
        playerAnimator.SetFloat("RotationSpeed", _rotation);
    }


    // Kick Attack Methods
    private void Attack()
    {
        _canAttack = false;
        _isAttacking = true;
        attackArea.SetActive(true);
        Invoke("EndAttack", 1f); // Attack duration: 1 second
    }
    private void EndAttack()
    {
        attackArea.SetActive(false);
        _isAttacking = false;
        Invoke("ResetAttack", 1f); // Cooldown after attack: 1 second
    }

    private void ResetAttack()
    {
        _canAttack = true;
    }
}
