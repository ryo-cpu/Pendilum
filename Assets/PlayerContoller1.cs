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
        return speed * dir;
    }
   public void SetDir(Vector3 vector)
    {
        dir = vector;
    }
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.zero);
        if (transform.parent != null)
        {
           
            if (Input.GetMouseButtonUp(0))///左クリックが離れた時
            {

                Debug.LogWarning("親に がアタッチされていません");

                PendulumContoroller parent = transform.parent.GetComponent<PendulumContoroller>();
                if (parent == null)
                {
                    Debug.LogWarning("親に ParentScript がアタッチされていません");
                }
                else
                {
                    dir = parent.GetMove();
                    parent.SetMove(-parent.GetMove()*100);

                    rb.useGravity = true;
                    rb.isKinematic = false;

                }
                this.transform.SetParent(null);
            }
            else
            {
                rb.useGravity = false;
                rb.isKinematic = true;

            }
        }
        if (isJunp)
        {

            transform.position += dir * Time.deltaTime;

        }
        else
        {
            dir = dir * 0.1f;
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
            if(dir.magnitude>10.0f)
            {
                Vector3 NDir=dir.normalized;
                dir = NDir * 10.0f;
            }
            transform.position += speed * dir * Time.deltaTime;
        }
       
    }
    void OnCollisionEnter(Collision collision) 
    { 
        if(collision.gameObject.name=="Terrain")
        {
            isJunp = false;
        }
        else
        {
            isJunp = true;
        }
    }
    
}

