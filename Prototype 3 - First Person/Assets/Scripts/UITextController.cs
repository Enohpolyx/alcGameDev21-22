using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITextController : MonoBehaviour
{
    public PlayerController player;
    public WeaponController weapon;
    public Text textThing;
    
    public TextMeshProUGUI ammoTextThingPro;
    public TextMeshProUGUI scoreTextThing;
    
    private string HP;
    
    

    void Awake()
    {
        
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HP = "HP: " + player.curHP.ToString();
        textThing.text = HP;

        string AmmoTMP = "Ammo: " + weapon.curAmmo.ToString() + "/" + weapon.maxAmmo.ToString();
        ammoTextThingPro.text = AmmoTMP;

    }
}
