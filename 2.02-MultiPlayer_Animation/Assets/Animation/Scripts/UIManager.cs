using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : NetworkBehaviour
{
    [SerializeField] private Button HostButton;
    [SerializeField] private Button ClientButton;
    private void Awake()
    {
        HostButton.onClick.AddListener(() => {
            NetworkManager.Singleton.StartHost();
        });

        ClientButton.onClick.AddListener(() => {
            NetworkManager.Singleton.StartClient();
        });
    }
}
