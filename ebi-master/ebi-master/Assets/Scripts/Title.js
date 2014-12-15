#pragma strict

function OnGUI () {

	if( GUI.Button(Rect (Screen.width / 2 -100, 200, 200, 30), "START"))
	{
	 Application.LoadLevel( "main" );
	 }

}