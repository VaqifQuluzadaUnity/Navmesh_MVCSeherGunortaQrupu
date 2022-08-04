using DynamicBox.EventManagement;

public class OnLoginButtonPressedEvent : GameEvent
{
  public LoginData userLoginData;


  public OnLoginButtonPressedEvent(LoginData _userLoginData)
	{
		userLoginData = _userLoginData;
	}
}
