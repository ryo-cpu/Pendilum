using System;
using UnityEngine;

public class PendulumContoroller : MonoBehaviour
{
    public float RopeLength = 20;
    private GameObject Root;   //�e���i�[�p
    private Vector3 Move;//���������悤
    private GameObject player;
    public float Gravity = 2.0f;
   public  void SetMove(Vector3 move)
    {
        Move = move;


    }
    public Vector3 GetMove()
    {
     return Move;
    }


    // Use this for initialization
    void Start()
    {
        Move = Vector3.zero;
        Root = this.transform.parent.gameObject;
        this.player= GameObject.Find("Pobject");
        if (Root != null )
        {
              Debug.Log("ERR");
        }




    }
    void Update()
    {
        Move.y -= Gravity * Time.deltaTime;
        Vector3 TopPos = transform.position+Move;///�Ȃɂ��Ȃ���Ԃł̓���
        var RootPos = Root.transform.position;
        float dis =Vector3.Magnitude( TopPos-RootPos);///�����Ȃ�����2�_�̋���
        Vector3 Tension = Vector3.zero;
        if (dis > RopeLength)
        {
            Vector3 Distance=RootPos-TopPos;
            Vector3 normalizDistance = Distance.normalized;
            Tension = Distance - (normalizDistance * RopeLength);

           

        }
        Move += Tension;
        transform.position += Move;

    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.name == "Pobject")
           {
            PlayerContoller player= FindObjectOfType<PlayerContoller>();
            if (player != null&&player.transform.parent == null)
            {
                Vector3 M=Move;
                Move = player.SendMove();
                player.SetDir(M);
                if (Input.GetMouseButton(0))
                {
                    player.SetDir(Vector3.zero);
                    player.transform.SetParent(this.transform);
                }
            }

        }
    }

}
