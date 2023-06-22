using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class EnvoiDonnees : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GetUsers());
        StartCoroutine(Login("jordy","jordy@gmail.com"));
    }
    IEnumerator GetUsers()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/projetdev/Getuser.php"))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);

                byte[] results = www.downloadHandler.data;
            }
        }
    }

    IEnumerator Login(string username, string email)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginEmail", email);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/projetdev/Login.php", form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);

                byte[] results = www.downloadHandler.data;
            }
        }
    }
}
