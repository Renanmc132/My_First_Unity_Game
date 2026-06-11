using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer _spr;
    private Rigidbody2D _rb;
    private Animator _anim;

    [Header("Shirts Variables")]
    private Animator _shirtAnim;
    public GameObject _shirts;
    private int types = 1;

    [Header("Movement")]
    private float moveSpeed = 5f;
    private Vector2 direction;
    private Vector2 lastDirection;
    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _spr = GetComponent<SpriteRenderer>();
        _shirtAnim = _shirts.GetComponent<Animator>();
    }


    void Update()
    {
        ChangeClothes();
    }

    private void FixedUpdate()
    {
        Debug.Log("LastX: "+ types);

        Move();
        
    }

    private void Move()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        _rb.MovePosition(_rb.position + direction.normalized * moveSpeed * Time.deltaTime);

        if (direction.sqrMagnitude > 0.1f)
        {
            _anim.SetFloat("XInput", direction.x);
            _anim.SetFloat("YInput", direction.y);
            _shirtAnim.SetFloat("XInput", direction.x);
            _shirtAnim.SetFloat("YInput", direction.y);

            lastDirection = direction;

            _anim.SetFloat("LastX", lastDirection.x);
            _anim.SetFloat("LastY", lastDirection.y);
            _shirtAnim.SetFloat("LastX", lastDirection.x);
            _shirtAnim.SetFloat("LastY", lastDirection.y);

            _anim.SetBool("Moviment", true);
            _shirtAnim.SetBool("Moviment", true);
        }
        else
        {
            _anim.SetBool("Moviment", false);
            _shirtAnim.SetBool("Moviment", false);
        }
    }

    private void ChangeClothes()
    {
        _shirtAnim.SetInteger("Type", types);

        if (types > 3)
        {
            types = 1;
        }
        else if (types < 1)
            types = 3;


        if (Input.GetKeyDown(KeyCode.C))
        {
            types++;
        }
    }

}
