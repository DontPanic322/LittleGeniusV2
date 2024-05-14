using UnityEngine;

public class ResetScript : MonoBehaviour
{
    public void ResetPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
