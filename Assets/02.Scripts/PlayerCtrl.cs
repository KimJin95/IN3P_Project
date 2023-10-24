using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityStandardAssets.Utility;


public class PlayerCtrl : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private PhotonView pv;

    // private float v;
    // private float h;
    // private float r;

    // [Header("이동 및 회전 속도")]
    // public float moveSpeed = 8.0f;
    // public float turnSpeed = 0f;
    // public float jumpPower = 5f;

    // private float turnSpeedValue = 200f;

    RaycastHit hit;
    IEnumerator Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        pv = GetComponent<PhotonView>();

       // turnSpeed = 0f;
        yield return new WaitForSeconds(0.5f);

        if (pv.IsMine)
        {
            //플레이어가 photonview를 가지고 있는 경우 target으로 설정해라
            Camera.main.GetComponent<SmoothFollow>().target = transform.Find("CamPivot").transform;
        }
        else
        {
            //그렇지 않은 경우 물리작용 비활성화
            //GetComponent<Rigidbody>().isKinematic = true;
        }
       // turnSpeed = turnSpeedValue;
    }


//     void Update()
//     {
//         v = Input.GetAxis("Vertical");
//         h = Input.GetAxis("Horizontal");
//         v = Input.GetAxis("Mouse X");

// //ground 확인을 위한 레이케스트
//         Debug.DrawRay(transform.position, -transform.up * 0.6f, Color.green);
//         if (Input.GetKeyDown("space"))
//         {
//             if (Physics.Raycast(transform.position, -transform.up, out hit, 0.6f))
//             {
//                 rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
//             }
//         }
//     }

//     void FixedUpdate()
//     {
//         //플레이어가 photonview 소유하는 경우
//         if (pv.IsMine)
//         {
//             Vector3 dir = (Vector3.forward * v) + (Vector3.right * h);
//             transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.Self);
//             transform.Rotate(Vector3.up * Time.smoothDeltaTime * turnSpeed * r);
//         }
//     }
}
