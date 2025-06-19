using UnityEngine;

public class GoldController : MonoBehaviour
{
    public int value;
    GameObject score;
    public float rotateX=0, rotateY=0, rotateZ=0;
    void Start()
    {
        score= GameObject.Find("Score");
        if(score!=null)
        {
           
        }

    }
    void Update()
    {
        transform.Rotate(new Vector3(rotateX, rotateY, rotateZ) * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {



        if (collision.gameObject.name == "Pobject")
        {
           

            ScoreController score = FindObjectOfType<ScoreController>();
            if (score!= null)
            {
              
                score.Add(value);
                Destroy(this.gameObject);
            }
           
        }
    }


}
