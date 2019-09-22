using UnityEngine;
using System.Collections;

public class CameraTracksPlayer : MonoBehaviour
{

    Transform player;
    float offsetXLandScape;

    // Use this for initialization
    void Start()
    {
        GameObject player_go = GameObject.FindGameObjectWithTag("Player");

        if (player_go == null)
        {
            Debug.LogError("Couldn't find an object with tag player.");
            return;
        }

        player = player_go.transform;
        offsetXLandScape = transform.position.x - player.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 temp = new Vector3(player.position.x + offsetXLandScape, transform.position.y, transform.position.z);
            transform.position = temp;
        }

    }
}
