using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;

public class CharacterHandler : MonoBehaviour
{
    // DECLERATIONS
    public TextMeshProUGUI EnduranceValue;
    public TextMeshProUGUI StrengthValue;
    public TextMeshProUGUI AgilityValue;
    public TextMeshProUGUI PerceptionValue;
    public TextMeshProUGUI StrainValue;
    public TextMeshProUGUI RemainingSkillPointsValue;
    public TextMeshProUGUI PlayerNameDisplay;

    public TextMeshProUGUI AdventureEnduranceScore;
    public TextMeshProUGUI AdventureStrengthScore;
    public TextMeshProUGUI AdventureAgilityScore;
    public TextMeshProUGUI AdventurePerceptionScore;

    public TextMeshProUGUI ChallengeResults;

    public Button AddEndurance;
    public Button AddStrength;
    public Button AddAgility;
    public Button AddPerception;
    public Button ContinueButton;

    public Button CarryTheArtifactOfAmlawtWithYou;

    public Button CorridorsOfDoomAChallengeButton;
    public Button CorridorsOfDoomBChallengeButton;

    public Button GoldenRoomLevelUpButton;

    public Button DarkPathChallengeButton;

    public Button TempleRiverAChallengeButton;
    public Button TempleRiverBChallengeButton;

    public Button TempleDoorsAChallengeButton;
    public Button TempleDoorsBChallengeButton;

    public Button FinaleContinue;
    public Button FinaleChallenge;
    public GameObject Finale;
    public GameObject FinaleWin;
    public GameObject FinaleLoss;

    public InputField PlayerNameInput;

    public Character MainCharacter;
    public StrainBar StrainBar;
   

// FUNCTIONS
    public void DisplayValue(TextMeshProUGUI text,int skill)
    {
        text.text = skill.ToString();
    }
    public void AddToSkill(Skill skill, int remainingSkills)
    {
        skill.value++;
        remainingSkills =- 1;

    }
    public void CheckForRemainignSkill(int remainingSkills,Button A,Button B,Button C,Button D)
    {
        if(remainingSkills == 0)
        {
            A.gameObject.SetActive(false);
            B.gameObject.SetActive(false);
            C.gameObject.SetActive(false);
            D.gameObject.SetActive(false);
        }
        else
        {
            A.gameObject.SetActive(true);
            B.gameObject.SetActive(true);
            C.gameObject.SetActive(true);
            D.gameObject.SetActive(true);
        }
    }
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    // CLASSES
    public class Character
    {
       
        public Skill endurance = new Skill("Endurance");
        public Skill strength = new Skill("Strength");
        public Skill agility = new Skill("Agility");
        public Skill perception = new Skill("Perception");

        public Attribute strain = new Attribute("Strain");

        public string playerName;
        public bool artifactInPosession = false;
        public int remainingSkills;

        
        public void AddOneToEndurance()
        {
            endurance.value++;
            remainingSkills--;
        }
        public void AddOneToStrength()
        {
            strength.value++;
            remainingSkills--;
        }
        public void AddOneToAgility()
        {
            agility.value++;
            remainingSkills--;
        }
        public void AddOneToPerception()
        {
            perception.value++;
            remainingSkills--;
        }
        public void LevelUp()
        {
           remainingSkills += 5;
        }
        public void Challenge(int ChallengeRating, Skill skill, TextMeshProUGUI ChallengeResults)
        {
            if(ChallengeRating <= skill.value)
            {
                ChallengeResults.text = "Using your " + skill.name + " of " + skill.value.ToString() + " - You overcome the challenge with ease.";
            }
            else
            {
                int damage = ChallengeRating - skill.value;
                strain.value = strain.value - damage;

                ChallengeResults.text = "Using your " + skill.name + " of " + skill.value.ToString() + " to aid in the challenge, your Strain is reduced by " + damage.ToString() + ".";
            }
        
        }


        
    }
    public class Skill
    {
        public int value;
        public string name;

        public Skill()
        {
            name = "";
            value = 0;
        }

        public Skill(string n)
        {
            name = n;
            value = 0;
        }
    }
    public class Attribute
    {
        public int value;
        public string name;

        public Attribute()
        {
            value = 10;
            name = "";
        }

