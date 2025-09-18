using Normal.Realtime;
using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class NetworkedGrabInteractable : MonoBehaviour
{
	[SerializeField] private XRGrabInteractable _grabInteractable;
	[SerializeField] private RealtimeView _realTimeView;
	[SerializeField] private RealtimeTransform _realTimeTransform;

	private void Awake()
	{
		_grabInteractable = GetComponent<XRGrabInteractable>();
		_realTimeView = GetComponent<RealtimeView>();
		_realTimeTransform = GetComponent<RealtimeTransform>();
	}

	private void OnEnable()
	{
		_grabInteractable.selectEntered.AddListener(RequestOwnership);
		_grabInteractable.selectExited.AddListener(ClearOwnership);

	}
	private void OnDisable()
	{
		_grabInteractable.selectEntered.RemoveListener(RequestOwnership);
		_grabInteractable.selectExited.RemoveListener(ClearOwnership);

	}

	private void ClearOwnership(SelectExitEventArgs arg0)
	{
		if (_realTimeView.isOwnedLocallySelf)
		{
			_realTimeView.ClearOwnership();
		}
		if (_realTimeView.isOwnedLocallySelf)
		{
			_realTimeTransform.ClearOwnership();
		}
	}

	private void RequestOwnership(SelectEnterEventArgs arg0)
	{
		_realTimeView.RequestOwnership();
		_realTimeTransform.RequestOwnership();
	}
}
