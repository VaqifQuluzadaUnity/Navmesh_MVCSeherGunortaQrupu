using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using Firebase.Extensions;
using TMPro;

public class FirestoreDataFetchController : MonoBehaviour
{
	public static string PlayerDataPath="PlayerData";

  [SerializeField] private TMP_Text userNameText;

  [SerializeField] private TMP_Text userNickNameText;

  FirebaseFirestore firestoreInstance;

	private void Start()
	{
		firestoreInstance = FirebaseFirestore.DefaultInstance;

		DocumentReference userDocReference = 
			firestoreInstance.Collection(PlayerDataPath).Document("VaqifQuluzada");

		userDocReference.GetSnapshotAsync().ContinueWithOnMainThread
			(task =>
			{
				if (task.Result.Exists)
				{
					FirestorePlayerData playerData = task.Result.ConvertTo<FirestorePlayerData>();



					userNameText.text = playerData.Name;

					userNickNameText.text = playerData.NickName;
				}
				else
				{
					Debug.Log("Cant find player data");
				}
			}

			);
	}
}