        public Attribute(string n)
        {
            name = n;
            value = 10;
        }
    }

    // GAMEPLAY
    void Start()
        {
        MainCharacter = new Character();
        MainCharacter.LevelUp();
        
        StrainBar.SetMaxStrain(MainCharacter.strain.value);

        DisplayValue(EnduranceValue, MainCharacter.endurance.value);
        DisplayValue(StrengthValue, MainCharacter.strength.value);
        DisplayValue(AgilityValue, MainCharacter.agility.value);
        DisplayValue(PerceptionValue, MainCharacter.perception.value); 
        DisplayValue(RemainingSkillPointsValue, MainCharacter.remainingSkills);

        PlayerNameDisplay.text = MainCharacter.playerName;

        AddEndurance.onClick.AddListener(MainCharacter.AddOneToEndurance);
        AddStrength.onClick.AddListener(MainCharacter.AddOneToStrength);
        AddAgility.onClick.AddListener(MainCharacter.AddOneToAgility);
        AddPerception.onClick.AddListener(MainCharacter.AddOneToPerception);

        ContinueButton.onClick.AddListener(() =>
            {
                MainCharacter.playerName = PlayerNameInput.text.ToString();
                PlayerNameDisplay.text = MainCharacter.playerName;
            });

        CarryTheArtifactOfAmlawtWithYou.onClick.AddListener(() =>
            {
                MainCharacter.agility.value = MainCharacter.agility.value - 1;
                MainCharacter.artifactInPosession = true;
            });
        CorridorsOfDoomAChallengeButton.onClick.AddListener(() => MainCharacter.Challenge(4, MainCharacter.strength, ChallengeResults));
        CorridorsOfDoomBChallengeButton.onClick.AddListener(() => MainCharacter.Challenge(4, MainCharacter.agility, ChallengeResults));
        GoldenRoomLevelUpButton.onClick.AddListener(() => MainCharacter.LevelUp());
        DarkPathChallengeButton.onClick.AddListener(() => MainCharacter.Challenge(2, MainCharacter.perception, ChallengeResults));
        TempleRiverAChallengeButton.onClick.AddListener(() => MainCharacter.Challenge(4, MainCharacter.strength, ChallengeResults));
        TempleRiverBChallengeButton.onClick.AddListener(() => MainCharacter.Challenge(2, MainCharacter.endurance, ChallengeResults));
        TempleDoorsAChallengeButton.onClick.AddListener(() => MainCharacter.Challenge(4, MainCharacter.agility, ChallengeResults));
        TempleDoorsBChallengeButton.onClick.AddListener(() => MainCharacter.Challenge(4, MainCharacter.perception, ChallengeResults));
        FinaleContinue.onClick.AddListener(() =>
        {
            Finale.SetActive(false);

            if (MainCharacter.artifactInPosession == false)
            {
                FinaleLoss.SetActive(true);
            }
            else
            {
                FinaleWin.SetActive(true);
            }
        });
        FinaleChallenge.onClick.AddListener(() => MainCharacter.Challenge(10, MainCharacter.endurance, ChallengeResults));


        }//end of Start()

    void Update()
        {

        if(MainCharacter.strain.value <= 0)
        {
            SceneManager.LoadScene("Death Scene");
        }
           
        CheckForRemainignSkill(MainCharacter.remainingSkills, AddEndurance, AddAgility, AddStrength, AddPerception);

        DisplayValue(RemainingSkillPointsValue, MainCharacter.remainingSkills);

        DisplayValue(EnduranceValue, MainCharacter.endurance.value);
        DisplayValue(StrengthValue, MainCharacter.strength.value);
        DisplayValue(AgilityValue, MainCharacter.agility.value);
        DisplayValue(PerceptionValue, MainCharacter.perception.value);

        AdventureEnduranceScore.text = MainCharacter.endurance.value.ToString();
        AdventureStrengthScore.text = MainCharacter.strength.value.ToString();
        AdventureAgilityScore.text = MainCharacter.agility.value.ToString();
        AdventurePerceptionScore.text = MainCharacter.perception.value.ToString();

        StrainBar.SetStrain(MainCharacter.strain.value);


       
    }

}
