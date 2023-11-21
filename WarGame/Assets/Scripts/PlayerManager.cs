using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public static int p1RPGAmmo = 1;
    public static int p1AKAmmo = 10;
    public static int p1SniperAmmo = 3;

    public static bool[] p2Guns;
    public static int p2RPGAmmo = 1;
    public static int p2AKAmmo = 10;
    public static int p2SniperAmmo = 3;
    Menu_Manager menu;
    private List<PlayerInput> players = new List<PlayerInput>();
    [SerializeField]
    private List<Transform> startingPoints;
    [SerializeField]
    private List<LayerMask> playerLayers;

    private PlayerInputManager playerInputManager;

    // Start is called before the first frame update
    void Start()
    {
        menu = FindObjectOfType<Menu_Manager>();
        menu.PlayerJoined();
        for (int i = 0; i < 2; i++)
        {
            p2Guns[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void Awake()
    {
        playerInputManager = FindObjectOfType<PlayerInputManager>();
    }

    private void OnEnable()
    {
        playerInputManager.onPlayerJoined += AddPlayer;
    }

    private void OnDisable()
    {
        playerInputManager.onPlayerJoined -= AddPlayer;
    }

    public void AddPlayer(PlayerInput player)
    {
        int Counter = 6;
        players.Add(player);

        
        Transform playerParent = player.transform.parent;


        int layerToAdd = Counter;
        Counter++;

       
        playerParent.GetComponentInChildren<CinemachineVirtualCamera>().gameObject.layer = layerToAdd;
       
        playerParent.GetComponentInChildren<Camera>().cullingMask |= 1 << layerToAdd;
       
        playerParent.GetComponentInChildren<InputHandler>().horizontal = player.actions.FindAction("Look");
    }

 }
