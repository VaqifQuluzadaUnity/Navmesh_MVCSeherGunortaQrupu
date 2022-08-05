using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.UIViews;
using DynamicBox.EventManagement;

//namespace DynamicBox.UIControllers
public class SignUpMenuController : MonoBehaviour
{
  [SerializeField] private SignUpMenuView view;

	private void OnEnable()
	{
		EventManager.Instance.AddListener<OnSignUpFailedEvent>(OnSignUpFailedEventHandler);
	}

	private void OnDisable()
	{
		EventManager.Instance.RemoveListener<OnSignUpFailedEvent>(OnSignUpFailedEventHandler);

	}

	private void OnSignUpFailedEventHandler(OnSignUpFailedEvent eventDetails)
	{
		Debug.Log(eventDetails.FailType);
		StartCoroutine(view.ShowSignUpInfo(SignUpNotificationType.FAILED,"Same username"));
	}

	public void OnSignUpButtonPressed(FirestorePlayerData playerData)
	{
		EventManager.Instance.Raise(new OnSignUpButtonPressedEvent(playerData));
	}
}
