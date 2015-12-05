using UnityEngine;
using System.Collections;

public class Listeners : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnJoinedRoom()
    {
        Debug.Log("PETER");
        PhotonNetwork.Instantiate("CoolerPlayer", Vector3.zero, Quaternion.identity, 0).GetComponent <UnityStandardAssets._2D.Platformer2DUserControl>().enabled = true;
    }
}
