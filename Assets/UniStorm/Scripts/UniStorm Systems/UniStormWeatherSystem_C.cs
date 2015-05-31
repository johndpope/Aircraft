//UniStorm Weather System C# Version 1.8.4 @ Copyright
//Black Horizon Studios

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.ImageEffects;

public class UniStormWeatherSystem_C : MonoBehaviour {

	//Added 1.8.4
	public float stormyMoonLightIntensity;

	public bool timeOptions = true;
	public bool caledarOptions = true;
	public bool skyOptions = true;
	public bool atmosphereOptions = true;
	public bool fogOptions = true;
	public bool lightningOptions = true;
	public bool temperatureOptions = true;
	public bool sunOptions = true;
	public bool moonOptions = true;
	public bool precipitationOptions = true;
	public bool GUIOptions = true;
	public bool soundManagerOptions = true;
	public bool colorOptions = true;
	public bool objectOptions = true;
	public bool helpOptions = true;
	public bool WindOptions = true;

	public bool terrainDetection = false;

	public float nightLength;
	public int nightLengthHour;
	public int dayLengthHour;
	public int nightLengthMinute;
	public int dayLengthMinute;

	public float stormGrassWavingSpeed;
	public float stormGrassWavingAmount;
	public float stormGrassWavingStrength;
	public float normalGrassWavingSpeed;
	public float normalGrassWavingAmount;
	public float normalGrassWavingStrength;

	public float HeavyRainSunIntensity;

	public string timeOfDayDisplay;
	public GameObject sunObject;

	//Added 1.8.2
	public int calendarType = 0;
	public int numberOfDaysInMonth = 31;
	public int numberOfMonthsInYear = 12;

	//Added 1.8.1
	public GameObject partlyCloudyClouds1;
	public GameObject partlyCloudyClouds2;

	public float partlyCloudyFader;

	public int cloudType = 1;
	public bool UseRainSplashes = true;
	public bool UseRainMist = true;
	public ParticleSystem rainSplashes;
	public ParticleSystem snow; 
	public ParticleSystem snowMistFog; 
	public float sunOffSetX;
	public float sunOffSetY;
	public Vector2 sunOffSet = new Vector2( 0.0f, 0.0f );

	public float dynamicPartlyCloudyFloat1;
	public float dynamicPartlyCloudyFloat2;
	
	public GameObject dynamicPartlyCloudy1;
	public GameObject dynamicPartlyCloudy2;
	
	public Color MorningSkyboxTintContrast;
	public Color MiddaySkyboxTintContrast;
	public Color DuskSkyboxTintContrast;
	public Color NightSkyboxTintContrast;
	
	public int springTemp = 0;
	public int summerTemp = 0;
	public int fallTemp = 0;
	public int winterTemp = 0;
	
	public bool weatherShuffled = false;
	
	public float minHeavyRainMistIntensity = 0;
	public int maxHeavyRainMistIntensity = 20;
	
	public ParticleSystem rainMist;
	
	public int moonSize = 4;
	public float moonRotationY = 4;
	public bool customMoonSize = false;
	public bool customMoonRotation = false;
	public Quaternion moonRotation = Quaternion.identity;
	
	public Color cloudColorMorning; 
	public Color cloudColorDay; 
	public Color cloudColorEvening; 
	public Color cloudColorNight;
	
	public Color stormyFogColorMorning; 
	public Color stormyFogColorDay; 
	public Color stormyFogColorEvening; 
	public Color stormyFogColorNight; 
	
	public Color originalFogColorMorning; 
	public Color originalFogColorDay; 
	public Color originalFogColorEvening; 
	public Color originalFogColorNight;
	
	public float fader = 0;
	public float fader2 = 0;
	
	public bool weatherHappened = false;
	
	public float moonFade = 0;
	public float moonFade2 = 0;
	
	public Color moonColorFade;
	
	public int temperatureType = 1;
	public int temperature_Celsius = 1;
	
	public bool stormControl = true;
	
	public int forceWeatherChange = 0;
	
	//Added 1.8
	public int randomizedRainIntensity;
	public int currentGeneratedIntensity;
	public int lastWeatherType;
	public bool randomizedPrecipitation = false;
	public int moonShadowQuality = 2;
	
	public bool useSunFlare = false;
	public GameObject lightFlareObject;
	public bool useRainStreaks = true;
	public Color sunFlareColor;
	
	public int timeToWaitMin;
	public int timeToWaitMax;
	public int timeToWaitCurrent = 3;
	
	public float TODSoundsTimer;
	public bool playedSound = false;
	public bool getDelay = false;
	public int amountOfSounds;
	public bool useMorningSounds = false;
	public bool useDaySounds = false;
	public bool useEveningSounds = false;
	public bool useNightSounds = false;
	
	public Material tempMat;
	public Color lightningColor;
	
	public int morningSize;
	public int daySize;
	public int eveningSize;
	public int nightSize;
	public List<AudioClip> ambientSoundsMorning = new List<AudioClip>();
	public List<AudioClip> ambientSoundsDay = new List<AudioClip>();
	public List<AudioClip> ambientSoundsEvening = new List<AudioClip>();
	public List<AudioClip> ambientSoundsNight = new List<AudioClip>();
	public List<bool> foldOutList = new List<bool>();
	//var ambientSoundsMorning : List.<AudioClip>;
	//var ambientSoundsDay : List.<AudioClip>;
	//var ambientSoundsEvening : List.<AudioClip>;
	//var ambientSoundsNight : List.<AudioClip>;
	//var foldOutList : List.<boolean >;
	
	public bool shadowsDuringDay = true;
	public float dayShadowIntensity;
	public int dayShadowType = 1;
	
	public bool shadowsDuringNight;
	public float nightShadowIntensity;
	public int nightShadowType = 1;
	
	public bool shadowsLightning;
	public float lightningShadowIntensity;
	public int lightningShadowType = 1;
	
	public int fogMode = 1;
	
	public string version;
	
	public int materialIndex = 0;
	
	public Vector2 uvAnimationRateA = new Vector2( 1.0f, 0.0f );
	public string CloudA = "_MainTex1";
	
	public Vector2 uvAnimationRateB = new Vector2( 1.0f, 0.0f );
	public string CloudB = "_MainTex2";
	
	public Vector2 uvAnimationRateC = new Vector2( 1.0f, 0.0f );
	public string CloudC = "_MainTex3";
	
	public Vector2 uvAnimationRateHeavyA = new Vector2( 1.0f, 0.0f );
	public Vector2 uvAnimationRateHeavyB = new Vector2( 1.0f, 0.0f );
	public Vector2 uvAnimationRateHeavyC = new Vector2( 1.0f, 0.0f );
	
	Vector2 uvOffsetA = Vector2.zero;
	Vector2 uvOffsetB = Vector2.zero;
	Vector2 uvOffsetC = Vector2.zero;
	
	Vector2 uvOffsetHeavyA = Vector2.zero;
	Vector2 uvOffsetHeavyB = Vector2.zero;
	Vector2 uvOffsetHeavyC = Vector2.zero;
	
	public bool scale = false;
	
	public float scaleX;
	public float scaleY;	
	
	public int cloudDensity;
	
	public AudioClip customRainSound;
	public AudioClip customRainWindSound;
	public AudioClip customSnowWindSound;
	
	public bool useCustomPrecipitationSounds = false;
	
	public bool useUnityFog = true;
	
	public float moonLightIntensity;

	//Added 1.8.4
	public Light moonLight;
	public Color moonColor;
	
	
	//
	
	
	//Time keeping variables
	public int minuteCounter = 0;  //Was int
	public int minuteCounterNew = 0;
	public string minute;
	public int hourCounter = 0;  //Was int
	public int hourCounter2 = 0;
	public float dayCounter = 0;  //Was int
	public float monthCounter = 0;  //Was int
	public float yearCounter = 0;  //Was int
	public int temperature = 0;  //Was int
	public float dayLength;
	public int cloudSpeed;
	public int heavyCloudSpeed;
	public int starSpeed;
	public float starSpeedCalculator;
	public int starRotationSpeed;
	public bool timeStopped = false;
	public bool staticWeather = false;
	//public Color instantWeather : boolean = false;
	public bool timeScrollBar = false;
	public bool horizonToggle  = true;
	public bool dynamicSnowEnabled = true;
	public bool weatherCommandPromptUseable = false;
	public bool timeScrollBarUseable = false;
	public float startTime;
	public int startTimeNumber;
	public float moonPhaseChangeTime;
	public int weatherForecaster = 0;
	private string stringToEdit = "0";
	
	public float SnowAmount;
	
	//Sun intensity control
	public float sunIntensity;
	public float maxSunIntensity; 
	
	//Sun angle control
	public float sunAngle;
	
	//Ambient light colors
	public Color MorningAmbientLight;
	public Color MiddayAmbientLight;
	public Color DuskAmbientLight;
	public Color NightAmbientLight;
	
	//Background colors
	//private Color backgroundNightColor;
	//private Color backgroundDuskColor;
	//private Color backgroundMorningColor;
	//private Color backgroundMiddayColor;
	
	//Sun colors
	public Color SunMorning;
	public Color SunDay;
	public Color SunDusk;
	public Color SunNight;
	
	//Storm color variables Global Fog
	public Color stormyFogColorDay_GF;
	public Color stormyFogColorDuskDawn_GF;
	public Color stormyFogColorNight_GF;
	
	//Horizon colors
	//public Color horizonMorning;
	//public Color horizonDay;
	//public Color horizonDusk;
	//public Color horizonNight;
	
	//Fog colors
	public Color fogMorningColor;
	public Color fogDayColor;
	public Color fogDuskColor;
	public Color fogNightColor;
	
	public float fogDensity;
	
	//Skyboxes
	public Material SkyBoxMaterial1;
	public Material SkyBoxMaterial2;
	
	public Color MorningSkyboxTint;
	public Color MiddaySkyboxTint;
	public Color DuskSkyboxTint;
	public Color NightSkyboxTint;
	
	//Atmospheric colors
	public Color MorningAtmosphericLight;
	public Color MiddayAtmosphericLight;
	public Color DuskAtmosphericLight;
	
	//Star System game objects
	public GameObject starSphere;
	public Color starBrightness;
	public GameObject moonObject;
	//public GameObject horizonObject;
	//public Material[] moonPhases;
	
	public int moonPhaseCalculator;
	public Color moonFadeColor;
	public Material moonPhase1;
	public Material moonPhase2;
	public Material moonPhase3;
	public Material moonPhase4;
	public Material moonPhase5;
	public Material moonPhase6;
	public Material moonPhase7;
	public Material moonPhase8;
	public Material moonPhase9;
	
	//private public Color changeInterval = 1;
	
	//Clouds game objects
	public GameObject lightClouds1;
	public GameObject lightClouds1a;
	public GameObject lightClouds2;
	public GameObject lightClouds3;
	public GameObject lightClouds4;
	public GameObject lightClouds5;
	public GameObject highClouds1;
	public GameObject highClouds2;
	public GameObject mostlyCloudyClouds;
	public GameObject heavyClouds;
	public GameObject heavyCloudsLayer1;
	public GameObject heavyCloudsLayerLight;
	
	//Max rain particles
	public int maxLightRainIntensity = 400;
	public int maxLightRainMistCloudsIntensity = 4;
	public int maxStormRainIntensity = 1000;
	public int maxStormMistCloudsIntensity = 15;
	
	public int maxLightSnowIntensity = 400;
	public int maxLightSnowDustIntensity = 4;
	public int maxSnowStormIntensity = 1000;
	public int maxHeavySnowDustIntensity = 15;
	
	//Weather game objects
	public ParticleSystem rain;
	//public GameObject snow;
	public ParticleSystem butterflies;
	public GameObject mistFog;
	//public GameObject snowMistFog;
	public GameObject mistCloud;
	public ParticleSystem windyLeaves;
	public GameObject windZone;
	
	public GameObject snowObject;
	
	public Light sun;
	public Light moon;
	//public Light sunCloudy;
	
	//Storm sound effects
	public GameObject rainSound;
	public GameObject windSound;
	public GameObject windSnowSound;
	//public Color nightSound : GameObject;
	
	public GameObject cameraThing;
	
	public float random;
	public float random2;
	
	//Our fade number values
	//private float sunRotate = 0;  //Was int
	private float fadeHorizonController = 0;  //Was int
	//private float fadeHorizon = 0;
	private float stormClouds = 0;
	private float fade = 0;
	private float fade2 = 0;
	private float butterfliesFade = 0;
	private float windyLeavesFade = 0;
	private float fadeStormClouds  = 0;
	private float fadeStars = 0;
	private float time = 0;
	private float sunShaftFade = 0;
	//private float fadeCloudsNight = 0;
	private float windControl = 0;
	private float windControlUp = 0;
	//private float clearClouds = 0;
	//private float windSnowSoundHandler  = 0;
	private float dynamicSnowFade = 0;
	private bool overrideFog = false;
	
	//1.6 weather helper variables
	public float stormCounter = 0.0f;
	private float forceStorm = 0;  //Was int
	private float changeWeather = 0;  //Was int
	
	//1.6 weather commands
	private string foggy = "01";
	private string lightRain_lightSnow = "02";
	private string rainStorm_snowStorm = "03";
	private string partlyCloudy1 = "04";
	private string partlyCloudy2 = "05";
	private string partlyCloudy3 = "06";
	private string clear1 = "07";
	private string clear2 = "08";
	private string cloudy = "09";
	private string mostlyCloudy = "001";
	private string heavyRain = "002";
	private string fallLeaves = "003";
	private string butterfliesSummer = "004";
	private bool commandPromptActive = false;
	
	//Rain particle density controls
	public float minRainIntensity;
	private float minFogIntensity;
	
	//Snow particle density controls
	private float minSnowIntensity;
	private float minSnowFogIntensity;
	
	//Priavte vars
	private float calculate2;
	//private int moonPhaseCalculator = 0;  //Was int
	//private int moonPhaseCalculator2 = 0;  //Was int
	//private float lockAxisZ = 0;
	//private float lockAxisY = 0;
	public float Hour;     //Was int
	public float minuteCounterCalculator = 0; //IDK
	//private float yearCounterCalculator = 0.0f; //IDK
	private float cloudSpeedY;
	private float cloudSpeedHighY;
	public SunShafts sunShaftScript;
	public GlobalFog fogScript;
	//private CustomTerrainScriptAtsV3Snow snowScript;
	//private public Color rainOnCamera : ImageRefractionEffect;
	public Color globalFogColor;
	//private float timeOfDay;
	private float startTimeTimer = 5;
	
	public int weatherOdds = 0;
	public int weatherChanceSpring = 0;
	public bool isSpring;
	public int weatherChanceSummer = 0;
	public bool isSummer;
	public int weatherChanceFall = 0;
	public bool isFall;
	public int weatherChanceWinter = 0;
	public bool isWinter;
	public int weatherUpdate = 0;
	public bool weatherUpdateActive;
	public bool nightTime;
	
	public int stormyFogDistance;
	public int stormyFogDistanceStart;
	
	public int fogStartDistance;
	public int fogEndDistance;
	
	public Transform lightningSpawn;
	public int lightningNumber;
	
	public GameObject lightningBolt1;
	
	public bool fadeLightning;
	public bool lightingGenerated;
	
	public Light lightSource;
	
	public GameObject gradientSphere;
	
	public AudioClip thunderSound1;
	public AudioClip thunderSound2;
	public AudioClip thunderSound3;
	public AudioClip thunderSound4;
	public AudioClip thunderSound5;
	
	//Temperature variables
	public int minSpringTemp;
	public int maxSpringTemp;
	public int minSummerTemp;
	public int maxSummerTemp;
	public int minFallTemp;
	public int maxFallTemp;
	public int minWinterTemp;
	public int maxWinterTemp;
	public int startingSpringTemp;
	public int startingSummerTemp;
	public int startingFallTemp;
	public int startingWinterTemp;
	public bool loadSpringTemp;
	public bool loadSummerTemp;
	public bool loadFallTemp;
	public bool loadWinterTemp;
	
