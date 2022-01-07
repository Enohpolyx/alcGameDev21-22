using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Grog : MonoBehaviour
{
    public PlayerController player;
    public WeaponController weapon;

    public GameObject Bubble;
    public TextMeshProUGUI Speech;

    public bool lowHealth = false;
    public bool lowAmmo = false;
    public bool chatting = false;
    public bool chat = false;

    private List<string> chats = new List<string>(){"Hey!", "Grog is hungry...", "Grog is displeased.", "Join the Nintendo fan club today!", "Knock knock!", "Who\'s there?", "Grog.", "Grog who?", "Grog is groggy!!!", "Grog reccomends running.", "Sign on now for a $100 bonus!", "You should thank Grog.", "Drink some milk.", "Grog bets you don\'t like cheese.", "And now a word from Grog\'s sponsor...", "ABCDEFG...", "Is it hot? Or is it just Grog?", "Hey, listen!", "Why'd you get hit??", "Grog has some notes."};

    void Awake()
    {
        Speech.text = "";
        Bubble.SetActive(false);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeBubble", 0, 0.3f);
        InvokeRepeating("ChatWrapper", 0, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.curHP <= 20)
            lowHealth = true;
        else if(player.curHP > 20)
            lowHealth = false;

        if(weapon.curAmmo <= 20)
            lowAmmo = true;
        else if(weapon.curAmmo > 20)
            lowAmmo = false;
    }

            

    void ChangeBubble()
    {
        if(lowHealth)
        {
            if(!Bubble.activeSelf)
                Bubble.SetActive(true);
            Speech.text = "You\'re low on health! Find some before you die!";
        }

        else if(lowAmmo)
        {
            if(!Bubble.activeSelf)
                Bubble.SetActive(true);
            Speech.text = "You\'re low on ammo! Better find some quick!";
        }

        else if(chatting)
            return;

        else
        {
            if(Bubble.activeSelf)
                Bubble.SetActive(false);
            Speech.text = null;
        }

    }

    void ChatWrapper()
    {
        chat = !chat;
        if(chat)
        {
            GetChatty();
        }

        else
        {
            chatting = false;
            if(!lowHealth && !lowAmmo)
            {
                if(Bubble.activeSelf)
                    Bubble.SetActive(false);
                Speech.text = null;
            }
        }
    }
    
    void GetChatty()
    {
        if(!lowHealth && !lowAmmo)
        {
            chatting = true;

            if(!Bubble.activeSelf)
                Bubble.SetActive(true);
            
            
            Speech.text = chats[Random.Range(0, chats.Count)];
        }
    }
}
