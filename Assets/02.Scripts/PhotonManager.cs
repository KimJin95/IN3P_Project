using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;
using UnityEngine.UI;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    //버전 입력
    private readonly string version = "1.0f";

    //사용자 아이디 입력
    public InputField NickNameInput;
    public GameObject LoginPanel;
    public GameObject Befor_Connect;
    public GameObject After_Connect;

    [Header("UI 관련 기능")]
    public GameObject connectUI;
    public GameObject joinUI;
    public Text connectingText;
    public Text joinText;


    void Awake()
    {
        //같은 룸의 유저들에게 자동으로 씬을 로딩
        //PhotonNetwork.AutomaticallySyncScene = true;
        //같은 버전의 유저끼리 접속 허용
        PhotonNetwork.GameVersion = version;
        //유저 아이디 할당
        //PhotonNetwork.NickName = userID;
        //포톤 서버와 통신 횟수 설정 -> 초당 30회
        // print(PhotonNetwork.SendRate);
        //서버 접속
        //PhotonNetwork.ConnectUsingSettings();


    }

    void Start()
    {
        //PhotonNetwork.NickName = userID;
        // connectingText.text = "connecting...";
        // joinText.text = "Please wait...";

        // yield return PhotonNetwork.ConnectUsingSettings();

        //if (PhotonNetwork.IsConnected)
        // {
        // Befor_Connect.SetActive(false);
        //After_Connect.SetActive(true);
        // }
        //  else
        //  {
        //      Application.Quit();
        //  }
    }

    public void Connect()
    {
        connectingText.text = "connecting...";
        joinText.text = "Please wait...";

        if (NickNameInput.text.Length > 1)
        {
            joinUI.SetActive(false);

            PhotonNetwork.NickName = NickNameInput.text;
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            joinUI.SetActive(false);

            NickNameInput.text = "Unkown";

            PhotonNetwork.NickName = NickNameInput.text;
            PhotonNetwork.ConnectUsingSettings();
        }


    }

    //포톤 서버에 접속 후 호출 되는 콜백 함수
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.LocalPlayer.NickName = NickNameInput.text;

        print("01.포톤 서버에 접속");
        print($"PhotonNetwork.InLobby={PhotonNetwork.InLobby}");


        //로비 입장
        PhotonNetwork.JoinRandomRoom();
    }

    //로비에 접속 후 호출되는 콜백 함수
    // public override void OnJoinedLobby()
    // {
    //     print($"PhotonNetwork.InLobby={PhotonNetwork.InLobby}");
    //     //랜덤 매치메이킹 기능 제공 (이미 열려있는 룸에 무작위로 조인할수 있도록 해줌)
    //     PhotonNetwork.JoinRandomRoom();
    // }

    //랜덤한 룸 입장이 실패했을 경우 호출되는 콜백 함수
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log($"랜덤 룸 접속 실패 {returnCode} : {message}");

        //룸 속성 정의
        RoomOptions ro = new RoomOptions();
        //최대 접속자 20명
        ro.MaxPlayers = 20;
        ro.IsOpen = true; //룸 오픈 여부
        ro.IsVisible = true; //로비에서 룸 목록 노출 시킬지 여부

        //룸 생성
        PhotonNetwork.CreateRoom("My Room", ro);
    }

    //룸 생성 완료된 후 호출되는 콜백 함수
    public override void OnCreatedRoom()
    {
        Debug.Log("룸 생성 완료");
        Debug.Log($"Room Name = {PhotonNetwork.CurrentRoom.Name}");
    }

    //룸 입장후 호출되는 콜백 함수
    public override void OnJoinedRoom()
    {

        print("룸 입장 완료");
        Debug.Log($"PhotonNetwork.InRoom = {PhotonNetwork.InRoom}");
        print($"Player Count = {PhotonNetwork.CurrentRoom.PlayerCount}");

        //룸에 접속한 사용자 정보 확인
        foreach (var player in PhotonNetwork.CurrentRoom.Players)
        {
            print($"{player.Value.NickName},{player.Value.ActorNumber}");
        }

        connectUI.SetActive(false);

        //캐릭터 출현 정보를 배열에 저장
        Transform[] points = GameObject.Find("Spawn Points").GetComponentsInChildren<Transform>();
        int idx = Random.Range(1, points.Length);

        //캐릭터 생성
        PhotonNetwork.Instantiate("Player", points[idx].position, points[idx].rotation, 0);

        //GameManager.instance.isConnect = true;
    }




    void Update()
    {

    }
}