	//Weather Timers	
	private float timer;
	public float onTimer;
	public float lightningOdds;
	public float lightningFlashLength;
	public int lightningMinChance = 5;
	public int lightningMaxChance = 10;
	
	public float minIntensity;
	public float maxIntensity;
	public float lightningIntensity;
	
	public Color MorningGradientLight;
	public Color DayGradientLight;
	public Color DuskGradientLight;
	public Color NightGradientLight;
	
	//Gradient Light Colors
	public Color MorningGradientContrastLight;
	public Color DayGradientContrastLight;
	public Color DuskGradientContrastLight;
	public Color NightGradientContrastLight;
	
	public bool isFalse = false;
	public float timerNew;
	
	public bool hour1 = false;
	public bool hour2 = false;
	public bool hour3 = false;
	public bool hour4 = false;
	public bool hour5 = false;
	public bool hour6 = false;
	public bool hour7 = false;
	public bool hour8 = false;
	public bool hour9 = false;	
	public bool hour10 = false;
	public bool hour11 = false;
	public bool hour12 = false;
	public bool hour13 = false;
	public bool hour14 = false;
	public bool hour15 = false;
	public bool hour16 = false;
	public bool hour17 = false;
	public bool hour18 = false;
	public bool hour19 = false;
	public bool hour20 = false;
	public bool hour21 = false;
	public bool hour22 = false;
	public bool hour23 = false;
	public bool hour0 = false;
	
	public float sunSize = 0.02f;
	public Color skyTintColor;
	public Color groundColor;
	public float atmosphereThickness;
	public float exposure;
	
	void Awake () 
	{
		if (useCustomPrecipitationSounds)
		{
			rainSound.GetComponent<AudioSource>().clip = customRainSound;
			rainSound.GetComponent<AudioSource>().enabled = false;
			
			windSound.GetComponent<AudioSource>().clip = customRainWindSound;
			windSound.GetComponent<AudioSource>().enabled = false;
			
			windSnowSound.GetComponent<AudioSource>().clip = customSnowWindSound;
			windSnowSound.GetComponent<AudioSource>().enabled = false;
		}	
	}
	
