using UnityEngine;

public class StereoPan : MonoBehaviour 
{

    #region Public Members
    public AudioSource m_audioSource;
    #endregion

    #region System
	
	void Start () 
	{
        m_audioSource.panStereo = 1f;
	}
	
	void Update () 
	{
		
	}

    #endregion

    #region Main Methods
    #endregion

    #region Utils
    #endregion

    #region Private and Protected Members
    #endregion
}
