using UnityEngine;
using Firebase.Firestore;
using Firebase.Extensions;
using DynamicBox.EventManagement;

public class FireStoreSignUpManager : MonoBehaviour
{
	FirebaseFirestore firestoreInstance;

	private void Start()
	{
		firestoreInstance = FirebaseFirestore.DefaultInstance;
	}

	private void OnEnable()
	{
		EventManager.Instance.AddListener<OnSignUpButtonPressedEvent>(OnSignUpButtonPressedEventHandler);
	}

	private void OnDisable()
	{
		EventManager.Instance.RemoveListener<OnSignUpButtonPressedEvent>(OnSignUpButtonPressedEventHandler);
	}




	private void OnSignUpButtonPressedEventHandler(OnSignUpButtonPressedEvent eventDetails)
	{
		Debug.Log(eventDetails.PlayerData.NickName);
		//Check if nickname available
		Query sameNickQuery = 
			firestoreInstance.Collection("PlayerData").
			WhereEqualTo("NickName", eventDetails.PlayerData.NickName);

		sameNickQuery.GetSnapshotAsync().ContinueWithOnMainThread(task => 
		{
			Debug.Log(task.Result.Count);
			if (task.Result.Count == 0)
			{
				//Sign up
				DocumentReference document = firestoreInstance.Collection("PlayerData").
				Document(eventDetails.PlayerData.NickName);

				document.SetAsync(eventDetails.PlayerData);
			}
			else
			{
				EventManager.Instance.Raise(new OnSignUpFailedEvent(LoginFailTypes.SAME_USERNAME_ERROR));
			}
		}
		);


		
	}



}
