using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SceneCoroutine : MonoBehaviour
{
    
    public GameObject beanUI1;
    public GameObject beanUI2;
    public GameObject sproutUI1;
    public GameObject sproutUI2;

    public GameObject VRRig;

    public GameObject fader;
    public GameObject olfy;

    public GameObject bean;
    public GameObject sprout;

    public GameObject grassSprout;
    public GameObject grassIn1;
    public GameObject grassIn2;

    public GameObject homePosBean;
    public GameObject homePosSprout;

    public void Start()
    {
        StartCoroutine(Begin());
    }

    /// <summary>
    /// This is to complicated to type out individual comments. Essentially this program
    /// runs the scene as a coroutine with each event timed and matched to an animation
    /// in the timeline. Each event is followed by the WaitForSecondsRealtime() which is
    /// how long it takes for that event to play out.
    /// 
    /// This is split into three acts but those are rather vague distinctions.
    /// </summary>
    /// <returns></returns>
    IEnumerator Begin()
    {
        // Start of the scene
        yield return new WaitForSecondsRealtime(2);

        fader.GetComponent<HMDFader>().FadeIn(2);

        yield return new WaitForSecondsRealtime(17);

        fader.GetComponent<HMDFader>().FadeOut(2);

        yield return new WaitForSecondsRealtime(2);


        yield return new WaitForSecondsRealtime(1);

        VRRig.transform.position = new Vector3(0, 0, 0);
        Debug.Log("Teleport");

        //
        // ACT 1
        //

        fader.GetComponent<HMDFader>().FadeIn(2);

        // Olfy triggers the GRASS smell
        // Intensity, duration, channel
        olfy.GetComponent<Channel1>().ActiveSmell(60, 2000, 1);

        // Bean is waiting out the front of her house
        yield return new WaitForSecondsRealtime(6);
        // 28" here
        FindObjectOfType<AudioManager>().Play("Thought");
        beanUI1.GetComponent<ThoughtTween>().UIAppear();
        yield return new WaitForSecondsRealtime(4);

        // Play sound for thought bubble
        FindObjectOfType<AudioManager>().Play("Stomach");
        beanUI1.GetComponent<ThoughtTween>().ChangeImage();

        yield return new WaitForSecondsRealtime(4);

        // Play sound for stomach growl
        FindObjectOfType<AudioManager>().Play("Thought");
        beanUI1.GetComponent<ThoughtTween>().ChangeImage();

        yield return new WaitForSecondsRealtime(4);

        beanUI1.GetComponent<ThoughtTween>().UIDisappear();

        // Bean is waiting out the front of her house
        yield return new WaitForSecondsRealtime(1);

        // Bean goes to the first tuft of grass
        bean.GetComponent<MoveBean>().BeanToInvest2(2, 1);
        grassIn2.GetComponent<GrassPassOnScript>().GrassDown();

        // Olfy triggers the BERRY smell
        olfy.GetComponent<Channel1>().ActiveSmell(60, 2000, 3);

        yield return new WaitForSecondsRealtime(5);

        // Bean goes to the second tuft of grass
        bean.GetComponent<MoveBean>().BeanToInvest1(1, 1);
        grassIn2.GetComponent<GrassPassOnScript>().GrassUp();
        grassIn1.GetComponent<GrassPassOnScript>().GrassDown();

        FindObjectOfType<AudioManager>().Play("Disapointment");

        // Olfy triggers the DISAPPOINTMENT smell
        olfy.GetComponent<Channel1>().ActiveSmell(60, 2000, 2);

        beanUI1.GetComponent<ThoughtTween>().ChangeImage();
        

        yield return new WaitForSecondsRealtime(5);

        // Bean goes to the third tuft of grass with Sprout hiding behind it
        bean.GetComponent<MoveBean>().BeanToSprout(3, 1);
        

        // Olfy triggers the GRASS smell
        olfy.GetComponent<Channel1>().ActiveSmell(80, 2000, 1);

        //
        // ACT 2
        //


        yield return new WaitForSecondsRealtime(3);

        grassIn1.GetComponent<GrassPassOnScript>().GrassUp();
        grassSprout.GetComponent<GrassPassOnScript>().GrassDown();

        yield return new WaitForSecondsRealtime(1);

        beanUI2.GetComponent<ThoughtTween>().UIAppear();

        FindObjectOfType<AudioManager>().Play("Stomach");

        yield return new WaitForSecondsRealtime(2);

        sproutUI1.GetComponent<ThoughtTween>().UIAppear();

        FindObjectOfType<AudioManager>().Play("Thought");

        yield return new WaitForSecondsRealtime(2);

        beanUI2.GetComponent<ThoughtTween>().ChangeImage();

        FindObjectOfType<AudioManager>().Play("Thought");

        yield return new WaitForSecondsRealtime(2);

        sproutUI1.GetComponent<ThoughtTween>().ChangeImage();

        FindObjectOfType<AudioManager>().Play("Thought");

        yield return new WaitForSecondsRealtime(2);

        beanUI2.GetComponent<ThoughtTween>().ChangeImage();

        FindObjectOfType<AudioManager>().Play("Giggle2");

        yield return new WaitForSecondsRealtime(2);

        sproutUI1.GetComponent<ThoughtTween>().ChangeImage();

        FindObjectOfType<AudioManager>().Play("Giggle1");

        yield return new WaitForSecondsRealtime(2);

        beanUI2.GetComponent<ThoughtTween>().UIDisappear();

        yield return new WaitForSecondsRealtime(2);

        sproutUI1.GetComponent<ThoughtTween>().UIDisappear();

        yield return new WaitForSecondsRealtime(2);

        // I had ten seconds in act 2, fix timeline when done

        //
        // I put in a ten second pause
        // This is where I will animate their meeting and telling of the food
        //

        // Olfy triggers the BERRY smell
        olfy.GetComponent<Channel1>().ActiveSmell(80, 2000, 3);

        // Bean and Sprout goes to the second tuft of grass with Sprout
        bean.GetComponent<MoveBean>().BeanToInvest1(4, 1);
        grassIn1.GetComponent<GrassPassOnScript>().GrassDown();

        yield return new WaitForSecondsRealtime(0.5f);

        sprout.GetComponent<MoveSprout>().SproutToInvest1(3, 1);

        olfy.GetComponent<Channel1>().ActiveSmell(80, 2000, 2);

        yield return new WaitForSecondsRealtime(6);

        // Bean goes to the first tuft of grass with Sprout
        bean.GetComponent<MoveBean>().BeanToInvest2(1, 1);
        sprout.GetComponent<MoveSprout>().SproutToInvest2(1, 1);
        grassIn2.GetComponent<GrassPassOnScript>().GrassDown();
        grassIn1.GetComponent<GrassPassOnScript>().GrassUp();

        FindObjectOfType<AudioManager>().Play("Disapointment");

        yield return new WaitForSecondsRealtime(6);

        // Bean goes home with Sprout
        bean.GetComponent<MoveBean>().BeanToHouse(3, 1);
        sprout.GetComponent<MoveSprout>().SproutToHouse(3, 1);
        grassIn2.GetComponent<GrassPassOnScript>().GrassUp();

        //
        // ACT 3
        //

        // To be animated later

        yield return new WaitForSecondsRealtime(4);

        beanUI1.GetComponent<ThoughtTween>().UIAppear();

        FindObjectOfType<AudioManager>().Play("Disapointment");

        yield return new WaitForSecondsRealtime(3);

        beanUI1.GetComponent<ThoughtTween>().ChangeImage();

        FindObjectOfType<AudioManager>().Play("Thought");

        yield return new WaitForSecondsRealtime(2);

        beanUI1.GetComponent<ThoughtTween>().UIDisappear();
        sproutUI2.GetComponent<ThoughtTween>().UIAppear();

        olfy.GetComponent<Channel1>().ActiveSmell(100, 2000, 3);

        FindObjectOfType<AudioManager>().Play("Thought");

        yield return new WaitForSecondsRealtime(3);

        sproutUI2.GetComponent<ThoughtTween>().ChangeImage();
        beanUI1.GetComponent<ThoughtTween>().ChangeImage();

        FindObjectOfType<AudioManager>().Play("Giggle1");

        yield return new WaitForSecondsRealtime(2);

        beanUI1.GetComponent<ThoughtTween>().UIAppear();

        FindObjectOfType<AudioManager>().Play("Giggle2");

        olfy.GetComponent<Channel1>().ActiveSmell(100, 2000, 1);

        yield return new WaitForSecondsRealtime(3);

        beanUI1.GetComponent<ThoughtTween>().UIDisappear();
        sproutUI2.GetComponent<ThoughtTween>().UIDisappear();

        

        yield return new WaitForSecondsRealtime(3);

        fader.GetComponent<HMDFader>().FadeOut(2);
    }
}
