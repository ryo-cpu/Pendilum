using UnityEngine;

public class CameraControllrt:MonoBehaviour
{
    private GameObject player;   //�v���C���[���i�[�p
    private Vector3 offset;      //���΋����擾�p
    public float sensitivityX = 2.0f; // ����]�̊��x
    public float sensitivityY = 2.0f; // �c��]�̊��x
    public float minY = -60f; // �c��]�̍ŏ��p�x
    public float maxY = 60f; // �c��]�̍ő�p�x

    private float rotationX = 0f;
    private float rotationY = 0f;

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
        // �}�E�X�̈ړ��ʂ��擾
        float mouseX = Input.GetAxis("Mouse X") * sensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityY;

        // �c�����̉�]������݂���
        rotationY -= mouseY;
        rotationY = Mathf.Clamp(rotationY, minY, maxY);

        // ����]�͂��̂܂܉��Z
        rotationX += mouseX;

        // ��]��K�p
        transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0);
        transform.position = player.transform.position + offset;
    }
    
}
