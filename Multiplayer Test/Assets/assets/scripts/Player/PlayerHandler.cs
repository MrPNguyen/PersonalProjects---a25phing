 using System.Collections.Generic;
 using TMPro;
 using Unity.VisualScripting;
 using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHandler : MonoBehaviour
{
    [Header("Information")]
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private List<RuntimeAnimatorController> animators;
    [HideInInspector] public List<GameObject> players;
    
    [Header("References")]
    [SerializeField] private GameObject playerPrefab;
    private PlayerInput player;

    void Awake()
    {
        players =  new List<GameObject>();
        foreach (Gamepad gamePad in Gamepad.all)
        {
            player = PlayerInput.Instantiate(playerPrefab, controlScheme: "Gamepad", pairWithDevice: gamePad);
            players.Add(player.gameObject);

        }
        for (int i = 0; i < players.Count; i++)
        {
            players[i].tag = $"Player{i + 1}";
        }
        players[0].name = "Hasse";
        players[1].name = "Gösta";
        players[2].name = "Ulla";
        players[3].name = "Kerstin";
        
        players[0].layer = LayerMask.NameToLayer(players[0].name);
        players[1].layer = LayerMask.NameToLayer(players[1].name);
        players[2].layer = LayerMask.NameToLayer(players[2].name);
        players[3].layer = LayerMask.NameToLayer(players[3].name);
        
    }
    void Start()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            players[i].transform.position = spawnPoints[i].transform.position;
            players[i].gameObject.GetComponent<SpriteRenderer>().sprite = sprites[i];
            players[i].gameObject.GetComponent<Animator>().runtimeAnimatorController = animators[i];
        }
    }
}
