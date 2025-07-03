using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public float MaxJump = 10;
    public float speed = 10.0f;
    Rigidbody rb;
    public float count = 50;
    public BoxCollider collider;
    bool isJump =false;
    Vector3 dir;
    Vector3 jumpdir;
    public LayerMask wallLayer;

    bool WillCollide(Vector3 moveDir)
    {
        Vector3 futurePos = transform.position + moveDir;
        float radius = transform.localScale.x*0.5f;

        return Physics.CheckSphere(futurePos, radius, wallLayer);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dir = Vector3.zero;
        jumpdir = Vector3.up;
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
        count = count + 1;
        transform.rotation = Quaternion.LookRotation(Vector3.zero);
        
        if(count==100)
        {
            ///当たり判定を有効にする
            collider.enabled = true;
        }
        if (transform.parent != null)
        {

            PendulumContoroller parent = transform.parent.GetComponent<PendulumContoroller>();
            if (parent == null)
            {

            }
            else
            {
                if (Input.GetMouseButtonUp(0))///左クリックが離れた時
                {
                    ///離れる時の処理

                    

                   


                    rb.useGravity = true;
                    rb.isKinematic = false;
                    isJump = true;
                    this.transform.SetParent(null);
                    dir = parent.GetMove();
                    count = 0;
                    ///少し動かしてすぐに当たらないようにする
                    transform.position += dir*2;
                    parent.SetMove(-dir);
                    collider.enabled = false;

                }
                else
                {
                    ///初期化
                    isJump = false;
   
                    ///くっついてる時の処理
                    dir = Vector3.zero;
                    ///playerの動きで振り子に干渉する
                    // Wキー（移動）
                    if (Input.GetKey(KeyCode.W))
                    {
                        dir += transform.forward;
                       
                    }

                    // Sキー（減速移動）
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
                    dir = dir.normalized;
                    Vector3 All_Power = parent.GetMove();
                    All_Power.Normalize();
                    parent.AddMove(dir * Time.deltaTime * 10);
                    rb.useGravity = false;
                    rb.isKinematic = true;

                }
            }
        }
        else
        {
            if (isJump)
            {
                
                transform.position += dir * speed / 20 * Time.deltaTime;

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

                    dir += jumpdir;
                    dir = dir * MaxJump;
                    isJump = true;
                    Debug.Log(dir);

                }
                if (dir.magnitude > 10.0f)
                {
                    Vector3 NDir = dir.normalized;
                    dir = NDir * 10.0f;
                }
                if (!isJump&&WillCollide(speed * dir * Time.deltaTime))
                {
                    transform.position += speed * dir * Time.deltaTime;
                }
            }
        }
       
    }
    void OnCollisionEnter(Collision collision) 
    { 
        
            isJump = false;
            dir=Vector3.zero;
            ContactPoint contact = collision.contacts[0];
            jumpdir = (contact.normal + Vector3.up).normalized;
    }
    }

