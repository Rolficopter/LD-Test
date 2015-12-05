using UnityEngine;
using System.Collections;

public class MagicSyncingThing : MonoBehaviour {

    private Vector3 correctPos;
    private Quaternion correctRotate;

    void Update()
    {
        if (!this.GetComponent<PhotonView>().isMine)
        {
            transform.position = Vector3.Lerp(transform.position, this.correctPos, Time.deltaTime * 10);
            transform.rotation = Quaternion.Lerp(transform.rotation, this.correctRotate, Time.deltaTime * 10);
        }
    }

	// Use this for initialization
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            this.correctPos = (Vector3)stream.ReceiveNext();
            this.correctRotate = (Quaternion)stream.ReceiveNext();
        }
    }
}
