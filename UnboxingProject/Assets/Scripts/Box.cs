using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections;
using System.Linq;

public class Box : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    GameObject openedBox;
    [SerializeField]
    GameObject closedBox;

    AudioSource audioSource;

    bool hasBeenOpened = false;
    
    public float interactableRange = 5f;
    [SerializeField]
    LayerMask layerMask;

    static EndGame endGameInstance;
    private static int unopenedBoxes = 0;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        unopenedBoxes++;
    }


    private void Start()
    {
        if (endGameInstance == null)
        {
            endGameInstance = FindObjectOfType<EndGame>();
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (hasBeenOpened)
        {
            return;
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, interactableRange, layerMask);
        if (colliders != null && colliders.Any())
        {
            StartCoroutine(OpenBox());
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactableRange);
    }


    IEnumerator OpenBox()
    {
        hasBeenOpened = true;
        unopenedBoxes--;
        audioSource.volume = Random.Range(0.7f, 0.85f);
        audioSource.pitch = Random.Range(1f, 1.5f);
        audioSource.Play();
        yield return new WaitForSeconds(0.5f);
        openedBox.SetActive(true);
        closedBox.SetActive(false);

        if (unopenedBoxes == 0)
        {
            endGameInstance.WinGame();
        }
    }

    
}
