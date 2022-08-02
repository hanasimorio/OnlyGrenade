using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator ani;

    private Quaternion rota;

    private Rigidbody rb;

    private PlayerStatus status;

    [SerializeField] private float movespeed;
    private float dashspeed;
    [SerializeField] private float jumppower;

    private float horizontal;
    private float vertical;
    private Vector3 velocity;
    private Vector3 shotvelocity;

    private bool isstart;
    private bool ismove;
    private bool isdash;
    private bool isjump;
    private bool jumpkey=false;
    private bool shotpre = false;

    private float xmove;
    private float zmove;


    void Start()
    {
        ani = this.gameObject.GetComponent<Animator>();
        status = gameObject.GetComponent<PlayerStatus>();

        rota = transform.rotation;
        rb = this.gameObject.GetComponent<Rigidbody>();

        dashspeed = movespeed + 2;

        Movestart();
    }

    // Update is called once per frame
    void Update()
    {
        if (isstart)
        {
            if (!status.isdead)
            {
                horizontal = Input.GetAxis("Horizontal");
                vertical = Input.GetAxis("Vertical");
                //Debug.Log(isjump);

                if (horizontal != 0 || vertical != 0)//ˆÚ“®‚Ì“ü—Í‚ª‚È‚©‚Á‚½‚ç
                {
                    ismove = true;
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        isdash = true;
                    }
                    else
                    {
                        isdash = false;
                    }
                }
                else
                {
                    ismove = false;
                }

                if (Input.GetKeyDown(KeyCode.Space)) Jump();

                var horizontalrotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);

                velocity = horizontalrotation * new Vector3(horizontal, 0, vertical).normalized;
                var anispeed = Input.GetKey(KeyCode.LeftShift) ? 2 : 1;
                var rotaSpeed = 600 * Time.deltaTime;
                //Debug.Log(velocity);

                if (Input.GetMouseButtonDown(0)) shotpre = true;
                if (Input.GetMouseButtonUp(0)) shotpre = false;

                if (!shotpre)
                {
                    if (velocity.magnitude > 0.5f)
                    {
                        rota = Quaternion.LookRotation(velocity, Vector3.up);
                    }
                }
                else
                {
                    shotvelocity = horizontalrotation * new Vector3(0, 0, 1).normalized;
                    if (shotvelocity.magnitude > 0.5f)
                    {
                        rota = Quaternion.LookRotation(shotvelocity, Vector3.up);
                    }
                }


                transform.rotation = Quaternion.RotateTowards(transform.rotation, rota, rotaSpeed);

                ani.SetFloat("Speed", velocity.magnitude * anispeed, 0.1f, Time.deltaTime);
            }
            else
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
                
                ani.SetBool("Death", true);
            }
        }





    }

    private void FixedUpdate()
    {
        if (isjump) return;
        if(ismove)
        {
            if (isdash)
            {
                xmove = velocity.x * dashspeed;
                zmove = velocity.z * dashspeed;
            }
            else
            {
                xmove = velocity.x * movespeed;
                zmove = velocity.z * movespeed;
            }
            rb.velocity = new Vector3(xmove, 0, zmove);
        }
    }

    public void Movestart()
    {
        isstart = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isjump)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isjump = false;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            if(jumpkey)
            isjump = true;
            jumpkey = false;
        }
    }

    void Jump()
    {
        if (isjump == true) return;
        rb.AddForce(transform.up * jumppower, ForceMode.Impulse);
        ani.SetTrigger("Jump");
        isjump = true;
        jumpkey = true;
        
    }

}
