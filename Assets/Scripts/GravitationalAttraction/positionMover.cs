using System;
using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.WebCam;
using Random = UnityEngine.Random;

public class positionMover : MonoBehaviour
{
    // Moi의 상태 정보
    public enum State
    {
        // 아무런 인풋이 없을 때 -불편한 존재
        IDLE,
        // 스페이스바 눌렀을 때 
        IN,
        // 감정 게이지가 쌓였을 때 , 이동
        MOVE,
        //RandomAction, //점프, 콩콩뛰기
        OVERLOAD, //과부하 상태

        /** 모든 상태 시작시 랜덤액션 하고들어감*/

    }

    // Moi의 현재 상태 
    [SerializeField] private State state = State.IDLE;

    // Moi의 감정 게이지 
    [SerializeField] private int emotionGauge;

    // WayPoint를 저장할 배열
    public Transform[] points;

    [SerializeField] private int nextIdx = 0;

    public float damping = 10.0f;
    public float moveSpeed = 40.0f;
    public float dist = 2.0f;   // WayPoint와의 거리

    public Text ptext;
    public Text atext;
    public float _positive;
    public float _active;

    float delaytime = 0f;
    int randomNum;

    private void Update()
    {
        randomNum = Random.Range(3, 7);
        delaytime += Time.deltaTime;
        if (delaytime > randomNum)
        {
            nextIdx = Random.Range(0, points.Length);
            //Debug.Log($"{randomNum}초");
            delaytime = 0f;
        }
        ptext.text = _positive.ToString();
        atext.text = _active.ToString();

        Debug.Log($"p: {ptext.text} n:{atext.text}");
    }
    // 스크립트가 활성화될 때마다 호출되는 함수
    private void OnEnable()
    {
        // 무아의 상태를 체크하는 코루틴 함수 호출
        StartCoroutine(CheckMoiState());

        // 상태에 따라 무아의 행동을 수행하는 코루틴 함수 호출
        StartCoroutine(MoiAction());
    }

    IEnumerator CheckMoiState()
    {
        while (true)
        {
            // 0.3초 중지(대기)하는 동안 제어권은 메시지 루브에 양보
            yield return new WaitForSeconds(0.001f);
            float distance = Vector3.Distance(transform.position, points[nextIdx].position);

            //Debug.Log($" WayPoint와의 거리 : {distance}");

            // Moi와 WayPoint가 WayPoint에 가깝게 들어와 있으면서 스페이스바를 눌렀을 때 
            if (Input.GetKey(KeyCode.Space) && distance <= dist)
            {
                Debug.Log($" 스페이스바 눌림 ");
                state = State.IN;
            }
            else if (emotionGauge >= 10)
            {
                state = State.MOVE;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                Debug.Log($" a -jump ");
            }
            else
            {
                state = State.IDLE;
            }

        }
    }

    IEnumerator MoiAction()
    {
        while (true)
        {
            switch (state)
            {
                // IDLE 상태
                case State.IDLE:
                    // Idle 애니메이션 실행
                    transform.LookAt(Camera.main.transform);
                    //transform.transform.localScale = ;
                    break;

                // CONVERSATIPN 상태
                case State.IN:
                    // 관객의 인풋에 따른 애니메이션 실행
                    transform.LookAt(Camera.main.transform);
                    emotionGauge++;
                    if (emotionGauge % 10 == 0)
                    {
                        // Moi가 이동할 랜덤한 위치 산출
                        nextIdx = Random.Range(0, points.Length);
                    }
                    break;

                // MOVE
                case State.MOVE:
                    // 다음 WayPoint 위치로 바라보는 각도 산출 
                    Vector3 dir = points[nextIdx].position - transform.position;

                    // 벡터를 Quaternion 변환
                    Quaternion rot = Quaternion.LookRotation(dir);

                    // 구면선형 보간(Spherecal Lineal Interpolate)을 사용해서 회전
                    transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * damping);

                    // 이동 (직진)
                    transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
                    break;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    void RandAction()
    {
        
    }

    private int switchIndex()
    {
        float delaytime = 0f;
        delaytime += Time.deltaTime;
        if (delaytime >= 3f)
        {
            nextIdx = Random.Range(0, points.Length);
            delaytime = 0f;
            Debug.Log("3초");
        }
        return nextIdx;
    }
}