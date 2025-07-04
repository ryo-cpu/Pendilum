using System;
using UnityEngine;

public class PendulumContoroller : MonoBehaviour
{
    public float RopeLength = 20;
    private GameObject Root;   //親情報格納用
    private Vector3 Move;//動きを作るよう
    private Vector3 tension;//渡す用の格納
    private GameObject player;
    public float Gravity = 2.0f;
   public  void SetMove(Vector3 move)
    {
        Move = move;


    }
    public void AddMove(Vector3 move)
    {
        Move += move;
    }
    public Vector3 GetMove()
    {

        Vector3 Dir = Move;
        Vector3 Dis = Root.transform.position-transform.position;
        Dir = Dir.normalized*Move.magnitude;
        Dis = Dis.normalized*tension.magnitude;
        Dir.y=tension.y;
        Vector3 P =(Dir+Dis);
        Debug.LogWarning(Dir);
        return Dir; 
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
       
        Move.y -= Gravity;//常に足されているのでいつか壊れる
        if (Move.y < -5.0f)
        {
            ///重力の最高加速度
            Move.y = -5.0f;
        }

        Vector3 TopPos = transform.position + Move;///なにもない状態での動き
        var RootPos = Root.transform.position;
        float dis = Vector3.Magnitude(TopPos - RootPos);///何もない時の2点の距離
        Vector3 Tension = Vector3.zero;
        if (dis > RopeLength)
        {
            Vector3 Distance = RootPos - TopPos;
            Vector3 normalizDistance = Distance.normalized;
            Tension = Distance-(normalizDistance * RopeLength) ;
            tension = Tension;

           
        }
        else
        {
            tension = new Vector3(0,0,0);
        }

            Move += Tension;
        ///瞬間の最大速度
        if (Move.magnitude > 10.0f)
        {
            Vector3 NMove = Move.normalized;
            Move = NMove * 10.0f;
        }
        transform.position += (Move)* Time.deltaTime*10;
        

    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.name == "Pobject")
           {
            PlayerContoller player= FindObjectOfType<PlayerContoller>();
            if (player != null&&player.transform.parent == null)
            {
                Vector3 M=Move;
                Debug.Log("Collison");
                Move = player.SendMove();
                Move.y = 0;
                player.SetDir(M * Time.deltaTime);
                if (Input.GetMouseButton(0))
                {
                    player.SetDir(Vector3.zero);
                    player.transform.SetParent(this.transform);
                }
            }

        }
    }

}
