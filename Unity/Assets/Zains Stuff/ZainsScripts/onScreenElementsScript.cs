using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class onScreenElementsScript : MonoBehaviour 
{
	//Author: Zain Ul-Abdeen
	//Date created: 29/01/2015
	//Last edited: 26/02/2015 



	Rect healthBar = new Rect(0,10,260,20); //rectangle for health
	Rect magicBar = new Rect(0,35,260,20);	//rectangle for mana
	//Rect levelBar = new Rect(10,100,20,260);
	Rect xpBar = new Rect(0,100,260,20);
	
	public static float health = 100f; //current health
	public static int maxHealth = 200;
	public static float magic = 50;//current mana
	public static int maxMagic = 100;

	public static int currentXP = 0;
	public static int maxXP = 200;
	public int xpLevelUp = 100;

	public int levelUpNum;

	public AudioClip levelUpSound;

	public Texture healthBackgroundTexture;
	public Texture healthForegroundTexture;
	public Texture magicBackgroundTexture;
	public Texture magicForegroundTexture;
	public Texture xpBackgroundTexture;
	public Texture xpForegroundTexture;

	public Font font;//reference to the same font that is used in the GUI for the Main and Options Menu

	int counter;

	public GameObject xpLevelText;
	Text levelText;
	// Use this for initialization
	void Start () 
	{
		levelText = xpLevelText.GetComponent<Text>();
		levelText.color = Color.blue;
		levelUpNum = 1;
	}
	// Update is called once per frame
	void Update () 
	{
		if(health >= getMaxHealth()/2)
		{
			health = getMaxHealth()/2;// do not allow health to go over 100
		}
		if (magic <= 0)
		{
			magic = 0;
		}
		if(magic >= getMaxMagic()/2)
		{
			magic = getMaxMagic()/2; //do not allow magic to go over 100
		}
		// Magic regen
		counter++;
		if(counter >= 50 && magic < getMaxMagic()/2){
			magic = magic + 1;
			counter = 0;
		}
		// End of Magic regen

	}
	// NEW METHODS ---- USED WITH ARCHER SCRIPT
	// Getters and setters
	public void setHealth(float value){
		health = value;
	}
	public float getHealth(){
		return health;
	}
	public void setMaxHealth(int value){
		maxHealth = value;
	}
	public int getMaxHealth(){
		return maxHealth;
	}
	public void setMagic(float value){
		magic = value;
	}
	public float getMagic(){
		return magic;
	}
	public void setMaxMagic(int value){
		maxMagic = value;
	}
	public int getMaxMagic(){
		return maxMagic;
	}
	public void Reset(){
		health = maxHealth/2;
		magic = maxMagic/2;
	}
	public void setMaxXP(int value){
		maxXP = value;
	}
	public int getMaxXP(){
		return maxXP;
	}
	public void setXP( int value){
		currentXP = value;
	}
	public int getXP(){
		return currentXP;
	}
	// END OF NEW METHODS ---- USED WITH ARCHER SCRIPT
	void OnGUI()
	{
		GUI.skin.font = font;//setting a customized font

		GUI.BeginGroup(healthBar); //drawing health bar
		{

			GUI.DrawTexture(new Rect(0, 0, 130, healthBar.height), healthBackgroundTexture, ScaleMode.StretchToFill);
			GUI.DrawTexture(new Rect(0, 0, healthBar.width*health/maxHealth, healthBar.height), healthForegroundTexture, ScaleMode.StretchToFill);
			GUI.Box((new Rect(0,0,130,healthBar.height)),"" + health + "/" + maxHealth/2);
		}
		GUI.EndGroup();
		
		GUI.BeginGroup (magicBar); //drawing mana bar
		{
			GUI.DrawTexture(new Rect(0,0,130,magicBar.height),magicBackgroundTexture,ScaleMode.StretchToFill);
			GUI.DrawTexture(new Rect(0, 0, magicBar.width*magic/maxMagic, magicBar.height), magicForegroundTexture, ScaleMode.StretchToFill);
			GUI.Box((new Rect(0,0,130,magicBar.height)),"" + magic + "/" + maxMagic/2);
		}
		GUI.EndGroup();

		GUI.BeginGroup(xpBar);
		{
			GUI.DrawTexture(new Rect(0,0,130,xpBar.height),xpBackgroundTexture,ScaleMode.StretchToFill);
			GUI.DrawTexture(new Rect(0,0,xpBar.width*currentXP/maxXP,xpBar.height),xpForegroundTexture,ScaleMode.StretchToFill);
			GUI.Box((new Rect(0,0,130,xpBar.height)),"" + currentXP + "/" + maxXP/2);

			if(levelUpNum == 1)
			{
				GUI.DrawTexture(new Rect(0,0,130,xpBar.height),xpBackgroundTexture,ScaleMode.StretchToFill);
				GUI.DrawTexture(new Rect(0,0,xpBar.width*currentXP/maxXP,xpBar.height),xpForegroundTexture,ScaleMode.StretchToFill);
				GUI.Box((new Rect(0,0,130,xpBar.height)),"" + currentXP + "/" + maxXP/2);
			}
		}
		GUI.EndGroup();
	}

}
