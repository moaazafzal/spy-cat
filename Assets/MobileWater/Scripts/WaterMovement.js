// speed of water
var speed : float = 0.7;
// transparency of water.  
// 0 is transparent 
// 1 is opaque
var alpha : float = 1;
// size of wave texture
var waveScale : float = 3;
var moveWater : float = 0;
var limitPingPong :float = 1.5;
var pingPong : boolean = false;

private var flag : boolean = false;

function Update () 
{
	if(pingPong == false) {
		moveWater += Time.deltaTime * speed;
	} else {
		if(flag == false) {
			moveWater = Mathf.Lerp(moveWater, limitPingPong, 0.3f * Time.deltaTime);
			if(moveWater >= limitPingPong - 0.5f)
				flag = true;
		} else {
			moveWater = Mathf.Lerp(moveWater, 0, 0.3f * Time.deltaTime);
				if(moveWater <= 0.5f)
					flag = false;
		}
	}
	gameObject.renderer.material.mainTextureOffset = Vector2( 0, moveWater );	
	gameObject.renderer.material.color.a = alpha;
	gameObject.renderer.material.mainTextureScale = new Vector2(waveScale, waveScale);
}