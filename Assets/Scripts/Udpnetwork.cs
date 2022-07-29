using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

public class Udpnetwork : MonoBehaviour
{
	public GameObject ob1;
	public positionMover moi;

	public float distance;
	private Queue<string> msg_queue = new Queue<string>();

	private static Udpnetwork instance;
	public static Udpnetwork Instance
	{
		get
		{
			return instance;
		}
		set
		{
			instance = null;
		}
	}
	// 1. Declare Variables
	float s;

	Thread receiveThread;
	UdpClient client;
	int port = 9988;

	public String targetip = "127.0.0.1";
	public int targetport = 9088;

	IPEndPoint anyIP;


	void Awake()
	{
		if (instance != null)
			Destroy(gameObject);
		else
			instance = this;
		DontDestroyOnLoad(gameObject);
	}
	// 2. Initialize variables
	private void Start()
	{
		InitUDP();
	}

	// 3. InitUDP
	private void InitUDP()
	{
		client = new UdpClient(port); //1
		anyIP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 0);
		Debug.Log("UDP Initialized");
		receiveThread = new Thread(new ThreadStart(ReceiveData));
		receiveThread.IsBackground = true;
		receiveThread.Start();
	}

	// 4. Receive Data
	private void ReceiveData()
	{
		while (true) //2
		{
			try
			{
				//3
				byte[] data = client.Receive(ref anyIP); //4
				string text = Encoding.UTF8.GetString(data); //5
				msg_queue.Enqueue(text);
				//Debug.Log(text);
			}
			catch (Exception e)
			{
				print(e.ToString()); //7
			}
		}
	}

	void dealQueue()
	{
		while (msg_queue.Count > 0)
		{
			try
			{
				string text = msg_queue.Dequeue();
				string[] msgs = text.Split(',');
				string target = msgs[0];
				if (target == "a1")
				{
					float s = float.Parse(msgs[1])*360;
					Debug.Log($"a1: {s}");
					ob1.transform.rotation = Quaternion.Euler(0, s, 0);
					moi._positive += 1;
					moi._active += .1f;
				}
				if (target == "a2")
				{
					float s = float.Parse(msgs[1]) * 360;
					ob1.transform.rotation = Quaternion.Euler(0, 0, s);
					moi._positive -= 1;
				}
				if (target == "b1")
				{
					if (msgs[1] == "p")
					{
						ob1.SetActive(true);
					}
					else if (msgs[1] == "r")
					{
						ob1.SetActive(false);
					}
				}
				if (target == "distance")
				{
					float s = float.Parse(msgs[1])*100;
					Debug.Log($"dis:{s}");
					ob1.transform.localScale = new Vector3(s,s,s);
					moi._active += 1 ;
				}
				if (target == "l")
				{
					float s = float.Parse(msgs[1]);
					ob1.transform.rotation = Quaternion.Euler(s, 0, 0);
				}
			}
			catch (Exception e)
			{
				print(e.ToString());
			}
		}
	}


	void Update()
	{
		//Sendmsg("f11110");
		//cube1.transform.localEulerAngles = new Vector3(0, 180 * s, 0);
		//cube.transform.position = new Vector3(0, distance, 0);
		dealQueue();
	}

	public void Sendmsg(String msg)
	{
		byte[] datagram = Encoding.UTF8.GetBytes(msg);
		Debug.Log(msg);
		client.Send(datagram, datagram.Length, targetip, targetport);
	}

	void OnApplicationQuit()
	{
		client.Close();
		receiveThread.Abort();
	}
}