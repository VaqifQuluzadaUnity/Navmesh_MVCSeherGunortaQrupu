using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
  [Header("Controller reference")]
  [SerializeField] private MainMenuController controller;

  [Header("View references")]

  [SerializeField] private TMP_InputField userNameInputField;

  [SerializeField] private TMP_InputField userPassInputField;

  [SerializeField] private TMP_Text redText;

  [SerializeField] private Button loginButton;

  public void OnUserNameInputFieldChanged(string input)
	{
    if(string.IsNullOrEmpty(input) || string.IsNullOrEmpty(userPassInputField.text))
		{
      Debug.Log("Username or password is empty");
      loginButton.interactable = false;
      return;
		}
    else if(input.Length<10 || userPassInputField.text.Length < 10)
		{
      Debug.Log("Weak username or pass");
      loginButton.interactable = false;
      return;
    }

    loginButton.interactable = true;
	}

  public void onUserPassInputFieldChanged(string input)
	{
    if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(userNameInputField.text))
    {
      Debug.Log("Username or password is empty");
      loginButton.interactable = false;
      return;
    }
    else if (input.Length < 10 || userNameInputField.text.Length < 10)
    {
      Debug.Log("Weak username or pass");
      loginButton.interactable = false;
      return;
    }

    loginButton.interactable = true;
  }


  public void OnLoginButtonPressed()
	{
    LoginData userLoginData = new LoginData(userNameInputField.text, userPassInputField.text);

    controller.OnLoginButtonPressed(userLoginData);
	}

  public void ShowRedText()
	{
    StartCoroutine(ShowRedTextCoroutine());
	}

  IEnumerator ShowRedTextCoroutine()
	{
    redText.gameObject.SetActive(true);

    yield return new WaitForSeconds(1f);

    redText.gameObject.SetActive(false);

  }

}
