using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public float MaxJump = 10;
    public float speed = 10.0f;
    Rigidbody rb;
    public float count = 50;
    bool isJump =false;
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
        count = count + 1;
        transform.rotation = Quaternion.LookRotation(Vector3.zero);
        
        if(count==10)
        {
            ///�����蔻���L���ɂ���
        }
        if (transform.parent != null)
        {

            PendulumContoroller parent = transform.parent.GetComponent<PendulumContoroller>();
            if (parent == null)
            {

            }
            else
            {
                if (Input.GetMouseButtonUp(0))///���N���b�N�����ꂽ��
                {
                    ///����鎞�̏���

                    

                   


                    rb.useGravity = true;
                    rb.isKinematic = false;
                    isJump = true;
                    this.transform.SetParent(null);
                    dir = parent.GetMove();
                    count = 0;
                    ///�����������Ă����ɓ�����Ȃ��悤�ɂ���
                    transform.position += dir*2;
                    parent.SetMove(-dir);
                

                }
                else
                {
                    ///������
                    isJump = false;
   
                    ///�������Ă鎞�̏���
                    dir = Vector3.zero;
                    ///player�̓����ŐU��q�Ɋ�����
                    // W�L�[�i�ړ��j
                    if (Input.GetKey(KeyCode.W))
                    {
                        dir += transform.forward;
                       
                    }

                    // S�L�[�i�����ړ��j
                    if (Input.GetKey(KeyCode.S))
                    {
                        dir -= transform.forward;
                       


                    }

                    // D�L�[�i�E�ړ��j
                    if (Input.GetKey(KeyCode.D))
                    {
                        dir += transform.right;
                        


                    }

                    // A�L�[�i���ړ��j
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
                // W�L�[�i�O���ړ��j
                if (Input.GetKey(KeyCode.W))
                {
                    dir += transform.forward;
                }

                // S�L�[�i����ړ��j
                if (Input.GetKey(KeyCode.S))
                {
                    dir -= transform.forward;

                }

                // D�L�[�i�E�ړ��j
                if (Input.GetKey(KeyCode.D))
                {
                    dir += transform.right;

                }

                // A�L�[�i���ړ��j
                if (Input.GetKey(KeyCode.A))
                {
                    dir -= transform.right;

                }
                if (Input.GetKeyDown(KeyCode.Space))
                {

                    dir += Vector3.up;
                    dir = dir * MaxJump;
                    isJump = true;
                    Debug.Log(dir);

                }
                if (dir.magnitude > 10.0f)
                {
                    Vector3 NDir = dir.normalized;
                    dir = NDir * 10.0f;
                }
                if (!isJump)
                {
                    transform.position += speed * dir * Time.deltaTime;
                }
            }
        }
       
    }
    void OnCollisionEnter(Collision collision) 
    { 
        
            isJump = false;
    }
    
}

