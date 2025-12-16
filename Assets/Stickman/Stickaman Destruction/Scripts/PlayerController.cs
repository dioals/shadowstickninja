using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public GameObject ArrowPrefab;
	public GameObject BaloonPrefab;
	public GameObject Granade;
	public GameObject touchCircleBegin;
	public GameObject touchCircleEnd;
	private LineRenderer touchesLineRenderer;
	protected Vector2 startPosition;
	protected Vector2 endPosition;
	private float length;
	public GameObject aimObject;
	public Transform transformForArrow;
	public GameObject bowBody;
	int TargetRemaining = 5;
	public GameObject Aiming;
	public GameObject ForceShow;
	GameManager gameManager;
	public GameObject head;
	Vector3 pos;
	Vector3 stickmanHead;
	float sp;
	float ep;
	void Start ()
	{			
		if ((bool)((UnityEngine.Object)this.touchCircleEnd))
		this.touchesLineRenderer = this.touchCircleEnd.GetComponent<LineRenderer> ();
		Aiming.SetActive (false);
		gameManager = FindObjectOfType<GameManager> ();
	}	
	void Update () 
	{		 
		sp = startPosition.x;
		ep = endPosition.x;
		float abc = sp - ep;
		//Debug.Log ("distance   "+abc);

		if (abc > .5f) {
			stickmanHead = head.transform.eulerAngles;
			stickmanHead.y = 180;
			head.transform.eulerAngles = stickmanHead;
			//head.transform.localRotation.y= stickmanHead.y;
		} else {
			stickmanHead = head.transform.eulerAngles;
			stickmanHead.y =    0;
			head.transform.eulerAngles = stickmanHead;
		}
		if (!gameManager.GameOver) 
		{
			
				ForceShow.transform.localScale = new Vector3 (length, 1, 1);
				int typeTouch = 0;
				if (Input.GetMouseButtonDown (0)) 
				{
					typeTouch = 1;
					this.TouchBegan ((Vector2)Input.mousePosition, true);
				} else if (Input.GetMouseButton (0)) 
				{
					typeTouch = 2;
					this.TouchMoved ((Vector2)Input.mousePosition, true);
				} else if (Input.GetMouseButtonUp (0)) 
				{
					typeTouch = 3;
					this.TouchEnded ((Vector2)Input.mousePosition, true);
				}
				if (typeTouch != 3)
					return;
				this.startPosition = Vector2.zero;
				this.endPosition = Vector2.zero;			
	}
//		if (gameManager.KnifeOfLevel <= 0 && TargetRemaining > 0) 
//		{
//			gameManager.GameOver = true;
//		}
	}

	protected void TouchBegan(Vector2 point ,bool needConvert)
	{
		
		this.length = 0.0f;
		if (needConvert)
		{
			this.startPosition = (Vector2) PlayerController.GetWorldPositionOnPlane((Vector3) point, 0.0f);
			this.endPosition = (Vector2) PlayerController.GetWorldPositionOnPlane((Vector3) point, 0.0f);
		}
		else
		{
			this.startPosition = point;
			this.endPosition = point;
		}
		if ((bool) ((UnityEngine.Object) this.touchCircleBegin) && (bool) ((UnityEngine.Object) this.touchCircleEnd))
		{
			this.touchCircleBegin.SetActive(true);
			this.touchCircleEnd.SetActive(true);
		}
		this.prepareArrow();

	} 
	protected void TouchMoved(Vector2 point, bool needConvert)
	{
		this.endPosition = !needConvert ? point : (Vector2) PlayerController.GetWorldPositionOnPlane((Vector3) point, 0.0f);
	
		bowBody.transform.rotation = this.transformForArrow.rotation;
		this.prepareArrow();
	}
	protected void TouchEnded(Vector2 point, bool needConvert)
	{
		
		this.endPosition = !needConvert ? point : (Vector2) PlayerController.GetWorldPositionOnPlane((Vector3) point, 0.0f);
		this.prepareArrow();
		FireArrow ();
		if (!(bool) ((UnityEngine.Object) this.touchCircleBegin) || !(bool) ((UnityEngine.Object) this.touchCircleEnd))
			return;
		this.touchCircleBegin.SetActive(false);
		this.touchCircleEnd.SetActive(false);

	}
	public static Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
	{
		Ray ray = Camera.main.ScreenPointToRay(screenPosition);
		float enter;
		new Plane(Vector3.forward, new Vector3(0.0f, 0.0f, z)).Raycast(ray, out enter);
		return ray.GetPoint(enter);
	}
	private void prepareArrow()
	{
		if ((!(bool) ((UnityEngine.Object) this.touchCircleBegin) || !(bool) ((UnityEngine.Object) this.touchCircleEnd) || (!this.touchCircleBegin.activeSelf || !this.touchCircleEnd.activeSelf)))
			return;
		this.RefreshTouchCircles();
		Vector2 vector2 = this.endPosition - this.startPosition;
		float num = this.normalizeAngle(Mathf.Atan2(vector2.y, vector2.x) * 57.29578f);
		float max = 1f;
		if ((double) this.transform.localScale.x > 0.0)
		{
			this.aimObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, Mathf.Clamp(num, -0, 360f));
			this.length = Mathf.Max(0.0f, vector2.magnitude - 1f) / 5f;
			this.length = Mathf.Clamp(this.length, 0.0f, max);
		}
		else if ((double) num >= -180.0 && (double) num <= -120.0 || (double) num >= 120.0 && (double) num <= 180.0 )
		{
			this.aimObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, num - 180f);
			this.length = Mathf.Max(0.0f, vector2.magnitude - 1f) / 5f;
			this.length = Mathf.Clamp(this.length, 0.0f, max);
		}
		Aiming.SetActive (true);
	//	this.SetAnimationFrameForAiming(this.length);
	}
	private float normalizeAngle(float angle)
	{
		while ((double) angle > 360.0)
			angle -= 360f;
		while ((double) angle < 0.0)
			angle += 360f;
		return angle;
	}
	private void RefreshTouchCircles()
	{
		if (!(bool) ((UnityEngine.Object) this.touchCircleBegin) || !(bool) ((UnityEngine.Object) this.touchCircleEnd) || !(bool) ((UnityEngine.Object) this.touchesLineRenderer))
			return;	
		this.touchCircleBegin.transform.position = (Vector3) this.startPosition;
		this.touchCircleEnd.transform.position = (Vector3) this.endPosition;	
	}
	private void FireArrow()
	{
		if ((double) this.length < 0.2)
		{
			
		}
		else
		{
			this.SetArroMotion();

		}
		this.aimObject.transform.eulerAngles = Vector3.zero;
		this.length = 0.0f;
		Aiming.SetActive (false);
		FindObjectOfType<SoundControl>().ShootSound.Play();
	}
	private void SetArroMotion()
	{			

		if (gameManager.IsKnife && gameManager.KnifeOfLevel >0) 
		{
			GameObject	gameObject = Instantiate(this.ArrowPrefab, Vector3.zero, Quaternion.identity);
			gameObject.transform.position = this.transformForArrow.position;
			gameObject.transform.rotation = this.transformForArrow.rotation;
			gameObject.transform.localScale = Vector3.one * this.gameObject.transform.localScale.y;

			float z = gameObject.transform.eulerAngles.z;
			if ((double) this.transform.localScale.x < 0.0)
				z -= 180f;
			float f = (float) Mathf.PI / 180f * z;
			float num = this.length * 1200f;
			Vector2 force = new Vector2(Mathf.Cos(f) * num, Mathf.Sin(f) * num);
			gameObject.GetComponent<Rigidbody2D>().AddForce(force * 0.1f);
			gameManager.KnifeOfLevel -= 1;
		} 
		if(gameManager.IsBaloon && gameManager.BaloonOfLevel >0)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BaloonPrefab, Vector3.zero, Quaternion.identity);
			gameObject.transform.position = this.transformForArrow.position;
			gameObject.transform.rotation = this.transformForArrow.rotation;
			gameObject.transform.localScale = new Vector3(0.4f,0.4f,0.4f);
			float z = gameObject.transform.eulerAngles.z;
			if ((double) this.transform.localScale.x < 0.0)
				z -= 180f;
			float f = (float) Mathf.PI / 180f * z;
			float num = this.length * 1200f;
			Vector2 force = new Vector2(Mathf.Cos(f) * num, Mathf.Sin(f) * num);
			gameObject.GetComponent<Rigidbody2D>().AddForce(force * 2f);
			gameManager.BaloonOfLevel -= 1;
		}
		if(gameManager.IsBomb && gameManager.BombOfLevel >0)
		{
			
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Granade, Vector3.zero, Quaternion.identity);
			gameManager.bombs.Add (gameObject.GetComponent<BombScript>());
			gameObject.transform.position = this.transformForArrow.position;
			gameObject.transform.rotation = this.transformForArrow.rotation;
			gameObject.transform.localScale = Vector3.one *0.8f;
			float z = gameObject.transform.eulerAngles.z;
			if ((double) this.transform.localScale.x < 0.0)
				z -= 180f;
			float f = (float) Mathf.PI / 180f * z;
			float num = this.length * 1200f;
			Vector2 force = new Vector2(Mathf.Cos(f) * num, Mathf.Sin(f) * num);
			gameObject.GetComponent<Rigidbody2D>().AddForce(force * 2f);
			gameManager.BombOfLevel -= 1;
		}


	}


}
