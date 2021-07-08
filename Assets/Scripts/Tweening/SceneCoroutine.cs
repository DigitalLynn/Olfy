using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SceneCoroutine : MonoBehaviour
{
    public GameObject olfy;

    public GameObject bean;
    public GameObject sprout;

    public GameObject grassSprout;
    public GameObject grassIn1;
    public GameObject grassIn2;

    public int pause = 5;

    public void Start()
    {
        StartCoroutine(Begin());
    }

    IEnumerator Begin()
    {
        //
        // ACT 1
        //

        // Olfy triggers the GRASS smell
        olfy.GetComponent<Channel1>().duration = 2000;
        olfy.GetComponent<Channel1>().intensity = 60;
        olfy.GetComponent<Channel1>().ActiveSmell();

        // Bean is waiting out the front of her house
        yield return new WaitForSecondsRealtime(7);

        // Play sound for thought bubble
        FindObjectOfType<AudioManager>().Play("Thought");

        yield return new WaitForSecondsRealtime(2);

        // Play sound for stomach growl
        FindObjectOfType<AudioManager>().Play("Stomach");

        // Bean is waiting out the front of her house
        yield return new WaitForSecondsRealtime(8);

        // Bean goes to the first tuft of grass
        bean.GetComponent<MoveBean>().BeanToInvest2_Slow();
        grassIn2.GetComponent<GrassPassOnScript>().GrassDown();

        // Olfy triggers the BERRY smell
        olfy.GetComponent<Channel3>().duration = 2000;
        olfy.GetComponent<Channel3>().intensity = 60;
        olfy.GetComponent<Channel3>().ActiveSmell();



        yield return new WaitForSecondsRealtime(pause);

        // Bean goes to the second tuft of grass
        bean.GetComponent<MoveBean>().BeanToInvest1_Quick();
        grassIn2.GetComponent<GrassPassOnScript>().GrassUp();
        grassIn1.GetComponent<GrassPassOnScript>().GrassDown();

        // Olfy triggers the DISAPPOINTMENT smell
        olfy.GetComponent<Channel2>().duration = 2000;
        olfy.GetComponent<Channel2>().intensity = 60;
        olfy.GetComponent<Channel2>().ActiveSmell();


        yield return new WaitForSecondsRealtime(pause);

        // Bean goes to the third tuft of grass with Sprout hiding behind it
        bean.GetComponent<MoveBean>().BeanToSprout();
        grassIn1.GetComponent<GrassPassOnScript>().GrassUp();
        grassSprout.GetComponent<GrassPassOnScript>().GrassDown();

        // Olfy triggers the GRASS smell
        olfy.GetComponent<Channel1>().duration = 2000;
        olfy.GetComponent<Channel1>().intensity = 80;
        olfy.GetComponent<Channel1>().ActiveSmell();

        //
        // ACT 2
        //

        yield return new WaitForSecondsRealtime(10);

        //
        // I put in a ten second pause
        // This is where I will animate their meeting and telling of the food
        //

        // Olfy triggers the BERRY smell
        olfy.GetComponent<Channel3>().duration = 2000;
        olfy.GetComponent<Channel3>().intensity = 80;
        olfy.GetComponent<Channel3>().ActiveSmell();

       

        yield return new WaitForSecondsRealtime(pause);

        // Bean and Sprout goes to the second tuft of grass with Sprout
        bean.GetComponent<MoveBean>().BeanToInvest1_Slow();
        sprout.GetComponent<MoveSprout>().SproutToInvest1_Slow();
        grassIn1.GetComponent<GrassPassOnScript>().GrassDown();



        yield return new WaitForSecondsRealtime(pause);

        // Bean goes to the first tuft of grass with Sprout
        bean.GetComponent<MoveBean>().BeanToInvest2_Quick();
        sprout.GetComponent<MoveSprout>().SproutToInvest2_Quick();
        grassIn2.GetComponent<GrassPassOnScript>().GrassDown();
        grassIn1.GetComponent<GrassPassOnScript>().GrassUp();

        yield return new WaitForSecondsRealtime(pause);

        // Bean goes home with Sprout
        bean.GetComponent<MoveBean>().BeanToHouse();
        sprout.GetComponent<MoveSprout>().SproutToHouse();
        grassIn2.GetComponent<GrassPassOnScript>().GrassUp();

        //
        // ACT 3
        //

        // To be animated later
    }
}