	void Start ()
	{

		RenderSettings.fog = true;
		RenderSettings.skybox = SkyBoxMaterial1;
		SkyBoxMaterial1.SetColor("_SkyTint", skyTintColor);
		SkyBoxMaterial1.SetColor("_GroundColor", groundColor);
		SkyBoxMaterial1.SetFloat("_AtmosphereThickness", atmosphereThickness);
		SkyBoxMaterial1.SetFloat("_Exposure", exposure);
		SkyBoxMaterial1.SetFloat("_SunSize", 0);
		useSunFlare = true;



		//Added 1.8.4
		gradientSphere.SetActive(false);

		if (Terrain.activeTerrain == null)
		{	
			terrainDetection = false;
		}
		
		if (Terrain.activeTerrain != null)
		{	
			terrainDetection = true;
		}

		if (terrainDetection)
		{
			if (Terrain.activeTerrain.terrainData.wavingGrassSpeed <= normalGrassWavingSpeed || Terrain.activeTerrain.terrainData.wavingGrassSpeed >= normalGrassWavingSpeed)
			{
				Terrain.activeTerrain.terrainData.wavingGrassSpeed = normalGrassWavingSpeed;
			}
			
			if (Terrain.activeTerrain.terrainData.wavingGrassAmount <= normalGrassWavingStrength || Terrain.activeTerrain.terrainData.wavingGrassAmount >= normalGrassWavingStrength)
			{
				Terrain.activeTerrain.terrainData.wavingGrassAmount = normalGrassWavingStrength;
			}
			
			if (Terrain.activeTerrain.terrainData.wavingGrassStrength <= normalGrassWavingAmount || Terrain.activeTerrain.terrainData.wavingGrassStrength >= normalGrassWavingAmount)
			{
				Terrain.activeTerrain.terrainData.wavingGrassStrength = normalGrassWavingAmount;
			}
		}
		
		
		if (cloudType == 1 && weatherForecaster == 4 || cloudType == 1 && weatherForecaster == 5 || cloudType == 1 && weatherForecaster == 6)
		{
			partlyCloudyFader = 1;
		}
		
		weatherUpdate = 0;
		timeScrollBar = false;
		fader2 = 1;
		
		LogErrorCheck ();
		
		//Added 1.8.1
		if (UseRainSplashes)
		{
			rainSplashes.gameObject.SetActive(true);
		}
		
		if (!UseRainSplashes)
		{
			rainSplashes.gameObject.SetActive(false);
		}
		
		//Added 1.8.1
		originalFogColorMorning = fogMorningColor;
		originalFogColorDay = fogDayColor;
		originalFogColorEvening = fogDuskColor;
		originalFogColorNight = fogNightColor;
		
		//Added 1.8.1
		if (customMoonSize)
		{
			moonObject.transform.localScale = new Vector3(moonSize, moonSize, moonSize);
		}
		
		if (customMoonRotation)
		{
			//moonObject.transform.eulerAngles = new Vector3(moonObject.transform.eulerAngles.x, moonRotationY, moonObject.transform.eulerAngles.x);
			moonObject.transform.eulerAngles = new Vector3(0, moonRotationY, 180);
		}
		
		//Added 1.7.5
		if (useUnityFog)
		{
			RenderSettings.fog = true;
		}
		
		if (fogMode == 1)
		{
			RenderSettings.fogMode = FogMode.Linear;
		}
		
		if (fogMode == 2)
		{
			RenderSettings.fogMode = FogMode.Exponential;
		}
		
		if (fogMode == 3)
		{
			RenderSettings.fogMode = FogMode.ExponentialSquared;
		}
		
		sunIntensity = maxSunIntensity;
		
		if (useCustomPrecipitationSounds)
		{
			rainSound.GetComponent<AudioSource>().enabled = true;
			windSound.GetComponent<AudioSource>().enabled = true;
			windSnowSound.GetComponent<AudioSource>().enabled = true;
		}	
		
		lightSource.color = lightningColor;
		
		//Added 1.7.5
		version = Application.unityVersion;
		
		
		
		//Updated 1.8.1 
		//This fix updates scripts to Unity 4.0+ so you no longer get obsolete messages
		
		//If user chooses to use standard clouds
		if (cloudType == 2)
		{
			//Fixed obsolete error
			heavyCloudsLayerLight.SetActive(false);
			heavyCloudsLayer1.SetActive(true);
			lightClouds1.SetActive(false);
			lightClouds1a.SetActive(false);
			lightClouds2.SetActive(true);
			lightClouds3.SetActive(true);
			lightClouds4.SetActive(true);
			lightClouds5.SetActive(true);
			highClouds1.SetActive(true);
			highClouds2.SetActive(true);
			mostlyCloudyClouds.SetActive(true);
			//horizonObject.SetActive(true);
		}
		
		//If user chooses to use dynamic clouds
		if (cloudType == 1)
		{
			//Updated 1.8.1
			lightClouds1.SetActive(true);
			heavyCloudsLayerLight.SetActive(true);
			heavyCloudsLayer1.SetActive(false);
			lightClouds2.SetActive(false);
			lightClouds3.SetActive(false);
			lightClouds4.SetActive(false);
			lightClouds5.SetActive(false);
			highClouds1.SetActive(false);
			highClouds2.SetActive(false);
			mostlyCloudyClouds.SetActive(false);
			//horizonObject.SetActive(false);

			partlyCloudyClouds1.SetActive(true);
			
			if (cloudDensity == 1)
			{
				//Warning Obsolete Message Update
				lightClouds1a.SetActive(false);
				partlyCloudyClouds2.SetActive(false);
			}
			
			if (cloudDensity == 2)
			{
				//Warning Obsolete Message Update
				lightClouds1a.SetActive(true);
				partlyCloudyClouds2.SetActive(true);
			}
		}
		
		//Set dynamic cloud values
		uvAnimationRateA = new Vector2(0.001f, 0.0f);
		uvAnimationRateB = new Vector2(0.001f, 0.001f);
		//uvAnimationRateB = new Vector2(0.001f, -0.0035f);
		uvAnimationRateC = new Vector2(0.0001f, 0.0f);
		
		uvAnimationRateHeavyA = new Vector2(0.005f, 0.001f);
		uvAnimationRateHeavyB = new Vector2(0.004f, 0.0035f);
		uvAnimationRateHeavyC = new Vector2(0.0001f, 0.0f);
		
		//Added 1.7.5
		//Fixed obsolete error
		if (useSunFlare)
		{
			lightFlareObject = GameObject.Find("Sun Glare");
			
			lightFlareObject.GetComponent<Light>().color = sunFlareColor;
			
			//Added 1.8.1
			//Fixed obsolete messages

			sunObject = GameObject.Find("SunGlow");
			sunObject.transform.localScale = new Vector3(sunSize, sunSize, sunSize);
			sunObject.SetActive(true);

			//Warning Obsolete Message Update
			//GameObject.Find("SunGlow").SetActive(false);
			//lightFlareObject.SetActive(false);
			
		}
		
		if (!useSunFlare)
		{		
			//lightFlareObject = GameObject.Find("Sun Glare");
			//GameObject.Find("Sun Glare").SetActive(false);
		}
		
		if (useRainStreaks)
		{
			mistFog.SetActive(true);
		}
		
		if (!useRainStreaks)
		{
			mistFog.SetActive(false);
		}
		
		//Disable star sphere instead	
		if (startTimeNumber == 1)
		{
			startTime = .28f;
			moon.intensity = 0;
			moonPhaseChangeTime = 0;
		}
		
		if (startTimeNumber == 2)
		{
			fadeStars = 0;
			startTime = .4100f;
			moon.intensity = 0;
			moonPhaseChangeTime = 0;
		}
		
		if (startTimeNumber == 3)
		{
			startTime = .72f;
			moon.intensity = 0;
			moonPhaseChangeTime = 0;
		}
		
		if (startTimeNumber == 4)
		{
			startTime = .0f;
			moonPhaseChangeTime = .4165f;
		}
		
		if (RenderSettings.fogMode == FogMode.Linear)
		{
			RenderSettings.fogStartDistance = fogStartDistance;
			RenderSettings.fogEndDistance = fogEndDistance;
		}

		//Aded 1.8.4
		moonLight = moon.GetComponent<Light>();
		moonLight.intensity = moonLightIntensity;
		
		//Test
		//sunOffSetX = sunOffSet.x;
		//sunOffSetY = sunOffSet.y;
		//lightFlareObject.transform.localPosition = new Vector3(lightFlareObject.transform.localPosition.x + sunOffSetX, lightFlareObject.transform.localPosition.y + sunOffSetY, lightFlareObject.transform.localPosition.z);
		//sunOffSet.x = lightFlareObject.transform.localPosition.x + sunOffSet.x;
		//sunOffSet.y = lightFlareObject.transform.localPosition.y + sunOffSet.y;
		//lightFlareObject.transform.localPosition = new Vector3(sunOffSet.x, sunOffSet.y, lightFlareObject.transform.localPosition.z);
		
		//lightFlareObject.transform.position = sunOffSet;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Added 1.7.5	
		if (weatherForecaster == 2 && useRainStreaks)
		{
			if (minFogIntensity <= 0)
			{
				mistFog.gameObject.SetActive(false);
			}
		}

		if (weatherForecaster == 3 && useRainStreaks || weatherForecaster == 12 && useRainStreaks)
		{
			if (minFogIntensity >= 1)
			{
				mistFog.gameObject.SetActive(true);
			}
		}
		
		//Added 1.8.1
		if (weatherForecaster == 2 && UseRainMist)
		{
			if (minHeavyRainMistIntensity <= 0)
			{
				rainMist.gameObject.SetActive(false);
			}
		}

		if (weatherForecaster == 3 && UseRainMist || weatherForecaster == 12 && UseRainMist)
		{
			if (minHeavyRainMistIntensity >= 1)
			{
				rainMist.gameObject.SetActive(true);
			}
		}

		//RenderSettings.skybox.SetFloat("kSUN_BRIGHTNESS", 0);
		
		DynamicTimeOfDaySounds ();
		
		//lightFlareObject.transform.localPosition = new Vector3(sunOffSet.x, sunOffSet.y, lightFlareObject.transform.localPosition.z);
		//lightFlareObject.transform.localPosition = new Vector3(sunOffSet.x, sunOffSet.y, lightFlareObject.transform.localPosition.z);
		
		if (startTimeNumber == 1 || startTimeNumber == 2 || startTimeNumber == 3)
		{
			startTimeTimer -= Time.deltaTime;
			starSphere.GetComponent<Renderer>().enabled = false;
			if (startTimeTimer <= 0)
			{
				startTimeNumber = 0;	
				starSphere.GetComponent<Renderer>().enabled = true;
			}
		}
		
		if (minuteCounter <= 5)
		{
			weatherShuffled = false;
		}
		
		//Rewrote weather generator
		//Weather now generates properly according to season
		//Weather will also not longer get stuck generating endlessly when using the slider
		//This allows for reliable consistant weather generation
		
		if (minuteCounter > 58 && !weatherShuffled)
		{
			weatherShuffled = true;
			
			if (weatherUpdate == 1 && isSpring == true)
			{	
				
				//80% chance for percipitation			
				if (weatherChanceSpring == 80)
				{
					weatherOdds = Random.Range (80,100);
				}
				
				//60% chance for percipitation			
				if (weatherChanceSpring == 60)
				{
					weatherOdds = Random.Range (60,100);
				}
				
				//40% chance for percipitation			
				if (weatherChanceSpring == 40)
				{
					weatherOdds = Random.Range (40,100);
				}	
				
				//20% chance for percipitation			
				if (weatherChanceSpring == 20)
				{
					weatherOdds = Random.Range (20,100);
				}
			}
			
			//Summer Weather Odds
			if (weatherUpdate == 1 && isSummer == true)
			{	
				
				//80% chance for percipitation			
				if (weatherChanceSummer == 80)
				{
					weatherOdds = Random.Range (80,100);
				}
				
				//60% chance for percipitation			
				if (weatherChanceSummer == 60)
				{
					weatherOdds = Random.Range (60,100);
				}
				
				//40% chance for percipitation			
				if (weatherChanceSummer == 40)
				{
					weatherOdds = Random.Range (40,100);
				}	
				
				//20% chance for percipitation			
				if (weatherChanceSummer == 20)
				{
					weatherOdds = Random.Range (20,100);
				}
			}
			
			//Fall Weather Odds
			if (weatherUpdate == 1 && isFall == true)
			{	
				
				//80% chance for percipitation			
				if (weatherChanceFall == 80)
				{
					weatherOdds = Random.Range (80,100);
				}
				
				//60% chance for percipitation			
				if (weatherChanceFall == 60)
				{
					weatherOdds = Random.Range (60,100);
				}
				
				//40% chance for percipitation			
				if (weatherChanceFall == 40)
				{
					weatherOdds = Random.Range (40,100);
				}	
				
				//20% chance for percipitation			
				if (weatherChanceFall == 20)
				{
					weatherOdds = Random.Range (20,100);
				}
			}
			
			//Winter Weather Odds
			if (weatherUpdate == 1 && isWinter == true)
			{	
				
				//80% chance for percipitation			
				if (weatherChanceWinter == 80)
				{
					weatherOdds = Random.Range (80,100);
				}
				
				//60% chance for percipitation			
				if (weatherChanceWinter == 60)
				{
					weatherOdds = Random.Range (60,100);
				}
				
				//40% chance for percipitation			
				if (weatherChanceWinter == 40)
				{
					weatherOdds = Random.Range (40,100);
				}	
				
				//20% chance for percipitation			
				if (weatherChanceWinter == 20)
				{
					weatherOdds = Random.Range (20,100);
				}
			}
		}
		
		
		
		if (horizonToggle == false)
		{
			//horizonObject.renderer.enabled = false;
		}
		
		if (horizonToggle == true)
		{
			//horizonObject.renderer.enabled = true;
		}
		
		//hourCounter = Hour;
		
		hourCounter = (int)Hour;
		
		//Fix 1.8.1
		stormCounter += Time.deltaTime * .5f;
		//minuteCounterCalculator = Hour*60f;
		
		minuteCounterCalculator = Hour*60f;	
		minuteCounter = (int)minuteCounterCalculator;
		minuteCounterNew = minuteCounter;
		
		float cloudScrollSpeedCalculator = cloudSpeed * .001f;
		float heavCloudScrollSpeedCalculator = heavyCloudSpeed * .001f;
		
		starSpeedCalculator = starSpeed * 0.1f;
		
		
		cloudSpeedY = .003f;
		//float cloudSpeedHighY = .0015f;
		float starSpeedY5 = .004f;	
		
		float offsetY5a = Time.time * cloudScrollSpeedCalculator;
		float offsetY5b = Time.time * heavCloudScrollSpeedCalculator;
		//float offsetY5c = Time.time * heavCloudScrollSpeedCalculator;
		
		float offsetY5 = Time.time * cloudSpeedY;
		//float offsetStormY5 = Time.time * starSpeedY5;
		float offsetYHigh5 = Time.time * cloudScrollSpeedCalculator;
		float offsetX5 = Time.time * starSpeedY5; 
		
		float starRotationSpeedCalc = Time.time * starRotationSpeed * 0.00005f;
		
		//Added 1.7.5
		if (cloudType == 2)
		{
			heavyCloudsLayer1.GetComponent<Renderer>().sharedMaterial.mainTextureOffset = new Vector2 (offsetY5b,0); 
			lightClouds1.GetComponent<Renderer>().sharedMaterial.mainTextureOffset = new Vector2 (0,offsetY5a);
			lightClouds2.GetComponent<Renderer>().sharedMaterial.mainTextureOffset = new Vector2 (offsetY5a,offsetY5a);
			lightClouds3.GetComponent<Renderer>().sharedMaterial.mainTextureOffset = new Vector2 (0,offsetY5a);
			lightClouds4.GetComponent<Renderer>().sharedMaterial.mainTextureOffset = new Vector2 (offsetY5a,offsetY5a);
			lightClouds5.GetComponent<Renderer>().sharedMaterial.mainTextureOffset = new Vector2 (0,offsetY5a);
			highClouds1.GetComponent<Renderer>().sharedMaterial.mainTextureOffset = new Vector2 (0,offsetYHigh5);
			highClouds2.GetComponent<Renderer>().sharedMaterial.mainTextureOffset = new Vector2 (0,offsetYHigh5);
			mostlyCloudyClouds.GetComponent<Renderer>().sharedMaterial.mainTextureOffset = new Vector2 (0,offsetY5);
			starSphere.GetComponent<Renderer>().sharedMaterial.mainTextureOffset = new Vector2 (offsetX5,0 + .02f);
			//heavyCloudsLayerLight.renderer.sharedMaterial.mainTextureOffset = new Vector2 (0,offsetY5b); 
		}
		
		heavyClouds.GetComponent<Renderer>().sharedMaterial.mainTextureOffset = new Vector2 (offsetY5b,offsetY5b); 
		
		//starSphere.transform.rotation = Quaternion.AngleAxis(starRotationSpeedCalc * 360 - 90, Vector3.up);
		//float hi = Quaternion.AngleAxis(starRotationSpeedCalc * 360 - 90, Vector3.up);
		
		
		
		starSphere.transform.eulerAngles = new Vector3(270, starRotationSpeedCalc, 0);
		//starSphere.transform.eulerAngles.z = default1;
		//starSphere.transform.eulerAngles.x = 270;
		
		//Added 1.7.5, Controls shadows for both day and night light sources
		if (shadowsDuringDay)
		{
			if (dayShadowType == 1)
			{
				sun.GetComponent<Light>().shadows = LightShadows.Hard;
			}
			
			if (dayShadowType == 2)
			{
				sun.GetComponent<Light>().shadows = LightShadows.Soft;
			}
			
			sun.GetComponent<Light>().shadowStrength = dayShadowIntensity;
		}
		
		if (!shadowsDuringDay)
		{
			sun.GetComponent<Light>().shadows = LightShadows.None;
		}
		
		if (shadowsDuringNight)
		{
			if (nightShadowType == 1)
			{
				moon.GetComponent<Light>().shadows = LightShadows.Hard;
			}
			
			if (nightShadowType == 2)
			{
				moon.GetComponent<Light>().shadows = LightShadows.Soft;
			}
			
			moon.GetComponent<Light>().shadowStrength = nightShadowIntensity;
		}
		
		if (!shadowsDuringNight)
		{
			moon.GetComponent<Light>().shadows = LightShadows.None;
		}
		
		if (shadowsLightning)
		{
			if (lightningShadowType == 1)
			{
				lightSource.GetComponent<Light>().shadows = LightShadows.Hard;
			}
			
			if (lightningShadowType == 2)
			{
				lightSource.GetComponent<Light>().shadows = LightShadows.Soft;
			}
			
			lightSource.GetComponent<Light>().shadowStrength = lightningShadowIntensity;
		}
		
		if (!shadowsLightning)
		{
			lightSource.GetComponent<Light>().shadows = LightShadows.None;
		}
		
		//
		
		
		//Calculates our minutes, hours, days, months, and years.

		
		
		//Calculates our seasons
		if (monthCounter >= 2 && monthCounter <= 4)
		{
			//print("It's Spring");
			//weatherOdds = dayLength * 43; 
			isSpring = true;
			isSummer = false;
			isFall = false;
			isWinter = false;
			WeatherForecaster ();
			
		}
		
		//Calculates our seasons
		if (monthCounter >= 5 && monthCounter <= 7)
		{
			//print("It's Summer");
			//weatherOdds = dayLength * 101; 
			isSummer = true;
			isSpring = false;
			isFall = false;
			isWinter = false;
			WeatherForecaster ();
		}
		
		//Calculates our seasons
		if (monthCounter >= 8 && monthCounter <= 10)
		{
			//print("It's Fall");
			//weatherOdds = dayLength * 46;
			isSummer = false;
			isSpring = false;
			isFall = true;
			isWinter = false; 
			WeatherForecaster ();
		}
		
		//Calculates our seasons
		if (monthCounter == 11 || monthCounter == 12 || monthCounter == 1)
		{
			//print("It's Winter");
			//weatherOdds = dayLength * 33; 
			isSummer = false;
			isSpring = false;
			isFall = false;
			isWinter = true;
			WeatherForecaster ();
		}
		
		//Controls wether the weather command prompt is enabled or disabled	
		if (weatherCommandPromptUseable == true)
		{
			if(Input.GetKeyDown(KeyCode.F12))
			{
				commandPromptActive = !commandPromptActive;
			}
		} 
		
		if (timeScrollBarUseable == true)
		{
			if(Input.GetKeyDown(KeyCode.F12))
			{
				timeScrollBar = !timeScrollBar;
			}
		} 
		
		if (weatherCommandPromptUseable == false)
		{ 
			commandPromptActive = false;
		}
		
		
		//Calculates our hours into days
		if(Hour >= 24)
		{
			startTime = 0;
			calculate2 = 0;
			Hour = 0;
			dayCounter += 1;
			forceStorm += 1;
			moonPhaseCalculator += 1;
			
			hour1 = false;
			hour2 = false;
			hour3 = false;
			hour4 = false;
			hour5 = false;
			hour6 = false;
			hour7 = false;
			hour8 = false;
			hour9 = false;
			hour10 = false;
			hour11 = false;
			hour12 = false;
			hour13 = false;
			hour14 = false;
			hour15 = false;
			hour16 = false;
			hour17 = false;
			hour18 = false;
			hour19 = false;
			hour20 = false;
			hour21 = false;
			hour22 = false;
			hour23 = false;
			hour0 = false;
			
			
			if (weatherForecaster == 3 || weatherForecaster == 2 || weatherForecaster == 12) 
			{
				changeWeather += 1; 
			}
			
			
		}
		
		
		//Updated 1.8.1
		//Temperatures will now properly generate with each season
		if (monthCounter >= 2 && monthCounter <= 4)
		{
			summerTemp = 0;
			winterTemp = 0;
			fallTemp = 0;
			
			if (springTemp == 0)
			{
				springTemp = 1;
				//Debug.Log("Spring Check 1");
			}
		}
		
		if (monthCounter >= 5 && monthCounter <= 7)
		{
			winterTemp = 0;
			fallTemp = 0;
			springTemp = 0;
			
			if (summerTemp == 0)
			{
				summerTemp = 1;
				//Debug.Log("Summer Check 1");
			}
		}
		
		if (monthCounter >= 8 && monthCounter <= 10)
		{
			summerTemp = 0;
			winterTemp = 0;
			springTemp = 0;
			
			if (fallTemp == 0)
			{
				fallTemp = 1;
				//Debug.Log("Fall Check 1");
			}
		}
		
		if (monthCounter == 11 || monthCounter == 12 || monthCounter == 1)
		{
			summerTemp = 0;
			fallTemp = 0;
			springTemp = 0;
			
			if (winterTemp == 0)
			{
				winterTemp = 1;
				//Debug.Log("Winter Check 1");
			}
		}
		
		if (monthCounter >= 2 && monthCounter <= 4)
		{
			if (springTemp == 1)
			{
				temperature = startingSpringTemp;
				springTemp = 2;
				//Debug.Log("Spring Check 2");
				
			}
			
			if (temperature <= minSpringTemp && springTemp == 2)
			{
				temperature = minSpringTemp;
			}
			
			if (temperature >= maxSpringTemp && springTemp == 2)
			{
				temperature = maxSpringTemp;
			}
		}
		
		//Generates the temperature for Summer
		if (monthCounter >= 5 && monthCounter <= 7)
		{
			
			if (summerTemp == 1)
			{
				temperature = startingSummerTemp;
				summerTemp = 2;
				//Debug.Log("Summer Check 2");
				
			}
			
			if (temperature <= minSummerTemp && summerTemp == 2)
			{
				temperature = minSummerTemp;
			}
			
			if (temperature >= maxSummerTemp && summerTemp == 2)
			{
				temperature = maxSummerTemp;
			}
		}
		
		//Generates the temperature for Fall
		if (monthCounter >= 8 && monthCounter <= 10)
		{
			
			if (fallTemp == 1)
			{
				temperature = startingFallTemp;
				fallTemp = 2;
				//Debug.Log("Fall Check 2");
				
			}
			
			if (temperature <= minFallTemp && fallTemp == 2)
			{
				temperature = minFallTemp;
			}
			
			if (temperature >= maxFallTemp && fallTemp == 2)
			{
				temperature = maxFallTemp;
			}
		}
		
		//Generates the temperature for Winter
		if (monthCounter >= 11 || monthCounter >= 12 || monthCounter <= 1)
		{
			//if (loadWinterTemp == true)
			if (winterTemp == 1)
			{
				temperature = startingWinterTemp;
				winterTemp = 2;
				//Debug.Log("Winter Check 2");
				
			}
			
			if (temperature <= minWinterTemp && winterTemp == 2)
			{
				temperature = minWinterTemp;
			}
			
			if (temperature >= maxWinterTemp && winterTemp == 2)
			{
				temperature = maxWinterTemp;
			}
		}	
		
		if (monthCounter == -1)
		{
			monthCounter = 11;
		}
		
		
		//Added 1.7.5
		if (Hour >= 20)
		{
			moon.GetComponent<Light>().enabled = true;
		}
		
		if (Hour >= 0 && Hour < 4)
		{
			moon.GetComponent<Light>().enabled = true;
		}
		
		if (Hour > 4 && Hour < 20)
		{
			moon.GetComponent<Light>().enabled = false;
		}
		//
		
		//Added 1.8.4 Moonlight Intensity Added
		//moon.GetComponent<Light>().intensity = moonLightIntensity;
		//moonLight.intensity = moonLightIntensity;
		//
		
		//Calculates our moon phases
		if (moonPhaseCalculator == 1)
		{
			moonObject.GetComponent<Renderer>().sharedMaterial = moonPhase1;	
		}
		
		if (moonPhaseCalculator == 2)
		{
			moonObject.GetComponent<Renderer>().sharedMaterial = moonPhase2;	
		}
		
		if (moonPhaseCalculator == 3)
		{
			moonObject.GetComponent<Renderer>().sharedMaterial = moonPhase3;	
		}
		
		if (moonPhaseCalculator == 4)
		{
			moonObject.GetComponent<Renderer>().sharedMaterial = moonPhase4;	
		}
		
		if (moonPhaseCalculator == 5)
		{
			moonObject.GetComponent<Renderer>().sharedMaterial = moonPhase5;	
		}
		
		if (moonPhaseCalculator == 6)
		{
			moonObject.GetComponent<Renderer>().sharedMaterial = moonPhase6;	
		}
		
		if (moonPhaseCalculator == 7)
		{
			moonObject.GetComponent<Renderer>().sharedMaterial = moonPhase7;	
		}
		
		if (moonPhaseCalculator == 8)
		{
			moonObject.GetComponent<Renderer>().sharedMaterial = moonPhase8;	
		}
		
		if (moonPhaseCalculator == 9)
		{
			moonPhaseCalculator = 1;	
		}
		
		
		
		//Rotates our sun using quaternion rotations so the angles don't coincide (sunAngle angles the sun based off the user's input)	
		//Added 1.7.5
		//Updated 1.8.1
		//Sun no longer flickers. Sun algorithm has been rewritten. This allows for perfectly smooth shadows while time is flowing.
		sun.transform.eulerAngles = new Vector3(startTime * 360 - 90, sunAngle, -7.0f);
		
		//sun.transform.rotation = Quaternion.AngleAxis(startTime * 360 - 90, Vector3.right + Vector3.up * sunAngle * 0.1f);
		
		//Fluctuates realistic temperatures
		if (hourCounter == 1 && hour1 == false)
		{
			temperature -= Random.Range (1,3);
			hour1 = true;
		}
		
		if (hourCounter == 2 && hour2 == false)
		{
			temperature -= Random.Range (1,3);
			hour2 = true;
		}
		
		if (hourCounter == 3 && hour3 == false)
		{
			temperature -= Random.Range (1,3);
			hour3 = true;
		}
		
		if (hourCounter == 4 && hour4 == false)
		{
			temperature -= Random.Range (1,3);
			hour4 = true;
		}
		
		if (hourCounter == 5 && hour5 == false)
		{
			temperature -= Random.Range (1,3);
			hour5 = true;
		}
		
		if (hourCounter == 6 && hour6 == false)
		{
			temperature += Random.Range (1,3);
			hour6 = true;
		}
		
		if (hourCounter == 7 && hour7 == false)
		{
			temperature += Random.Range (1,3);
			hour7 = true;
		}
		
		if (hourCounter == 8 && hour8 == false)
		{
			temperature += Random.Range (1,3);
			hour8 = true;
		}
		
		if (hourCounter == 9 && hour9 == false)
		{
			temperature += Random.Range (1,3);
			hour9 = true;
		}
		
		if (hourCounter == 10 && hour10 == false)
		{
			temperature += Random.Range (1,3);
			hour10 = true;
		}
		
		if (hourCounter == 11 && hour11 == false)
		{
			temperature += Random.Range (1,3);
			hour11 = true;
		}
		
		if (hourCounter == 12 && hour12 == false)
		{
			temperature += Random.Range (1,3);
			hour12 = true;
		}
		
		if (hourCounter == 13 && hour13 == false)
		{
			temperature += Random.Range (1,3);
			hour13 = true;
		}
		
		if (hourCounter == 14 && hour14 == false)
		{
			temperature += Random.Range (1,3);
			hour14 = true;
		}
		
		if (hourCounter == 15 && hour15 == false)
		{
			temperature += Random.Range (1,3);
			hour15 = true;
		}
		
		if (hourCounter == 16 && hour16 == false)
		{
			temperature += Random.Range (1,3);
			hour16 = true;
		}
		
		if (hourCounter == 17 && hour17 == false)
		{
			temperature -= Random.Range (1,3);
			hour17 = true;
		}
		
		if (hourCounter == 18 && hour18 == false)
		{
			temperature -= Random.Range (1,3);
			hour18 = true;
		}
		
		if (hourCounter == 19 && hour19 == false)
		{
			temperature -= Random.Range (1,3);
			hour19 = true;
		}
		
		if (hourCounter == 20 && hour20 == false)
		{
			temperature -= Random.Range (1,3);
			hour20 = true;
		}
		
		if (hourCounter == 21 && hour21 == false)
		{
			temperature -= Random.Range (1,3);
			hour21 = true;
		}
		
		if (hourCounter == 22 && hour22 == false)
		{
			temperature -= Random.Range (1,3);
			hour22 = true;
		}
		
		if (hourCounter == 23 && hour23 == false)
		{
			temperature -= Random.Range (1,3);
			hour23 = true;
		}
		
		if (hourCounter == 24 && hour0 == false)
		{
			temperature -= Random.Range (1,3);
			hour0 = true;
		}	
		
		//Calculates our minutes into hours
		if(minuteCounter >= 60)
		{	
			minuteCounter = (int)minuteCounterCalculator % 60;	
			//Picks our forecast randomly, if random generators are equal
			
		}
		
		if(minuteCounter == 59)
		{	
			weatherUpdate += 1;
		}
		
		if(minuteCounter == 1)
		{
			weatherUpdate = 0;
		}
		
		//Added 1.8.2
		if (calendarType == 1)
		{				
			//Calculates our days into months
			if(dayCounter >= 32 && monthCounter == 1 || dayCounter >= 32 && monthCounter == 3 || dayCounter >= 32 && monthCounter == 5 || dayCounter >= 32 && monthCounter == 7 || dayCounter >= 32 && monthCounter == 8 || dayCounter >= 32 && monthCounter == 10 || dayCounter >= 32 && monthCounter == 12)
			{
				dayCounter = dayCounter % 32;
				dayCounter += 1;
				monthCounter += 1;
			}
			
			if(dayCounter == 31 && monthCounter == 4 || dayCounter == 31 && monthCounter == 6 || dayCounter == 31 && monthCounter == 9 || dayCounter == 31 && monthCounter == 11)
			{
				dayCounter = dayCounter % 31;
				dayCounter += 1;
				monthCounter += 1;
			}
			
			//Calculates Leap Year
			if(dayCounter >= 30 && monthCounter == 2 && (yearCounter % 4 == 0 && yearCounter % 100 != 0) || (yearCounter % 400 == 0))
			{
				dayCounter = dayCounter % 30;
				dayCounter += 1;
				monthCounter += 1;
			}
			
			else if (dayCounter >= 29 && monthCounter == 2 && yearCounter % 4 != 0)
			{
				dayCounter = dayCounter % 29;
				dayCounter += 1;
				monthCounter += 1;
			}
			
			//Calculates our months into years
			if (monthCounter > 12)
			{
				monthCounter = monthCounter % 13;
				yearCounter += 1;
				monthCounter += 1;
			}
		}
		
		if (calendarType == 2)
		{
			//Calculates our custom days into months
			if(dayCounter > numberOfDaysInMonth)
			{
				dayCounter = dayCounter % numberOfDaysInMonth - 1;
				dayCounter += 1;
				monthCounter += 1;
			}
			
			//Calculates our custom months into years
			if (monthCounter > numberOfMonthsInYear)
			{
				monthCounter = monthCounter % numberOfMonthsInYear - 1;
				yearCounter += 1;
				monthCounter += 1;
			}
		}
		
		//If staticWeather is true, the weather will never change
		if (staticWeather == false)
		{			
			//20% Chance of weather change
			if (weatherOdds == 20 && weatherChanceSpring == 20 || weatherOdds == 20 && weatherChanceSummer == 20 || weatherOdds == 20 && weatherChanceFall == 20 || weatherOdds == 20 && weatherChanceWinter == 20)
			{
				//Controls our storms from switching too often
				if (stormCounter >= 13)
				{
					weatherForecaster = Random.Range(1,13);
					weatherOdds = 1;
					stormCounter = Random.Range (0,7);
				}
			}
			
			//40% Chance of weather change
			if (weatherOdds == 40 && weatherChanceSpring == 40 && weatherOdds == 40 && weatherChanceSummer == 40 || weatherOdds == 40 && weatherChanceFall == 40 || weatherOdds == 40 && weatherChanceWinter == 40)
			{
				//Controls our storms from switching too often
				if (stormCounter >= 13)
				{
					weatherForecaster = Random.Range(1,13);
					weatherOdds = 1;
					stormCounter = Random.Range (0,7);
				}
			}
			
			//60% Chance of weather change
			if (weatherOdds == 60 && weatherChanceSpring == 60 && weatherOdds == 60 && weatherChanceSummer == 60 || weatherOdds == 60 && weatherChanceFall == 60 || weatherOdds == 60 && weatherChanceWinter == 60)
			{
				//Controls our storms from switching too often
				if (stormCounter >= 13)
				{
					weatherForecaster = Random.Range(1,13);
					weatherOdds = 1;
					stormCounter = Random.Range (0,7);
				}
			}
			
			//80% Chance of weather change
			if (weatherOdds == 80 && weatherChanceSpring == 80 && weatherOdds == 80 && weatherChanceSummer == 80 || weatherOdds == 80 && weatherChanceFall == 80 || weatherOdds == 80 && weatherChanceWinter == 80)
			{
				//Controls our storms from switching too often
				if (stormCounter >= 13)
				{
					weatherForecaster = Random.Range(1,13);
					weatherOdds = 1;
					stormCounter = Random.Range (0,7);
				}
			}		
		}
		
		//Calculates our day length so it stays consistent	
		Hour = startTime*24;
		//timeOfDay = calculate2*24;

		//Added 1.8.4
		//This adds support for night length
		//If timeStopped is checked, time doesn't flow
		if (timeStopped == false)
		{	
			if (Hour >= dayLengthHour && Hour < nightLengthHour) 
			{
				startTime = startTime +Time.deltaTime/dayLength/60;
			}
			
			if (Hour >= nightLengthHour || Hour < dayLengthHour)
			{
				startTime = startTime +Time.deltaTime/nightLength/60;
			}
		}
		
		//Fades the suns intencity for morning and evening
		sun.intensity = (calculate2-0.1f) * sunIntensity;
		//sunCloudy.intensity = (calculate2-0.35f) * 3;
		
		if (sunIntensity <= 0)
		{
			sunIntensity = 0;
			sun.enabled = false;
			
			//Added 1.8.1
			//Warning Obsolete Message Update
			gradientSphere.SetActive(false);
		}
		
		if (sunIntensity >= .01)
		{
			sun.enabled = true;
			
			//Added 1.8.1
			//Warning Obsolete Message Update
			//gradientSphere.SetActive(true);
		}
		
		if (sunIntensity >= maxSunIntensity)
		{
			sunIntensity = maxSunIntensity;	
			lightSource.GetComponent<Light>().enabled = false;	
			//sunCloudy.enabled = false;
		}
		
		
		//Keeps our calculations looping
		if(startTime < 0.5)
		{
			calculate2 = startTime;
		}
		if(startTime > 0.5)
		{
			calculate2 = (1-startTime);
		}
		
		/*
	//Controls our weather so it doesn't change unrealistically
	if (stormCounter >= 10)
	{
		stormCounter = Random.Range (0,1);
	}
	*/
		
		//Forces precipitation if none has happened in an in-game week, prevents drouts
		if (forceStorm >= 7)
		{
			if (staticWeather == false)
			{	
				weatherForecaster = Random.Range(2,3);
				forceStorm = 0;
			}
		}
		
		//Changes our weather type if there has been precipitation for more than 3 in-game days
		if (changeWeather >= forceWeatherChange && stormControl == true)
		{
			if (staticWeather == false)
			{	
				weatherForecaster = Random.Range(4,11);
				changeWeather = 0;
			}
		}
		
		//Added 1.7.5
		if(Hour > 2 && Hour < 4)
		{
			//Added 1.7.5
			moon.color = Color.Lerp (moonColor, moonFadeColor, (Hour/2)-1);
			//moonObject.renderer.material.SetFloat("_FogAmountMax", (50000));
			//moonObject.renderer.material.SetFloat("_FogAmountMin", (0));
			
			//moonObject.renderer.material.SetFloat("_FogAmountMax", (50000));
			//moonObject.renderer.sharedMaterial.SetFloat("_FloatMax", (Hour/2)-1);
			//moonFade = moonObject.renderer.sharedMaterial.GetFloat("_FloatMax") * 50000;
			//moonObject.renderer.sharedMaterial.SetFloat("_FogAmountMax", (moonFade));
			
		}
		
		if (weatherForecaster == 1 || weatherForecaster == 2 || weatherForecaster == 3 || weatherForecaster == 12 || weatherForecaster == 9)
		{
			fader += 0.002f; //Was 0.002f
			fader2 -= 0.01f; //Was 0.01f
			
			if (fader2 <= 0)
			{
				fader2 = 0;
				//weatherHappened = true; //Try
			}
			
			if (fader >= 1)
			{
				fader = 1;
				weatherHappened = true; //Try
			}
			
			fogMorningColor = Color.Lerp (originalFogColorMorning, stormyFogColorMorning, fader);
			fogDayColor = Color.Lerp (originalFogColorDay, stormyFogColorDay, fader);
			fogDuskColor = Color.Lerp (originalFogColorEvening, stormyFogColorEvening, fader);
			fogNightColor = Color.Lerp (originalFogColorNight, stormyFogColorNight, fader);
			
			
		}
		
		//if (weatherForecaster == 4 && weatherHappened || weatherForecaster == 5  && weatherHappened || weatherForecaster == 6  && weatherHappened || weatherForecaster == 7  && weatherHappened || weatherForecaster == 8 && weatherHappened )
		if (weatherForecaster == 4 || weatherForecaster == 5 || weatherForecaster == 6 || weatherForecaster == 7 || weatherForecaster == 8)
		{
			fader2 += 0.0005f; //Was 0.002f
			fader -= 0.0025f; //Was 0.01f
			
			fogMorningColor = Color.Lerp (stormyFogColorMorning, originalFogColorMorning, fader2);
			fogDayColor = Color.Lerp (stormyFogColorDay, originalFogColorDay, fader2);
			fogDuskColor = Color.Lerp (stormyFogColorEvening, originalFogColorEvening, fader2);
			fogNightColor = Color.Lerp (stormyFogColorNight, originalFogColorNight, fader2);
			
			if (fader2 >= 1)
			{
				weatherHappened = false;
				fader2 = 1;
			}
			
			if (fader <= 0)
			{
				fader = 0;
			}
			
		}
		
		
		
		//Dynamic Sounds
		//Calculates morning fading in from night
		if(Hour > 4 && Hour < 6){
			RenderSettings.ambientLight = Color.Lerp (NightAmbientLight, MorningAmbientLight, (Hour/2)-2);
			sun.color = Color.Lerp (SunNight, SunMorning, (Hour/2)-2);
			
			RenderSettings.fogColor = Color.Lerp (fogNightColor, fogMorningColor, (Hour/2)-2);
			
			gradientSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_PeakColor", Color.Lerp (NightGradientContrastLight, MorningGradientContrastLight, (Hour/2)-2) );
			gradientSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_Level2Color", Color.Lerp (NightGradientLight, MorningGradientLight, (Hour/2)-2) );
			gradientSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_Level3Color", Color.Lerp (NightGradientLight, MorningGradientLight, (Hour/2)-2) );
			gradientSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_WaterColor", Color.Lerp (NightGradientLight, MorningGradientLight, (Hour/2)-2) );
			
			//RenderSettings.skybox=SkyBoxMaterial1;
			//RenderSettings.skybox.SetFloat("_Blend", 0);
			//RenderSettings.skybox.SetFloat("_Blend", (Hour/2)-2);
			//SkyBoxMaterial1.SetColor ("_Tint", Color.Lerp (NightSkyboxTint, MorningSkyboxTint, (Hour/2)-2) );
			//horizonObject.renderer.material.color = Color.Lerp (horizonNight, horizonMorning, (Hour/2)-2);
			
			//Added 1.8.1
			//This allows our skies to have a realistic horizon band. The color of this can be adjusted
			//SkyBoxMaterial1.SetColor ("_FogTint", Color.Lerp (Color.black, MorningSkyboxTintContrast, (Hour/2)-2) );
			//SkyBoxMaterial2.SetColor ("_FogTint", Color.Lerp (Color.black, MorningSkyboxTintContrast, (Hour/2)-2) );


			//SkyBoxMaterial1.SetColor ("_FogTint", Color.Lerp (Color.black, Color.black, (Hour/2)-2) );
			//RenderSettings.
			
			//Added 1.8.1
			lightClouds1.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp (cloudColorNight, cloudColorMorning, (Hour/2)-2) );
			lightClouds1a.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp (cloudColorNight, cloudColorMorning, (Hour/2)-2) );
			
