#pragma strict

function OnGUI () {

	if( GUI.Button(Rect (Screen.width / 2 -300, 200, 200, 30), "RESTART"))
	{
	 Application.LoadLevel( "main" );
	 }
	 
	 if( GUI.Button(Rect (Screen.width / 2, 200, 200, 30), "Twitter"))
	 {
	 Application.OpenURL("http://twitter.com/intent/tweet?text=" + WWW.EscapeURL("ebifry**!"));
	 }

}