using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _anim;
    private float moveSpeed = 5f;
    private Vector2 direction;
    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }


    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        _rb.MovePosition(_rb.position + direction.normalized * moveSpeed * Time.deltaTime);

        if(direction.sqrMagnitude > 0.1)
        {
            _anim.SetFloat("XInput", direction.x);
            _anim.SetFloat("YInput", direction.y);

            _anim.SetBool("Moviment", true);
        }
        else
        {
            _anim.SetBool("Moviment", false);
        }
        
    }


}
