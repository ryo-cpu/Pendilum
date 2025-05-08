using System;
using UnityEngine;

public class PendulumContoroller : MonoBehaviour
{
    public float RopeLength = 20;
    private GameObject Root;   //eî•ñŠi”[—p
    private Vector3 Move;//“®‚«‚ðì‚é‚æ‚¤
    private GameObject player;
    public float Gravity = 2.0f;
   public  void SetMove(Vector3 move)
    {
        Move = move;


    }
    public Vector3 GetMove()
    {
        return Move*10; 
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
       
        Move.y -= Gravity;//í‚É‘«‚³‚ê‚Ä‚¢‚é‚Ì‚Å‚¢‚Â‚©‰ó‚ê‚é
       
        Vector3 TopPos = transform.position+Move;///‚È‚É‚à‚È‚¢ó‘Ô‚Å‚Ì“®‚«
        var RootPos = Root.transform.position;
        float dis =Vector3.Magnitude( TopPos-RootPos);///‰½‚à‚È‚¢Žž‚Ì2“_‚Ì‹——£
        Vector3 Tension = Vector3.zero;
        if (dis > RopeLength)
        {
            Vector3 Distance=RootPos-TopPos;
            Vector3 normalizDistance = Distance.normalized;
            Tension = Distance - (normalizDistance * RopeLength);

           

        }
       
        Move += Tension;//í‚É‘«‚³‚ê‚Ä‚¢‚é‚Ì‚Å‚¢‚Â‚©‰ó‚ê‚é
        ///uŠÔ‚ÌÅ‘å‘¬“x
        if (Move.magnitude > 10.0f)
        {
            Vector3 NMove = Move.normalized;
            Move = NMove * 10.0f;
         }
        transform.position += Move * Time.deltaTime*10;

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
