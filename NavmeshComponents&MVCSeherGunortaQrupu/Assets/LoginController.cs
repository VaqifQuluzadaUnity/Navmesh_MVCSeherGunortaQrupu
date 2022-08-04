using DynamicBox.EventManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginController : MonoBehaviour
{
  [SerializeField] private string correctUserName;

  [SerializeField] private string correctPass;

	private void OnEnable()
	{
		EventManager.Instance.AddListener<OnLoginButtonPressedEvent>(OnLoginButtonPressedEventHandler);
	}

	private void OnDisable()
	{
		EventManager.Instance.RemoveListener<OnLoginButtonPressedEvent>(OnLoginButtonPressedEventHandler);
	}


	private void OnLoginButtonPressedEventHandler(OnLoginButtonPressedEvent eventDetails)
	{
		Debug.Log(eventDetails.userLoginData.userName);

    if(eventDetails.userLoginData.userName!=correctUserName || eventDetails.userLoginData.userPass != correctPass)
		{
			EventManager.Instance.Raise(new OnLoginFailedEvent());
      return;
		}

    Debug.Log("Logged in successfully");
	}

}


[System.Serializable]
public class LoginData
{
  public string userName;

  public string userPass;

  public LoginData(string _userName,string _userPass)
	{
    userName = _userName;

    userPass = _userPass;
	}
}
