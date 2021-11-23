using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextController : MonoBehaviour
{
    public PlayerController player;
    public WeaponController weapon;
    public Text textThing;
    public Text ammoTextThing;
    private string HP;
    private string Ammo;
    
    

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

        Ammo = "Ammo: " + weapon.curAmmo.ToString();
        ammoTextThing.text = Ammo;
    }
}
