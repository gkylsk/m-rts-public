using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    public int totalParts; // Total number of parts the castle has
    private int remainingParts; // Number of parts remaining
    public GameObject lostPanel;
    public GameObject wonPanel;
    public GameObject healthBar;

    private NetworkRunner _runner;

    void Start()
    {
        // Initialize totalParts and remainingParts based on the current number of castle parts
        totalParts = GameObject.FindGameObjectsWithTag("Enemy Castle").Length;
        remainingParts = totalParts;
    }

    public void PartDestroyed()
    {
        remainingParts = remainingParts - 1;
        if (remainingParts <= 0)
        {
            healthBar.SetActive(false); // deactivate healthbar;
            CastleDestroyed();

        }
    }

    public void CastleDestroyed()
    {
        if (_runner == null)
        {
            _runner = FindObjectOfType<NetworkRunner>();

            if (_runner.IsServer)
            {
                // Host (Player) wins if the client's (Enemy's) castle is destroyed
                BattleWonPanel();
                Debug.LogError("You Win!");
            }
            if (_runner.IsClient)
            {
                // Client lost when enemy castle destroyed
                BattleLostPanel();
                Debug.LogError("You Lose!");
            }
        }

    }

    public void BattleLostPanel()
    {
        lostPanel.SetActive(true);
    }

    public void BattleWonPanel()
    {
        wonPanel.SetActive(true);
    }

}
