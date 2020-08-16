using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShoppingState
{
	None,
	Play,
	Close
}

public class ShoppingEffect : MonoBehaviour
{

	public ShoppingState m_shoppingState;
	public GameObject m_BigSphere;
	public GameObject m_SmallSphere;

	public float m_BigSphereSpeed = 1.0f;
	public float m_SmallSphereSpeed = 1.0f;

	public float m_rotationTime = 0;

	public float moveSpeed = 1;

	public Vector4 m_Boundary;

	public int m_MaxColliderNumber = 4;
	public int m_CurrentColliderNumber = 0;

	/// <summary>
	/// Initialize the current object position and rotation
	/// </summary>
	/// <param name="position"></param>
	/// <param name="rotation"></param>
	/// <param name="Boundary"></param>
	public void InitializeDirection(Vector2 position , float rotation, Vector4 Boundary)
	{
		transform.position = new Vector3(position.x, position.y, 0);
		transform.rotation = Quaternion.Euler(0,0,rotation);
		m_Boundary = Boundary; 
	}

    // Start is called before the first frame update
    void Start()
    {
        m_rotationTime = 0;
		m_shoppingState = ShoppingState.Play;
		m_CurrentColliderNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
		switch (m_shoppingState)
		{
			case ShoppingState.None:

				break;

			case ShoppingState.Play:
				SphereRotation();
				SphereMovement();

				if(m_CurrentColliderNumber >= m_MaxColliderNumber)
				{

					Debug.Log("销毁");
					Destroy(gameObject);
				}
				break;

			case ShoppingState.Close:

				break;
		}
    }

	public void SphereRotation()
	{
		m_rotationTime = m_rotationTime + Time.deltaTime;
		m_BigSphere.transform.rotation = Quaternion.Euler(0,0,m_rotationTime * m_BigSphereSpeed);
		m_SmallSphere.transform.rotation = Quaternion.Euler(0,0,m_rotationTime * m_SmallSphereSpeed);
	}

	public void SphereMovement()
	{
		Vector3 normal = Vector3.zero;
		Vector3 moveDirection = transform.right*-1;

		if(transform.position.x >= m_Boundary.y)
		{
			Debug.Log("右边界");
			normal = Vector3.left;
			m_CurrentColliderNumber++;
		}

		if(transform.position.x <= m_Boundary.x)
		{
			Debug.Log("左边界");
			normal = Vector3.right;
			m_CurrentColliderNumber++;
		}

		if(transform.position.y >= m_Boundary.w)
		{
			Debug.Log("上");
			normal = Vector3.down;
			m_CurrentColliderNumber++;
		}

		if(transform.position.y <= m_Boundary.z)
		{
			Debug.Log("下");
			normal = Vector3.up;
			m_CurrentColliderNumber++;
		}

		if(normal != Vector3.zero)
		{
			//Debug.Log("1111111111111111");
			Vector2 dir = Vector2.Reflect(moveDirection, normal);
            transform.rotation = Quaternion.FromToRotation(moveDirection, dir);
			moveDirection = (new Vector2(dir.x, dir.y)).normalized;
			normal = Vector3.zero;
		}

		//Vector3 moveDirection = transform.right*-1;
		transform.position += moveDirection * Time.deltaTime * moveSpeed;
	}

}
