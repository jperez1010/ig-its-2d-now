using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [Header("Params")]
    [SerializeField] private float typingSpeed = 0.04f;
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject Health;
    [SerializeField] private GameObject Mythogem;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;

    private TextMeshProUGUI[] choicesText;

    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }

    private bool canContinueToNextLine = false;

    private Coroutine displayLineCoroutine;
    private static DialogueManager instance;

    float lerpSpeed;
    private Vector3 targetHP;
    private Vector3 targetMythogem;
    private Vector3 targetPanel;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than one Dialogue Manager in scene");
        }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        targetPanel = new Vector3(20f, 28f, 0f);
        targetMythogem = new Vector3(-325f, -158f, 0f);
        //get all of the choices text
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        lerpSpeed = 5f * Time.deltaTime;
        UpdateUI();
        if (!dialogueIsPlaying)
        {
            return;
        }

        if (canContinueToNextLine && currentStory.currentChoices.Count == 0 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        for (int i = 0; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
        targetHP = new Vector3(0f, 100f, 0f);
        targetMythogem = new Vector3(-325f, -275f, 0f);

        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        targetHP = Vector3.zero;
        targetMythogem = new Vector3(-325f, -158f, 0f);
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            // set text for the current dialogue line
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
            // display choices, if any, for this dialogue line
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }   
    }

    private IEnumerator DisplayLine(string line)
    {
        // empty the dialogue text
        dialogueText.text = "";

        canContinueToNextLine = false;
        int counter = 0;

        // display each letter one at a time
        foreach (char letter in line.ToCharArray())
        {
            // if button is pressed, finish displaying line
            if (Input.GetKey(KeyCode.Mouse0) && counter >= 2)
            {
                dialogueText.text = line;
                break;
            }
            dialogueText.text += letter;
            counter += 1;
            yield return new WaitForSeconds(typingSpeed);
        }
        DisplayChoices();
        canContinueToNextLine = true;
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        //Check to see if amount of choices can be supported
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: "
                + currentChoices.Count);
        }
        //Shift upwards
        if (currentChoices.Count > 0)
        {
            targetPanel = new Vector3(20f, 45f, -0.60114f);
        }

        int index = 0;
        // initialize choices up to the amount of choices available for this line of dialogue.
        foreach(Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }
    private IEnumerator SelectFirstChoice()
    {
        // Event System requires we clear it first, then wait
        // for at least one frame before we set the current selected object
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        if (canContinueToNextLine)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
            for (int i = 0; i < choices.Length; i++)
            {
                choices[i].gameObject.SetActive(false);
            }
            targetPanel = new Vector3(20f, 28f, -0.60114f);
            ContinueStory();
        }
    }
    private void UpdateUI()
    {
        Vector3 position = Vector3.Lerp(Health.GetComponent<RectTransform>().localPosition, targetHP, lerpSpeed);
        Health.GetComponent<RectTransform>().localPosition = position;
        Vector3 position2 = Vector3.Lerp(Mythogem.GetComponent<RectTransform>().localPosition, targetMythogem, lerpSpeed);
        Mythogem.GetComponent<RectTransform>().localPosition = position2;
        Vector3 position3 = Vector3.Lerp(dialoguePanel.transform.Find("Dialogue Panel").GetComponent<RectTransform>().anchoredPosition, targetPanel, lerpSpeed);
        dialoguePanel.transform.Find("Dialogue Panel").GetComponent<RectTransform>().anchoredPosition = position3;
        for (int i = 0; i < choices.Length; i++)
        {
            if (choices[i])
            {
                Vector3 targetChoice = choices[i].GetComponent<RectTransform>().anchoredPosition;
                targetChoice.y = 16f - i * 18f;
                Vector3 position4 = Vector3.Lerp(choices[i].GetComponent<RectTransform>().anchoredPosition, targetChoice, lerpSpeed);
                choices[i].GetComponent<RectTransform>().anchoredPosition = position4;
            } else
            {
                Vector3 targetChoice = choices[i].GetComponent<RectTransform>().anchoredPosition;
                targetChoice.y = 16f;
                Vector3 position4 = Vector3.Lerp(choices[i].GetComponent<RectTransform>().anchoredPosition, targetChoice, lerpSpeed);
                choices[i].GetComponent<RectTransform>().anchoredPosition = position4;
            }
        }
    }
}