using UnityEngine;

public class CameraController :  MonoBehaviour
{
    private GameObject player;   //プレイヤー情報格納用
    private Vector3 offset;      //相対距離取得用
    public float sensitivityX = 2.0f; // 横回転の感度
    public float sensitivityY = 2.0f; // 縦回転の感度
    public float minY = -60f; // 縦回転の最小角度
    public float maxY = 60f; // 縦回転の最大角度
    public bool isRota = false;
    private float rotationX = 0f;
    private float rotationY = 0f;
    void Move(Vector3 MoveVector)
    {

        transform.position = transform.position + MoveVector;
        offset = transform.position - player.transform.position;
    }
    void Rota(Vector3 RotaVector)
    {
        transform.localRotation = Quaternion.Euler(RotaVector.x,RotaVector.y,RotaVector.z);
    }
    // Use this for initialization
    void Start()
    {
        rotationX = this.transform.localEulerAngles.y;
        rotationY = this.transform.localEulerAngles.x;

        //unitychanの情報を取得
        this.player = GameObject.Find("Pobject");

        // MainCamera(自分自身)とplayerとの相対距離を求める
        offset = transform.position - player.transform.position;

    }
    void Update()
    {
        if (isRota)
        {
            // マウスの移動量を取得
            float mouseX = Input.GetAxis("Mouse X") * sensitivityX;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivityY;

            // 縦方向の回転制限を設ける
            rotationY -= mouseY;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);

            // 横回転はそのまま加算
            rotationX += mouseX;

            // 回転を適用
          
        }
        transform.position = player.transform.position + offset;
    }
    
}
