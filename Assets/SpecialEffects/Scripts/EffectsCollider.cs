using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsCollider : MonoBehaviour
{

	public ParticleSystem m_particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	// 需要处理的碰撞信息，放在被撞的物体身上  
	void OnParticleCollision(GameObject other) {  
	     Debug.Log(other.name + "碰撞发生(角色脚本)"); 
		m_particleSystem.Play();
	}  

	//private void OnCollisionEnter2D(Collision2D coll)
 //   {

	//	Debug.Log("碰撞发生(角色脚本)");
 //       //if (coll.gameObject.tag == "EnemyBullet")
 //       //{
 //       //    
 //       //    GameObject.Destroy(this.gameObject);
 //       //    Debug.Log("玩家角色被销毁");
 //       //}
 //   }

}
