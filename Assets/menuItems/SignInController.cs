using Assets.Personajes.Astronaut.scripts;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SignInController : MonoBehaviour
{
    string email = "";
    string password = "";
    public GameObject alert;

    public void OnClickSignIn() {
        UserRequestModel request = new()
        {
            email = email,
            password = password
        };
        StartCoroutine(PostRequest("http://localhost:8000/api/sign_in", JsonUtility.ToJson(request)));
    }

    IEnumerator PostRequest(string url, string json)
    {
        UnityWebRequest uwr = new(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = new DownloadHandlerBuffer();
        uwr.SetRequestHeader("content-type", "application/json");

        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.ConnectionError)
        {
            print("Error While Sending: " + uwr.error);
        }
        else
        {
            if (uwr.responseCode == 200)
            {
                UserResponseModel response = JsonUtility.FromJson<UserResponseModel>(uwr.downloadHandler.text);
                print("Received: " + response.token);
                PlayerPrefs.SetString("token", response.token);
                AstronautEntity.user = response.user;
                if(AstronautEntity.user.type == "estudiante")
                {
                    SceneManager.LoadScene(2);
                }else
                {
                    SceneManager.LoadScene(3);
                }
            }else if(uwr.responseCode == 401)
            {
                ErrorResponse response = JsonUtility.FromJson<ErrorResponse>(uwr.downloadHandler.text);
                alert.SetActive(true);
                GameObject.Find("ErrorText").GetComponent<Text>().text = response.mssg;
                print("Error: " + uwr.downloadHandler.text);
            }
        }
        uwr.Dispose();
    }

    public void OnChangeEmail(string email){
        this.email = email;
    }

    public void OnChangePassword(string password){
        this.password = password;
    }

    public void GoRegister()
    {
        SceneManager.LoadScene(1);
    }
}
