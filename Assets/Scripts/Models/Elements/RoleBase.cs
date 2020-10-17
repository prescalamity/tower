using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleBase : ElementBase
{

    protected int attackDistance;
    protected int attack;
    protected bool isActiveGO = true;
    protected Sprite cannonSprite;

    public int AttackDistance { get => attackDistance; set => attackDistance = value; }
    public int Attack { get => attack; set => attack = value; }
    public bool IsActiveGO { get => isActiveGO;
        set {
            isActiveGO = value;
            if(isActiveGO)
                gameObject.SetActive(true);
            else
                gameObject.SetActive(false);
        }
    }
    public Sprite CannonSprite { get => cannonSprite; set => cannonSprite = value; }
}
