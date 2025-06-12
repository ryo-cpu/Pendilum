using System;
using UnityEngine;

public class PendulumContoroller : MonoBehaviour
{
    public float RopeLength = 20;
    private GameObject Root;   //êeèÓïÒäiî[óp
    private Vector3 Move;//ìÆÇ´ÇçÏÇÈÇÊÇ§
    private Vector3 tension;//ìnÇ∑ópÇÃäiî[
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

        Vector3 P =(Dir+Dis);
        Debug.LogWarning(P);
        return P*10 ; 
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
       
        Move.y -= Gravity;//èÌÇ…ë´Ç≥ÇÍÇƒÇ¢ÇÈÇÃÇ≈Ç¢Ç¬Ç©âÛÇÍÇÈ
        if (Move.y < -5.0f)
        {
            ///èdóÕÇÃç≈çÇâ¡ë¨ìx
            Move.y = -5.0f;
        }

        Vector3 TopPos = transform.position + Move;///Ç»Ç…Ç‡Ç»Ç¢èÛë‘Ç≈ÇÃìÆÇ´
        var RootPos = Root.transform.position;
        float dis = Vector3.Magnitude(TopPos - RootPos);///âΩÇ‡Ç»Ç¢éûÇÃ2ì_ÇÃãóó£
        Vector3 Tension = Vector3.zero;
        if (dis > RopeLength)
        {
            Vector3 Distance = RootPos - TopPos;
            Vector3 normalizDistance = Distance.normalized;
            Tension = Distance-(normalizDistance * RopeLength) ;
            tension = Tension;

            Debug.LogWarning(Tension);
        }
        else
        {
            tension = new Vector3(0,0,0);
        }

            Move += Tension;
        ///èuä‘ÇÃç≈ëÂë¨ìx
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
