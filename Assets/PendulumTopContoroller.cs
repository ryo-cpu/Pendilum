using System;
using UnityEngine;

public class PendulumContoroller : MonoBehaviour
{
    public float RopeLength = 20;
    private GameObject Root;   //eî•ñŠi”[—p
    private Vector3 Move;//“®‚«‚ðì‚é‚æ‚¤
    private GameObject player;
    public float Gravity = 2.0f;
     void SetMove(Vector3 move)
    {
        Move = move;
        
        
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
        Move.y -= Gravity;
        Vector3 TopPos = transform.position+Move;
        var RootPos = Root.transform.position;
        float dis =Vector3.Magnitude( TopPos-RootPos);
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
            if (player != null)
            {
                Move = player.SendMove();
                player.SetDir(Vector3.zero);
            }

        }
    }

}
