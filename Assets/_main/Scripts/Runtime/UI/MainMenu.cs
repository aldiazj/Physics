using Runtime.Target;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Runtime.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button houseButton;
        [SerializeField] private Button macarenaButton;
        [SerializeField] private Button waveButton;
        [SerializeField] private Button startButton;
        [SerializeField] private Target.Target target;

        private void Awake()
        {
            houseButton.onClick.AddListener(() => target.SetDance(Dance.House));
            macarenaButton.onClick.AddListener(() => target.SetDance(Dance.Macarena));
            waveButton.onClick.AddListener(() => target.SetDance(Dance.Wave));
            startButton.onClick.AddListener(() => SceneManager.LoadScene(sceneBuildIndex: 1));
        }

        private void OnDestroy()
        {
            houseButton.onClick.RemoveAllListeners();
            macarenaButton.onClick.RemoveAllListeners();
            waveButton.onClick.RemoveAllListeners();
            startButton.onClick.RemoveAllListeners();
        }
    }
}
