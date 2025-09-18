using Normal.Realtime;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
	[SerializeField] private Realtime realTime;
	[SerializeField] private TMP_InputField roomNameTextField;
	[SerializeField] private Button joinRoomButton;
	[SerializeField] private GameObject CanvasGameobject;

	private void Start()
	{
		if (joinRoomButton != null) {
			joinRoomButton.onClick.AddListener(OnClickJoinRoomButton);
		}
	}

	private void OnEnable()
	{
		if (realTime != null)
		{
			realTime.didConnectToRoom += DidConnectToRoom;
			realTime.didDisconnectFromRoom += DidDisconnectFromRoom;
		}
	}

	private void OnDisable()
	{
		if (realTime != null)
		{
			realTime.didConnectToRoom -= DidConnectToRoom;
			realTime.didDisconnectFromRoom -= DidDisconnectFromRoom;
		}
	}

	private void DidConnectToRoom(Realtime room)
	{
		Debug.Log("✅ Successfully connected to room: " + room.name);
		// You can enable your gameplay canvas here
		CanvasGameobject.SetActive(true);
	}

	private void DidDisconnectFromRoom(Realtime room)
	{
		Debug.Log("❌ Disconnected from room: " + room.name);
		// Handle cleanup or show UI
		CanvasGameobject.SetActive(false);
	}

	private void OnClickJoinRoomButton()
	{
		string roomName = roomNameTextField.text;
		Debug.Log("Room Name: " + roomNameTextField.text);
		if (string.IsNullOrEmpty(roomName)) {
			Debug.Log("Empty room name....");
			return;
		}

		if(realTime != null)
		{
			realTime.Connect(roomName);
		}
	}
}
