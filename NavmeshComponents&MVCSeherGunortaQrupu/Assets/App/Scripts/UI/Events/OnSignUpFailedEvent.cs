using DynamicBox.EventManagement;

public class OnSignUpFailedEvent : GameEvent
{
	public LoginFailTypes FailType;

	public OnSignUpFailedEvent(LoginFailTypes failType)
	{
		FailType = failType;
	}
}

public enum LoginFailTypes {NONE,SAME_USERNAME_ERROR,INTERNET_CONNECTION_ERROR }