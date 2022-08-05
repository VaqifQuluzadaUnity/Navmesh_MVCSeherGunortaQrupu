using DynamicBox.EventManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.UIViews;

public class MainMenuController : MonoBehaviour
{
  [SerializeField] private MainMenuView view;



	private void OnEnable()
	{
		EventManager.Instance.AddListener<OnLoginFailedEvent>(OnLoginFailedEventHandler);
	}


	private void OnDisable()
	{
		EventManager.Instance.RemoveListener<OnLoginFailedEvent>(OnLoginFailedEventHandler);

	}

	public void OnLoginButtonPressed(LoginData userLoginData)
	{
		EventManager.Instance.Raise(new OnLoginButtonPressedEvent(userLoginData));
	}


	public void OnLoginFailedEventHandler(OnLoginFailedEvent eventDetails)
	{
		view.ShowRedText();
	}
}
