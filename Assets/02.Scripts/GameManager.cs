using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public bool isConnect = false;
    public Transform spawnpoint;


    // void Awake()
    // {
    //     if (instance == null)
    //     {
    //         instance = this;
    //         DontDestroyOnLoad(this.gameObject);
    //     }
    //     else if (instance != this)
    //     {
    //         Destroy(this.gameObject);
    //     }
    // }

    void Start()
    {
        //StartCoroutine(CreatePlayer());

       
    }

    // // Update is called once per frame
    // void Update()
    // {

    // }

    // IEnumerator CreatePlayer()
    // {
    //     yield return new WaitUntil(() => isConnect);

    //     spawnpoint = GameObject.Find("Spawn Point").GetComponent<Transform>();

    //     Vector3 pos = spawnpoint.position;
    //     Quaternion rot = spawnpoint.rotation;

    //     GameObject playerTemp = PhotonNetwork.Instantiate("Player", pos, rot, 0);
    // }
}
