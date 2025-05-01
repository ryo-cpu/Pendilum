using UnityEngine;

public class CameraControllrt:MonoBehaviour
{
    private GameObject player;   //ƒvƒŒƒCƒ„[î•ñŠi”[—p
    private Vector3 offset;      //‘Š‘Î‹——£æ“¾—p
    public float sensitivityX = 2.0f; // ‰¡‰ñ“]‚ÌŠ´“x
    public float sensitivityY = 2.0f; // c‰ñ“]‚ÌŠ´“x
    public float minY = -60f; // c‰ñ“]‚ÌÅ¬Šp“x
    public float maxY = 60f; // c‰ñ“]‚ÌÅ‘åŠp“x

    private float rotationX = 0f;
    private float rotationY = 0f;

    // Use this for initialization
    void Start()
    {

        //unitychan‚Ìî•ñ‚ğæ“¾
        this.player = GameObject.Find("Pobject");

        // MainCamera(©•ª©g)‚Æplayer‚Æ‚Ì‘Š‘Î‹——£‚ğ‹‚ß‚é
        offset = transform.position - player.transform.position;

    }
    void Update()
    {
        // ƒ}ƒEƒX‚ÌˆÚ“®—Ê‚ğæ“¾
        float mouseX = Input.GetAxis("Mouse X") * sensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityY;

        // c•ûŒü‚Ì‰ñ“]§ŒÀ‚ğİ‚¯‚é
        rotationY -= mouseY;
        rotationY = Mathf.Clamp(rotationY, minY, maxY);

        // ‰¡‰ñ“]‚Í‚»‚Ì‚Ü‚Ü‰ÁZ
        rotationX += mouseX;

        // ‰ñ“]‚ğ“K—p
        transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0);
        transform.position = player.transform.position + offset;
    }
    
}
