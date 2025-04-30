using UnityEngine;

public class CameraControllrt:MonoBehaviour
{
    private GameObject player;   //プレイヤー情報格納用
    private Vector3 offset;      //相対距離取得用

    // Use this for initialization
    void Start()
    {

        //unitychanの情報を取得
        this.player = GameObject.Find("Pobject");

        // MainCamera(自分自身)とplayerとの相対距離を求める
        offset = transform.position - player.transform.position;

    }
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
    
}
