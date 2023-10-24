using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
    public class SmoothFollow : MonoBehaviour
    {
        //카메라가 쫒을 타겟
        [SerializeField] public Transform target;

        //거리
        [SerializeField] private float distance = 10f;
        //카메라 높이
        [SerializeField] private float height = 5f;

        [SerializeField] private float rotationDamping;
        [SerializeField] private float heightDamping;
        void Start()
        {
          //target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // Update is called once per frame
        void Update()
        {
            //타켓 없으면 아웃
            if (!target) return;


            // 현재 회전 각도 계산
            var wantedRotationAngle = target.eulerAngles.y;
            var wantedHeight = target.position.y + height;

            var currentRotationAngle = transform.eulerAngles.y;
            var currentHeight = transform.position.y;

            //y축 회전 감소
            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
            //높이 감소
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
            //각도를 회전으로 바꾸다..?
            var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

            transform.position = target.position;
            transform.position -= currentRotation * Vector3.forward * distance;

            transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

            transform.LookAt(target);

        }
    }
}

