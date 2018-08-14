using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour {

    public Sprite pauseSprite;
    public Sprite playSprite;

    public Sprite muteSprite;
    public Sprite volumeSprite;

    public Button pauseButton;
    public Button volumeButton;

    private bool isPaused = true;
    private bool isMuted = true;


    public GameObject phoneWindow;

    public GameObject phoneMessage;

    private List<GameObject> messages = new List<GameObject>();

    public Sprite elon;
    public Sprite trump;
    public Sprite generic;
    public Sprite dog;
    public Sprite HQ;



    private string[] mrPresidentBad = {
        "This drone is useless #SAD",
        "Frankly I think I would do greatly better",
        "The FBI should look into this drone #NOTME",
        "We should source the new ones from Russia",
        "#bevfefe down",
        "As a hero myself I am saddened by this loss"
    };

    private string[] mrPresidentGood = {
        "New satellite up. #welcome",
        "Were sending that swamp up to space",
        "This is the best satellite in the world",
        "Take that China, new Satellite up",
        "New Russia-American Sat is up #LUVUPU",
        "Try to take these jobs Mexico"
    };

    private string[] mrPresidentNeutral = {
        "I was great on the news last night",
        "I drink can in ova ofiice",
        "Dog News was great last night #NUMBAONE",
        "Okay",
        "Will my toupee float off in space? #wondering",
        "Space Wall? You bet! #makethemartianspay"
    };

    private string[] noelAromaBad = {
        "My drone would have worked better",
        "I will do the job myself if I have to",
        "Slight delay while we replace the satellite",
        "At least now there will be better suits",
        "Star Link delays immenant",
        "Bet ya a signed dollar that drones a pedo"
    };

    private string[] noelAromaGood = {
        "T-0 to launch",
        "Make sure to tune in to our launch stream",
        "Another successful launch for XSpace",
        "Take that NASA",
        "GG NASA",
        "Take that Red Destination"
    };

    private string[] noelAromaNeutral = {
        "I miss my car",
        "Man I have a lot of money",
        "Took the tunnel to work today, great view",
        "So long and thanks for all the fish",
        "Production ramped up for the Edison S3X",
        "Wonder if my BFR will fit in the new space port"
    };

    private string[] genericBad = {
        "I built a robot in my backyard that is better",
        "Put some liberals in the station next time",
        "Racist republican drone strikes again",
        "Satellite must of hit the dome",
        "Thots and prayers for the astronauts lost",
        "That satellite was crap anyways"
    };

    private string[] genericGood = {
        "I went to go see the new satellite launch",
        "New Satellite is #BREATHTAKING",
        "Russia spying on us with that new sat",
        "Keep up the good work droney #NEWSAT",
        "Dad left us to go work on the new satellite",
        "Drop the beat but not the new sat"
    };

    private string[] genericNeutral = {
        "#FAKENEWS",
        "I want that drone to have my babies",
        "Hey Guys, check out my new Lets Play",
        "I wonder how the developers are doing?",
        "Writing fake tweets is hard. #SAD",
        "Check me out on SoundCloud"
    };

    private string[] newsBad = {
        "BREAKING NEWS: BREAKING SAT",
        "Used Futon impacts with Satellite"
    };

    private string[] newsGood = {
        "BREAKING NEWS: Aroma Delievers"
    };

    private string[] newsGeneric = {
        "This is a threat to our democracy",
        "Florida Man is in Florida",
        "Diced Tomatoes on Pizza is Wrong",
        "Everything is Fine",
        "Developers sleep 99hrs after LD",
        "Tweets take a long time to make"
    };


	private void Start()
	{
        StartCoroutine(randomTweets());
	}




	public void pauseGame(){

        isPaused = !isPaused;

        if(isPaused){
            Time.timeScale = 1;
            pauseButton.image.sprite = pauseSprite;
        }else if(!isPaused){
            Time.timeScale = 0;
            pauseButton.image.sprite = playSprite;
        }
    }

    public void muteGame(){
        isMuted = !isMuted;

        if (isMuted)
        {
            AudioListener.volume = 1;
            volumeButton.image.sprite = muteSprite;
        }
        else if (!isMuted)
        {
            AudioListener.volume = 0;
            volumeButton.image.sprite = volumeSprite;
        }
    }

    public void backToMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void makeMessage(string type){

        GameObject newMessage = phoneMessage;

        int whoToUse = Random.Range(0, 4);

        if (type == "bad")
        {

            if(whoToUse == 0){
                // Trump
                newMessage.GetComponent<TMessage>().icon = trump;
                newMessage.GetComponent<TMessage>().userName = "Mr President";
                newMessage.GetComponent<TMessage>().message = mrPresidentBad[Random.Range(0, mrPresidentBad.Length)];
            }
            if(whoToUse == 1){
                // Elon
                newMessage.GetComponent<TMessage>().icon = elon;
                newMessage.GetComponent<TMessage>().userName = "Nole Aroma";
                newMessage.GetComponent<TMessage>().message = noelAromaBad[Random.Range(0, noelAromaBad.Length)];
            }
            if(whoToUse == 2){
                // Generic
                newMessage.GetComponent<TMessage>().icon = generic;
                newMessage.GetComponent<TMessage>().userName = "Generic User";
                newMessage.GetComponent<TMessage>().message = genericBad[Random.Range(0, genericBad.Length)];
            }
            if(whoToUse == 3){
                // Dog
                newMessage.GetComponent<TMessage>().icon = dog;
                newMessage.GetComponent<TMessage>().userName = "Dog News";
                newMessage.GetComponent<TMessage>().message = newsBad[Random.Range(0, newsBad.Length)];
            }
        }

        if (type == "good")
        {

            if (whoToUse == 0)
            {
                // Trump
                newMessage.GetComponent<TMessage>().icon = trump;
                newMessage.GetComponent<TMessage>().userName = "Mr President";
                newMessage.GetComponent<TMessage>().message = mrPresidentGood[Random.Range(0, mrPresidentGood.Length)];
            }
            if (whoToUse == 1)
            {
                // Elon
                newMessage.GetComponent<TMessage>().icon = elon;
                newMessage.GetComponent<TMessage>().userName = "Nole Aroma";
                newMessage.GetComponent<TMessage>().message = noelAromaGood[Random.Range(0, noelAromaGood.Length)];
            }
            if (whoToUse == 2)
            {
                // Generic
                newMessage.GetComponent<TMessage>().icon = generic;
                newMessage.GetComponent<TMessage>().userName = "Generic User";
                newMessage.GetComponent<TMessage>().message = genericGood[Random.Range(0, genericGood.Length)];
            }
            if (whoToUse == 3)
            {
                // Dog
                newMessage.GetComponent<TMessage>().icon = dog;
                newMessage.GetComponent<TMessage>().userName = "Dog News";
                newMessage.GetComponent<TMessage>().message = newsGood[Random.Range(0, newsGood.Length)];
            }
        }

        if (type == "generic")
        {

            if (whoToUse == 0)
            {
                // Trump
                newMessage.GetComponent<TMessage>().icon = trump;
                newMessage.GetComponent<TMessage>().userName = "Mr President";
                newMessage.GetComponent<TMessage>().message = mrPresidentNeutral[Random.Range(0, mrPresidentNeutral.Length)];
            }
            if (whoToUse == 1)
            {
                // Elon
                newMessage.GetComponent<TMessage>().icon = elon;
                newMessage.GetComponent<TMessage>().userName = "Nole Aroma";
                newMessage.GetComponent<TMessage>().message = noelAromaNeutral[Random.Range(0, noelAromaNeutral.Length)];
            }
            if (whoToUse == 2)
            {
                // Generic
                newMessage.GetComponent<TMessage>().icon = generic;
                newMessage.GetComponent<TMessage>().userName = "Generic User";
                newMessage.GetComponent<TMessage>().message = genericNeutral[Random.Range(0, genericNeutral.Length)];
            }
            if (whoToUse == 3)
            {
                // Dog
                newMessage.GetComponent<TMessage>().icon = dog;
                newMessage.GetComponent<TMessage>().userName = "Dog News";
                newMessage.GetComponent<TMessage>().message = newsGeneric[Random.Range(0, newsGeneric.Length)];
            }
        }

        newMessage = Instantiate(newMessage, phoneWindow.transform);


        newMessage.transform.localPosition = new Vector3(0, 95.69998f);

        messages.Add(newMessage);


        phoneWindow.GetComponent<AudioSource>().Play();

        for (int i = 0; i < messages.Count; i++){
            if (i != messages.Count-1)
            {
                messages[i].transform.localPosition = new Vector3(0, messages[i].transform.localPosition.y - 55);
            }
        }

        if(messages.Count > 6){
            Destroy(messages[0]);
            messages.RemoveAt(0);
        }
        
    }

    public void HQTweet(string type){
        GameObject newMessage = phoneMessage;
        if(type == "good"){
            newMessage.GetComponent<TMessage>().icon = HQ;
            newMessage.GetComponent<TMessage>().userName = "Head Quarters";
            newMessage.GetComponent<TMessage>().message = "A new Satellite has been launched";
        }
        if(type == "bad"){
            newMessage.GetComponent<TMessage>().icon = HQ;
            newMessage.GetComponent<TMessage>().userName = "Head Quarters";
            newMessage.GetComponent<TMessage>().message = GetComponent<GameMaster>().health + " more destroyed sats until termination";
        }

        newMessage = Instantiate(newMessage, phoneWindow.transform);

        newMessage.transform.localPosition = new Vector3(0, 95.69998f);

        messages.Add(newMessage);


        phoneWindow.GetComponent<AudioSource>().Play();

        for (int i = 0; i < messages.Count; i++)
        {
            if (i != messages.Count - 1)
            {
                messages[i].transform.localPosition = new Vector3(0, messages[i].transform.localPosition.y - 55);
            }
        }

        if (messages.Count > 6)
        {
            Destroy(messages[0]);
            messages.RemoveAt(0);
        }


    }




    IEnumerator randomTweets(){
        yield return new WaitForSeconds(Random.Range(5, 30));
        makeMessage("generic");
        StartCoroutine(randomTweets());
    }





}
