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
    // Moi�� ���� ����
    public enum State
    {
        // �ƹ��� ��ǲ�� ���� �� -������ ����
        IDLE,
        // �����̽��� ������ �� 
        IN,
        // ���� �������� �׿��� �� , �̵�
        MOVE,
        //RandomAction, //����, ����ٱ�
        OVERLOAD, //������ ����

        /** ��� ���� ���۽� �����׼� �ϰ��*/

    }

    // Moi�� ���� ���� 
    [SerializeField] private State state = State.IDLE;

    // Moi�� ���� ������ 
    [SerializeField] private int emotionGauge;

    // WayPoint�� ������ �迭
    public Transform[] points;

    [SerializeField] private int nextIdx = 0;

    public float damping = 10.0f;
    public float moveSpeed = 40.0f;
    public float dist = 2.0f;   // WayPoint���� �Ÿ�

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
            //Debug.Log($"{randomNum}��");
            delaytime = 0f;
        }
        ptext.text = _positive.ToString();
        atext.text = _active.ToString();

        Debug.Log($"p: {ptext.text} n:{atext.text}");
    }
    // ��ũ��Ʈ�� Ȱ��ȭ�� ������ ȣ��Ǵ� �Լ�
    private void OnEnable()
    {
        // ������ ���¸� üũ�ϴ� �ڷ�ƾ �Լ� ȣ��
        StartCoroutine(CheckMoiState());

        // ���¿� ���� ������ �ൿ�� �����ϴ� �ڷ�ƾ �Լ� ȣ��
        StartCoroutine(MoiAction());
    }

    IEnumerator CheckMoiState()
    {
        while (true)
        {
            // 0.3�� ����(���)�ϴ� ���� ������� �޽��� ��꿡 �纸
            yield return new WaitForSeconds(0.001f);
            float distance = Vector3.Distance(transform.position, points[nextIdx].position);

            //Debug.Log($" WayPoint���� �Ÿ� : {distance}");

            // Moi�� WayPoint�� WayPoint�� ������ ���� �����鼭 �����̽��ٸ� ������ �� 
            if (Input.GetKey(KeyCode.Space) && distance <= dist)
            {
                Debug.Log($" �����̽��� ���� ");
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
                // IDLE ����
                case State.IDLE:
                    // Idle �ִϸ��̼� ����
                    transform.LookAt(Camera.main.transform);
                    //transform.transform.localScale = ;
                    break;

                // CONVERSATIPN ����
                case State.IN:
                    // ������ ��ǲ�� ���� �ִϸ��̼� ����
                    transform.LookAt(Camera.main.transform);
                    emotionGauge++;
                    if (emotionGauge % 10 == 0)
                    {
                        // Moi�� �̵��� ������ ��ġ ����
                        nextIdx = Random.Range(0, points.Length);
                    }
                    break;

                // MOVE
                case State.MOVE:
                    // ���� WayPoint ��ġ�� �ٶ󺸴� ���� ���� 
                    Vector3 dir = points[nextIdx].position - transform.position;

                    // ���͸� Quaternion ��ȯ
                    Quaternion rot = Quaternion.LookRotation(dir);

                    // ���鼱�� ����(Spherecal Lineal Interpolate)�� ����ؼ� ȸ��
                    transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * damping);

                    // �̵� (����)
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
            Debug.Log("3��");
        }
        return nextIdx;
    }
}