			moonObject.GetComponent<Renderer>().sharedMaterial.SetFloat("_FloatMin", (Hour/2)-2);
			moonFade2 = moonObject.GetComponent<Renderer>().sharedMaterial.GetFloat("_FloatMin") * -50000.0f;
			moonObject.GetComponent<Renderer>().sharedMaterial.SetFloat("_FogAmountMin", (moonFade2));

			moonObject.GetComponent<Renderer>().sharedMaterial.SetColor ("_MoonColor", Color.Lerp (moonColorFade, moonFadeColor, (Hour/2)-2) );
			
			fogScript = cameraThing.GetComponent<Camera>().GetComponent<GlobalFog>();
			//fogScript.globalFogColor = Color.Lerp (stormyFogColorDuskDawn_GF, stormyFogColorDuskDawn_GF, (Hour/2)-2);
			
			sunShaftScript = cameraThing.GetComponent<Camera>().GetComponent<SunShafts>();
			sunShaftScript.sunColor = Color.Lerp (DuskAtmosphericLight, MorningAtmosphericLight, (Hour/2)-2);
			
			//Added 1.7.5
			moon.color = moonFadeColor;
			
			//Fades the stars on morning
			starSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_TintColor", Color.Lerp (starBrightness, moonFadeColor, (Hour/2)-2) );
		}
		
		//Calculates day
		if(Hour>6&&Hour<8){
			RenderSettings.ambientLight = Color.Lerp (MorningAmbientLight, MiddayAmbientLight, (Hour/2)-3);
			sun.color = Color.Lerp (SunMorning, SunDay, (Hour/2)-3);
			starSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_TintColor",  starBrightness * fadeStars);
			RenderSettings.fogColor = Color.Lerp (fogMorningColor, fogDayColor, (Hour/2)-3);
			
			gradientSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_PeakColor", Color.Lerp (MorningGradientContrastLight, DayGradientContrastLight, (Hour/2)-3) );
			gradientSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_Level2Color", Color.Lerp (MorningGradientLight, DayGradientLight, (Hour/2)-3) );
			gradientSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_Level3Color", Color.Lerp (MorningGradientLight, DayGradientLight, (Hour/2)-3) );
			gradientSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_WaterColor", Color.Lerp (MorningGradientLight, DayGradientLight, (Hour/2)-3) );
			
			//Skybox
			//RenderSettings.skybox=SkyBoxMaterial2;
			//RenderSettings.skybox.SetFloat("_Blend", 1);
			//SkyBoxMaterial2.SetColor ("_Tint", Color.Lerp (MorningSkyboxTint, MiddaySkyboxTint,  (Hour/2)-3) );
			
			//Added 1.8.1
			//This allows our skies to have a realistic horizon band. The color of this can be adjusted
			//SkyBoxMaterial2.SetColor ("_FogTint", Color.Lerp (MorningSkyboxTintContrast, MiddaySkyboxTintContrast, (Hour/2)-3) );
			//SkyBoxMaterial1.SetColor ("_FogTint", Color.Lerp (MorningSkyboxTintContrast, MiddaySkyboxTintContrast, (Hour/2)-3) );
			
			//Added 1.8.1
			lightClouds1.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp (cloudColorMorning, cloudColorDay, (Hour/2)-3) );
			lightClouds1a.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp (cloudColorMorning, cloudColorDay, (Hour/2)-3) );
			
			fogScript = cameraThing.GetComponent<Camera>().GetComponent<GlobalFog>();
			//fogScript.globalFogColor = Color.Lerp (stormyFogColorDuskDawn_GF, stormyFogColorDay_GF, (Hour/2)-3);
			
			sunShaftScript = cameraThing.GetComponent<Camera>().GetComponent<SunShafts>();
			sunShaftScript.sunColor = Color.Lerp (MorningAtmosphericLight, MiddayAtmosphericLight, (Hour/2)-3);
			
			fadeStars = 0;
			
		}
		
		//Calculates day
		if(Hour>8&&Hour<16){
			RenderSettings.ambientLight = Color.Lerp (MiddayAmbientLight, MiddayAmbientLight, (Hour/2)-4);
			sun.color = Color.Lerp (SunDay, SunDay, (Hour/2)-4);
			starSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_TintColor",  starBrightness * fadeStars);
			RenderSettings.fogColor = Color.Lerp (fogDayColor, fogDayColor, (Hour/2)-4);
			
			gradientSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_PeakColor", Color.Lerp (DayGradientContrastLight, DayGradientContrastLight, (Hour/2)-4) );
			gradientSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_Level2Color", Color.Lerp (DayGradientLight, DayGradientLight, (Hour/2)-4) );
			gradientSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_Level3Color", Color.Lerp (DayGradientLight, DayGradientLight, (Hour/2)-4) );
			gradientSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_WaterColor", Color.Lerp (DayGradientLight, DayGradientLight, (Hour/2)-4) );
			
			//Skybox
			//RenderSettings.skybox=SkyBoxMaterial2;
			//RenderSettings.skybox.SetFloat("_Blend", 1);
			//SkyBoxMaterial2.SetColor ("_Tint", Color.Lerp (MiddaySkyboxTint, MiddaySkyboxTint,  (Hour/2)-4) );
			
			//Added 1.8.1
			//This allows our skies to have a realistic horizon band. The color of this can be adjusted
			//SkyBoxMaterial2.SetColor ("_FogTint", Color.Lerp (MiddaySkyboxTintContrast, MiddaySkyboxTintContrast, (Hour/2)-4) );
			//SkyBoxMaterial1.SetColor ("_FogTint", Color.Lerp (MiddaySkyboxTintContrast, MiddaySkyboxTintContrast, (Hour/2)-4) );
			
			//Added 1.8.1
			lightClouds1.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp (cloudColorDay, cloudColorDay, (Hour/2)-4) );
			lightClouds1a.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp (cloudColorDay, cloudColorDay, (Hour/2)-4) );
			
			fogScript = cameraThing.GetComponent<Camera>().GetComponent<GlobalFog>();
			//fogScript.globalFogColor = Color.Lerp (stormyFogColorDuskDawn_GF, stormyFogColorDay_GF, (Hour/2)-4);
			
			sunShaftScript = cameraThing.GetComponent<Camera>().GetComponent<SunShafts>();
			sunShaftScript.sunColor = Color.Lerp (MiddayAtmosphericLight, MiddayAtmosphericLight, (Hour/2)-4);
			
			fadeStars = 0;
			
		}
		
		//Calculates dusk fading in from day
		if(Hour>16&&Hour<18)
		{
			RenderSettings.ambientLight = Color.Lerp (MiddayAmbientLight, DuskAmbientLight, (Hour/2)-8);
			sun.color = Color.Lerp (SunDay, SunDusk, (Hour/2)-8);
			RenderSettings.fogColor = Color.Lerp (fogDayColor, fogDuskColor, (Hour/2)-8);
			
			gradientSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_PeakColor", Color.Lerp (DayGradientContrastLight, DuskGradientContrastLight, (Hour/2)-8) );
			gradientSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_Level2Color", Color.Lerp (DayGradientLight, DuskGradientLight, (Hour/2)-8) );
			gradientSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_Level3Color", Color.Lerp (DayGradientLight, DuskGradientLight, (Hour/2)-8) );
			gradientSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_WaterColor", Color.Lerp (DayGradientLight, DuskGradientLight, (Hour/2)-8) );
			
			//Skybox
			//RenderSettings.skybox=SkyBoxMaterial1;
			//RenderSettings.skybox.SetFloat("_Blend", 1);
			//SkyBoxMaterial1.SetColor ("_Tint", Color.Lerp (MiddaySkyboxTint, DuskSkyboxTint, (Hour/2)-8) );
			
			//Added 1.8.1
			//This allows our skies to have a realistic horizon band. The color of this can be adjusted
			//SkyBoxMaterial1.SetColor ("_FogTint", Color.Lerp (MiddaySkyboxTintContrast, DuskSkyboxTintContrast, (Hour/2)-8) );
			//SkyBoxMaterial2.SetColor ("_FogTint", Color.Lerp (MiddaySkyboxTintContrast, DuskSkyboxTintContrast, (Hour/2)-8) );
			
			//Added 1.8.1
			lightClouds1.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp (cloudColorDay, cloudColorEvening, (Hour/2)-8) );
			lightClouds1a.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp (cloudColorDay, cloudColorEvening, (Hour/2)-8) );

			moonObject.GetComponent<Renderer>().sharedMaterial.SetColor ("_MoonColor", Color.Lerp (moonFadeColor, moonFadeColor, (Hour/2)-8) );
			
			//horizonObject.renderer.material.color = Color.Lerp (horizonDay, horizonDusk, (Hour/2)-8);
			
			fogScript = cameraThing.GetComponent<Camera>().GetComponent<GlobalFog>();
			//fogScript.globalFogColor = Color.Lerp (stormyFogColorDuskDawn_GF, stormyFogColorDuskDawn_GF, (Hour/2)-8);
			
			sunShaftScript = cameraThing.GetComponent<Camera>().GetComponent<SunShafts>();
			sunShaftScript.sunColor = Color.Lerp (MiddayAtmosphericLight, DuskAtmosphericLight, (Hour/2)-8);
			
			fadeStars = 0; 	
			
		}
		
		//Calculates night fading in from dusk
		if(Hour>18&&Hour<20)
		{
			RenderSettings.ambientLight = Color.Lerp (DuskAmbientLight, NightAmbientLight, (Hour/2)-9);
			sun.color = Color.Lerp (SunDusk, SunNight, (Hour/2)-9);
			RenderSettings.fogColor = Color.Lerp (fogDuskColor, fogNightColor, (Hour/2)-9);
			
			gradientSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_PeakColor", Color.Lerp (DuskGradientContrastLight, NightGradientContrastLight, (Hour/2)-9) );
			gradientSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_Level2Color", Color.Lerp (DuskGradientLight, NightGradientLight, (Hour/2)-9) );
			gradientSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_Level3Color", Color.Lerp (DuskGradientLight, NightGradientLight, (Hour/2)-9) );
			gradientSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_WaterColor", Color.Lerp (DuskGradientLight, NightGradientLight, (Hour/2)-9) );
			
			//Skybox
			//RenderSettings.skybox=SkyBoxMaterial1;
			//RenderSettings.skybox.SetFloat("_Blend", 1);
			//SkyBoxMaterial1.SetColor ("_Tint", Color.Lerp (DuskSkyboxTint, NightSkyboxTint, (Hour/2)-9) );
			
			//Added 1.8.1
			//This allows our skies to have a realistic horizon band. The color of this can be adjusted
			//SkyBoxMaterial1.SetColor ("_FogTint", Color.Lerp (DuskSkyboxTintContrast, NightSkyboxTintContrast, (Hour/2)-9) );
			//SkyBoxMaterial2.SetColor ("_FogTint", Color.Lerp (DuskSkyboxTintContrast, NightSkyboxTintContrast, (Hour/2)-9) );
			
			//Added 1.8.1
			lightClouds1.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp (cloudColorEvening, cloudColorNight, (Hour/2)-9) );
			lightClouds1a.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp (cloudColorEvening, cloudColorNight, (Hour/2)-9) );

			moonObject.GetComponent<Renderer>().sharedMaterial.SetColor ("_MoonColor", Color.Lerp (moonFadeColor, starBrightness, (Hour/2)-9) );
			
			//horizonObject.renderer.material.color = Color.Lerp (horizonDusk, horizonNight, (Hour/2)-9);
			
			fogScript = cameraThing.GetComponent<Camera>().GetComponent<GlobalFog>();
			//fogScript.globalFogColor = Color.Lerp (stormyFogColorDuskDawn_GF, stormyFogColorNight_GF, (Hour/2)-9);
			
			sunShaftScript = cameraThing.GetComponent<Camera>().GetComponent<SunShafts>();
			sunShaftScript.sunColor = Color.Lerp (DuskAtmosphericLight, DuskAtmosphericLight, (Hour/2)-9);
			
			starSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_TintColor", Color.Lerp (moonFadeColor, starBrightness, (Hour/2)-9) );
			
			
			if (fadeStars >= 1)
			{
				fadeStars = 1;
			}
			
		}
		
		
		//Calculates night
		if(Hour>20)
		{
			RenderSettings.ambientLight = NightAmbientLight;
			sun.color = Color.Lerp (SunNight, SunNight, (Hour/2)-10);	
			starSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_TintColor",  starBrightness * fadeStars);
			
			gradientSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_PeakColor", Color.Lerp (NightGradientContrastLight, NightGradientContrastLight, (Hour/2)-10) );
			gradientSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_Level2Color", Color.Lerp (NightGradientLight, NightGradientLight, (Hour/2)-10) );
			gradientSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_Level3Color", Color.Lerp (NightGradientLight, NightGradientLight, (Hour/2)-10) );
			gradientSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_WaterColor", Color.Lerp (NightGradientLight, NightGradientLight, (Hour/2)-10) );

			moonObject.GetComponent<Renderer>().sharedMaterial.SetColor ("_MoonColor", Color.Lerp (starBrightness, starBrightness, (Hour/2)-10) );
			
			//Added 1.8.1
			//lightClouds1.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp (cloudColorNight, cloudColorNight, (Hour/2)-10) );
			//lightClouds1a.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp (cloudColorNight, cloudColorNight, (Hour/2)-10) );
				
			moonObject.GetComponent<Renderer>().sharedMaterial.SetFloat("_FogAmountMin", (0));
			
			moonObject.GetComponent<Renderer>().sharedMaterial.SetFloat("_FloatMax", (Hour/2)-10);
			moonFade = moonObject.GetComponent<Renderer>().sharedMaterial.GetFloat("_FloatMax") * 50000.0f;
			moonObject.GetComponent<Renderer>().sharedMaterial.SetFloat("_FogAmountMax", (moonFade));
			
			
			RenderSettings.fogColor = Color.Lerp (fogNightColor, fogNightColor, (Hour/2)-10);
			
			//Added 1.7.5
			moon.color = Color.Lerp (moonFadeColor, moonColor, (Hour/2)-10);
			
			//Skybox
			//RenderSettings.skybox = SkyBoxMaterial1;
			
			//RenderSettings.skybox.SetFloat("_Blend", (Hour/-2)+11);
			
			//horizonObject.renderer.material.color = Color.Lerp (horizonNight, horizonNight, (Hour/2)-10);
			
			fogScript = cameraThing.GetComponent<Camera>().GetComponent<GlobalFog>();
			//fogScript.globalFogColor = Color.Lerp (stormyFogColorNight, stormyFogColorNight, (Hour/2)-10);
			
			sun.enabled = false;
			
			fadeStars = 1;
			
		}
		
		if (Hour > 22 && Hour < 24)
		{
			//moonObject.renderer.material.SetFloat("__FogAmountMax", (Hour/2)-11);
			//moonObject.renderer.material.SetFloat("__FogAmountMax", 70000);
		}
		
		
		if(Hour<4)
		{
			RenderSettings.ambientLight = NightAmbientLight;
			sun.color = Color.Lerp (SunNight, SunNight, (Hour/2)-2);	
			starSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_TintColor",  starBrightness * fadeStars);
			
			gradientSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_PeakColor", Color.Lerp (NightGradientContrastLight, NightGradientContrastLight, (Hour/2)-2) );
			gradientSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_Level2Color", Color.Lerp (NightGradientLight, NightGradientLight, (Hour/2)-2) );
			gradientSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_Level3Color", Color.Lerp (NightGradientLight, NightGradientLight, (Hour/2)-2) );
			gradientSphere.GetComponent<Renderer>().sharedMaterial.SetColor ("_WaterColor", Color.Lerp (NightGradientLight, NightGradientLight, (Hour/2)-2) );
			
			RenderSettings.fogColor = Color.Lerp (fogNightColor, fogNightColor, (Hour/2)-2);
			
			//Skybox
			//RenderSettings.skybox = SkyBoxMaterial1;
			//RenderSettings.skybox.SetFloat("_Blend", 0);
			//SkyBoxMaterial1.SetColor ("_Tint", NightSkyboxTint);
			
			//Added 1.8.1
			//This allows our skies to have a realistic horizon band. The color of this can be adjusted
			//SkyBoxMaterial1.SetColor ("_FogTint", Color.black);
			//SkyBoxMaterial2.SetColor ("_FogTint", Color.black);

			
			moonObject.GetComponent<Renderer>().sharedMaterial.SetColor ("_MoonColor", Color.Lerp (starBrightness, starBrightness, (Hour/2)-10) );
			
			moonObject.GetComponent<Renderer>().sharedMaterial.SetFloat("_FogAmountMin", (0));
			moonObject.GetComponent<Renderer>().sharedMaterial.SetFloat("_FogAmountMax", (50000));
			
			//horizonObject.renderer.material.color = Color.Lerp (horizonNight, horizonNight, (Hour/2)-2);
			
			fogScript = cameraThing.GetComponent<Camera>().GetComponent<GlobalFog>();
			//fogScript.globalFogColor = Color.Lerp (stormyFogColorNight, stormyFogColorNight, (Hour/2)-2);
			
			//sun.enabled = false;
			
			fadeStars = 1;
			
		}
		
	}

	//Puts all fading in and out weather types into 2 function then picks by weather type to control individual weather factors
	void WeatherForecaster () 
	{	
		//Foggy 
		if (weatherForecaster == 1)
		{
			FadeInPrecipitation();
		}

		//Light Snow / Light Rain
		if (weatherForecaster == 2)
		{
			FadeInPrecipitation();
		}

		//Heavy Snow
		if (weatherForecaster == 3)
		{
			FadeInPrecipitation();
		}

		//Partly Cloudy 1
		if (weatherForecaster == 4)
		{
			FadeOutPrecipitation ();
		}
		
		//Partly Cloudy 2
		if (weatherForecaster == 5)
		{
			FadeOutPrecipitation ();
		}
		
		//Partly Cloudy 3
		if (weatherForecaster == 6)
		{
			FadeOutPrecipitation ();
		}
		
		//Mostly clear 1
		if (weatherForecaster == 7)
		{
			FadeOutPrecipitation();
		}
		
		//Mostly clear 2
		if (weatherForecaster == 8)
		{
			FadeOutPrecipitation ();
		}
		
		//Mostly Cloudy
		if (weatherForecaster == 11)
		{
			weatherForecaster = 8;
		}
		
		//Cloudy
		if (weatherForecaster == 9)
		{
			weatherForecaster = 1;
		}
		
		//Butterflies (Summer Only)
		if (weatherForecaster == 10)
		{
			FadeOutPrecipitation ();
		}	
		
		//Heavy Rain (No Thunder)
		if (weatherForecaster == 12)
		{
			FadeInPrecipitation ();
		}
		
		//Falling Fall Leaves
		if (weatherForecaster == 13)
		{
			FadeOutPrecipitation ();
		}
	}
	
	
	void OnGUI () {
		
		if (timeScrollBar == true)
		{
			//Allows a scrolling GUI bar that controls the time of day by the user
			//startTime = GUI.HorizontalSlider( Rect(20,20,200,30), startTime, 0,1.0f);
			startTime = GUI.HorizontalSlider(new Rect(25, 25, 200, 30), startTime, 0.0F, 0.99F);
			
		}
		
		if (commandPromptActive == true)
		{
			stringToEdit = GUI.TextField (new Rect (10, 430, 40, 20), stringToEdit, 10);
			
			if(GUI.Button(new Rect(10, 450, 60, 40), "Change"))
			{
				weatherCommandPrompt ();
			}
		}
		
		
	}
	
	
	void FixedUpdate ()
	{
		if (weatherCommandPromptUseable == true)
		{
			//weatherCommandPrompt ();
		}
	}
	
	
	void weatherCommandPrompt ()
	{
		//Calculates our weather command prompts
		if (stringToEdit == foggy)
		{
			weatherForecaster = 1;
			print ("Weather Forced: Foggy");
		}
		
		if (stringToEdit == lightRain_lightSnow)
		{
			weatherForecaster = 2;
			print ("Weather Forced: Light Rain/Light Snow (Winter Only)");
		}
		
		if (stringToEdit == rainStorm_snowStorm)
		{
			weatherForecaster = 3;
			print ("Weather Forced: Tunder Storm/Snow Storm (Winter Only)");
		}
		
		if (stringToEdit == partlyCloudy1)
		{
			weatherForecaster = 4;
			print ("Weather Forced: Partly Cloudy 1");
		}
		
		if (stringToEdit == partlyCloudy2)
		{
			weatherForecaster = 5;
			print ("Weather Forced: Partly Cloudy 2");
		}
		
		if (stringToEdit == partlyCloudy3)
		{
			weatherForecaster = 6;
			print ("Weather Forced: Partly Cloudy 3");
		}
		
		if (stringToEdit == clear1)
		{
			weatherForecaster = 7;
			print ("Weather Forced: Clear 1");
		}
		
		if (stringToEdit == clear2)
		{
			weatherForecaster = 8;
			print ("Weather Forced: Clear 2");
		}
		
		if (stringToEdit == cloudy)
		{
			weatherForecaster = 9;
			print ("Weather Forced: Cloudy");
		}
		
		if (stringToEdit == butterfliesSummer)
		{
			weatherForecaster = 10;
			print ("Weather Forced: Butterflies (Summer Only)");
		}
		
		if (stringToEdit == mostlyCloudy)
		{
			weatherForecaster = 11;
			print ("Weather Forced: Mostly Cloudy");
		}
		
		if (stringToEdit == heavyRain)
		{
			weatherForecaster = 12;
			print ("Weather Forced: Heavy Rain (No Thunder)");
		}
		
		if (stringToEdit == fallLeaves)
		{
			weatherForecaster = 13;
			print ("Weather Forced: Falling Fall Leaves (Fall Only)");
		}
		//else
		//print ("Incorrect ID, please refer UniStorm documentation for ID's");
		
	}	
	
	
	void Lightning () {



		if (gradientSphere.activeSelf == false)
		{
			
			timer += Time.deltaTime;
			
			if (timer >= lightningOdds && lightingGenerated == false)
			{
				lightingGenerated = true;
				lightSource.GetComponent<Light>().enabled = true;
				//audio.PlayOneShot(lightningSound[Random.Range(0,lightningSound.Length)]);
				
				lightningNumber = Random.Range(1,5);
				
				if (lightningNumber == 1)
				{
					GetComponent<AudioSource>().PlayOneShot(thunderSound1);
				}
				
				if (lightningNumber == 2)
				{
					GetComponent<AudioSource>().PlayOneShot(thunderSound2);
				}
				
				if (lightningNumber == 3)
				{
					GetComponent<AudioSource>().PlayOneShot(thunderSound3);
				}
				
				if (lightningNumber == 4)
				{
					GetComponent<AudioSource>().PlayOneShot(thunderSound4);
				}
				
				if (lightningNumber == 5)
				{
					GetComponent<AudioSource>().PlayOneShot(thunderSound5);
				}
				
				//lightningSpawn.position = Random.insideUnitSphere * 15;
				Instantiate(lightningBolt1, lightningSpawn.position, lightningSpawn.rotation);
			}
			
			if (lightingGenerated == true)
			{
				if (fadeLightning == false)
				{
					lightSource.GetComponent<Light>().intensity += .22f;
				}
				
				if (lightSource.GetComponent<Light>().intensity >= lightningIntensity && fadeLightning == false)
				{
					lightSource.GetComponent<Light>().intensity = lightningIntensity;
					fadeLightning = true;
				}
			}
			
			if (fadeLightning == true)
			{
				
				onTimer += Time.deltaTime;
				
				if (onTimer >= lightningFlashLength)
				{
					lightSource.GetComponent<Light>().intensity -= .14f;
				}
				
				
				if (lightSource.GetComponent<Light>().intensity <= 0)
				{
					lightSource.GetComponent<Light>().intensity = 0;
					fadeLightning = false;
					lightingGenerated = false;
					timer = 0;
					onTimer = 0;
					lightSource.GetComponent<Light>().enabled = false;
					
					lightningOdds = Random.Range(lightningMinChance, lightningMaxChance);
					lightningIntensity = Random.Range(minIntensity, maxIntensity);
				}
			}
		}
		
	}
	
	
	void LogErrorCheck () 
	{
		//Check Null and Log Errors for weather effects
		if (rain == null)
		{
			//Error Log if object is not found unable to find UniStorm Editor
			Debug.LogError("<color=red>Rain System Null Reference:</color> There is no Rain Particle System, make sure there is one assigned to the Rain Particle System slot of the UniStorm Editor. ");
		}
		
		if (snow == null)
		{
			//Error Log if script is unable to find UniStorm Editor
			Debug.LogError("<color=red>Snow System Null Reference:</color> There is no Snow Particle System, make sure there is one assigned to the Snow Particle System slot of the UniStorm Editor. ");
		}
		
		if (butterflies == null)
		{
			//Error Log if script is unable to find UniStorm Editor
			Debug.LogError("<color=red>Butterflies System Null Reference:</color> There is no Butterflies Particle System, make sure there is one assigned to the Butterflies Particle System slot of the UniStorm Editor. ");
		}
		
		/*		
	if (butterflies == null)
		{
			//Error Log if script is unable to find UniStorm Editor
			Debug.LogError("<color=red>Butterflies System Null Reference:</color> There is no Butterflies Particle System, make sure there is one assigned to the Butterflies Particle System slot of the UniStorm Editor. ");
		}
	*/
		
		if (mistFog == null)
		{
			//Error Log if script is unable to find UniStorm Editor
			Debug.LogError("<color=red>Mist System Null Reference:</color> There is no Mist Particle System, make sure there is one assigned to the Mist Particle System slot of the UniStorm Editor. ");
		}
		
		if (snowMistFog == null)
		{
			//Error Log if script is unable to find UniStorm Editor
			Debug.LogError("<color=red>Snow Dust System Null Reference:</color> There is no Snow Dust Particle System, make sure there is one assigned to the Snow Dust Particle System slot of the UniStorm Editor. ");
		}
		
		if (windyLeaves == null)
		{
			//Error Log if script is unable to find UniStorm Editor
			Debug.LogError("<color=red>Windy Leaves System Null Reference:</color> There is no Windy Leaves Particle System, make sure there is one assigned to the Windy Leaves Particle System slot of the UniStorm Editor. ");
		}
		
		if (windZone == null)
		{
			//Error Log if script is unable to find UniStorm Editor
			Debug.LogError("<color=red>Wind Zone Null Reference:</color> There is no Wind Zone System, make sure there is one assigned to the Wind Zone System slot of the UniStorm Editor. ");
		}
		
		//Check Null and Log Errors for the SkyBox Mateirals that UniStorm uses	
		if (SkyBoxMaterial1 == null || SkyBoxMaterial2 == null)
		{
			//Error Log if script is unable to find UniStorm Editor
			Debug.LogError("<color=red>Sky Box Material Null Reference:</color> There is a missing Sky Box Material, make sure there is one assigned to each of the Sky Box Material slots of the UniStorm Editor. ");
		}
		
		//Check Null and Log Errors for the Moon Phase Material that UniStorm uses	
		if (moonPhase1 == null || moonPhase2 == null || moonPhase3 == null || moonPhase4 == null || moonPhase5 == null || moonPhase6 == null || moonPhase7 == null || moonPhase8 == null)
		{
			//Error Log if script is unable to find UniStorm Editor
			Debug.LogError("<color=red>Moon Phase Material Null Reference:</color> There is a missing Moon Phase Material, make sure there is one assigned to each of the Moon Phase Material slots of the UniStorm Editor. ");
		}
		
		//Check Null and Log Errors for the Cloud GameObjects that UniStorm uses
		if (lightClouds1 == null || lightClouds2 == null || lightClouds3 == null || lightClouds4 == null || lightClouds5 == null || heavyClouds == null || heavyCloudsLayer1 == null || heavyCloudsLayerLight == null || mostlyCloudyClouds == null)
		{
			//Error Log if script is unable to find UniStorm Editor
			Debug.LogError("<color=red>Cloud GameObject Null Reference:</color> There is a missing Cloud GameObject, make sure there is one assigned to each of the Cloud GameObject slots of the UniStorm Editor. ");
		}
		
		//Check Null and Log Errors for the Sky Sphere GameObjects that UniStorm uses	
		if (starSphere == null || gradientSphere == null)
		{
			//Error Log if script is unable to find UniStorm Editor
			Debug.LogError("<color=red>Sky Sphere GameObject Null Reference:</color> There is a missing Sky Sphere GameObject, make sure there is one assigned to both the Star Sphere and Gradient Sphere slots of the UniStorm Editor. ");
		}
		
		//Check Null and Log Errors for the Cloud GameObjects that UniStorm uses
		if (moonObject == null)
		{
			//Error Log if script is unable to find UniStorm Editor
			Debug.LogError("<color=red>Moon GameObject Null Reference:</color> The Moon GameObject is missing, make sure there it is assigned to the Moon GameObject slot of the UniStorm Editor. ");
		}

		/*
		//Check Null and Log Errors for the Cloud GameObjects that UniStorm uses
		if (horizonObject == null)
		{
			//Error Log if script is unable to find UniStorm Editor
			//Debug.LogError("<color=red>Moon GameObject Null Reference:</color> The Horizon GameObject is missing, make sure it is assigned to the Horizon GameObject slot of the UniStorm Editor. ");
		}
		*/
		
		//Check Null and Log Errors for the Sun GameObjects that UniStorm uses
		if (sun == null)
		{
			//Error Log if script is unable to find UniStorm Editor
			Debug.LogError("<color=red>Sun GameObject Null Reference:</color> The Sun GameObject is missing, make sure it is assigned to the Sun GameObject slot of the UniStorm Editor. ");
		}
		
		//Check Null and Log Errors for the Moon GameObjects that UniStorm uses
		if (moon == null)
		{
			//Error Log if script is unable to find UniStorm Editor
			Debug.LogError("<color=red>Moon GameObject Null Reference:</color> The Moon GameObject is missing, make sure it is assigned to the Moon GameObject slot of the UniStorm Editor. ");
		}
		
		//Check Null and Log Errors for the lightning GameObjects that UniStorm uses
		if (lightSource == null)
		{
			//Error Log if script is unable to find UniStorm Editor
			Debug.LogError("<color=red>Lightning Light GameObject Null Reference:</color> The Lightning Light GameObject is missing, make sure it is assigned to the Lightning Light GameObject slot of the UniStorm Editor. ");
		}
		
		//Check Null and Log Errors for the Weather Sound GameObjects that UniStorm uses
		if (rainSound == null || windSound == null || windSnowSound == null)
		{
			//Error Log if script is unable to find UniStorm Editor
			Debug.LogError("<color=red>Weather Sound Effect Null Reference:</color>  There is a missing Weather Sound Effect, make sure there is one assigned to each of the Weather Sound Effect slots of the UniStorm Editor.");
		}
		
		//Check Null and Log Errors for the thunder Sound GameObjects that UniStorm uses
		if (thunderSound1 == null || thunderSound2 == null || thunderSound3 == null || thunderSound4 == null || thunderSound5 == null)
		{
			//Error Log if script is unable to find UniStorm Editor
			Debug.LogError("<color=red>Weather Sound Effect Null Reference:</color>  There is a missing Thunder Sound Effect, make sure there is one assigned to each of the Thunder Sound Effect slots of the UniStorm Editor.");
		}
		
		if (lightningBolt1 == null)
		{
			//Error Log if script is unable to find UniStorm Editor
			Debug.LogError("<color=red>Lightning Bolt Null Reference:</color> The Lightning Bolt is missing, make sure there is one attached to the UniStorm UniStorm Editor.");
		}
		
		if (lightningSpawn == null)
		{
			//Error Log if script is unable to find UniStorm Editor
			Debug.LogError("<color=red>Lightning Bolt Spawn Null Reference:</color> The Lightning Bolt Spawn is missing, make sure there is one attached to the UniStorm UniStorm Editor.");
		}
		
		if (sunShaftScript == null)
		{
			//Error Log if script is unable to find UniStorm Editor
			//Debug.LogError("<color=red>Sun Shafts Null Reference:</color> The Sun Shafts Image Effect is missing, make sure there is one attached to the camera that is using UniStorm (Even if you are using Unity Free).");
		}
		
		if (fogScript == null)
		{
			//Error Log if script is unable to find UniStorm Editor
			//Debug.LogError("<color=red>Global Fog Null Reference:</color> The Global Fog Image Effect is missing, make sure there is one attached to the camera that is using UniStorm (Even if you are using Unity Free).");
		}
	}

	//Added 1.7.5
	void LateUpdate()
	{
		if (cloudType == 1)
		{
			uvOffsetA += (uvAnimationRateA * Time.deltaTime * cloudSpeed * 0.1f);
			uvOffsetB += (uvAnimationRateB * Time.deltaTime * cloudSpeed * 0.1f);
			uvOffsetC += (uvAnimationRateB * Time.deltaTime * cloudSpeed * 0.1f);

			//float scaleX = Time.time * 0.5f * 0.003F + 4 * -1;
			//float scaleY = Time.time * 0.5f * 0.003F + 4* -1;
			//partlyCloudyClouds1.GetComponent<Renderer>().material.SetTextureScale("_MainTex1", new Vector2(scaleX, scaleY));
			//partlyCloudyClouds2.GetComponent<Renderer>().material.SetTextureScale("_MainTex1", new Vector2(scaleX, scaleY));
			
			lightClouds1.GetComponent<Renderer>().materials[ materialIndex ].SetTextureOffset( CloudA, uvOffsetB );
			lightClouds1.GetComponent<Renderer>().materials[ materialIndex ].SetTextureOffset( CloudB, uvOffsetB );
			lightClouds1.GetComponent<Renderer>().materials[ materialIndex ].SetTextureOffset( CloudC, uvOffsetC );
			partlyCloudyClouds1.GetComponent<Renderer>().materials[ materialIndex ].SetTextureOffset( CloudA, uvOffsetB );
			partlyCloudyClouds1.GetComponent<Renderer>().materials[ materialIndex ].SetTextureOffset( CloudB, uvOffsetB );
			partlyCloudyClouds1.GetComponent<Renderer>().materials[ materialIndex ].SetTextureOffset( CloudC, uvOffsetB );
			
			if (cloudDensity == 2)
			{
				lightClouds1a.GetComponent<Renderer>().materials[ materialIndex ].SetTextureOffset( CloudA, uvOffsetB );
				lightClouds1a.GetComponent<Renderer>().materials[ materialIndex ].SetTextureOffset( CloudB, uvOffsetB );
				lightClouds1a.GetComponent<Renderer>().materials[ materialIndex ].SetTextureOffset( CloudC, uvOffsetC );
				partlyCloudyClouds2.GetComponent<Renderer>().materials[ materialIndex ].SetTextureOffset( CloudA, uvOffsetB );
				partlyCloudyClouds2.GetComponent<Renderer>().materials[ materialIndex ].SetTextureOffset( CloudB, uvOffsetB );
				partlyCloudyClouds2.GetComponent<Renderer>().materials[ materialIndex ].SetTextureOffset( CloudC, uvOffsetB );
			}
			
			uvOffsetHeavyA += (uvAnimationRateHeavyA * Time.deltaTime * heavyCloudSpeed * 0.1f);
			uvOffsetHeavyB += (uvAnimationRateHeavyB * Time.deltaTime * heavyCloudSpeed * 0.1f);
			uvOffsetHeavyC += (uvAnimationRateHeavyB * Time.deltaTime * heavyCloudSpeed * 0.1f);
			
			heavyCloudsLayerLight.GetComponent<Renderer>().materials[ materialIndex ].SetTextureOffset( CloudA, uvOffsetHeavyA );
			heavyCloudsLayerLight.GetComponent<Renderer>().materials[ materialIndex ].SetTextureOffset( CloudB, uvOffsetHeavyB );
			heavyCloudsLayerLight.GetComponent<Renderer>().materials[ materialIndex ].SetTextureOffset( CloudC, uvOffsetHeavyC );
		}
		
	}
	
	void DynamicTimeOfDaySounds () 
	{
		
		TODSoundsTimer += Time.deltaTime;
		
		//Updated 1.8.1
		//Dynamic sounds will now properly play at night
		if (TODSoundsTimer >= timeToWaitCurrent && Hour > 4 && Hour < 8 && playedSound == false && useMorningSounds)
		{
			GetComponent<AudioSource>().PlayOneShot(ambientSoundsMorning[Random.Range(0,ambientSoundsMorning.Count)]);
			playedSound = true;
			//Debug.Log("Morning Sound Played");
		}
		
		if (TODSoundsTimer > timeToWaitCurrent && Hour > 8 && Hour < 16 && playedSound == false && useDaySounds)
		{
			GetComponent<AudioSource>().PlayOneShot(ambientSoundsDay[Random.Range(0,ambientSoundsDay.Count)]);
			playedSound = true;
			//Debug.Log("Day Sound Played");
		}
		
		if (TODSoundsTimer > timeToWaitCurrent && Hour > 16 && Hour < 20 && playedSound == false && useEveningSounds)
		{
			GetComponent<AudioSource>().PlayOneShot(ambientSoundsEvening[Random.Range(0,ambientSoundsEvening.Count)]);
			playedSound = true;
			//Debug.Log("Evening Sound Played");
		}
		
		if (TODSoundsTimer > timeToWaitCurrent && Hour > 20 && Hour < 25 && playedSound == false && useNightSounds)
		{	
			GetComponent<AudioSource>().PlayOneShot(ambientSoundsNight[Random.Range(0,ambientSoundsNight.Count)]);
			playedSound = true;
			//Debug.Log("Night Sound Played");
		}
		
		if (TODSoundsTimer > timeToWaitCurrent && Hour > 0 && Hour < 4 && playedSound == false && useNightSounds)
		{	
			GetComponent<AudioSource>().PlayOneShot(ambientSoundsNight[Random.Range(0,ambientSoundsNight.Count)]);
			playedSound = true;
			//Debug.Log("Night Sound Played");
		}
		
		
		
		if (TODSoundsTimer >= timeToWaitCurrent+2)
		{
			timeToWaitCurrent = Random.Range(timeToWaitMin,timeToWaitMax);
			TODSoundsTimer = 0;
			playedSound = false;
		}
		
	}

	//Puts all fading out weather types into one function then picks by weather type to control individual weather factors
	void FadeOutPrecipitation ()
	{
			fade -= Time.deltaTime * .04f; //Was 0.04f
			fade2 -= Time.deltaTime * .06f; //Was 0.06f
			fadeStormClouds -= Time.deltaTime * .04f;
			windControl -= Time.deltaTime;
			time -= Time.deltaTime * .14f;
			sunShaftFade += Time.deltaTime * .14f;
			minRainIntensity -= 1;
			minFogIntensity -= .04f;
			minHeavyRainMistIntensity -= .08f;
			minSnowFogIntensity -= .024f;	
			minSnowIntensity -= .9f;
			stormClouds -= Time.deltaTime * .011f;
			//light.enabled = false;	
			sunIntensity += .0015f;
			sun.enabled = true;
			dynamicSnowFade -= Time.deltaTime * .0095f; 
			overrideFog = false;
			
			heavyClouds.GetComponent<Renderer>().material.color = new Color(.35f,.35f,.35f,fade);
			heavyCloudsLayer1.GetComponent<Renderer>().material.color = new Color(0,0,0,fade2);	
			heavyCloudsLayerLight.GetComponent<Renderer>().material.color = new Color(.5f,.5f,.5f,fade2);

			//Added 1.8.4
			moonLight.intensity += 0.001f;
			
			if (moonLight.intensity >= moonLightIntensity)
			{
				moonLight.intensity = moonLightIntensity;
			}
			
			//Fade in and out leaves for Fall weather type
			if (weatherForecaster == 13 && monthCounter >= 8 && monthCounter <= 10)
			{
				windyLeavesFade += .04f;

				if (windyLeavesFade >= 6)
				{
					windyLeavesFade = 6;
				}
			}
			else
			{
				windyLeavesFade -= .04f;
			
				if (windyLeavesFade <= 0)
				{
					windyLeavesFade = 0;
				}
			}

			//Fade in and out butterflies (lightning bugs) for Fall weather type
			if (weatherForecaster == 10 && monthCounter >= 5 && monthCounter <= 7)
			{
				butterfliesFade += .04f;

				if (butterfliesFade >= 8)
				{
					butterfliesFade = 8;
				}
			}
			else
			{
				butterfliesFade -= .04f;

				if (butterfliesFade <= 0)
				{
					butterfliesFade = 0;
				}
			}
			
		if (terrainDetection)
		{
			//Added 1.8.4
			Terrain.activeTerrain.terrainData.wavingGrassSpeed -= 0.00025f;
			Terrain.activeTerrain.terrainData.wavingGrassAmount -= 0.00025f;
			Terrain.activeTerrain.terrainData.wavingGrassStrength -= 0.00025f;
			
			if (Terrain.activeTerrain.terrainData.wavingGrassSpeed <= normalGrassWavingSpeed)
			{
				Terrain.activeTerrain.terrainData.wavingGrassSpeed = normalGrassWavingSpeed;
			}
			
			if (Terrain.activeTerrain.terrainData.wavingGrassAmount <= normalGrassWavingStrength)
			{
				Terrain.activeTerrain.terrainData.wavingGrassAmount = normalGrassWavingStrength;
			}
			
			if (Terrain.activeTerrain.terrainData.wavingGrassStrength <= normalGrassWavingAmount)
			{
				Terrain.activeTerrain.terrainData.wavingGrassStrength = normalGrassWavingAmount;
			}
		}
		
		//Added 1.7.5
		lightFlareObject.GetComponent<Light>().intensity += 0.0022f;
			
			if (lightFlareObject.GetComponent<Light>().intensity >= 1f)
			{
				lightFlareObject.GetComponent<Light>().intensity = 1f;
			}
			//
			
			if (RenderSettings.fogMode == FogMode.Linear)
			{
				RenderSettings.fogStartDistance += 0.75f; //Was 0.75f
				RenderSettings.fogEndDistance += 0.75f;
				
				if (RenderSettings.fogStartDistance >= fogStartDistance)
				{
					RenderSettings.fogStartDistance = fogStartDistance;
				}
				
				if (RenderSettings.fogEndDistance >= fogEndDistance)
				{
					RenderSettings.fogEndDistance = fogEndDistance;
				}
			}
			
			if (fade2 <= 0)
			{
				fade2 = 0;
			}
			
			//Added 1.7.5
			if (cloudType == 2 && weatherForecaster == 4)
			{		
				lightClouds2.GetComponent<Renderer>().enabled = true;
				
				lightClouds3.GetComponent<Renderer>().enabled = false;
				
				lightClouds4.GetComponent<Renderer>().enabled = false;
				
				lightClouds5.GetComponent<Renderer>().enabled = false;
				
				highClouds1.GetComponent<Renderer>().enabled = true;
				
				highClouds2.GetComponent<Renderer>().enabled = false;
				
				mostlyCloudyClouds.GetComponent<Renderer>().enabled = false;
			}

			if (cloudType == 2 && weatherForecaster == 5)
			{		
				lightClouds2.GetComponent<Renderer>().enabled = false;
				
				lightClouds3.GetComponent<Renderer>().enabled = true;
				
				lightClouds4.GetComponent<Renderer>().enabled = true;
				
				lightClouds5.GetComponent<Renderer>().enabled = false; 
				
				highClouds1.GetComponent<Renderer>().enabled = false;
				
				highClouds2.GetComponent<Renderer>().enabled = true;
				
				mostlyCloudyClouds.GetComponent<Renderer>().enabled = false;
			}

			if (cloudType == 2 && weatherForecaster == 5)
			{
				lightClouds2.GetComponent<Renderer>().enabled = false;
				
				lightClouds3.GetComponent<Renderer>().enabled = false;
				
				lightClouds4.GetComponent<Renderer>().enabled = false;
				
				lightClouds5.GetComponent<Renderer>().enabled = true;
				
				highClouds1.GetComponent<Renderer>().enabled = false;
				
				highClouds2.GetComponent<Renderer>().enabled = false;
				
				mostlyCloudyClouds.GetComponent<Renderer>().enabled = false;
			}
			
		if (weatherForecaster == 4 || weatherForecaster == 5 || weatherForecaster == 6)
		{
			partlyCloudyFader += 0.0025f;
			
			//Added 1.8.1 Final
			if (cloudType == 1)
			{
				partlyCloudyClouds1.GetComponent<Renderer>().material.color = new Color(lightClouds1.GetComponent<Renderer>().material.color.r, lightClouds1.GetComponent<Renderer>().material.color.g, lightClouds1.GetComponent<Renderer>().material.color.b, partlyCloudyFader);
				partlyCloudyClouds2.GetComponent<Renderer>().material.color = new Color(lightClouds1.GetComponent<Renderer>().material.color.r, lightClouds1.GetComponent<Renderer>().material.color.g, lightClouds1.GetComponent<Renderer>().material.color.b, partlyCloudyFader);
				
				if (partlyCloudyFader >= 1)
				{
					partlyCloudyFader = 1;
				}
			}
		}

		if (cloudType == 2 && weatherForecaster == 7)
		{
			//lightClouds1.renderer.enabled = false;
			
			lightClouds2.GetComponent<Renderer>().enabled = false;
			
			lightClouds3.GetComponent<Renderer>().enabled = false;
			
			lightClouds5.GetComponent<Renderer>().enabled = false;
			
			lightClouds4.GetComponent<Renderer>().enabled = false;
			
			highClouds1.GetComponent<Renderer>().enabled = true;
			
			highClouds2.GetComponent<Renderer>().enabled = false;
			
			mostlyCloudyClouds.GetComponent<Renderer>().enabled = false;
		}

			if(weatherForecaster == 7 || weatherForecaster == 8)
			{
				partlyCloudyFader -= 0.005f;
				
				//Added 1.8.1 Final
				if (cloudType == 1)
				{
					partlyCloudyClouds1.GetComponent<Renderer>().material.color = new Color(lightClouds1.GetComponent<Renderer>().material.color.r, lightClouds1.GetComponent<Renderer>().material.color.g, lightClouds1.GetComponent<Renderer>().material.color.b, partlyCloudyFader);
					partlyCloudyClouds2.GetComponent<Renderer>().material.color = new Color(lightClouds1.GetComponent<Renderer>().material.color.r, lightClouds1.GetComponent<Renderer>().material.color.g, lightClouds1.GetComponent<Renderer>().material.color.b, partlyCloudyFader);
					
					if (partlyCloudyFader <= 0)
					{
						partlyCloudyFader = 0;
					}
				}
			}


			//Added 1.8.4
			butterflies.emissionRate = butterfliesFade;
			
			//Calculates fading in our particles
			snow.emissionRate = minSnowIntensity;
			
			snowMistFog.emissionRate = minSnowFogIntensity;
			
			//Added 1.8.1 Shuriken Particles
			rain.emissionRate = minRainIntensity;
			rainMist.emissionRate = minHeavyRainMistIntensity;
			
			mistFog.GetComponent<ParticleEmitter>().minEmission = minFogIntensity;
			mistFog.GetComponent<ParticleEmitter>().maxEmission = minFogIntensity;	
			
			windyLeaves.emissionRate = windyLeavesFade;
			
			
			//Fades our fog
			fogScript = cameraThing.GetComponent<Camera>().GetComponent<GlobalFog>();
			fogScript.heightDensity -= .0005f * Time.deltaTime;
			fogScript.startDistance += 5 * Time.deltaTime;
			
			
			if (dynamicSnowFade <= .25)
			{
				dynamicSnowFade = .25f;
			}
			
			if (fogScript.heightDensity <= 0)
			{
				fogScript.heightDensity = 0;
			}
			
			if (fogScript.startDistance >= 300)
			{
				fogScript.startDistance = 300;
			}
			
			//Keep snow from going below 0
			if (minSnowIntensity <= 0)
			{
				minSnowIntensity = 0;
			}
			
			//Keep snow fog from going below 0
			if (minSnowFogIntensity <= 0)
			{
				minSnowFogIntensity = 0;
			}
			
			rainSound.GetComponent<AudioSource>().volume -= Time.deltaTime * .07f;
			windSound.GetComponent<AudioSource>().volume -= Time.deltaTime * .04f;
			windSnowSound.GetComponent<AudioSource>().volume -= Time.deltaTime * .04f;
			
			if (stormClouds <= 0)
			{
				stormClouds = 0;
			}
			
			//Calculates our wind making it lessen		
			if (minRainIntensity <= 0)
			{
				minRainIntensity = 0;
				//Keeps our wind at 0 if there hasn't been a storm
				windZone.transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
				
				//1.8.1
				//Warning Obsolete Message Update
				windZone.gameObject.SetActive(false);
				
				if (windZone.transform.eulerAngles.y <= 1)
				{
					windZone.transform.eulerAngles = new Vector3(0, 0, 0);
					
					//1.8.1
					//Warning Obsolete Message Update
					windZone.gameObject.SetActive(false);
				}
				
			}
			
			if (minRainIntensity >= 1)
			{
				//Makes our wind weaker for when the storm ends
				windZone.transform.Rotate(-Vector3.up * Time.deltaTime * 12);
				
				
				if (windZone.transform.eulerAngles.y <= 1)
				{
					windZone.transform.eulerAngles = new Vector3(0, 0, 0);
				}
				
			}
			
			//Keeps our fade numbers from going below 0
			if (minFogIntensity <= 0)
			{
				minFogIntensity = 0;
			}
			
			if (minHeavyRainMistIntensity <= 0)
			{
				minHeavyRainMistIntensity = 0;
			}
			
			if (fade <= 0)
			{
				fade = 0;
				
			}
			
			if (fadeStormClouds <= 0)
			{
				fadeStormClouds = 0;
			}
			
			if (time <= 0)
			{
				time = 0;
			}
			
			sunShaftScript = cameraThing.GetComponent<Camera>().GetComponent<SunShafts>();
			sunShaftScript.sunShaftIntensity += .005f;
			
			if (sunShaftScript.sunShaftIntensity >= 2)
			{
				sunShaftScript = cameraThing.GetComponent<Camera>().GetComponent<SunShafts>();
				sunShaftScript.sunShaftIntensity = 2;
				sun.enabled = true;
				RenderSettings.fogDensity += .00012f * Time.deltaTime;
				
				//ControlUnityFog
				//If you wish to have denser fog you can increase the numbers below, you will have to do this for each day without percipitation
				if (RenderSettings.fogDensity >= fogDensity)
				{
					RenderSettings.fogDensity = fogDensity;
				}
			}
			
			//If the game speed is fast fade clouds instantly	
			if (dayLength >= 0 && dayLength <=15) 
			{
				fade = 0;
			}
	}

	//Puts all fading in weather types into one function then picks by weather type to control individual weather factors
	void FadeInPrecipitation()
	{
			fade += Time.deltaTime * .015f;
			fade2 += Time.deltaTime * .015f;
			butterfliesFade -= .04f;
			windyLeavesFade -= .04f;
			fadeHorizonController += Time.deltaTime * .04f;
			fadeStormClouds += Time.deltaTime * .04f;
			time += Time.deltaTime * .0014f;
			windControlUp += 1;
			sunShaftFade -= Time.deltaTime * .14f;
			stormClouds += Time.deltaTime * .011f;
			sunIntensity -= .005f;
			dynamicSnowFade -= Time.deltaTime * .0095f; 
			
			//Light Rain
			if (temperature >= 33 && temperatureType == 1 && weatherForecaster == 2 || temperatureType == 2 && temperature >= 1 && weatherForecaster == 2)
			{

				minRainIntensity += .2f;
				minFogIntensity -= .008f;
				
				if (minRainIntensity >= maxLightRainIntensity)
				{
					minRainIntensity = maxLightRainIntensity;
				}
				
				if (minFogIntensity <= 0)
				{
					minFogIntensity = 0;
				}
				
				if (minHeavyRainMistIntensity <= 0)
				{
					minHeavyRainMistIntensity = 0;
				}

				rainSound.GetComponent<AudioSource>().volume += Time.deltaTime * .01f;
				windSound.GetComponent<AudioSource>().volume += Time.deltaTime * .01f;
				
				//This keeps the sound levels low because this is just a little rain	
				if (windSound.GetComponent<AudioSource>().volume >= .0)
				{
					windSound.GetComponent<AudioSource>().volume = .0f;
				}
				
				if (rainSound.GetComponent<AudioSource>().volume >= .3)
				{
					rainSound.GetComponent<AudioSource>().volume = .3f;
				}

				//Added 1.8.4
				//If generated precipitation is eqaul to last roll, regenerate intensity (If randomized rain is true)
				//Light Rain
				if (lastWeatherType != weatherForecaster && randomizedPrecipitation)
				{
					randomizedRainIntensity = Random.Range(100,maxLightRainIntensity);
					currentGeneratedIntensity = randomizedRainIntensity;
					lastWeatherType = weatherForecaster;
				}
				
				//Added 1.7.5
				//Not using 
				if (!randomizedPrecipitation)
				{
					if (minRainIntensity >= maxLightRainIntensity)
					{
						minRainIntensity = maxLightRainIntensity;
					}
				}
				
				//Using
				if (randomizedPrecipitation)
				{
					if (minRainIntensity >= currentGeneratedIntensity)
					{
						minRainIntensity = currentGeneratedIntensity;
					}
				}
			}

			//Thunder Storm or Heavy Rain (No Thunder)
			if (temperature >= 33 && temperatureType == 1  && weatherForecaster == 3 || temperatureType == 2 && temperature >= 1 && weatherForecaster == 3 || temperature >= 33 && temperatureType == 1  && weatherForecaster == 12 || temperatureType == 2 && temperature >= 1 && weatherForecaster == 12)
			{
				minRainIntensity += .2f;
				minFogIntensity += .008f;
				minHeavyRainMistIntensity += .008f;

				minSnowFogIntensity -= .024f;	
				minSnowIntensity -= .9f;

				rainSound.GetComponent<AudioSource>().volume += Time.deltaTime * .01f;
				windSound.GetComponent<AudioSource>().volume += Time.deltaTime * .01f;

				if (weatherForecaster == 3 && minRainIntensity >= 150)
				{
					Lightning ();
				}

				//Added 1.8.4
				//Not using RP
				if (!randomizedPrecipitation)
				{
					//Gradually fades our rain effects in
					if (minRainIntensity >= maxStormRainIntensity)
					{
						minRainIntensity = maxStormRainIntensity;
					}
				}
				
				//Using RP
				if (randomizedPrecipitation)
				{
					if (minRainIntensity >= currentGeneratedIntensity)
					{
						minRainIntensity = currentGeneratedIntensity;
					}
				}

				//Added 1.8.4
				//If generated precipitation is eqaul to last roll, regenerate intensity (If randomized rain is true)
				//Heavy Rain
				if (lastWeatherType != weatherForecaster && randomizedPrecipitation)
				{
					randomizedRainIntensity = Random.Range(400,maxStormRainIntensity);
					currentGeneratedIntensity = randomizedRainIntensity;
					lastWeatherType = weatherForecaster;
				}
				
				//Gradually fades our rain effects in
				if (minRainIntensity >= maxStormRainIntensity)
				{
					minRainIntensity = maxStormRainIntensity;
				}
				
				if (minFogIntensity >= maxStormMistCloudsIntensity)
				{
					minFogIntensity = maxStormMistCloudsIntensity;
				}
				
				if (minHeavyRainMistIntensity >= maxHeavyRainMistIntensity)
				{
					minHeavyRainMistIntensity = maxHeavyRainMistIntensity;
				}

				//Keep snow from going below 0
				if (minSnowIntensity <= 0)
				{
					minSnowIntensity = 0;
				}
				
				//Keep snow fog from going below 0
				if (minSnowFogIntensity <= 0)
				{
					minSnowFogIntensity = 0;
				}
			}

		//Snow Storm
		if (temperature <= 32 && temperatureType == 1  && weatherForecaster == 3 || temperatureType == 2 && temperature <= 0  && weatherForecaster == 3)
		{
			minSnowIntensity += .2f;
			minSnowFogIntensity += .008f;

			minRainIntensity -= 1;
			minFogIntensity -= .04f;
			minHeavyRainMistIntensity -= .08f;

			windSnowSound.GetComponent<AudioSource>().volume += Time.deltaTime * .01f;
			windSound.GetComponent<AudioSource>().volume -= Time.deltaTime * .04f;

			//Added 1.7.5
			//If generated precipitation is eqaul to last roll, regenerate intensity (If randomized rain is true)
			//Light Snow
			if (lastWeatherType != weatherForecaster && randomizedPrecipitation)
			{
				randomizedRainIntensity = Random.Range(100,maxSnowStormIntensity);
				currentGeneratedIntensity = randomizedRainIntensity;
				lastWeatherType = weatherForecaster;
			}
			
			//Added 1.7.5
			//Not using RP
			if (!randomizedPrecipitation)
			{
				//Keeps our snow level maxed at users input
				if (minSnowIntensity >= maxSnowStormIntensity)
				{
					minSnowIntensity = maxSnowStormIntensity;
				}
			}
			
			//Using RP
			if (randomizedPrecipitation)
			{
				if (minSnowIntensity >= currentGeneratedIntensity)
				{
					minSnowIntensity = currentGeneratedIntensity;
				}
			}
			
			//Keeps our snow level maxed at users input
			if (minSnowIntensity >= maxSnowStormIntensity)
			{
				minSnowIntensity = maxSnowStormIntensity;
			}
			
			//Keeps our snow fog level maxed at users input
			if (minSnowFogIntensity >= maxHeavySnowDustIntensity)
			{
				minSnowFogIntensity = maxHeavySnowDustIntensity;
			}
			
			//Keeps our fade numbers from going below 0
			if (minRainIntensity <= 0)
			{
				minRainIntensity = 0;
			}

			if (minFogIntensity <= 0)
			{
				minFogIntensity = 0;
			}
			
			if (minHeavyRainMistIntensity <= 0)
			{
				minHeavyRainMistIntensity = 0;
			}
		}

		//Light Snow
		if (temperature <= 32 && temperatureType == 1  && weatherForecaster == 2 || temperatureType == 2 && temperature <= 0  && weatherForecaster == 2)
		{
			minSnowIntensity += .2f;
			minSnowFogIntensity += .008f;	

			minRainIntensity -= 1;
			minFogIntensity -= .04f;
			minHeavyRainMistIntensity -= .08f;

			windSnowSound.GetComponent<AudioSource>().volume += Time.deltaTime * .01f;
			
			//Added 1.7.5
			//If generated precipitation is eqaul to last roll, regenerate intensity (If randomized rain is true)
			//Light Snow
			if (lastWeatherType != weatherForecaster && randomizedPrecipitation)
			{
				randomizedRainIntensity = Random.Range(100,maxLightSnowIntensity);
				currentGeneratedIntensity = randomizedRainIntensity;
				lastWeatherType = weatherForecaster;
			}
			//
			
			//Added 1.7.5
			//Not using RP
			if (!randomizedPrecipitation)
			{
				//Keeps our snow level maxed at users input
				if (minSnowIntensity >= maxLightSnowIntensity)
				{
					minSnowIntensity = maxLightSnowIntensity;
				}
			}
			
			//Using RP
			if (randomizedPrecipitation)
			{
				if (minSnowIntensity >= currentGeneratedIntensity)
				{
					minSnowIntensity = currentGeneratedIntensity;
				}
			}
			//
			
			//Keeps our snow level maxed at users input
			if (minSnowIntensity >= maxLightSnowIntensity)
			{
				minSnowIntensity = maxLightSnowIntensity;
			}
			
			//Keeps our snow fog level maxed at users input
			if (minSnowFogIntensity >= maxLightSnowDustIntensity)
			{
				minSnowFogIntensity = maxLightSnowDustIntensity;
			}

			//Keeps our fade numbers from going below 0
			if (minRainIntensity <= 0)
			{
				minRainIntensity = 0;
			}
			
			if (minFogIntensity <= 0)
			{
				minFogIntensity = 0;
			}
			
			if (minHeavyRainMistIntensity <= 0)
			{
				minHeavyRainMistIntensity = 0;
			}

			if (windSnowSound.GetComponent<AudioSource>().volume >= .3)
			{
				windSnowSound.GetComponent<AudioSource>().volume = .3f;
			}
		}
			
		if (terrainDetection)
		{
			//Fades in our Dynamic Wind
			if (weatherForecaster == 2 || weatherForecaster == 3 || weatherForecaster == 12)
			{
				//Added 1.8.4
				Terrain.activeTerrain.terrainData.wavingGrassSpeed += 0.0002f;
				Terrain.activeTerrain.terrainData.wavingGrassAmount += 0.0002f;
				Terrain.activeTerrain.terrainData.wavingGrassStrength += 0.0002f;
				
				if (Terrain.activeTerrain.terrainData.wavingGrassSpeed >= stormGrassWavingSpeed)
				{
					Terrain.activeTerrain.terrainData.wavingGrassSpeed = stormGrassWavingSpeed;
				}
				
				if (Terrain.activeTerrain.terrainData.wavingGrassAmount >= stormGrassWavingStrength)
				{
					Terrain.activeTerrain.terrainData.wavingGrassAmount = stormGrassWavingStrength;
				}
				
				if (Terrain.activeTerrain.terrainData.wavingGrassStrength >= stormGrassWavingAmount)
				{
					Terrain.activeTerrain.terrainData.wavingGrassStrength = stormGrassWavingAmount;
				}
			}

			//Fades in our Dynamic Wind
			if (weatherForecaster == 1)
			{
				//Added 1.8.4 test
				Terrain.activeTerrain.terrainData.wavingGrassSpeed -= 0.00025f;
				Terrain.activeTerrain.terrainData.wavingGrassAmount -= 0.00025f;
				Terrain.activeTerrain.terrainData.wavingGrassStrength -= 0.00025f;
				
				if (Terrain.activeTerrain.terrainData.wavingGrassSpeed <= normalGrassWavingSpeed)
				{
					Terrain.activeTerrain.terrainData.wavingGrassSpeed = normalGrassWavingSpeed;
				}
				
				if (Terrain.activeTerrain.terrainData.wavingGrassAmount <= normalGrassWavingStrength)
				{
					Terrain.activeTerrain.terrainData.wavingGrassAmount = normalGrassWavingStrength;
				}
				
				if (Terrain.activeTerrain.terrainData.wavingGrassStrength <= normalGrassWavingAmount)
				{
					Terrain.activeTerrain.terrainData.wavingGrassStrength = normalGrassWavingAmount;
				}
			}
		}
			
			//Added1.8.4
			if (sunIntensity <= HeavyRainSunIntensity)
			{
				sunIntensity = HeavyRainSunIntensity;
			}
			
			moonLight.intensity -= 0.001f;
			
			if (moonLight.intensity <= stormyMoonLightIntensity)
			{
				moonLight.intensity = stormyMoonLightIntensity;
			}
			
			//Added 1.7.5
			lightFlareObject.GetComponent<Light>().intensity -= 0.0022f;
			
			if (lightFlareObject.GetComponent<Light>().intensity <= 0)
			{
				lightFlareObject.GetComponent<Light>().intensity = 0;
			}
			
			if (RenderSettings.fogMode == FogMode.Linear)
			{
				RenderSettings.fogStartDistance -= 0.75f;
				RenderSettings.fogEndDistance -= 0.75f;
				
				if (RenderSettings.fogStartDistance <= stormyFogDistanceStart)
				{
					RenderSettings.fogStartDistance = stormyFogDistanceStart;
				}
				
				if (RenderSettings.fogEndDistance <= stormyFogDistance)
				{
					RenderSettings.fogEndDistance = stormyFogDistance;
				}
			}
			
			//Slowly increases the wind to make it stronger for the storm
			if (minRainIntensity >= 1)
			{
				//Makes our wind stronger for the storm
				windZone.transform.Rotate(Vector3.up * Time.deltaTime * 3);
				
				//1.8.1
				//Warning Obsolete Message Update	
				windZone.gameObject.SetActive(true);
			}
			
			if (windZone.transform.eulerAngles.y >= 180)
			{
				windZone.transform.eulerAngles = new Vector3(0, 180, 0);
			}
			
			
			if (dynamicSnowFade <= .25)
			{
				dynamicSnowFade = .25f;
			}

			//Fades in storm clouds
			heavyClouds.GetComponent<Renderer>().material.color = new Color(.35f,.35f,.35f,fade);
			heavyCloudsLayer1.GetComponent<Renderer>().material.color = new Color(0,0,0,fade2);	
			heavyCloudsLayerLight.GetComponent<Renderer>().material.color = new Color(.5f,.5f,.5f,fade2);
			
			if (fade2 >= .75)
			{
				fade2 = .75f;
			}
			
			if (butterfliesFade <= 0)
			{
				butterfliesFade = 0;
			}
			
			//Added 1.8.4
			butterflies.emissionRate = butterfliesFade;
			
			//Calculates fading in our particles
			snow.emissionRate = minSnowIntensity;
			
			snowMistFog.emissionRate = minSnowFogIntensity;
			
			//Added 1.8.1 Shuriken Particles
			rain.emissionRate = minRainIntensity;
			rainMist.emissionRate = minHeavyRainMistIntensity;
			
			mistFog.GetComponent<ParticleEmitter>().minEmission = minFogIntensity;
			mistFog.GetComponent<ParticleEmitter>().maxEmission = minFogIntensity;	
			
			windyLeaves.emissionRate = windyLeavesFade;
			
			//Fades our fog in	
			RenderSettings.fogDensity -= .00012f * Time.deltaTime;
			
			if (RenderSettings.fogDensity <= .0006)
			{
				RenderSettings.fogDensity = .0006f;
				fogScript = cameraThing.GetComponent<Camera>().GetComponent<GlobalFog>();
				fogScript.heightDensity += .0008f * Time.deltaTime;
				fogScript.startDistance -= 5 * Time.deltaTime;
				
				if (fogScript.startDistance <= 30)
				{
					fogScript.startDistance = 30;
					fogScript.heightDensity -= .0005f * Time.deltaTime;
				}
				
				if (overrideFog == false)
				{
					
					fogScript.heightDensity += .0005f * Time.deltaTime;
					
					if (fogScript.heightDensity >= .0038)
					{   			    
						fogScript.heightDensity = .0038f;
					}
				}
			}
			
			if (overrideFog == true)
			{
				fogScript.heightDensity -= .001f * Time.deltaTime;
				
				if (fogScript.heightDensity <= .0038)
				{   			    
					fogScript.heightDensity = .0038f;
				}
			}
			
			if (stormClouds >= .55)
			{
				stormClouds = .55f;
			}
			
			if (fade >= .40)
			{
				
			}
			
			if (fade2 >= .75)
			{
				fade2 = .75f;
			}
			
			if (fade >= 1)
			{
				fade = 1;
			}
			
			if (fadeStormClouds >= 1)
			{
				fadeStormClouds = 1;
			}
			
			sunShaftScript = cameraThing.GetComponent<Camera>().GetComponent<SunShafts>();
			sunShaftScript.sunShaftIntensity -= .0015f;
			
			if (sunShaftScript.sunShaftIntensity <= .1)
			{
				sunShaftScript = cameraThing.GetComponent<Camera>().GetComponent<SunShafts>();
				sunShaftScript.sunShaftIntensity = 0;
			}
			
			
			if (time >= 1)
			{
				time = 1;
			}
			
			//If the game speed is fast forward fade clouds instantly	
			if (dayLength >= 0 && dayLength <=15) 
			{
				fade = 1;
			}
	}
}







