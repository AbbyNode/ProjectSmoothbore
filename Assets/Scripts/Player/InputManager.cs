using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerManager playerM;

    private string hMove;
    private string vMove;
    // private string anchor;
    private string fire;
    // private string genModule;
    private string selectOne;
    private string selectTwo;
    private string selectThree;

    // private InventoryManager inventoryM;
    // private ModuleGenerator1 moduleGenerator;
    private TankController tankC;
    private GunController gunC;

    void Start()
    {
        string prefix = "P" + playerM.playerNum;

        hMove = prefix + "Horizontal";
        vMove = prefix + "Vertical";
        // anchor = prefix + "Anchor";
        fire = prefix + "Fire";
        // genModule = prefix + "GenerateModule";
        selectOne = prefix + "SelectOne";
        selectTwo = prefix + "SelectTwo";
        selectThree = prefix + "SelectThree";

        // inventoryM = playerM.inventoryManager;
        // moduleGenerator1 = playerM.moduleGenerator;
        tankC = playerM.tankController;
        gunC = playerM.gunController;
    }

    void Update()
    {
        // Anchor
        // tankC.IsAnchored = (Input.GetAxisRaw(anchor) != 0);

        // Move
        Vector2 moveInput = Vector2.zero;
        moveInput.x = Input.GetAxis(hMove);
        moveInput.y = Input.GetAxis(vMove);
        if (moveInput != Vector2.zero)
        {
            tankC.MoveInput = moveInput;
        }

        // Fire
        if (Input.GetButtonDown(fire))
        {
            gunC.Fire();
        }

        // Generate Module
        // if (Input.GetButtonDown(genModule)) {
        // moduleGenerator.GenerateModule();
        // }

        //Select Module
        if (Input.GetButtonDown(selectOne))
        {
            gunC.ChangeToShotgun();
        }

        if (Input.GetButtonDown(selectTwo))
        {
            gunC.ChangeToMachineGun();
        }
        if (Input.GetButtonDown(selectThree))
        {
            gunC.ChangeToHeavyGun();
        }

    }
}
