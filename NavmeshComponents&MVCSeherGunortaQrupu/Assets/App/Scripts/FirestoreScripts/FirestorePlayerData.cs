using Firebase.Firestore;

[FirestoreData]
public class FirestorePlayerData
{

  public FirestorePlayerData()
	{
    Name = "";

    NickName = "";

    Password = "";
  }

  [FirestoreProperty]
  public string Name { get; set; }

  [FirestoreProperty]
  public string NickName { get; set; }

  [FirestoreProperty]
  public string Password { get; set; }

}
