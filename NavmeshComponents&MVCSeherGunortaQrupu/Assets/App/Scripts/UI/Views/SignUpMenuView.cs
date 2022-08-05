using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DynamicBox.UIViews
{
  public class SignUpMenuView : MonoBehaviour
  {
    [Header("Controller reference")]
    [SerializeField] private SignUpMenuController controller;

    [Header("View elements")]
    [SerializeField] private TMP_InputField userNameInputField;

    [SerializeField] private TMP_InputField userNickInputField;

    [SerializeField] private TMP_InputField userPassInputField;

    [SerializeField] private TMP_InputField userPassConfirmInputField;

    [SerializeField] private TMP_Text notificationText;

    [SerializeField] private Button signUpButton;

    public void OnInputFieldChanged()
    {
      if (string.IsNullOrEmpty(userNameInputField.text) || string.IsNullOrEmpty(userNickInputField.text)
        || string.IsNullOrEmpty(userPassInputField.text) || string.IsNullOrEmpty(userPassConfirmInputField.text))
      {
        signUpButton.interactable = false;

        return;
      }

      signUpButton.interactable = true;

    }

    public void OnSignUpButtonPressed()
    {
      if (userPassInputField.text != userPassConfirmInputField.text)
      {
        StartCoroutine(ShowSignUpInfo(SignUpNotificationType.WARNING, "Your password doesen't match"));
        return;
      }

      FirestorePlayerData playerData = new FirestorePlayerData 
      {
        Name=userNameInputField.text,
        NickName=userNickInputField.text,
        Password=userPassInputField.text 
      };



      controller.OnSignUpButtonPressed(playerData) ;

    }

    public IEnumerator ShowSignUpInfo(SignUpNotificationType notifType, string notifText)
    {
      Color textColor = new Color();

      switch (notifType)
      {
        case SignUpNotificationType.SUCCESS:
          textColor = Color.green;
          break;
        case SignUpNotificationType.WARNING:
          textColor = Color.yellow;
          break;
        case SignUpNotificationType.FAILED:
          textColor = Color.red;
          break;
      }

      notificationText.color = textColor;

      notificationText.text = notifText;

      notificationText.gameObject.SetActive(true);

      yield return new WaitForSeconds(1f);

      notificationText.gameObject.SetActive(false);
    }

  }

}
public enum SignUpNotificationType {NONE,SUCCESS,FAILED,WARNING }