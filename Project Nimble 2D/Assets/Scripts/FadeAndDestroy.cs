using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SlicedSprite))]
public class FadeAndDestroy : MonoBehaviour 
{
	public float m_FadeDelay = .25f;
	public float m_FadeTime = .25f;
    public bool m_WaitUntilStationary = false;
    public float m_StationaryVelocity = 0.2f;

	SlicedSprite m_SlicedSprite;
    Rigidbody2D m_RigidBody;
    Material m_Material;
    Color m_InitialColor;    
	float m_Timer;    
		
    //construct
    //set color fade
	void Awake()
	{        
		m_SlicedSprite = GetComponent<SlicedSprite>();
        m_RigidBody = m_SlicedSprite.GetComponent<Rigidbody2D>();
        m_Material = m_SlicedSprite.GetComponent<Renderer>().material;
		m_InitialColor = m_Material.color;
	}
		
    //check state
    //covert the fade
    //set fade timer
	void Update () 
	{
        if (!m_WaitUntilStationary || m_RigidBody.velocity.sqrMagnitude < (m_StationaryVelocity * m_StationaryVelocity))
        {
            m_Timer += Time.deltaTime;

            if (m_FadeTime > 0)
            {
                Color newColor = m_InitialColor;
                newColor.a = 1.0f - Mathf.Clamp01((m_Timer - m_FadeDelay) / m_FadeTime);
                m_SlicedSprite.GetComponent<Renderer>().material.color = newColor;
            }

            if ((m_Timer - m_FadeDelay) >= m_FadeTime)
            {
                Destroy(this.gameObject);
            }
        }		
	}
}
