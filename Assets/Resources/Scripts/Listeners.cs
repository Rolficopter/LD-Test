using UnityEngine;
using UnityStandardAssets._2D;

public class Listeners : MonoBehaviour {
    public LayerMask PlayerGroup = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnJoinedRoom()
    {
        Vector3 spawnLocation = this.GetRandomSpawn().position;
        GameObject newPlayer = PhotonNetwork.Instantiate("CoolerPlayer", spawnLocation, Quaternion.identity, PlayerGroup);

        // follow new player
        Camera mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        Camera2DFollow cameraFollow = mainCamera.GetComponent<Camera2DFollow>();
        cameraFollow.target = newPlayer.transform;
        cameraFollow.enabled = true;

        // enable control
        newPlayer.GetComponent<Platformer2DUserControl>().enabled = true;
    }

    private Transform GetRandomSpawn()
    {
        Transform[] spawns = this.GetSpawns();

        int index = Random.Range(0, spawns.Length);
        return spawns[index];
    }
    private Transform[] GetSpawns()
    {
        GameObject spawnPointsParent = GameObject.Find("Map/SpawnPoints");
        Transform[] spawnPoints = spawnPointsParent.GetComponentsInChildren<Transform>();

        return spawnPoints;
    }
}
