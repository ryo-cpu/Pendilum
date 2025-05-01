using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public float MaxJunp = 10;
    public float speed = 10.0f;
    Rigidbody rb;
    bool isJunp =false;
    Vector3 dir;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dir = Vector3.zero;
    }
   public Vector3 SendMove()
    {
        return speed * dir * Time.deltaTime;
    }
   public void SetDir(Vector3 vector)
    {
        dir = vector;
    }
    void Update()
    {
        if (transform.parent != null)
        {
            if (!Input.GetMouseButton(0))
            {

                PendulumContoroller parent = transform.parent.GetComponent<PendulumContoroller>();
                if (parent == null)
                {
                    Debug.LogWarning("親に ParentScript がアタッチされていません");
                }
                else
                {
                 dir = parent.GetMove()/speed/Time.deltaTime;

                    parent.SetMove(-parent.GetMove()/10);
                  
                    rb.useGravity = true;
                }
                this.transform.SetParent(null);
            }
            else
            {
                rb.useGravity = false;
            }
        }
        if (isJunp)
        {

        }
        else
        {
            dir = dir * 0.9f;
            // Wキー（前方移動）
            if (Input.GetKey(KeyCode.W))
            {
                dir += transform.forward;
            }

            // Sキー（後方移動）
            if (Input.GetKey(KeyCode.S))
            {
                dir -= transform.forward;

            }

            // Dキー（右移動）
            if (Input.GetKey(KeyCode.D))
            {
                dir += transform.right;

            }

            // Aキー（左移動）
            if (Input.GetKey(KeyCode.A))
            {
                dir -= transform.right;

            }
            if (Input.GetKeyDown(KeyCode.Space))
            {

                rb.linearVelocity = Vector3.up * MaxJunp;
                isJunp = true;

            }
        }
        transform.position += speed * dir * Time.deltaTime;
    }
    void OnCollisionEnter(Collision collision) 
    { 
        if(collision.gameObject.name=="Terrain")
        {
            isJunp = false;
        }
    }
}

