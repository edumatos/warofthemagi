package 
{
	import org.flixel.FlxGame;
	import states.AuthentiState;
	[SWF(width = "640", height = "480", backgroundColor = "#000000")]
	[Frame(factoryClass = "Preloader")]
	
	/**
	 * ...
	 * @author GDSkeptic
	 */
	public class Main extends FlxGame
	{
		public function Main():void
		{
			useDefaultHotKeys = false;
			super( 640, 480, AuthentiState, 1 );
			useDefaultHotKeys = false;
		}
	}
	
}