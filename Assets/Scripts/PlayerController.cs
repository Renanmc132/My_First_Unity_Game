using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer _spr;
    private Rigidbody2D _rb;
    private Animator _anim;

    [Header("Customizable Variables")]
    private Animator _shirtAnim;
    public GameObject _shirts;
    private int types = 1;

    private Animator _pantsAnim;
    public GameObject _pants;

    private Animator _hairAnim;
    public GameObject _hair;
    private int hairType = 1;

   

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
        _pantsAnim = _pants.GetComponent<Animator>();
        _hairAnim = _hair.GetComponent<Animator>();
    }


    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        ChangeClothes();
        ChangeHair();
    }

    private void FixedUpdate()
    {
        Move();
        
    }

    private void Move()
    {
       

        _rb.MovePosition(_rb.position + direction.normalized * moveSpeed * Time.deltaTime);

        if (direction.sqrMagnitude > 0.1f)
        {
            _anim.SetFloat("XInput", direction.x);
            _anim.SetFloat("YInput", direction.y);
            _shirtAnim.SetFloat("XInput", direction.x);
            _shirtAnim.SetFloat("YInput", direction.y);
            _pantsAnim.SetFloat("XInput", direction.x);
            _pantsAnim.SetFloat("YInput", direction.y);
            _hairAnim.SetFloat("XInput", direction.x);
            _hairAnim.SetFloat("YInput", direction.y);

            lastDirection = direction;

            _anim.SetFloat("LastX", lastDirection.x);
            _anim.SetFloat("LastY", lastDirection.y);
            _shirtAnim.SetFloat("LastX", lastDirection.x);
            _shirtAnim.SetFloat("LastY", lastDirection.y);
            _pantsAnim.SetFloat("LastX", lastDirection.x);
            _pantsAnim.SetFloat("LastY", lastDirection.y);
            _hairAnim.SetFloat("LastX", lastDirection.x);
            _hairAnim.SetFloat("LastY", lastDirection.y);

            _anim.SetBool("Moviment", true);
            _shirtAnim.SetBool("Moviment", true);
            _pantsAnim.SetBool("Moviment", true);
            _hairAnim.SetBool("Moviment", true);
        }
        else
        {
            _anim.SetBool("Moviment", false);
            _shirtAnim.SetBool("Moviment", false);
            _pantsAnim.SetBool("Moviment", false);
            _hairAnim.SetBool("Moviment", false);
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

    private void ChangeHair()
    {
        _hairAnim.SetInteger("hairType", hairType);

        if (hairType > 3)
        {
            hairType = 1;
        }
        else if (hairType < 1)
            hairType = 3;


        if (Input.GetKeyDown(KeyCode.H))
        {
            hairType++;
        }
    }

}
