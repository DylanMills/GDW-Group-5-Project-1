using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonDefinition : MonoBehaviour
{
    public bool _animated = false;
    public Color _unselectedTint = Color.grey;
    public Color _selectedTint = Color.white;
    public bool _selected = false;
    private Button _button;
    private Image _image;
    private bool _disableControls = false;
    private Animator _animator;


   // public AudioClip _swapToSFX;
   // public AudioClip _confirmSFX;
    public float _confirmTime = 0.75f;
    // Start is called before the first frame update
    private void Start()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();

     //   _animated = TryGetComponent<Animator>(out _animator);

     //   if (!_animated)
        {
            if (_selected)
            {
                _image.color = _selectedTint;
            }
            else
            {
                _image.color = _unselectedTint;
            }
        }
    }

    public void SwappedTo()
    {

      //  if (_swapToSFX)
      //  {
      //      AudioSource.PlayClipAtPoint(_swapToSFX, Vector3.zero);
      //  }

        _selected = true;
        if (_animated)
        {
            _animator.SetBool("Selected", _selected);
        }
        else
        {
            _image.color = _selectedTint;
        }





    }

    public void SwappedOff()
    {
        _selected = false;
          if (_animated)
        {
            _animator.SetBool("Selected", _selected);
        }
        else
        {
            _image.color = _unselectedTint;
        }
    }

    public IEnumerator ClickButton()
    {

        if (!_disableControls)
        {
            _disableControls = true;



          //  if (_confirmSFX != null)
            {
        //        AudioSource.PlayClipAtPoint(_confirmSFX, Vector3.zero);
            }
            yield return new WaitForSeconds(_confirmTime);
            _button.onClick.Invoke();
            _disableControls = false;
        }
    }

    public bool GetDisableControls()
    {
        return _disableControls;
    }

    // Update is called once per frame
    private void Update()
    {
    }
}