using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lands_of_Arkana
{

    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public Transform PlayerSpawnPoint;

        [HideInInspector] public PlayerController Player;
        [HideInInspector] public InputManager InputHandler;
        [HideInInspector] public CameraRig CameraControl;

        void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Game Manager Error: Instance Already Exists. Deleting new Instance.");
                Destroy(this.gameObject);
                return;
            }
            Instance = this;

            InputHandler = GetComponent<InputManager>();
            
            
            CameraControl = Instantiate(CameraRigPrefab).GetComponent<CameraRig>();
            Player = Instantiate(PlayerPrefab, PlayerSpawnPoint.position, Quaternion.identity).GetComponent<PlayerController>();

        }

        void Start()
        {
            CameraControl.Init();
            Player.Init();
            CameraControl.Target = Player.transform;

        }

        void Update()
        {
            deltaTime = Time.deltaTime;
  
            InputHandler.Tick(deltaTime);
            CameraControl.Tick(deltaTime);
            
            Player.Tick(deltaTime);
            
        }

        void FixedUpdate()
        {
            fixedDeltaTime = Time.fixedDeltaTime;

            CameraControl.FixedTick(fixedDeltaTime);
            Player.FixedTick(fixedDeltaTime);

        }

        void LateUpdate()
        {
            Player.LateTick();
        }


        float deltaTime;
        float fixedDeltaTime;

        [SerializeField] GameObject PlayerPrefab;
        [SerializeField] GameObject CameraRigPrefab;


    }

}