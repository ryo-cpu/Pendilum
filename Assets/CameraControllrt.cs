using UnityEngine;

public class CameraControllrt:MonoBehaviour
{
    private GameObject player;   //�v���C���[���i�[�p
    private Vector3 offset;      //���΋����擾�p

    // Use this for initialization
    void Start()
    {

        //unitychan�̏����擾
        this.player = GameObject.Find("Pobject");

        // MainCamera(�������g)��player�Ƃ̑��΋��������߂�
        offset = transform.position - player.transform.position;

    }
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
    
}
