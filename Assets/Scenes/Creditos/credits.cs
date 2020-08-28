using UnityEngine;
using UnityEngine.SceneManagement;

public class credits : MonoBehaviour
{
    void Start()
    {

        GameObject camera = GameObject.Find("Main Camera");

        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();

        videoPlayer.playOnAwake = false;

        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;

        videoPlayer.url = "Assets/Scenes/Creditos/creditosFinalxd.mp4";

        videoPlayer.isLooping = true;

        videoPlayer.loopPointReached += EndReached;

        videoPlayer.Play();
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.playbackSpeed = vp.playbackSpeed / 10.0F;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Inicio");
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
