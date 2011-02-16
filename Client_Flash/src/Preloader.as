package 
{
	import org.flixel.FlxPreloader;
	import Main;
	
	/**
	 * ...
	 * @author GDSkeptic
	 */
	public class Preloader extends FlxPreloader
	{	
		public function Preloader():void
		{
			className = "Main";
			super();
		}
	}
}